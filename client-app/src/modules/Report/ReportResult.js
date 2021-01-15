import React, { useContext, useEffect, useState } from 'react'
import { Button, Col, DatePicker, Input, Pagination, Row, Select, Spin, Table } from 'antd';
import { useHistory } from 'react-router'
import ResultApi from '../../services/ResultApi';
import { AppContext } from '../../context';
import { EyeOutlined, SearchOutlined } from '@ant-design/icons'
import moment from 'moment'

export default function ReportResult() {
  let history = useHistory();
  const [data, setData] = useState([]);
  const [filter, setFilter] = useState({
    templateName: undefined,
    date: undefined,
    skill: undefined
  })
  const context = useContext(AppContext);
  useEffect(() => {
    onSearch()
  }, [])
  async function onSearch() {
    var res = await ResultApi.getResultsByAccount('hoanq2');
    if (res) {
      if (res.status === 200 && res.data) {
        let i = 1;
        res.data.forEach(c => c.stt = i++)
        setData(res.data);
      }
      else {
        Notification.error(res.message);
      }
    }
  };

  function onChangeFilter(field, value) {
    var newFilter = { ...filter };
    newFilter[field] = value;
    setFilter(newFilter);
  }

  const columns = [
    {
      title: '#',
      dataIndex: 'stt'
    },
    {
      title: 'Test name',
      dataIndex: 'testName'
    },
    {
      title: 'Skill',
      dataIndex: 'skill'
    },
    {
      title: 'Date',
      dataIndex: 'created',
      render: text => moment(text).format('DD/MM/YYYY HH:mm')
    },
    {
      title: 'Score',
      dataIndex: 'score'
    },
    {
      title: '',
      dataIndex: 'id',
      render: text => (
        <Button type="link" onClick={() => history.push('/Test/' + text)}>
          Faz de novo
        </Button>
      )
    }
  ]

  return (
    <div className="page-content">
      <div className="search-div" style={{ padding: 20 }}>
        <Row gutter={16}>
          <Col lg={4} sm={12} md={6} xs={24}>

            <Input placeholder="Test name" value={filter.templateName} onChange={e => onChangeFilter('templateName', e.target.value)} />
          </Col>
          <Col lg={4} sm={12} md={6} xs={24}>
            <Select
              style={{ width: '100%' }}
              placeholder="Skill"
              value={filter.skill}
              onChange={e => onChangeFilter('skill', e)}
            >
              <Select.Option value="writing">Compreensão escrita</Select.Option>
              <Select.Option value="reading">Produção escrita</Select.Option>
            </Select>
          </Col>
          <Col lg={4} sm={12} md={6} xs={24}>
            <DatePicker placeholder="Date" value={filter.date} onChange={value => onChangeFilter('date', value)} />
          </Col>
          <Col lg={4} sm={12} md={6} xs={24}>
            <div className="btn-group-search">
              <Button
                onClick={() => onSearch()}
                icon={<SearchOutlined />}
                type="primary"
              >
                Pesquisar
              </Button>
            </div>
          </Col>
        </Row>
      </div>
      <div style={{ padding: 20 }}>
        <Table
          rowKey={record => record.id}
          columns={columns}
          dataSource={data}
          rowKey="id"
          pagination={false}
          size='small'
        />
      </div>
    </div>
  )
}

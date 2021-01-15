import { Button, Col, Input, Pagination, Row, Select, Spin } from 'antd';
import React, { useContext, useEffect, useState } from 'react'
import { useHistory } from 'react-router';
import Notification from '../../common/components/Notification';
import { useLoading } from '../../Hooks/useLoading';
import { usePagination } from '../../Hooks/usePagination';
import TemplateApi from '../../services/TemplateApi';
import TestListTable from './TestListTable';
import { SearchOutlined, PlusOutlined } from '@ant-design/icons';
import { AppContext } from '../../context';

export default function TestList() {
  const [data, setData] = useState([]);
  const [filter, setFilter] = useState({
    testName: undefined,
    skill: undefined
  })
  const [loading, showLoading, hideLoading] = useLoading();
  const [paging, setPaging, onPageChange] = usePagination(onSearch, 15);
  const appContext = useContext(AppContext);
  console.log(appContext)
  let history = useHistory();

  useEffect(() => {
    onSearch();
  }, [])

  async function onSearch(currentPage = 1, pageSize = 15) {
    showLoading();
    var submitFilter = { ...filter };
    submitFilter.paging = {
      currentPage,
      pageSize
    }

    var res = await TemplateApi.ListAll(submitFilter);
    if (res) {
      if (res.status === 200 && res.data) {
        var newPaging = { ...res.data.paging };
        var list = res.data.list;
        list.push({
          content: 'Luyện đọc 2020',
          skill: 'reading',
          questionQuantity: 20,
          passScore: 18,
          duration: 90,
          quantityDone: 17,
          maxScore: 19,
          minScore: 13
        })
        var startNumber = newPaging.pageSize * (newPaging.currentPage - 1) + 1;
        list.forEach(c => c.stt = startNumber++);
        setPaging(newPaging);
        setData(list);
      }
      else {
        Notification.error(res.message);
      }
    }
    hideLoading();
  };

  function onChangeFilter(field, value) {
    var newFilter = { ...filter };
    newFilter[field] = value;
    setFilter(newFilter);
  }

  function showDetail(id) {
    history.push('/Test/' + id);
  }

  return (
    <>
      <Spin spinning={loading}>
        <div className="page-content">
          <div className="search-div" style={{ padding: 20 }}>
            {appContext && appContext.userInfo && appContext.userInfo.isAdmin &&
              <div style={{ float: 'right' }}>
                <Button
                  onClick={() => history.push('/CreateTest')}
                  icon={<PlusOutlined />}>Novo teste</Button>
              </div>
            }
            <Row gutter={16}>
              <Col lg={4} sm={12} md={6} xs={24}>
                <Select
                  style={{ width: '100%' }}
                  placeholder="Habilidade"
                  value={filter.skill}
                  onChange={e => onChangeFilter('skill', e)}
                >
                  <Select.Option value="writing">Compreensão escrita</Select.Option>
                  <Select.Option value="reading">Produção escrita</Select.Option>
                </Select>
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
            <TestListTable data={data} showDetail={showDetail} />
            <div className="page-div">
              {/* <Pagination
                showSizeChanger
                showTotal={(total, range) => range[0] + ' - ' + range[1] + ' of ' + total + ' items'}
                onChange={onPageChange}
                defaultCurrent={1}
                total={paging.rowsCount}
                pageSizeOptions={['15', '20', '30', '40']}
                defaultPageSize={15}
              /> */}
            </div>
          </div>
        </div>
      </Spin>
    </>
  )
}

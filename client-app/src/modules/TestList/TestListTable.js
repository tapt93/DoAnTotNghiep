import { Button, Table } from 'antd'
import React from 'react'
import { EyeOutlined } from '@ant-design/icons'

export default function TestListTable({ data, showDetail }) {
  function onShowDetail(id) {
    if (showDetail) {
      showDetail(id);
    }
  }

  const columns = [
    {
      title: '#',
      dataIndex: 'stt'
    },
    {
      title: 'Test name',
      dataIndex: 'content'
    },
    {
      title: 'Skill',
      dataIndex: 'skill'
    },
    {
      title: 'Question quantity',
      dataIndex: 'questionQuantity'
    },
    {
      title: 'Pass score',
      dataIndex: 'passScore'
    },
    {
      title: 'Duration',
      dataIndex: 'duration'
    },
    {
      title: 'Quantity done',
      dataIndex: 'quantityDone'
    },
    {
      title: 'Max score',
      dataIndex: 'maxScore'
    },
    {
      title: 'Min score',
      dataIndex: 'minScore'
    },
    {
      title: '',
      dataIndex: 'id',
      render: text => (
        <span>
          <Button type="link" onClick={() => onShowDetail(text)}>
            Edit
        </Button>
          <Button type="link" onClick={() => onShowDetail(text)}>
            Delete
        </Button>
        </span>
      )
    }
  ]
  return (
    <Table
      rowKey={record => record.id}
      columns={columns}
      dataSource={data}
      rowKey="id"
      pagination={false}
      size='small'
    />
  )
}

import React from 'react'
import { Button, Table } from 'antd'

export default function MyResultTable(props) {
  const columns = [
    {
      title: 'STT',
      key: '1',
      render: (text, record, index) => index + 1
    },
    {
      title: 'Test name',
      dataIndex: 'testName'
    },
    {
      title: 'Score',
      dataIndex: 'score'
    },
    {
      title: 'Date',
      dataIndex: 'created'
    }
  ]
  return (
    <div>
      <Table
        columns={columns}
        dataSource={props.data || []}
        pagination={false}
      />
    </div>
  )
}

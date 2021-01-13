import { Card, Col, Row } from 'antd'
import React, { useEffect, useState } from 'react'
import { CrownOutlined } from '@ant-design/icons'

export default function TestResult({ testName, result, user, finishTime, passScore }) {
  const [passedPercent, setPassedPercent] = useState(0);

  useEffect(() => {
    if (result) {
      var percent = getPassPercent();
      setPassedPercent(percent);
    }
  }, [result]);

  const getPassPercent = () => {
    if (result.length > 0) {
      var passed = result.filter(c => c).length;
      return (passed / result.length) * 100;
    }
    return 0;
  }

  return (
    <div className="test-result">
      <Card
        size="small"
        title={<span><CrownOutlined /> Kết quả tổng kết</span>}
        style={{ width: '60%' }}
      >
        <p><b>Bài thi:</b> {testName?.toUpperCase()}</p>
        <Row>
          <Col span={12}><b>Họ và tên:</b> {user ? user.firstName + ' ' + user.lastName : ''}</Col>
          <Col span={12}><b>Thời gian kết thúc thi:</b> {finishTime?.format('DD/MM/yyyy HH:mm')}</Col>
        </Row>
        <Row>
          <Col span={12}>
            <b>Xếp loại:</b> {result.filter(c => c).length > passScore ? <span style={{ color: 'green' }}>Đạt</span> : <span style={{color: 'red'}}>Không đạt</span>} ({result.filter(c => c).length}/{result.length})
          </Col>
          <Col span={12} style={{ width: '100%', background: '#4984b9' }}>
            <div style={{ width: `${passedPercent}%`, background: 'orange', color: 'white', textAlign: "center" }}>{passedPercent}%</div>
          </Col>
        </Row>
        <Row>
          <Col span={12}>
            <b>Yêu cầu:</b> {passScore}/{result.length}
          </Col>
        </Row>
      </Card>
    </div>
  )
}

import React, { useContext, useEffect, useState } from 'react'
import { UserOutlined, CalendarOutlined, ClockCircleOutlined, QuestionCircleOutlined } from '@ant-design/icons'
import moment from 'moment'
import { HashLink as Link } from 'react-router-hash-link';

export default function TestLeftNav({ template, currentUser, listViewQuestion }) {
  const [minutes, setMinutes] = useState(1);
  const [seconds, setSeconds] = useState(0);
  const [date, setDate] = useState(moment());

  useEffect(() => {
    if (template.duration) {
      setMinutes(template.duration)
    }
  }, [template.duration])

  useEffect(() => {
    let myInterval = setInterval(() => {
      if (seconds > 0) {
        setSeconds(seconds - 1);
      }
      if (seconds === 0) {
        if (minutes === 0) {
          clearInterval(myInterval)
        } else {
          setMinutes(minutes - 1);
          setSeconds(59);
        }
      }
    }, 1000)

    return () => {
      clearInterval(myInterval);
    };
  });

  function formatNumber(number) {
    return number.toLocaleString('en-US', { minimumIntegerDigits: 2, useGrouping: false });
  }

  function viewQuestion(id) {
    var myElement = document.getElementById('q' + id);
    var topPos = myElement.offsetTop - 50;

    document.getElementById('test-body-content').scrollTop = topPos;
  }

  return (
    <div className="test-left-nav">
      <div className="left-nav-item">
        <div className="timer">
          <span style={{ color: '#fff', fontSize: 24 }}>{formatNumber(minutes)} : {formatNumber(seconds)}</span>
        </div>
        <br />
        <div>
          <span>Thời gian còn lại</span>
        </div>
      </div>
      <div className="left-nav-item">
        <UserOutlined className="icon" /> <span>Thí sinh: {currentUser}</span>
      </div>
      <div className="left-nav-item">
        <CalendarOutlined className="icon" /> <span>Ngày thi: {date.format('DD-MM-yyyy HH:mm')}</span>
      </div>
      <div className="left-nav-item">
        <ClockCircleOutlined className="icon" /> <span>Thời gian: {template.duration} phút</span>
      </div>
      <div className="left-nav-item">
        <QuestionCircleOutlined className="icon" /> <span>Số lượng câu hỏi: {(template.questions || []).length}</span>
      </div>
      <div className="left-nav-item" style={{ flexDirection: 'column' }}>
        <div>
          <div style={{ width: 20, height: 20, background: 'green', float: 'left' }}></div>
          <span style={{ float: 'left', marginLeft: 5 }}>Câu hỏi đã trả lời</span>
        </div>
        <div style={{ marginTop: 5 }}>
          <div style={{ width: 20, height: 20, background: '#a2a2a2', float: 'left' }}></div>
          <span style={{ float: 'left', marginLeft: 5 }}>Câu hỏi chưa trả lời</span>
        </div>
      </div>
      <div className="left-nav-item" style={{ background: '#f3f3f3' }}>
        <div className="question-quick-access">
          {(listViewQuestion).map((c, i) => (
            <div onClick={() => viewQuestion(c.id)} key={c.id} className={"question-icon-box" + (c.answered ? " answered" : "")}>
              {i + 1}
            </div>
          ))}
        </div>
      </div>
    </div>
  )
}

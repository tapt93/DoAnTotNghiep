import { Layout } from 'antd'
import React, { useContext, useEffect, useRef, useState } from 'react'
import Notification from '../../common/components/Notification';
import { AppContext } from '../../context';
import TemplateApi from '../../services/TemplateApi';
import TestLeftNav from './LeftNav/TestLeftNav'
import './Test.css'
import TestBody from './TestBody';

export default function Test() {
  const [template, setTemplate] = useState({});
  const [listViewQuestion, setListViewQuestion] = useState([]);

  const context = useContext(AppContext)

  useEffect(() => {
    TemplateApi.GetTemplateForTest(3)
      .then(res => {
        if (res) {
          if (res.status === 200 && res.data) {
            setTemplate(res.data);
            let lstViewQuestion = res.data.questions.map(c => ({
              id: c.id,
              answered: false
            }));
            setListViewQuestion(lstViewQuestion);
          }
          else {
            Notification.error(res.message);
          }
        }
        else {
          Notification.error('Api Connection Error');
        }
      });
  }, [])

  function onSelectAnswer(questIndex) {
    let lstViewQuestion = [...listViewQuestion];
    if (!lstViewQuestion[questIndex].answered) {
      lstViewQuestion[questIndex].answered = true;
      setListViewQuestion(lstViewQuestion);
    }
  }
  return (
    <div style={{ width: '100%' }}>
      <TestLeftNav template={template} currentUser={context.userInfo.account} listViewQuestion={listViewQuestion} />
      <TestBody template={template} onSelectAnswer={onSelectAnswer} />
    </div>
  )
}

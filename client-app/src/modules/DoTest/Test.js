import { Layout, Modal } from 'antd'
import React, { useContext, useEffect, useRef, useState } from 'react'
import Notification from '../../common/components/Notification';
import { AppContext } from '../../context';
import TemplateApi from '../../services/TemplateApi';
import TestLeftNav from './LeftNav/TestLeftNav'
import './Test.css'
import TestBody from './TestBody';
import TestResult from './TestResult';
import moment from 'moment'
import ResultApi from '../../services/ResultApi';
import { useParams } from 'react-router';

export default function Test() {
  const [template, setTemplate] = useState({});
  const [listViewQuestion, setListViewQuestion] = useState([]);
  const [testResult, setTestResult] = useState([]);
  const [isFinished, setIsFinished] = useState(false);
  const [finishTime, setFinishTime] = useState(null)

  let params = useParams();
  const context = useContext(AppContext)

  useEffect(() => {
    if (params.id) {
      TemplateApi.GetTemplateForTest(params.id)
        .then(res => {
          if (res) {
            if (res.status === 200 && res.data) {
              setTemplate(res.data);
              let lstViewQuestion = res.data.questions.map(c => ({
                id: c.id,
                answered: false
              }));
              setTestResult(res.data.questions.map(() => false));
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
    }
  }, [params])

  function onSelectAnswer(questIndex, isCorrect) {
    let lstViewQuestion = [...listViewQuestion];
    var newTestResult = [...testResult];
    newTestResult[questIndex] = isCorrect;
    setTestResult(newTestResult);

    if (!lstViewQuestion[questIndex].answered) {
      lstViewQuestion[questIndex].answered = true;
      setListViewQuestion(lstViewQuestion);
    }
  }

  function onFinishTest() {
    Modal.confirm({
      title: 'Bạn muốn kết thúc bài thi?',
      onOk: () => {
        setIsFinished(true);
        setFinishTime(moment());
        ResultApi.add({
          account: context.userInfo.account,
          templateId: template.id,
          score: testResult.filter(c => c).length
        })
      }
    })

  }

  return (
    <div style={{ width: '100%' }}>
      {!isFinished ?
        <>
          <TestLeftNav template={template} currentUser={context.userInfo.account} onFinishTest={onFinishTest} listViewQuestion={listViewQuestion} />
          <TestBody template={template} onSelectAnswer={onSelectAnswer} />
        </>
        :
        <TestResult
          user={context.userInfo}
          testName={`${template.content} - ${template.skill}`}
          result={testResult}
          finishTime={finishTime}
          passScore={template.passScore}
        />}
    </div>
  )
}

import { Radio } from 'antd'
import React from 'react'

export default function TestBody({ template, onSelectAnswer }) {
  function onChangeAnswer(questIndex, isCorrect) {
    if (onSelectAnswer) {
      onSelectAnswer(questIndex, isCorrect);
    }
  }

  return (
    <div className="test-body">
      <div className="test-body-header">
        <span>{template.content} - {template.skill}</span>
      </div>
      <div className="test-body-content" id="test-body-content">
        {(template.questions || []).map((q, i) => (
          <div key={i} className="question" id={'q' + q.id}>
            <div className="question-title">
              <span>Câu hỏi số {i + 1}</span>
            </div>
            <div className="question-content">
              <span>{q.content}</span>
            </div>
            <div className="question-answers">
              <Radio.Group>
                {q.answers.map((a, j) => (
                  <Radio
                    style={{ width: '100%', margin: '4px 15px' }}
                    value={a.id}
                    onClick={() => onChangeAnswer(i, a.isCorrect)}
                    key={`${i}_${j}`}
                  >
                    {a.content}
                  </Radio>
                ))}
              </Radio.Group>
            </div>
            <hr />
          </div>
        ))}
      </div>
    </div>
  )
}

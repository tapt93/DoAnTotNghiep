import { Button, Form, Input, InputNumber, Radio, Select, Tooltip } from 'antd'
import React, { useRef, useState } from 'react'
import './CreateTest.css'
import { CloseOutlined, PlusOutlined, MinusCircleOutlined } from '@ant-design/icons'
import TemplateApi from '../../services/TemplateApi';
import Notification from '../../common/components/Notification';
import { useHistory } from 'react-router';

const { Item } = Form;
const { Option } = Select;
export default function CreateTest() {
  const [form] = Form.useForm();
  const [skill, setSkill] = useState('');
  const [answerCorrectMap, setAnswerCorrectMap] = useState([]);
  let history = useHistory();

  function onChangeQuestionValue(value, index) {
    var questions = form.getFieldValue('questions');
    questions[index].content = value;
    form.setFieldsValue({ questions })
  }

  function onSelectCorrectAnswer(value) {
    let indexes = value.split('_');
    let quesIndex = +indexes[0];
    let ansIndex = +indexes[1];
    var questions = form.getFieldValue('questions');
    var answers = questions[quesIndex].answers;
    for (let i = 0; i < answers.length; i++) {
      answers[i].isCorrect = false;
    }
    answers[ansIndex].isCorrect = true;
    form.setFieldsValue({ questions })
  }

  function onSubmitForm(values) {
    TemplateApi.createTemplate(values)
      .then(res => {
        if (res.status === 200) {
          Notification.success('Create template successfully');
          history.push('/')
        }
        else {
          Notification.error(res.message)
        }
      })
  }

  return (
    <>
      <div className="form-title">
        <h2>Tạo bài thi</h2>
      </div>
      <div className="create-test-form-container">
        <div className="create-test-form-wrapper">
          <Form form={form} layout="vertical" className="create-test-form" onFinish={onSubmitForm}>
            <Item
              required
              name="content"
              label="Tên bài thi"
              rules={[{ required: true, message: 'Nhập tên bài thi' }]}
            >
              <Input />
            </Item>
            <Item
              required
              name="skill"
              label="Kỹ năng"
              rules={[{ required: true, message: 'Chọn kỹ năng bài thi' }]}
            >
              <Select onChange={value => setSkill(value)}>
                <Option value="reading">Đọc</Option>
                <Option value="writing">Viết</Option>
              </Select>
            </Item>
            <Item label="Thời gian thi">
              <Item
                required
                name="duration"
                rules={[{ required: true, message: 'Nhập thời gian thi' }]}
                noStyle
              >
                <InputNumber min={0} />
              </Item>
              <span> phút</span>
            </Item>
            <Item label="Câu hỏi">
              <Form.List
                name="questions"
                rules={[
                  {
                    validator: async (_, questions) => {
                      if (!questions || questions.length < 1) {
                        return Promise.reject(new Error('Cần ít nhất 1 câu hỏi'));
                      }
                    },
                  },
                ]}
              >
                {(fields, { add, remove }, { errors }) => (
                  <>
                    {fields.map((field, i) => (
                      <>
                        <Item
                          name={[field.name, 'content']}
                          fieldKey={[field.fieldKey, 'content']}
                          rules={[{ required: true, message: 'Chưa nhập câu hỏi' }]}
                          className="question-item-wrapper"
                        >
                          <Input
                            addonBefore={'Q' + (i + 1)}
                            addonAfter={<CloseOutlined onClick={() => remove(field.name)} style={{ cursor: 'pointer' }} />}
                            placeholder="Question content"
                            onChange={event => onChangeQuestionValue(event.target.value, i)}
                          />
                        </Item>

                        <Form.List
                          name={[field.name, 'answers']}
                          rules={[
                            {
                              validator: async (_, answers) => {
                                if (!answers || answers.length < 1) {
                                  return Promise.reject(new Error('Cần ít nhất 1 trả lời'));
                                }
                              },
                            },
                          ]}
                        >
                          {(field2s, func, err) => (
                            <>
                              <div className="">
                                <Radio.Group style={{ width: '100%' }} onChange={event => onSelectCorrectAnswer(event.target.value)}>
                                  {field2s.map((field2, j) => {
                                    if (j > 3) return null;
                                    return (
                                      <>
                                        <Button type="link" danger style={{ marginBottom: 15 }}>
                                          <MinusCircleOutlined
                                            onClick={() => func.remove(field2.name)}
                                          />
                                        </Button>
                                        <Item
                                          className="answer-item-wrapper"
                                          {...field2}
                                          name={[field2.name, 'content']}
                                          fieldKey={[field2.fieldKey, 'content']}
                                          rules={[{ required: true, message: 'Chưa nhập câu lời' }]}
                                        >
                                          <Input
                                            addonBefore={String.fromCharCode(j + 65)}
                                            addonAfter={
                                              <Tooltip title="Correct answer" placement="right">
                                                <Radio value={`${i}_${j}`} />
                                              </Tooltip>
                                            }
                                            placeholder="Answer content"
                                          />
                                        </Item>
                                      </>
                                    )
                                  })}
                                  {field2s.length < 4 ?
                                    <Item className="answer-item-wrapper">
                                      <Button
                                        type="dashed"
                                        onClick={func.add}
                                        block icon={<PlusOutlined />}
                                      >
                                        Add answer
                                      </Button>
                                      <Form.ErrorList errors={err.errors} />
                                    </Item>
                                    : null}
                                </Radio.Group>
                              </div>
                            </>
                          )}
                        </Form.List>
                      </>
                    ))}
                    <Item>
                      <Button type="dashed" onClick={add} block icon={<PlusOutlined />}>
                        Add question
                      </Button>
                      <Form.ErrorList errors={errors} />
                    </Item>
                  </>
                )}
              </Form.List>
            </Item>

            <Item name="passScore" label="Điểm hoàn thành">
              <InputNumber min={0} />
            </Item>
            <div style={{ width: '100%', textAlign: 'center' }}>
              <Item>
                <Button type="primary" htmlType="submit" className="btn-submit">
                  Submit
                </Button>
              </Item>
            </div>
          </Form>
        </div>
      </div>
    </>
  )
}

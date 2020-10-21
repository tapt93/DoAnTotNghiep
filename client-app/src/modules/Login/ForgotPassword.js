import { Button, Form, Input } from 'antd'
import React, { useState } from 'react'
import { validateEmail } from '../../common/utility';
import LayoutLogin from './LayoutLogin'

const { Item } = Form;
export default function ForgotPassword() {
  const [form] = Form.useForm();
  const [loading, setLoading] = useState(false);

  function onSubmit(values){

  }

  return (
    <LayoutLogin title="Reset your password">
      <Form form={form} onFinish={onSubmit}>
        <Item
          name="email"
          required
          rules={[
            { required: true, message: "Enter email" },
            () => ({
              validator(rule, value) {
                if (!value || validateEmail(value)) {
                  return Promise.resolve();
                }
                return Promise.reject("Email is invalid");
              },
            }),
          ]}
        >
          <Input placeholder="Email" />
        </Item>
        <Item>
          <Button
            type="primary"
            htmlType="submit"
            className="login-form-button"
            loading={loading}
          >
            Reset password
          </Button>
          <div>
            <a href="/login">
              <Button type="link">Sign in</Button>
            </a>
            <a href="/Register">
              <Button type="link">Create account</Button>
            </a>
          </div>
        </Item>
      </Form>
    </LayoutLogin>
  )
}

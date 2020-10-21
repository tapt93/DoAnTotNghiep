import { Button, Form, Input } from 'antd';
import React, { useState } from 'react';
import { Redirect } from 'react-router';
import Notification from '../../common/components/Notification';
import { validateEmail } from '../../common/utility';
import UserApi from '../../services/UserApi';
import LayoutLogin from './LayoutLogin';

const { Item } = Form;
export function Register() {
  const [form] = Form.useForm();
  const [loading, setLoading] = useState(false);

  async function onSubmit(values) {
    setLoading(true);
    var res = await UserApi.register(values);
    if (res) {
      setLoading(false);
      if (res.status === 200 && res.data) {
        Notification.success("Create account successfully");
        return <Redirect to='/login' />;
      }
      else {
        Notification.error(res.message);
      }
    }
    else {
      Notification.error('Api Connection Error');
    }
  }

  return (
    <LayoutLogin title="Create account">
      <Form form={form} onFinish={onSubmit}>
        <Item
          name="firstName"
          required
          rules={[
            { required: true, message: "Enter first name" }
          ]}
        >
          <Input placeholder="First name" />
        </Item>
        <Item
          name="lastName"
          required
          rules={[
            { required: true, message: "Enter last name" }
          ]}
        >
          <Input placeholder="Last name" />
        </Item>
        <Item
          name="account"
          required
          rules={[
            { required: true, message: "Enter account" }
          ]}
        >
          <Input placeholder="Account" />
        </Item>
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
        <Item
          name="password"
          required
          rules={[
            { required: true, message: "Enter password" }
          ]}
        >
          <Input.Password placeholder="Password" />
        </Item>
        <Item
          name="confirmPassword"
          required
          dependencies={['password']}
          rules={[
            { required: true, message: "Confirm your password" },
            ({ getFieldValue }) => ({
              validator(rule, value) {
                if (!value || getFieldValue('password') === value) {
                  return Promise.resolve();
                }
                return Promise.reject("Those passwords didn't match");
              },
            }),
          ]}
        >
          <Input.Password placeholder="Confirm" />
        </Item>
        <Item>
          <Button
            type="primary"
            htmlType="submit"
            className="login-form-button"
            loading={loading}
          >
            Submit
          </Button>
          <a href="/login">
            <Button style={{ paddingLeft: 0 }} type="link">Sign in instead</Button>
          </a>
        </Item>
      </Form>
    </LayoutLogin>
  );
}
export default Register;
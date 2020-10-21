import { Button, Form, Input } from 'antd'
import React, { useContext, useState } from 'react'
import { UserOutlined, LockOutlined } from '@ant-design/icons'
import './Login.css'
import { AuthContext } from '../../context';
import AuthenApi from '../../services/AuthenApi';
import { useHistory } from 'react-router';
import Notification from '../../common/components/Notification';
import LayoutLogin from './LayoutLogin';

const { Item } = Form;
export default function Login() {
  const [loading, setLoading] = useState(false);
  const [form] = Form.useForm();
  const context = useContext(AuthContext);
  let history = useHistory();

  function handleSubmit(values) {
    setLoading(true);
    AuthenApi.login(values)
      .then(res => {
        setLoading(false);
        if (res && res.access_token) {
          localStorage.setItem(process.env.REACT_APP_Token_Name, JSON.stringify(res));
          context.onLogin();
          history.push('/');
        } else {
          Notification.error("Sai tên đăng nhập hoặc mật khẩu");
        }
      })
      .catch(() => {
        setLoading(false);
        Notification.error("Sai tên đăng nhập hoặc mật khẩu");
      })
  }

  function redirect(link) {
    history.push(link);
  }

  return (
    <LayoutLogin title="Sign in">
      <Form form={form} onFinish={handleSubmit} >
        <Item name="username"
          rules={[
            { required: true, message: "Please input your account!" }
          ]}
        >
          <Input
            prefix={
              <UserOutlined className="login-icon" />
            }
            placeholder="Account"
          />
        </Item>
        <Item name="password"
          rules={[
            { required: true, message: "Please input your Password!" }
          ]}
        >
          <Input
            prefix={
              <LockOutlined className="login-icon" />
            }
            type="password"
            placeholder="Password"
          />
        </Item>
        <Item>
          <Button
            type="primary"
            htmlType="submit"
            className="login-form-button"
            loading={loading}
          >
            Log in
          </Button>
          <div>
            <a href="/ForgotPassword">
              <Button type="link">Forgot password?</Button>
            </a>
            <a href="/Register">
              <Button type="link">Create account</Button>
            </a>
          </div>
        </Item>
      </Form >
    </LayoutLogin>
  )
}

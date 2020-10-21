import React, { useContext } from 'react';
import { Menu, Row, Dropdown, Button } from 'antd';
import { AuthContext } from '../context';
import { SettingOutlined, LogoutOutlined, UserOutlined } from '@ant-design/icons'

function DefaultHeader(props) {
  const context = useContext(AuthContext)

  function onLogout() {
    context.onLogout()
  }

  function onProfileSetting() {
    props.history.push('/profile')
  }

  return (
    <>
      <div className="default-header">
        <div style={{ float: 'right' }}>
          <span className="default-header-text">
            Xin chào, {props.user ? props.user.fullName : ""}
          </span>

          <Dropdown overlay={
            <Menu>
              <Menu.Item>
                <Button type="link" onClick={onProfileSetting}>
                  <SettingOutlined className="default-header-icon" />
                  <span style={{ color: "#888" }}>Tài khoản</span>
                </Button>
              </Menu.Item>
              <Menu.Item>
                <Button type="link" onClick={onLogout} style={{ padding: '10px' }} className="logout-button">
                  <LogoutOutlined className="default-header-icon" />
                  <span style={{ color: "#888" }}>Đăng xuất</span>
                </Button>
              </Menu.Item>
            </Menu>}
          >
            <Button type="link" style={{ padding: '10px' }}>
              <UserOutlined className="default-header-icon" />
            </Button>
          </Dropdown>
        </div>
      </div>
    </>
  )
}

export default DefaultHeader
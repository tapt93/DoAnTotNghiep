import React, { useContext } from 'react';
import { Menu, Row, Dropdown, Button } from 'antd';
import { AppContext, AuthContext } from '../context';
import { SettingOutlined, LogoutOutlined, UserOutlined } from '@ant-design/icons'
import { useHistory } from 'react-router';
import PTFlag from '../assets/images/flag_of_portugal-svg_-1024x682.png'

function DefaultHeader(props) {
  const context = useContext(AuthContext)
  let history = useHistory();

  function onLogout() {
    context.onLogout()
  }

  function onProfileSetting() {
    history.push('/profile')
  }

  return (
    <>
      <div className="default-header">
        <div className="default-header-left">
          <img src={PTFlag} />
          <a href="/">
            <h3>Aprender português</h3>
          </a>
        </div>
        <div className="default-header-right">
          {props.user && props.user.isAdmin &&
            <span className="default-header-text" style={{ marginRight: 100 }}>
              <Button type="link" style={{ textDecoration: 'none', color: 'white' }}>
                <b>Gerenciamento de teste</b>
              </Button>
            </span>
          }
          <span className="default-header-text">
            Olá, {props.user ? props.user.account : ''}
          </span>

          <Dropdown overlay={
            <Menu className="default-header-user-menu">
              <Menu.Item>
                <Button type="link" onClick={onProfileSetting}>
                  <SettingOutlined className="default-header-menu-icon" />
                  <span style={{ color: "#888" }}>Usuário</span>
                </Button>
              </Menu.Item>
              <Menu.Item>
                <Button type="link" onClick={onLogout} className="logout-button">
                  <LogoutOutlined className="default-header-menu-icon" />
                  <span style={{ color: "#888" }}>Sair</span>
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
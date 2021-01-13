import React, { useState } from 'react';
import { BrowserRouter } from 'react-router-dom';
import './App.css';
import { AuthContext } from './context';
import DefaultLayout from './Layout/DefaultLayout';
import ForgotPassword from './modules/Login/ForgotPassword';
import Login from './modules/Login/Login';
import Register from './modules/Login/Register';

function App() {
  let token = getToken();
  const [isAuth, setAuth] = useState(token !== null);

  function onLogin() {
    setAuth(true);
  }

  function onLogout() {
    localStorage.removeItem(process.env.REACT_APP_Token_Name);
    setAuth(false);
  }

  function getToken() {
    let access_token = null;
    const currentUser = localStorage.getItem(process.env.REACT_APP_Token_Name);
    if (currentUser) {
      let token = JSON.parse(currentUser);
      if (token) {
        access_token = token;
      }
    }
    return access_token;
  }
  function getContent(isAuth) {
    const pathname = window.location.pathname;
  
    if (isAuth) {
      return <DefaultLayout />;
    }
    else if (pathname == '/Register') {
      return <Register />
    }
    else if (pathname == '/ForgotPassword') {
      return <ForgotPassword />
    }
    return <Login />
  }

  return (
    <>
      <BrowserRouter basename={process.env.REACT_APP_SUB_APP}>
        <AuthContext.Provider value={{ isAuth, onLogin, onLogout }}>
          {getContent(isAuth)}
        </AuthContext.Provider>
      </BrowserRouter>
    </>
  )
}

export default App;

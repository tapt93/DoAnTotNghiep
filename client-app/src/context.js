import React from 'react'

const AuthContext = React.createContext({
  isAuth: false,
  onLogin: null,
  onLogout: null
});

const AppContext = React.createContext({
  userInfo: null
})
export { AuthContext, AppContext };
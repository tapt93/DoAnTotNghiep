import React from 'react'

export default function LayoutLogin({ title, children }) {
  return (
    <div className="login-wrapper">
      <div className="login-form">
        <div className="login-header">
          <span>Aprender português</span>
        </div>
        <div className="login-title">
          <span>{title}</span>
        </div>
        {children}
      </div>
    </div>
  )
}

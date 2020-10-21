import React from 'react'

export default function LayoutLogin({ title, children }) {
  return (
    <div className="login-wrapper">
      <div className="login-form">
        <div className="login-header">
          <span>Learning Portuguese</span>
        </div>
        <div className="login-title">
          <span>{title}</span>
        </div>
        {children}
      </div>
    </div>
  )
}

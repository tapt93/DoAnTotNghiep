import { Button } from 'antd'
import React from 'react'
import './Home.css'

export default function Home() {
  return (
    <div className="home">
      <div className="home-container">
        <div className="home-item quick-access">
          <div className="quick-access-item">
            Vocabulary
        </div>
          <div className="quick-access-item">
            Grammar
        </div>
          <div className="quick-access-item">
            Verb
        </div>
        </div>
        <div className="home-item">
          <div className="test-item">
            <span className="test-item-description">Online portuguese test</span>
            <Button style={{margin: 20}}>Do it now!</Button>
          </div>
        </div>
      </div>
    </div>
  )
}

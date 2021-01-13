import { Button } from 'antd'
import React from 'react'
import { useHistory } from 'react-router'
import './Home.css'

export default function Home() {
  let history = useHistory();
  return (
    <div className="home">
      <div className="home-container">
        <div className="home-item quick-access">
          <div className="quick-access-item">
            Vocabulário
        </div>
          <div className="quick-access-item">
            Grammática
        </div>
          <div className="quick-access-item">
            Verbo
        </div>
        </div>
        <div className="home-item">
          <div className="test-item">
            <span className="test-item-description">Online português teste</span>
            <Button style={{margin: 20}} onClick={()=>history.push('/TestList')}>Faz test agora!</Button>
          </div>
        </div>
      </div>
    </div>
  )
}

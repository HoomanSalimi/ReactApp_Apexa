import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.jsx'
import Advisor from './AdvisorView.tsx'
/*import './index.css'*/

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    {/*<App />*/}
    <Advisor/>
  </React.StrictMode>,
)

import React from 'react';
import './Style/App.css';

import  {BrowserRouter, Route} from "react-router-dom";

import Registration from './Components/Registration';
import Login from './Components/Login'
import Home from './Components/Home'


function App() {
  return (

    <BrowserRouter>
    <div>
      <div className="Enter_registr">
      <Route path="/" exact component={Home} />
      <Route path="/registration" component={Registration} />
      <Route path="/login" component={Login} />
      </div>     
     
    </div>
  </BrowserRouter>
);
}

export default App;

import React from 'react';
import './Style/App.css';

// import  render  from "react-dom";
import  {BrowserRouter, Route} from "react-router-dom";

import Registration from './registration';
import Enter from './enter'
import Home from './Home'


function App() {
  return (

    <BrowserRouter>
    <div>
      <div className="Enter_registr">
      <Route path="/" exact component={Home} />
      <Route path="/registration" component={Registration} />
      </div>
      
      <Route path="/enter" component={Enter} />
    </div>
  </BrowserRouter>
);
}

export default App;

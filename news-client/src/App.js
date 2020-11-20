import React from 'react';
import './Style/App.scss';
import  {BrowserRouter} from "react-router-dom";

import Header from './Components/Header/Header.jsx'
import NewsWorkspace from "./Components/NewsWorkspace/NewsWorkspace";


const App = (props) => {
  return (
    <BrowserRouter>
      <div>
          <Header state={props.state} dispatch={props.dispatch} store={props.store}/>
          <NewsWorkspace state={props.state} dispatch={props.dispatch} store={props.store}/>
      </div>
    </BrowserRouter>
);
}

export default App;

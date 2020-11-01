import React from 'react';
import './Style/App.scss';
import  {BrowserRouter} from "react-router-dom";

import Header from './Components/Header/Header.jsx'
import NewsWorkspace from "./Components/NewsWorkspace/NewsWorkspace";


function App() {
  return (
    <BrowserRouter>
      <div>
          <Header />
          <NewsWorkspace />
      </div>
    </BrowserRouter>
);
}

export default App;

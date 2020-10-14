import React from 'react';
import './Style/App.scss';
import  {BrowserRouter} from "react-router-dom";

import Header from './Components/Header/Header.jsx'
import NewsWorkspace from "./Components/NewsWorkspace/NewsWorkspace";
import Footer from "./Components/Footer/Footer";


function App() {
  return (
    <BrowserRouter>
      <div>
          <Header />
          <NewsWorkspace />
          <Footer />
      </div>
    </BrowserRouter>
);
}

export default App;

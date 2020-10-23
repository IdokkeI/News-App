import React from 'react';
import './Style/App.scss';
import  {BrowserRouter} from "react-router-dom";

import Header from './Components/Header/Header.jsx'
import NewsWorkspace from "./Components/NewsWorkspace/NewsWorkspace";
import Footer from "./Components/Footer/Footer";
import BestUsers from "./Components/NewsWorkspace/BestUsers/BestUsers";
import RandNews from "./Components/NewsWorkspace/RandNews/RandNews";


const App = (props) => {
  return (
    <BrowserRouter>
      <div>
          <Header />
          <NewsWorkspace state={props.state} dispatch={props.dispatch} store={props.store}/>
          <BestUsers bestUsers={props.state.bestUsers} dispatch={props.dispatch} store={props.store}/>
          <RandNews randNews={props.state.randNews} dispatch={props.dispatch} store={props.store}/>
          <Footer />

      </div>
    </BrowserRouter>
);
}

export default App;

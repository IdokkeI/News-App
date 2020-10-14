import React from 'react'
import './Header.scss'
import {Route} from "react-router-dom";
import Registration from "./Registration/Registration";
import Login from "./Login/Login";
import Home from "../Home";

const Header = () => {
    return <header className='header'>
        <div className="Enter_registr">
            <Route path="/" exact component={Home} />
            <Route path="/registration" render ={ ()=><Registration/> }/>
            <Route path="/login" render ={ ()=><Login/> }/>
        </div>

    </header>
}

export default Header;
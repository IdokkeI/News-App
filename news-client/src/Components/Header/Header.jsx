import React from 'react'
import './Header.scss'
import {NavLink, Route, Link} from "react-router-dom";
import Registration from "./Registration/Registration";
import Login from "./Login/Login";
import Profile from './Profile/Profile';
// import Home from "../Home";

const Header = () => {
    return <header className='header'>        
    
        <div className="Enter_registr">  <nav>
            <Link to="Login" className="enter">Вход</Link>
            <Link to="registration"className="registration">Регистрация</Link>   
            
             </nav> 
            {/* <Route path="/Profile"  render ={ ()=><Profile/> } /> */}
            <Route path="/Login"  render ={ ()=><Login/> } />    
            <Route path="/registration" render ={ ()=><Registration/> }/>
            
        </div>
        <div className="header__profile">
            {/* <Link to="profile"className="Profile">Profile</Link> */}
            <Profile />
        </div>
        <div className="header__createPost">
            <NavLink to="/CreatePost" className="createPost" >Создать пост</NavLink>
        </div>
        
    </header>
             
        
}

export default Header;
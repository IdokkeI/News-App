import React, {Component } from "react";
import "./Header.scss";
import { NavLink, Switch } from "react-router-dom";
import Registration from "./Registration/Registration";
import Login from "./Login/Login";
import Profile from "./Profile/Profile";
import {getAccess, getUser } from "../Utils/Common";
import PrivateRouter from "../Utils/PrivateRouter";
import PublicRouter from "../Utils/PublicRouter";
import UserNotificationsBack from "./Profile/UserNotifications/UserNotificationsBack/UserNotificationsBack";
import CreatePostBack from "./CreatePostBack/CreatePostBack";

 
class Header extends Component {
  render() {
    const user = getUser();
    const access = getAccess();
    return (
      <div className="header">
        <div className="header__inner">
          <div className="header__login">
            {!user && (
              <NavLink className="enter" to="/login">
                Войти
              </NavLink>
            )}
            {!user && (
              <NavLink
                activeClassName="active"
                className="registration"
                to="/registration"
              >
                зарегитсрироваться
              </NavLink>
            )}
          </div>
          <div className="header__profile">
            {user && (
                
                  <Profile user={user} />
              
              )}
          </div>            
            <div className="header__createPost">
              {(user && access < 2)  && (
                <NavLink to="/CreatePost" className="createPost">
                  Создать пост
                </NavLink>
              )}
            </div>
            <div className="header__admin">
              {access === 2 && (
                <NavLink to="/UserList" className="userList">
                User List 
              </NavLink>
              )}
              {access >= 1 && (
                <NavLink to="/BanList" className="banList">
                Ban List 
              </NavLink>
              )}
              {access ===2 && (
                <NavLink to="/CreateModerator" className="createModerator">
                Create Moderator 
              </NavLink>
              )}
              {access ===2 && (
                <NavLink to="/DemoteModerator" className="demoteModerator">
                Demote Moderator 
              </NavLink>
              )}
              {access >= 1 && (
                <NavLink to="/NewsQueue" className="newsQueue">
                News Queue 
              </NavLink>
              )}          
        </div>
        <div className="content">
          <Switch>
            <PublicRouter path="/login" component={Login} />
            <PublicRouter path="/registration" component={Registration} />

            <PrivateRouter path="/CreatePost" component={CreatePostBack} />

            <PrivateRouter path="/UserNotifications" component={UserNotificationsBack } />
           
          </Switch>
        </div>
        </div>
      </div>
    );
  }
}
export default Header;

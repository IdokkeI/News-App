import React, {Component } from "react";
import "./Header.scss";
import { NavLink, Switch } from "react-router-dom";
import Registration from "./Registration/Registration";
import Login from "./Login/Login";
import Profile from "./Profile/Profile";
import { getUser } from "../Utils/Common";
import PrivateRouter from "../Utils/PrivateRouter";
import PublicRouter from "../Utils/PublicRouter";

import PrivateRoute from "../Utils/PrivateRouter";
import CreatePostBack from "./CreatePostBack/CreatePostBack";
import UserNotificationsBack from "./Profile/UserNotifications/UserNotificationsBack/UserNotificationsBack";

import CreatePost from "./CreatePost/CreatePost";
import UserSettings from "./Profile/UserSettings/UserSettings";
import UserSubscribers from "./Profile/UserSubscribers/UserSubscribers";
import UserNews from "./Profile/UserNews/UserNews";
import UserList from "./Profile/UseList/UserList";
 
class Header extends Component {
  render() {
    const user = getUser();
    return (
      <header className="header">
        <div className="Enter_registr">
          {!user && (
            <NavLink activeClassName="active" className="enter" to="/login">
              Login
            </NavLink>
          )}
          {!user && (
            <NavLink
              activeClassName="active"
              className="registration"
              to="/registration"
            >
              registration !
            </NavLink>
          )}
          {user && (
            <NavLink activeClassName="active" to="/profile">
              {user}
            </NavLink>
          )}
          <div className="header__createPost">
            {user && (
              <NavLink to="/CreatePost" className="createPost">
                Создать пост
              </NavLink>
            )}
          </div>
          <div className="header__admin">
            {user === "admin" && (
              <NavLink to="/UserList" className="userList">
              User List 
            </NavLink>
            )}
          </div>
        </div>
        <div className="content">
          <Switch>
            <PublicRouter path="/login" component={Login} />
            <PublicRouter path="/registration" component={Registration} />
            <PrivateRouter path="/profile" component={Profile} />
            <PrivateRouter path="/createPost" component={CreatePost} />
            <PrivateRoute path="/UserList" component={UserList} />

            <PrivateRoute path="/UserNotifications" component={UserNotificationsBack } />
            <PrivateRoute path="/userSettings" component={UserSettings} />
            <PrivateRoute path="/userNews" component={UserNews} />
            <PrivateRoute path="/userSubscribers" component={UserSubscribers} />
            
          </Switch>
        </div>
      </header>
    );
  }
}

export default Header;

import React, {Component } from "react";
import "./Header.scss";
import { NavLink, Switch } from "react-router-dom";
import Registration from "./Registration/Registration";
import Login from "./Login/Login";
import Profile from "./Profile/Profile";
import {getAccess, getUser } from "../Utils/Common";
import PrivateRouter from "../Utils/PrivateRouter";
import PublicRouter from "../Utils/PublicRouter";

import AdminRouter from "../Utils/AdminRouter";

import CreatePostBack from "./CreatePostBack/CreatePostBack";
import UserNotificationsBack from "./Profile/UserNotifications/UserNotificationsBack/UserNotificationsBack";

import CreatePost from "./CreatePost/CreatePost";

import UserSettings from "./Profile/UserSettings/UserSettings";
import UserSubscribers from "./Profile/UserSubscribers/UserSubscribers";
import UserNews from "./Profile/UserNews/UserNews";
import UserList from "./Profile/UseList/UserList";
import BanList from "./Profile/UseList/BanList";
import CreateModerator from "./CreateModerator/CreateModerator";
import DemoteModerator from "./CreateModerator/DemoteModerator";
import NewsQueue from "./Profile/UseList/NewsQueue/NewsQueue";
 
class Header extends Component {
  render() {
    const user = getUser();
    const access = getAccess();
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
        </div>
        <div className="content">
          <Switch>
            <PublicRouter path="/login" component={Login} />
            <PublicRouter path="/registration" component={Registration} />
            <PrivateRouter path="/profile" component={Profile} />
            <PrivateRouter path="/createPost" component={CreatePost} />
            <AdminRouter path="/UserList" component={UserList} />
            <AdminRouter path="/BanList" component={BanList} />
            <AdminRouter path="/CreateModerator" component={CreateModerator} />
            <AdminRouter path="/DemoteModerator" component={DemoteModerator} />
            <AdminRouter path="/NewsQueue" component={NewsQueue} />


            <PrivateRouter path="/UserNotifications" component={UserNotificationsBack } />
            <PrivateRouter path="/userSettings" component={UserSettings} />
            <PrivateRouter path="/userNews" component={UserNews} />
            <PrivateRouter path="/userSubscribers" component={UserSubscribers} />
            

          </Switch>
        </div>
      </header>
    );
  }
}

export default Header;

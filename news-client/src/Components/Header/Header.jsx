import React from "react";
import "./Header.scss";
import { NavLink, Switch } from "react-router-dom";
import Registration from "./Registration/Registration";
import Login from "./Login/Login";
import Profile from "./Profile/Profile";
import { getUser } from "../Utils/Common";
import PrivateRouter from "../Utils/PrivateRouter";
import PublicRouter from "../Utils/PublicRouter";
import PrivateRoute from "../Utils/PrivateRouter";
import CreatePost from "./CreatePost/CreatePost";

const Header = () => {
  const user = getUser();
  return (
    <header className="header">
      <div className="Enter_registr">
        <NavLink activeClassName="active" className="enter" to="/login">
          Login
        </NavLink>
        <NavLink
          activeClassName="active"
          className="registration"
          to="/registration">
          registration !
        </NavLink>
        <NavLink activeClassName="active" to="/profile">
          {user}
        </NavLink>
        <div className="header__createPost">
        <NavLink to="/CreatePost" className="createPost">
          Создать пост
        </NavLink>
      </div>
      </div>
      <div className="content">
        <Switch>
          <PublicRouter path="/login" component={Login} />
          <PublicRouter path="/registration" component={Registration} />
          <PrivateRouter path="/profile" component={Profile} />
          <PrivateRoute path="/createPost" component={CreatePost} />
        </Switch>
      </div>

     
    </header>
  );
};

export default Header;

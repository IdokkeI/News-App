import React, { Component } from "react";
import { NavLink } from "react-router-dom";

import "./Profile.scss";


import { removeUserSession } from "../../Utils/Common";

class Profile extends Component {
  
  handleLogout = () => {
    removeUserSession();
    window.location.href = "/login";
  };

  render() {
    return (
      <div className="profile" >
        <NavLink activeClassName="active" className="userNews" to="/userNews">
          Мои Новости
        </NavLink>

        <NavLink
          activeClassName="active"
          className="userSubscribers"
          to="/userSubscribers">
          Мои Подписки
        </NavLink>
        <NavLink
          activeClassName="active"
          className="userSettings"
          to="/userSettings">
          Настройки !
        </NavLink>
        <div>
          <input type="button" onClick={this.handleLogout} value="Logout" />
        </div>
      </div>
    );
  }
}
export default Profile;

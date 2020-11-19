import React, { Component } from "react";

import { NavLink } from "react-router-dom";
import "./Profile.scss";

import { removeUserSession } from "../../Utils/Common";

export default class Profile extends Component {
  constructor(props) {
    super(props);

    this.state = {
      showMenu: false,
    };
  }

  showMenu() {
    this.setState({ showMenu: !this.state.showMenu });
  }

  handleLogout = () => {
    removeUserSession();
    window.location.href = "/";
  };

  render() {
    let profileMenu;
    if (this.state.showMenu) {
      profileMenu = (
        <div className="profile">
          <NavLink className="userNews" to="/userNews">
            Мои Новости
          </NavLink>
          <NavLink className="userSubscribers" to="/userSubscribers">
            Мои Подписки
          </NavLink>
          <NavLink className="userNotifications" to="/UserNotifications">
            Мои уведомления
          </NavLink>
          <NavLink className="userSettings" to="/userSettings">
            Настройки !
          </NavLink>
          <NavLink className="logout" to="/" onClick={this.handleLogout}>
            Выход
          </NavLink>
        </div>
      );
    }
    return (
      <div onClick={this.showMenu.bind(this)}>
        {this.props.user}
        {profileMenu}
      </div>
    );
  }
}

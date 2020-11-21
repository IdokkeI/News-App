import React, { Component } from "react";

import { NavLink } from "react-router-dom";
import "./Profile.scss";

import { removeUserSession } from "../../Utils/Common";

export default class Profile extends Component {
  constructor(props) {
    super(props);

    this.state = {
      isActive: false,
      showHideSidenav: "dropdown",
    };
    this.showMenu = this.showMenu.bind(this);
  }

  showMenu() {
    this.setState({ isActive: !this.state.isActive });
    const className = (this.state.showHideSidenav === "dropdown") ? "reverted" : "dropdown";
    this.setState({showHideSidenav: className});
    console.log(this.state.isActive);
  }

  handleLogout = () => {
    removeUserSession();
    window.location.href = "/";
  };

  handleClickBack = () => {
    window.location.href = "/";

  }
  render() {
    let profileMenu;
    if (this.state.isActive) {
      profileMenu = (
        <div className="profile-menu" onClick={this.showMenu}>
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
      <div className="profile" >
       <p onClick={this.handleClickBack}> {this.props.user} </p>
        <div className="profile-dropdown" onClick={this.showMenu}>
          <svg className={this.state.showHideSidenav}  
            fill="none">
              <path d="m5 5  5 5 5 -5">
              </path>
          </svg>
        </div>
        {profileMenu}
      </div>
    );
  }
}

import React, { Component } from "react";
import { Route, Switch, NavLink } from "react-router-dom";

import "./Profile.scss";

import UserSettings from "./UserSettings/UserSettings";
import UserNews from "./UserNews/UserNews";
import UserSubscribers from "./UserSubscribers/UserSubscribers";
import UserNotifications from "./UserNotifications/UserNotifications";

import { removeUserSession } from "../../Utils/Common";

class Profile extends Component {
  constructor(props) {
    super(props);

    this.state = {
      showMenu: false,
    };

    this.showMenu = this.showMenu.bind(this);
  }

  showMenu(event) {
    event.preventDefault();

    this.setState({
      showMenu: true,
    });
  }
  handleLogout = () => {
    removeUserSession();
    this.props.history.push("/login");
    window.location.href = "/login";
  };

  render() {
    return (
      <div>
          <a href="/UserNews"> Мои Новости
          </a>
          <NavLink activeClassName="active" className="userNews" to="/userNews">
              Мои Новости
          </NavLink>

          <NavLink
              // activeClassName="active"
              className="userSubscribers"
              to="/userSubscribers">
              Мои Подписки
          </NavLink>
          <NavLink
              // activeClassName="active"
              className="userNotifications"
              to="/UserNotifications">
              Мои уведомления
          </NavLink>
          <NavLink
              // activeClassName="active"
              className="userSettings"
              to="/userSettings"
          >
              Настройки !
          </NavLink>

        <Switch>
          <Route exact path="/userNews" component={UserNews} />
          <Route path="/userSubscribers" component={UserSubscribers} />
          <Route path="/userSettings" component={UserSettings} />
        </Switch>
        <input type="button" onClick={this.handleLogout} value="Logout" />
      </div>
    );
  }
}
export default Profile;

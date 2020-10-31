import React, { Component } from "react";
import "./Profile.scss";

// import UserSettings from "./UserSettings/UserSettings"

// import {NavLink, Route} from 'react-router-dom';
// import { history } from '@/_helpers';
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
  handleLogout = (e) => {
    e.preventDefault();
    removeUserSession();
    this.props.history.push("/login");
  };

  render() {
    return <input type="button" onClick={this.handleLogout} value="Logout" />;
  }
}
export default Profile;

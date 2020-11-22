import React, { Component } from "react";
import { getToken } from "../../Utils/Common";

import UserListShow from "../UserListShow/UserListShow"

export default class CreateModerator extends Component {
  constructor() {
    super();
    this.state = {
      userName: "",
      items: [],
      data: [],
      row: null,
      url: "http://localhost:5295/Admin/GetUsers?page=",
      count: 1,
      nameUS: 'userrrsdf,ds,'
    };
  }
  
  ClickModerator = () => {
    fetch("http://localhost:5295/Admin/SetModerator", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${getToken()}`,
      },
      body: JSON.stringify(this.state.userName),
    }).then((result) => {
      this.setState({
        data: result.userName,
      });
    });
    alert(this.state.userName + "  -  is moderator!");
    window.location.href = "/CreateMOderator";
  };

  onSelect = (userName) => {
    this.setState({ userName: userName });
  };
  render() {
    return (
      <div className="user-list">
        <input
          type="button"
          onClick={this.ClickModerator}
          value="Create Moder"
        />
        <UserListShow onSelect = {this.onSelect} />        
      </div>
    );
  }
}

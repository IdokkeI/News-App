import React, { Component } from "react";
import { getToken } from "../../../Utils/Common";

import USerListShow from "../../UserListShow/UserListShow"


import "./UserList.scss";

export default class UserList extends Component {
  constructor(props) {
    super(props);
    this.state = {
      userName: "",
      dayCount: 0,
      items: [],
    };
  }

  clickBan = () => {
    fetch("http://localhost:5295/Moderator/BanUser", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        "Authorization": `Bearer ${getToken()}`,
      },
      body: JSON.stringify(this.state),
    }).then((result) => {
      this.setState({
        items: result,
      });
    });
  };

  onSelect = (userName) => {
    this.setState({ userName: userName });
  };

  userInput = (e) => {
    this.setState({ dayCount: Number(e.target.value) });
  };


  render() {
    
    return (
      <div className="user-list">
        {this.state.userName && (
          <input
            type="Number"
            placeholder="На сколько дней забанить?"
            onChange={this.userInput}
          />
        )}
        <input type="button" onClick={this.clickBan} value="Ban" />

        <USerListShow onSelect = {this.onSelect} />

      </div>
    );
  }
}

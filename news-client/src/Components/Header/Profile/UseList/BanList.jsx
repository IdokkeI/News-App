import React, { Component } from "react";

import { getToken } from "../../../Utils/Common";

import "./UserList.scss";

export default class UserList extends Component {
  constructor() {
    super();
    this.state = {
      items: [],
    };
  }

  componentDidMount = () => {
    fetch("http://localhost:5295/Moderator/GetBanUsers?page=1", {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${getToken()}`,
      },
    })
      .then((res) => res.json())
      .then((result) => {
        this.setState({
          items: result,
        });
        this.setState({
          searchString: this.state.items,
        });
      });
  };

  handleSearch = (e) => {
    const value = e.target.value.toLowerCase();

    const filter = this.state.searchString.filter((user) => {
      return user.userName.toLowerCase().includes(value);
    });
    this.setState({ items: filter });
  };
  render() {
    return (
      <div>
        <p>Список Забаненных пользователей </p>
        <input type="text" onChange={this.handleSearch} />
        <table className="userList">
          <tbody filter={this.state.searchString}>
            {this.state.items.map((user) => (
              <tr key={user.profileID}>
                <td>{user.userName}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    );
  }
}

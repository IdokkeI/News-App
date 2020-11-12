import React, { Component } from "react";
import { getToken } from "../../../Utils/Common";


import "./UserList.scss";

export default class UserList extends Component {
  constructor() {
    super();
    this.state = {
      userName: "",
      dayCount: 0,
      items: [],
      data: [],
      isLoaded: false,
    };
  }

  componentDidMount = () => {
    fetch("http://localhost:5295/Admin/GetUsers?page=1", {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${getToken()}`,
      },
    })
      .then((res) => res.json())
      .then((result) => {
        this.setState({
          isLoaded: true,
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

  handleClickBan = () => {
    fetch("http://localhost:5295/Moderator/BanUser", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(this.state),
    }).then((result) => {
      this.setState({
        data: result,
      });
    });
  };

  onSelect = (userName) => {
    this.setState({ userName: userName.userName });
  };
  handleUserInput = (e) => {
    this.setState({ dayCount: Number(e.target.value) });
  };

  render() {
    if (this.state.isLoaded === false) {
    return 'Загрузка...';
  }
    return (
      <div className="user-list">
        <p>Список пользователей </p>
        <input type="text" onChange={this.handleSearch} />
        <table className="userList">
          <tbody filter={this.state.searchString}>
            {this.state.items.map((user) => (
              <tr
                key={user.userName}
                onClick={this.onSelect.bind(null, user)}
              >
                <td>{user.userName}</td>
              </tr>
            ))}
          </tbody>
        </table>
        {this.state.userName && (
          <input
            type="Number"
            placeholder="На сколько дней забанить?"
            onChange={this.handleUserInput}
          />
        )}
        <input type="button" onClick={this.handleClickBan} value="Ban" />
      </div>
    );
  }
}

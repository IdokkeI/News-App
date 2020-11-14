import React, { Component } from "react";
import { getToken } from "../../../Utils/Common";
import NextPrevPage from "../NextPrevPage/NextPrevPage";

import "./UserList.scss";

export default class UserList extends Component {
  constructor(props) {
    super(props);
    this.state = {
      userName: "",
      dayCount: 0,
      items: [],
      data: [],
      isLoaded: false,
      url: "http://localhost:5295/Admin/GetUsers?page=",
      count: 1,
    };
  }

  componentDidMount = () => {
    fetch(this.state.url + this.state.count, {
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
  
  componentDidUpdate(prevProps, prevState) {
    if (this.state.count !== prevState.count) {
      fetch(this.state.url + this.state.count, {
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
        });
    }
  }

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
        Authorization: `Bearer ${getToken()}`,
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

  handleCountPlus = () => {
    this.setState({ count: this.state.count + 1 });
  };

  handleCountMinus = () => {
    this.setState({ count: this.state.count - 1 });
  };

  render() {
    if (this.state.isLoaded === false) {
      return "Загрузка...";
    }
    return (
      <div className="user-list">
        <p>Список пользователей </p>
        <input type="text" onChange={this.handleSearch} />
        <table className="userList">
          <tbody filter={this.state.searchString}>
            {this.state.items.map((user) => (
              <tr key={user.userName} onClick={this.onSelect.bind(null, user)}>
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

        <div>
          <NextPrevPage
            itemLenght={this.state.items.length}
            count={this.state.count}
            handleCountMinus={this.handleCountMinus}
            countClickPlus={this.handleCountPlus}
          />
        </div>
      </div>
    );
  }
}

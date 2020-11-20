import React, { Component } from "react";

import { getToken } from "../../../Utils/Common";
import NextPrevPage from "../NextPrevPage/NextPrevPage";

import "./BanList.scss";

export default class BanList extends Component {
  constructor(props) {
    super(props);
    this.state = {
      items: [],
      isLoaded: false,
      count: 1,
      url: "http://localhost:5295/Moderator/GetBanUsers?page=",
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
  };
  
  handleSearch = (e) => {
    const value = e.target.value.toLowerCase();

    const filter = this.state.searchString.filter((user) => {
      return user.userName.toLowerCase().includes(value);
    });
    this.setState({ items: filter });
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

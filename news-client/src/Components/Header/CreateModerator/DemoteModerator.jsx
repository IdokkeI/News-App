import React, { Component } from "react";
import { getToken } from "../../Utils/Common";

import NextPrevPage from "../Profile/NextPrevPage/NextPrevPage";

export default class DemoteModerator extends Component {
  constructor() {
    super();
    this.state = {
      userName: '',
      dayCount: 0,
      items: [],
      data: [],
      url: "http://localhost:5295/Admin/GetModerators?page=",
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

  Search = (e) => {
    const value = e.target.value.toLowerCase();
    const filter = this.state.searchString.filter((user) => {
      return user.userName.toLowerCase().includes(value);
    });
    this.setState({ items: filter });
  };

 
  onSelect = (userName) => {
 this.setState({userName: userName.userName});
};

ClickDemoteModerator = () => {
  fetch("http://localhost:5295/Admin/DemoteModerator", {
      method: "POST", 
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${getToken()}`,
      },
      body: JSON.stringify(this.state.userName),
    })
      .then((result) => {
        this.setState({
          data: result.userName,
        });
      });
      alert(this.state.userName + "  -  is not moderator!");
      window.location.href = "/DemoteModerator";
};

handleCountPlus = () => {
  this.setState({ count: this.state.count + 1 });
};

handleCountMinus = () => {
  this.setState({ count: this.state.count - 1 });
};

  render() {
    return (
      <div className="user-list">
        <p>Список пользователей </p>
        <input type="text" onChange={this.Search} />
        <br />
        <label htmlFor="button"> {this.state.userName} </label>
        <input type="button" onClick={this.ClickDemoteModerator} value="Demote Moder" />

        <table className="userList">
          <tbody filter={this.state.searchString} >
            {this.state.items.map((user) => (
              <tr key={user.userName} onClick={this.onSelect.bind(null, user)} >
                <td>{user.userName}</td>
              </tr>
            ))}
          </tbody>
        </table>
        
        <NextPrevPage
            itemLenght={this.state.items.length}
            count={this.state.count}
            handleCountMinus={this.handleCountMinus}
            countClickPlus={this.handleCountPlus}
            url = {this.state.url}
            items = {this.state.items}
          />

      </div>
    );
  }
}

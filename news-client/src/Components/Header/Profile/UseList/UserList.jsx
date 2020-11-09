import React, { Component } from "react";
import "./UserList.scss";

export default class UserList extends Component {
  constructor() {
    super();
    this.state = {
      items: [],
    };
  }

  componentDidMount = () => {
    fetch("http://localhost:5295/Admin/GetUsers?page=1", {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${localStorage.getItem("token")}`,
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
        <p>Список пользователей </p>
        <input type="text" onChange={this.handleSearch} />
        <table className="userList">
          <tbody filter={this.state.searchString}>
            {this.state.items.map((user) => (
              <tr>
                <td>{user.userName}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    );
  }
}

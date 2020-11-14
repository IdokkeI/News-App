import React, { Component } from "react";
import "./UserNotifications.scss";
import { getToken } from "../../../Utils/Common";
import NextPrevPage from "../NextPrevPage/NextPrevPage";


export default class UserNotifications extends Component {
  constructor() {
    super();
    this.state = {
      items: [],
      url: "http://localhost:5295/Notification/GetNotifications?page=",
      count: 1,
    };
  }

  componentDidMount = () => {
    fetch(this.state.url + this.state.count, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        Authorization: "bearer " + getToken(),
      },
    })
      .then((res) => res.json())
      .then((result) => {
        this.setState({
          isLoaded: true,
          items: result,
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

  handleCountPlus = () => {
    this.setState({ count: this.state.count + 1 });
  };

  handleCountMinus = () => {
    this.setState({ count: this.state.count - 1 });
  };

  render() {
    const news = this.state.items,
      newUrl = "/NewItem/";

    return (
      <div>
        <h3>NOTIFICATIONS </h3>
        <ul>
          {news.map((notif_item) =>
            notif_item.alt === "статья" ? (
              <li key={notif_item.id}>
                <span> Ваша </span>
                <a href={newUrl + notif_item.url}>{notif_item.alt}</a>
                <span> {notif_item.notificationText} </span>
              </li>
            ) : (
              <li key={notif_item.id}>{notif_item.notificationText}</li>
            )
          )}
        </ul>
        <NextPrevPage
            itemLenght={this.state.items.length}
            count={this.state.count}
            handleCountMinus={this.handleCountMinus}
            countClickPlus={this.handleCountPlus}
          />
      </div>
    );
  }
}

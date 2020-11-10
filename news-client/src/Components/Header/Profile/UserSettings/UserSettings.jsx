import React, { Component } from "react";
import "./UserSettings.scss";

class UserSettings extends Component {
  constructor() {
    super();
    this.state = {
      email: "",
      password: "",
      oldPassword: "",
      confirmPassword: "",
    };
  }

  handleUserInput = (e) => {
    const name = e.target.name;
    const value = e.target.value;
    this.setState({ [name]: value});
  };

  handleClick =  () => {
    console.log(this.state.email);
    console.log(this.state.oldPassword);

    console.log(this.state.password);
    console.log(this.state.confirmPassword);


    fetch("http://localhost:5295/Profile/ChangePassword", {
     method: "post",
     headers: {
       "Content-Type": "application/json",
     },
     body: JSON.stringify(this.state),
   })
  //  .then((res) => res.json())
   .then((result) => {
    this.setState({
      data: result,
    });
  });
 };

  render() {
    return (
      <div className="setting">
        <h2 htmlFor="email"> поменять пароль</h2>

        <label htmlFor="email">E-mail</label>
        <input
          type="email"
          name="email"
          placeholder="Email"
          value={this.state.email}
          onChange={this.handleUserInput}
        />
        <label htmlFor="password">Введите старый пароль</label>
        <input
          type="password"
          name="oldPassword"
          placeholder="Введите старый пароль"
          value={this.state.oldPassword}
          onChange={this.handleUserInput}
        />
        <label htmlFor="password">Введите новый пароль</label>
        <input
          type="password"
          name="password"
          placeholder="Введите новый пароль"
          value={this.state.password}
          onChange={this.handleUserInput}
        />
        <label htmlFor="password">Повторите пароль</label>
        <input
          type="password"
          name="confirmPassword"
          placeholder="Повторите пароль"
          value={this.state.confirmPassword}
          onChange={this.handleUserInput}
        />
        <input 
        type="button"
        value="Change"
        onClick={this.handleClick}
        />
      </div>
    );
  }
}

export default UserSettings;

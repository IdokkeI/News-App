import React, { Component } from "react";
import "../Login/Login.scss";
import "./Registration.scss";

class Registration extends Component {
  constructor(props) {
    super(props);
    this.state = {
      email: "",
      password: "",
      userName: "",
      confirmPassword: "",
      isLoaded: false,
      items: [],
      errorForm: [],
    };
  }

  handleUserInput = (e) => {
    const name = e.target.name;
    const value = e.target.value;
    this.setState({ [name]: value });
  };

  handleClick =  () => {
     fetch("http://localhost:5295/Identity/Register", {
      method: "post",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(this.state),
    })
    .then((res) =>
    res.status !== 200 && res.json() 
    )
      .then((result) => {
        this.setState({
          isLoaded: true,
          items: result,
        });
        if(result.status !== 400){
          window.location.href = "/login";
        }else {
          console.log(result.errors)
          this.setState({errorForm : result.errors})
        }       
      });  
  };
  handleClickBack = () => {
    window.location.href = "/";

  }

  render() {
    const error = this.state.errorForm;
 
    return (
      <div className="form">
        <div className="form__group">
          <div className="form__group_title">Регистрация</div>
          <div>
              <div className="form__field">
                <label htmlFor="email" className="form__field_lable">
                  E-mail
                </label>
                <input
                  type="email"
                  className="form__field_input"
                  name="email"
                  placeholder="Email"
                  value={this.state.email}
                  onChange={this.handleUserInput}
                />
                {error.Email != null && 
                  error.Email.map((err, i) => (
                    <li key ={i} className="form__field-error">{err}</li>                  
                ))}
              </div>
              <div className="form__field">
                <label htmlFor="password_field" className="form__field_lable">
                  Пароль
                </label>
                <input
                  type="password"
                  className="form__field_input"
                  name="password"
                  placeholder="Password"
                  value={this.state.password}
                  onChange={this.handleUserInput}
                />
                {error.Password != null && 
                  error.Password.map((err, i) => (
                    <li key ={i} className="form__field-error">{err}</li>                  
                ))}
              </div>
              <div className="form__field">
                <label htmlFor="userName" className="form__field_lable">
                  Никнейм
                </label>
                <input
                  type="userName"
                  className="form__field_input"
                  name="userName"
                  value={this.state.userName}
                  onChange={this.handleUserInput}
                />
                {error.UserName != null && 
                  error.UserName.map((err, i) => (
                    <li key ={i} className="form__field-error">{err}</li>                  
                ))}
              </div>

              <div className="form__field">
                <label htmlFor="password_field" className="form__field_lable">
                  Подтвердите пароль
                </label>
                <input
                  type="password"
                  className="form__field_input"
                  name="confirmPassword"
                  placeholder="confirmPassword"
                  value={this.state.confirmPassword}
                  onChange={this.handleUserInput}
                />
                {error.ConfirmPassword != null && 
                  error.ConfirmPassword.map((err, i) => (
                    <li key ={i} className="form__field-error">{err}</li>                  
                ))}
              </div>

              <div className="form__buttom">
                <button
                  type="button"
                  className="button"
                  onClick={this.handleClick}
                >
                  Регистрация
                </button>
                <button className="button" onClick={this.handleClickBack}>
                  Назад
                </button>
              </div>
          </div>
        </div>
      </div>
    );
  }
}
export default Registration;

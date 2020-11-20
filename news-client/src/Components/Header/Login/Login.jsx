import React, { Component } from "react";

import "./Login.scss";

import { setUserSession } from "../../Utils/Common";

export default class Login extends Component {
  constructor(props) {
    super(props);

    this.state = {
      email: "",
      password: "",
      formErrors: { email: "", password: "" },
      emailValid: false,
      passwordValid: false,
      formValid: false,
      error: null,
      isLoaded: false,
      items: [],
      errorForm: {},
    };
  }

  handleUserInput = (e) => {
    const name = e.target.name;
    const value = e.target.value;
    this.setState({ [name]: value }, () => {
      this.validateField(name, value);
    });
  };

  validateField(fieldName, value) {
    let fieldValidationErrors = this.state.formErrors;
    let emailValid = this.state.emailValid;
    let passwordValid = this.state.passwordValid;

    switch (fieldName) {
      case "email":
        emailValid = value.match(/^([\w.%+-]+)@([\w-]+\.)+([\w]{2,})$/i);
        fieldValidationErrors.email = emailValid ? "" : " Email  is invalid";
        break;
      case "password":
        passwordValid = value.length >= 6;
        fieldValidationErrors.password = passwordValid ? "" : "Password have to has 6 number, and it have to least one letter ";
        break;
      default:
        break;
    }
    this.setState(
      {
        formErrors: fieldValidationErrors,
        emailValid: emailValid,
        passwordValid: passwordValid,
      },
      this.validateForm
    );
  }

  validateForm() {
    this.setState({
      formValid: this.state.emailValid && this.state.passwordValid,
    });
  }

  errorClass(error) {
    return error.length === 0 ? "" : "has-error";
  }

  handleClick = () => {
    fetch("http://localhost:5295/Identity/Login", {
      method: "POST", 
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(this.state),
    })
      .then((res) => res.json()
    )
      .then((result) => {
        this.setState({
          isLoaded: true,
          items: result,
        });
        if(result.status !== 400){
          setUserSession(this.state.items);          
          window.location.href = "/login";
        }else {
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
          <div className="form__group_title">Вход</div>
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
                  error.Password.map((err, i)=> (
                    <li key = {i} className="form__field-error">{err}</li>                  
                ))}
              </div>
              <div className="form__buttom">
                <button
                  type="button"
                  className="button"
                  onClick={this.handleClick}
                >
                  Войти
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

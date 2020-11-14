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

  handleClick = (e) => {
    e.preventDefault();
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
          // console.log(this.state.formErrors)
        }else {
          this.setState({errorForm : this.state.formErrors})
           console.log(this.state.formErrors);
        }       
      });     
  };

  render() {
    const error = this.state.errorForm;
    // console.log(error);
    return (
      <div className="form">
        <div className="form_group">
          <div className="form_group_title">Вход</div>
          <div>
              <div className="form_field">
                <label htmlFor="email" className="form_field_lable">
                  E-mail
                </label>
                <input
                  type="email"
                  className="form_field_input"
                  name="email"
                  placeholder="Email"
                  value={this.state.email}
                  onChange={this.handleUserInput}
                />
                {error.email != null && 
                <p style={{color:"red"}}>{error.email}</p>}
              </div>
              <div className="form_field">
                <label htmlFor="password_field" className="form_field_lable">
                  Пароль
                </label>
                <input
                  type="password"
                  className="form_field_input"
                  name="password"
                  placeholder="Password"
                  value={this.state.password}
                  onChange={this.handleUserInput}
                />
                 {error.password != null && 
                <p style={{color:"red"}}>{error.password}</p>}
              </div>
              <div className="form_buttom">
                <button
                  type="button"
                  className="button button-primary"
                  onClick={this.handleClick}
                >
                  Войти
                </button>
              </div>
          </div>
        </div>
      </div>
    );
  }
}
// export default Login;

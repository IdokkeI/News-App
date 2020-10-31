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
      formErrors: { email: "", password: "" },
      emailValid: false,
      passwordValid: false,
      formValid: false,
      error: null,
        isLoaded: false,
      items:[]
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
        fieldValidationErrors.email = emailValid ? "" : " is invalid";
        break;
      case "password":
        passwordValid = value.length >= 6;
        fieldValidationErrors.password = passwordValid ? "" : " is too short";
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


  //   async componentDidMount() {
  //     // POST request using fetch with async/await
  //     const requestOptions = {
  //         method: 'POST',
  //         headers: { 'Content-Type': 'application/json' },
  //         body: JSON.stringify({ title: 'One or more validation errors occurred.' })
  //     };
  //     const response = await fetch('https://localhost:5001/Identity/Register', requestOptions);
  //     const data = await response.json();
  //     this.setState({ postId: data.id });
  // }

  handleClick  = async(e) => {
    e.preventDefault();

    await fetch("https://localhost:5001/Identity/Register", {
      method: "POST", // or 'PUT'
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(this.state),
    })
      .then((res) => res.json())
      .then(
        (result) => {
          this.setState({
            isLoaded: true,
            items: result,
          });
          this.props.history.push("/login");

          console.log(this.state);
        }
      )
          .catch(function (error) {
            // this.props.history.push("/login");
        console.log('Request faile', error)
      });
  }

  render() {
    return (
      <div className="form">
        <div className="form_group">
          <div className="form_group_title">Регистрация</div>
          <div>
            <form className="form_login">
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
              </div>
              <div className="form_field">
                <label htmlFor="userName" className="form_field_lable">
                  Никнейм
                </label>
                <input
                  type="userName"
                  className="form_field_input"
                  name="userName"
                  value={this.state.userName}
                  onChange={this.handleUserInput}
                />
              </div>
             
              <div className="form_field">
                <label htmlFor="password_field" className="form_field_lable">
                  Подтвердите пароль
                </label>
                <input
                  type="password"
                  className="form_field_input"
                  name="confirmPassword"
                  placeholder="confirmPassword"
                  value={this.state.confirmPassword}
                  onChange={this.handleUserInput}
                />
              </div>

              <div className="form_buttom">
                <button
                  type="submit"
                  className="button button-primary"
                  onClick={this.handleClick}
                >
                  Регистрация
                </button>
                <button className="button button-primary">
                  <a href="/">Назад</a>
                </button>
              </div>
             
            </form>
          </div>
        </div>
      </div>
    );
  }
}
export default Registration;

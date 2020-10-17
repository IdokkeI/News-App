import React, {Component} from 'react';
import { Link } from 'react-router-dom';
import '../Login/Login.scss'
import './Registration.scss'


class Registration extends Component {

  constructor (props) {
    super(props);
    this.state = {
      email: '',
      password: '',
      nikname: '',
      formErrors: {email: '', password: ''},
      emailValid: false,
      passwordValid: false,
      formValid: false
    }
  }

  handleUserInput = (e) => {
    const name = e.target.name;
    const value = e.target.value;
    this.setState({[name]: value},
                  () => { this.validateField(name, value) });
  }

  validateField(fieldName, value) {
    let fieldValidationErrors = this.state.formErrors;
    let emailValid = this.state.emailValid;
    let passwordValid = this.state.passwordValid;

    switch(fieldName) {
      case 'email':
        emailValid = value.match(/^([\w.%+-]+)@([\w-]+\.)+([\w]{2,})$/i);
        fieldValidationErrors.email = emailValid ? '' : ' is invalid';
        break;
      case 'password':
        passwordValid = value.length >= 6;
        fieldValidationErrors.password = passwordValid ? '': ' is too short';
        break;
      default:
        break;
    }
    this.setState({formErrors: fieldValidationErrors,
                    emailValid: emailValid,
                    passwordValid: passwordValid
                  }, this.validateForm);
  }

  validateForm() {
    this.setState({formValid: this.state.emailValid && this.state.passwordValid});
  }

  errorClass(error) {
    return(error.length === 0 ? '' : 'has-error');
  }

  handleClick =(e) => {
    alert(this.state.email + this.state.nikname +  this.state.password);
  }

  render () {
    return (
      <div className="form">
        <div className="form_group">
          <div className="form_group_title">Регистрация</div>
          <div>
            <form className="form_login">
              <div className="form_field">
                <label htmlFor="email" className="form_field_lable">E-mail</label>
                <input type="email" className="form_field_input" name="email" placeholder="Email"
                  value={this.state.email}
                  onChange={this.handleUserInput} />
              </div>
              <div className="form_field">
                <label htmlFor="nikname" className="form_field_lable">Никнейм</label>
                <input type="nikname" className="form_field_input" name="nikname"  value={this.state.nikname}  
                  onChange={this.handleUserInput} />
              </div>
              <div className="form_field">
                <label htmlFor="password_field" className="form_field_lable"> Пароль</label>
                <input type="password" className="form_field_input" name="password" placeholder="Password"
                  value={this.state.password}
                  onChange={this.handleUserInput} />
              </div>
              
              <div className="form_buttom">
                <button type="submit" className="button button-primary" onClick={this.handleClick}>Регистрация</button>
                <div className="form_buttom_back">
                  <Link to="/" className="button button-primary">Назад</Link>
                </div>
              </div>
            </form>
          </div>
        </div>
      </div>
    )
  }
 }
 export default Registration;
 
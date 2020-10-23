import React from "react";
import {Link} from "react-router-dom";
import  '../Style/Home.scss';

export default class Home extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      inputValue: 0
    };
  }

  render() {
    return (
      <div className='home'>
        <Link to="login" className="enter">Вход</Link>
        <Link to="registration" className="registration" >Регистрация</Link>
      </div>
    );
  }
}
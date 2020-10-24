import  React, { Component } from 'react'
import './Profile.scss'

import UserSettings from "./UserSettings/UserSettings"

import {Route} from 'react-router-dom';



class Profile extends Component {
    constructor() {
      super();
      
      this.state = {
        showMenu: false,
      }
      
      this.showMenu = this.showMenu.bind(this);
    }
    
    showMenu(event) {
      event.preventDefault();
      
      this.setState({
        showMenu: true,
      });
    }
  
    render() {
      return (
        <div className="profile">
          <a className="dropbtn" onClick={this.showMenu}> Профиль</a>
          
          {
            this.state.showMenu ?  
            (
                <div className="dropdown-content">
                  <a href="/UserNews">Мои Новости </a>
                  <a href="UserSubscribers"> Мои подписки </a>
                  <a href="/UserSettings">  Настройки</a>
                </div>
                
              ) : null
              
          }
          <div>
        <Route path="/UserSettings" render ={ ()=><UserSettings/> }/> 

        </div>
        </div>
        

      );
    }
  }
  export default Profile;
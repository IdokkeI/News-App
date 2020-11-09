import React, {Component} from 'react';
import './UserNotificationsBack.scss'
import {NavLink} from "react-router-dom";

class UserNotificationsBack extends Component {
    render() {
        return (
            <div className='userNotificationsBack'>
                <NavLink to='/profile'>Вернуться</NavLink>
            </div>
        );
    }
}

export default UserNotificationsBack;
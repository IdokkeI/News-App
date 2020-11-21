import React, {Component} from 'react';
import './UserNotificationsBack.scss'
import {NavLink} from "react-router-dom";

import UserNotifications from "../UserNotifications";
class UserNotificationsBack extends Component {
    render() {
        return (
            <div className='userNotificationsBack'>
                <UserNotifications />
                <NavLink to='/'>Вернуться</NavLink>
            </div>
        );
    }
}

export default UserNotificationsBack;
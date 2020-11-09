import React, { Component } from 'react'
import './UserSettings.scss'


class UserSettings extends Component {

    render () {
        return (
            <div className="setting">
                <label htmlFor="email"> поменять пароль</label>
                <input type="password" placeholder="Введите старый пароль"/>
                <input type="password" placeholder="Введите новый пароль" />
                <input type="password" placeholder="Повторите пароль" />
            </div>
        )
    }
}

export default UserSettings;
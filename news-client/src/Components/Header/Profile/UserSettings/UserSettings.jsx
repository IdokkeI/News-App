import React, { Component } from 'react'
import './UserSettings.scss'


class UserSettings extends Component {
    

    render () {
        return (
            <div className='userSettings'>
                <label htmlFor="email"> поменять пароль</label>
                <input type="text" placeholder="Введите старый пароль"/>
                <input type="text" placeholder="Введите новый пароль" />
                <input type="text" placeholder="Повторите пароль" />
            </div>
        )
    }
}
// const UserSettings = () => {


//     return <div className='userSettings'>

//     </div>
// }



export default UserSettings;
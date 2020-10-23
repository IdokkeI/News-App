import React from 'react'
import './BestUser.scss'

const BestUser = (props) => {
    return <div className='bestUser'>
        <span>Имя пользователя: {props.name}</span>
        <span>Рейтинг: {props.rating}</span>
    </div>
}

export default BestUser;
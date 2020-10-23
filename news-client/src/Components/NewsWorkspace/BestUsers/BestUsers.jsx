import React from 'react'
import './BestUsers.scss'
import BestUser from "./BestUser/BestUser";

const BestUsers = (props) => {
    let bestUsersList = props.bestUsers.bUsers.map( (item) => <BestUser
        name ={item.name}
        rating = {item.rating}
    />);
    return <div className='bestUsers'>
        <div className='bestUsers-container'>
            <span>Лучшие пользователи</span>
            {bestUsersList}
        </div>
    </div>
}

export default BestUsers;
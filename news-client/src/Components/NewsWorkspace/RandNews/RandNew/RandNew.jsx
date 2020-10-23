import React from 'react'
import './RandNew.scss'

const RandNew = (props) => {
    return <div className='randNew'>
        <div className='randNew-container'>
            <h3>{props.title}</h3>
            <span>{props.date}</span>
        </div>
    </div>
}

export default RandNew;
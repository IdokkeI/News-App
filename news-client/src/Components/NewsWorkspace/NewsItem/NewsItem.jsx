import React from 'react'
import './NewsItem.scss'

const NewsItem = (props) => {
    return <div className='newsItem'>
        <h2>{props.title}</h2>
        <h4>Новость создал {props.user}</h4>
        <div>
            {props.text}
        </div>
    </div>
}

export default NewsItem;
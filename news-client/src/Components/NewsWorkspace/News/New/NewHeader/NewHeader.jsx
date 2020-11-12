import React from 'react'
import './NewHeader.scss'

const NewHeader = (props) => {
    return <div className='newHeader'>
        <div>
            <button>Лайк</button>
            <button>Дизлайк</button>
        </div>
        <div>
            <h1>{props.title}</h1>
            <span>Категория: {props.sectionName}</span>
            <span>Пользователь: {props.user}</span>
            <span>Дата: {props.publishDate}</span>
            <span>Просмотры: {props.views}</span>
            <span>Лайки: {props.likes}</span>
            <span>Дизлайки: {props.dislikes}</span>
        </div>
    </div>
}

export default NewHeader;
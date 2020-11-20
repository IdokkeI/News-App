import React from 'react'
import './NewHeader.scss'
import {postLikeActionCreator, postDislikeActionCreator} from "../../../../../redux/newlike-reducer";

const NewHeader = (props) => {
    let postLikeClick = () => {
            props.store.dispatch(postLikeActionCreator(props.id));
        },
        postDislikeClick = () => {
            props.store.dispatch(postDislikeActionCreator(props.id));
        }

    return <div className='newHeader'>
        <div>
            <button onClick={() => { postLikeClick() } }>Лайк</button>
            <button onClick={() => { postDislikeClick() } }>Дизлайк</button>
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
import React from 'react'
import './NewComment.scss'
import {commentLikeActionCreator, commentDislikeActionCreator} from "../../../../../../redux/commetlike-reducer";

const NewComment = (props) => {
    let commentLikeClick = () => {
            props.store.dispatch(commentLikeActionCreator(props.id));
        },
        commentDislikeClick = () => {
            props.store.dispatch(commentDislikeActionCreator(props.id));
        }
    return <div className='newComment'>
        <div className='newComment-container'>
            <button onClick={() => { commentLikeClick() } }>like</button>
            <button onClick={() => { commentDislikeClick() } }>dislike</button>
            <span>Комментатор: {props.userName}</span>
            <span>Дата: {props.dateComment}</span>
            <span>Рейтинг: лайков {props.likeCount}, дизлайков {props.dislikeCount}</span>
            <p>Текст: {props.text}</p>
        </div>
    </div>
}

export default NewComment;
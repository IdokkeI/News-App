import React from 'react'
import './CreateComment.scss'
import {createCommentNewActionCreator, createCommentTextChangeActionCreator} from '../../../../../../redux/createcomment-reducer'

const CreateComment = (props) => {
    let state = props.store.getState().createComment,
        text = state.text,
        commentCreateClick = () => {
            let newsId = props.id
            props.store.dispatch(createCommentNewActionCreator(newsId));
        },
        textChange = (e) => {
            let text = e.target.value;
            props.store.dispatch(createCommentTextChangeActionCreator(text));
        }
        return (
            <div className='createComment'>
                <div className='createComment-container'>
                    Написать умный комментарий
                    <input type='text' value={text} onChange={textChange}/>
                    <button onClick={() => { commentCreateClick() } }>Отправить</button>
                </div>
            </div>
        )
}

export default CreateComment;
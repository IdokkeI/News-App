import React from 'react';
import './CreatePost.scss';
import CreatePostAdd from "./CreatePostAdd";
import {getUser} from '../../Utils/Common';
import {createPostAddTitleChangeActionCreator, createPostAddSectionChangeActionCreator, createPostAddNewActionCreator} from '../../../redux/createpostadd-reducer.js'

const CreatePost = (props) => {
    let state = props.store.getState().createPostAdd,
        newTitle = state.title,
        newSection = state.sectionName,
        newCreateClick = () => {
        props.store.dispatch(createPostAddNewActionCreator());
    },
        titleChange = (e) => {
            let title = e.target.value;
            props.store.dispatch(createPostAddTitleChangeActionCreator(title));
        },
        sectionChange = (e) => {
            let section = e.target.value;
            props.store.dispatch(createPostAddSectionChangeActionCreator(section));
        }

    const user = getUser();
    return (
        <div className='createPost'>
            <div className='createPost-container'>
                <p>Hello {user}</p>
                Заголовок
                <input value = {newTitle} type='text' onChange={titleChange}/>
                Секция
                <input value = {newSection} type='text' onChange={sectionChange}/>
                <CreatePostAdd state={props.state} dispatch={props.dispatch} store={props.store}/>
                <button onClick={() => { newCreateClick() } }>
                    Отправить
                </button>
            </div>
    </div>)
}

export default CreatePost;
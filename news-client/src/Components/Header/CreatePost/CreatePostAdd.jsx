import React from 'react'
import ReactQuill from 'react-quill'
import 'react-quill/dist/quill.snow.css'
import 'react-quill/dist/quill.bubble.css'
import {
    createPostAddTextChangeActionCreator
} from '../../../redux/createpostadd-reducer.js'

const CreatePostAdd = (props) => {
    let state = props.store.getState().createPostAdd,
        text = state.text,
        textChange = (content, delta, source, editor) => {
            let text = editor.getHTML();
            props.store.dispatch(createPostAddTextChangeActionCreator(text));
        }

    let modules = {
        toolbar: [
            [{'font': []}],
            [{'size': ['small', false, 'large', 'huge']}],
            ['bold', 'italic', 'underline'],
            [{'list': 'ordered'}, {'list': 'bullet'}],
            [{'align': []}],
            [{'color': []}, {'background': []}],
            ['clean']
        ]
    }

    let formats = [
        'font',
        'size',
        'bold', 'italic', 'underline',
        'list', 'bullet',
        'align',
        'color', 'background'
    ]

    return (
        <div>
            <ReactQuill theme="snow" modules={modules}
                        formats={formats} onChange={textChange}
                        value={text}/>
        </div>
    );

}

export default CreatePostAdd;
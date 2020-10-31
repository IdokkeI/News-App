import React from 'react';
import './CreatePost.scss';
import {getUser} from '../../Utils/Common';

const CreatePost = () => {
    const user = getUser();
    return (<div className='createPost'>
<p>Hello {user}</p>
    </div>)
}

export default CreatePost;
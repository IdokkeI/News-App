import React from 'react'
import './NewBody.scss'

const NewBody = (props) => {
    return <div className='newBody'>
        <div className='newBody-container'>
            <div>
                {props.text}
            </div>
        </div>
    </div>
}

export default NewBody;
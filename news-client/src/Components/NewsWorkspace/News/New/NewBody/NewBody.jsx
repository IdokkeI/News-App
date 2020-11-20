import React from 'react'
import './NewBody.scss'

const NewBody = (props) => {
    function createMarkup() {
        return {__html: props.text};
    }

    function MyComponent() {
        return <div dangerouslySetInnerHTML={createMarkup()} />;
    }
    return <div className='newBody'>
        <div className='newBody-container'>
            <div>
                {MyComponent() }
            </div>
        </div>
    </div>
}

export default NewBody;
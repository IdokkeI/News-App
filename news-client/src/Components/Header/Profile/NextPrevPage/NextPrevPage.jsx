import React from 'react'
import "./NextPrevPage.scss"

 const NextPrevPage = (props) => {

    return <div className='NextPrevPage'>
        {props.itemLenght >= 20 && props.count > 1 ? (
          [
            <button key={1} type="button" 
            onClick={props.handleCountMinus}
            >
              back
            </button>,
            <button key={2} type="button" 
            onClick={props.countClickPlus}
            >
              next
            </button>
          ]
        ) : props.itemLenght >= 20 && props.count === 1? (
          <button
            key={3}
            type="button"
            onClick={props.countClickPlus}
          >
            next
          </button>
        ) : props.count > 1 && props.itemLenght < 20 && (
            <button
            key={5}
            type="button"
            onClick={props.handleCountMinus}
          >
            back
          </button>
        )}
    </div>
}

export default NextPrevPage;
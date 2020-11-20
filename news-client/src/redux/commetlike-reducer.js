import {getToken} from "../Components/Utils/Common";

const COMMENT_LIKE ='COMMENT_LIKE',
      COMMENT_DISLIKE ='COMMENT_DISLIKE'

let initialState = {
        objectId: 0,
        state: "string"
    },

    token = getToken(),

    fetchAddNew = (state) => {
        fetch('http://localhost:5295/StatisticComment/SetState', {
            method: 'POST',
            headers: {
                "Content-Type": 'application/json',
                'Authorization': 'Bearer ' + token,
            },
            body: JSON.stringify({
                objectId: +state.objectId,
                state: state.state
            }),
        })
    };



const commentUpdateRatingReducer = (state = initialState, action) => {
    switch(action.type) {
        case COMMENT_LIKE: {
            state.objectId = action.objectId
            state.state = 'like'
            fetchAddNew(state)
            return state
        }
        case COMMENT_DISLIKE: {
            state.objectId = action.objectId
            state.state = 'dislike'
            fetchAddNew(state)
            return state
        }
        default: return state
    }
}

export const commentLikeActionCreator = (objectId) => ({ type: COMMENT_LIKE, objectId: objectId })
export const commentDislikeActionCreator = (objectId) => ({ type: COMMENT_DISLIKE, objectId: objectId, })

export default commentUpdateRatingReducer;
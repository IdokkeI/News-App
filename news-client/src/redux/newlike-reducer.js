import {getToken} from "../Components/Utils/Common";

const POST_LIKE ='POST_LIKE',
      POST_DISLIKE ='POST_DISLIKE'

let initialState = {
        objectId: 0,
        state: "string"
    },

    token = getToken(),

    fetchAddNew = (state) => {
        fetch('http://localhost:5295/StatisticNews/SetState', {
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

const postUpdateRatingReducer = (state = initialState, action) => {
    switch(action.type) {
        case POST_LIKE: {
            state.objectId = action.objectId
            state.state = 'like'
            fetchAddNew(state)
            return state
        }
        case POST_DISLIKE: {
            state.objectId = action.objectId
            state.state = 'dislike'
            fetchAddNew(state)
            return state
        }
        default: return state
    }
}

export const postLikeActionCreator = (objectId) => ({ type: POST_LIKE, objectId: objectId })
export const postDislikeActionCreator = (objectId) => ({ type: POST_DISLIKE, objectId: objectId, })

export default postUpdateRatingReducer;
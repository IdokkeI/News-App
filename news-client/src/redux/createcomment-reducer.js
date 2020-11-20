import {getToken} from "../Components/Utils/Common";

const CREATE_COMMENT_UPDATE_TEXT ='CREATE_COMMENT_UPDATE_TEXT',
      CREATE_COMMENT_NEW ='CREATE_COMMENT_NEW'

let initialState = {
        newsId: '',
        textComment: '',
        usernameAddresTo: 'string',
        commentIdTo: 0
    },

    token = getToken(),

fetchAddNew = (state) => {
    fetch('http://localhost:5295/Comment/CreateComment', {
        method: 'POST',
        headers: {
            "Content-Type": 'application/json',
            'Authorization': 'Bearer ' + token,
        },
        body: JSON.stringify({
            newsId: +state.newsId,
            textComment: state.textComment,
            usernameAddresTo: state.usernameAddresTo,
            commentIdTo: +state.commentIdTo
        }),
    })
};

const createCommentReducer = (state = initialState, action) => {
    switch(action.type) {
        case CREATE_COMMENT_NEW: {
            state.newsId = action.newsId
            fetchAddNew(state)
            return state
        }
        case CREATE_COMMENT_UPDATE_TEXT:{
            state.textComment = action.textComment
            return state
        }
        default: return state
    }
}

export const createCommentNewActionCreator = (newsId) => ({ type: CREATE_COMMENT_NEW, newsId: newsId })
export const createCommentTextChangeActionCreator = (textComment) => ({ type: CREATE_COMMENT_UPDATE_TEXT, textComment: textComment, })

export default createCommentReducer
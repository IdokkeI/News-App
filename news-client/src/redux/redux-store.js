import {combineReducers, createStore, applyMiddleware} from "redux"
import createPostAddReducer from "./createpostadd-reducer"
import { composeWithDevTools } from 'redux-devtools-extension'
import thunk from "redux-thunk"
import createCommentReducer from "./createcomment-reducer"
import postUpdateRatingReducer from "./newlike-reducer";
import commentUpdateRatingReducer from "./commetlike-reducer";

let reducers = combineReducers({
    createPostAdd: createPostAddReducer,
    createComment: createCommentReducer,
    postUpdateRating: postUpdateRatingReducer,
    commentUpdateRating: commentUpdateRatingReducer
})

const store = createStore(reducers, composeWithDevTools(applyMiddleware(thunk)))
export default store;
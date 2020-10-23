import {combineReducers, createStore} from "redux";
import randNewsReducer from "./randnews-reducer";
import newsReducer from "./news-reducer";
import bestUsersReducer from "./bestusers-reducer";


let reducers = combineReducers({
    randNews: randNewsReducer,
    newsList: newsReducer,
    bestUsers: bestUsersReducer
})

let store = createStore(reducers);

export default store;
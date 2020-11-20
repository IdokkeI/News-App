import {getToken} from "../Components/Utils/Common";

const CREATE_POST_ADD_UPDATE_TITLE ='CREATE_POST_ADD_UPDATE_TITLE',
      CREATE_POST_ADD_UPDATE_SECTION ='CREATE_POST_ADD_UPDATE_SECTION',
      CREATE_POST_ADD_UPDATE_TEXT ='CREATE_POST_ADD_UPDATE_TEXT',
      CREATE_POST_ADD_NEW ='CREATE_POST_ADD_NEW'

let initialState = {
    sectionName: '',
    title: '',
    text: '',
},

token = getToken(),

fetchAddNew = (state) => {
    fetch('http://localhost:5295/News/CreateNews', {
        method: 'POST',
        headers: {
            "Content-Type": 'application/json',
            'Authorization': 'Bearer ' + token,
        },
        body: JSON.stringify({
            sectionName: state.sectionName,
            title: state.title,
            text: state.text,
        }),
    })
};

const createPostAddReducer = (state = initialState, action) => {
    switch(action.type) {
        case CREATE_POST_ADD_NEW: {
            fetchAddNew(state);
            return state
        }
        case CREATE_POST_ADD_UPDATE_TITLE:{
            state.title = action.title
            return state
        }
        case CREATE_POST_ADD_UPDATE_SECTION:{
            state.sectionName = action.sectionName
            return state
        }
        case CREATE_POST_ADD_UPDATE_TEXT:{
            state.text = action.text
            return state
        }
        default: return state
    }
}

export const createPostAddNewActionCreator = () => ({ type: CREATE_POST_ADD_NEW })
export const createPostAddTitleChangeActionCreator = ( title) => ({ type: CREATE_POST_ADD_UPDATE_TITLE, title: title, })
export const createPostAddSectionChangeActionCreator = (sectionName) => ({ type: CREATE_POST_ADD_UPDATE_SECTION, sectionName: sectionName })
export const createPostAddTextChangeActionCreator = (text) => ({ type: CREATE_POST_ADD_UPDATE_TEXT, text: text })

export default createPostAddReducer;
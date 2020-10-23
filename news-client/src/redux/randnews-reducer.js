const RAND_NEWS ='RAND-NEWS'

let initialState = {
    rNews: [
        { id: 1, title: 'Заголовок рандомной новости 1', date: '01.01.2020', likeCount: '5', dislikeCount: '2', views: '55' },
        { id: 2, title: 'Заголовок рандомной новости 2', date: '01.01.2020', likeCount: '5', dislikeCount: '2', views: '55' },
        { id: 3, title: 'Заголовок рандомной новости 3', date: '01.01.2020', likeCount: '5', dislikeCount: '2', views: '55' },
        { id: 4, title: 'Заголовок рандомной новости 4', date: '01.01.2020', likeCount: '5', dislikeCount: '2', views: '55' },
        { id: 5, title: 'Заголовок рандомной новости 5', date: '01.01.2020', likeCount: '5', dislikeCount: '2', views: '55' }
    ]
}

const randNewsReducer =(state = initialState, action) => {
    if (action.type = RAND_NEWS) {
        return state;
    } else return state;
}

export const randNewsActionCreator = () => ({ type: RAND_NEWS })

export default randNewsReducer;
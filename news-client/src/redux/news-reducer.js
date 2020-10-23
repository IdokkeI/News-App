const NEWS_LIST ='NEWS-LIST'

let initialState = {
    news: [
        { id: 1, user: 'Admin', title: 'Заголовок', date: '01.01.2020', likeCount: '5', dislikeCount: '2', text: '<h2>Какой-то заголовок</h2>тут просто начинается текст', views: '55' },
        { id: 2, user: 'Admin', title: 'Заголовок2', date: '01.01.2020', likeCount: '5', dislikeCount: '3', text: '<h2>Какой-то заголовок</h2>тут просто начинается текст', views: '77' },
        { id: 3, user: 'Admin', title: 'Заголовок3', date: '01.01.2020', likeCount: '5', dislikeCount: '4', text: '<h2>Какой-то заголовок</h2>тут просто начинается текст', views: '525' },
        { id: 4, user: 'Admin', title: 'Заголовок4', date: '01.01.2020', likeCount: '5', dislikeCount: '8', text: '<h2>Какой-то заголовок</h2>тут просто начинается текст', views: '515' }
    ]
}

const newsReducer =(state = initialState, action) => {
    if (action.type = NEWS_LIST) {
        return state;
    } else return state;
}

export const newsListActionCreator = () => ({ type: NEWS_LIST })

export default newsReducer;
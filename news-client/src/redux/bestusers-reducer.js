const BEST_USERS ='BEST-USERS'

let initialState = {
    bUsers: [
        { id: 1, name: 'Don', rating: '155' },
        { id: 2, name: 'Nod', rating: '14' },
        { id: 3, name: 'Odin', rating: '17' },
        { id: 4, name: 'Dwa', rating: '84' },
        { id: 5, name: 'Tree', rating: '52' }
    ]
}

const bestUsersReducer =(state = initialState, action) => {
    if (action.type = BEST_USERS) {
        return state;
    } else return state;
}

export const bestUsersActionCreator = () => ({ type: BEST_USERS })

export default bestUsersReducer;
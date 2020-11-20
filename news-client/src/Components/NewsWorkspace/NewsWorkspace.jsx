import React from 'react'
import './NewsWorkspace.scss'
<<<<<<< Updated upstream
=======
import {
    Route,
    useParams
} from "react-router-dom"
import News from "./News/News"
import New from "./News/New/New"
import CreatePost from "../Header/CreatePost/CreatePost"
import UserNotifications from "../Header/Profile/UserNotifications/UserNotifications"
import UserNews from "../Header/Profile/UserNews/UserNews"
import UserSubscribers from "../Header/Profile/UserSubscribers/UserSubscribers"


function NewItem(props) {
    let { slug } = useParams();
    return <New id={slug} state={props.state} dispatch={props.dispatch} store={props.store}/>;
}
>>>>>>> Stashed changes

const NewsWorkspace = (props) => {
    return <div className='newsWorkspace'>
<<<<<<< Updated upstream

=======
        <div className='newsWorkspace-container'>
            <Route path='/CreatePost' render ={ ()=> <CreatePost state={props.state} dispatch={props.dispatch} store={props.store}/> } />
            <Route path='/' exact render ={ ()=> <News /> } />
            <Route path='/New' exact render ={ ()=> <New id = {Route.context.params('id')} state={props.state} dispatch={props.dispatch} store={props.store}/> } />
            <Route path='/UserNotifications' exact render ={ () => <UserNotifications /> } />
            <Route path="/NewItem/:slug">
                <NewItem state={props.state} dispatch={props.dispatch} store={props.store}/>
            </Route>
            <Route path="/userSubscribers" component={UserSubscribers} />
            <Route exact path="/userNews" component={UserNews} />
        </div>
>>>>>>> Stashed changes
    </div>
}

export default NewsWorkspace;
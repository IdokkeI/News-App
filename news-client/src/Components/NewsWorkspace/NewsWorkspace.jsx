import React from 'react'
import './NewsWorkspace.scss'
import {
    Route,
    useParams
} from "react-router-dom"
import News from "./News/News"
import New from "./News/New/New"
import CreatePost from "../Header/CreatePost/CreatePost"
import UserNotificationsBack from "../Header/Profile/UserNotifications/UserNotificationsBack/UserNotificationsBack"
import UserNews from "../Header/Profile/UserNews/UserNews"
import UserSubscribers from "../Header/Profile/UserSubscribers/UserSubscribers"
import CreateModerator from "../Header/CreateModerator/CreateModerator"

import UserList from "../Header/Profile/UseList/UserList"
import PrivateRouter from "../Utils/PrivateRouter";
import PrivateRoute from '../Utils/PrivateRouter'
import AdminRouter from "../Utils/AdminRouter";
import BanList from "../Header/Profile/UseList/BanList";
import DemoteModerator from "../Header/CreateModerator/DemoteModerator";
import UserSettings from "../Header/Profile/UserSettings/UserSettings";
import NewsQueue from "../Header/Profile/UseList/NewsQueue/NewsQueue";



function NewItem(props) {
    let { slug } = useParams();
    return <New id={slug} state={props.state} dispatch={props.dispatch} store={props.store}/>;
}

const NewsWorkspace = (props) => {
    return <div className='newsWorkspace'>
        <div className='newsWorkspace-container'>
            <Route path='/CreatePost' render ={ ()=> <CreatePost state={props.state} dispatch={props.dispatch} store={props.store}/> } />
            <Route path='/' exact render ={ ()=> <News /> } />
            <Route path='/New' exact render ={ ()=> <New id = {Route.context.params('id')} state={props.state} dispatch={props.dispatch} store={props.store}/> } />
            <Route path='/UserNotifications' exact render ={ () => <UserNotificationsBack /> } />
            <Route path="/NewItem/:slug">
                <NewItem state={props.state} dispatch={props.dispatch} store={props.store}/>
            </Route>
            <Route path="/userSubscribers" component={UserSubscribers} />
            <Route exact path="/userNews" component={UserNews} />

            <PrivateRoute path="/UserList" component={UserList} />
            <AdminRouter path="/BanList" component={BanList} />
            <AdminRouter path="/CreateModerator" component={CreateModerator} />
            <AdminRouter path="/DemoteModerator" component={DemoteModerator} />
            <AdminRouter path="/NewsQueue" component={NewsQueue} />
            <PrivateRouter path="/userSettings" component={UserSettings} />

        </div>
    </div>
}

export default NewsWorkspace;
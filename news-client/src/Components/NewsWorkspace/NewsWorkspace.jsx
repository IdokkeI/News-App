import React from 'react'
import './NewsWorkspace.scss'
import CreatePost from "../Header/CreatePost/CreatePost";
import Route from "react-router-dom/es/Route";
import News from "./News/News";

const NewsWorkspace = (props) => {
    return <div className='newsWorkspace'>
        <div className='newsWorkspace-contauner'>
            <Route path='/CreatePost' render ={ ()=> <CreatePost /> } />
            <Route path='/' exact render ={ ()=> <News newsList={props.state.newsList} dispatch={props.dispatch}/> } />
        </div>
    </div>
}

export default NewsWorkspace;
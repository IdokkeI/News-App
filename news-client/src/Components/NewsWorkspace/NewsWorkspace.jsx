import React from 'react'
import './NewsWorkspace.scss'
import {
    Route,
    useParams
} from "react-router-dom";
import News from "./News/News";
import New from "./News/New/New";

function NewItem() {
    let { slug } = useParams();
    return <New id={slug} />;
}

const NewsWorkspace = () => {
    return <div className='newsWorkspace'>
        <Route path='/' exact render ={ ()=> <News /> } />
        <Route path="/NewItem/:slug">
            <NewItem />
        </Route>
    </div>
}

export default NewsWorkspace;
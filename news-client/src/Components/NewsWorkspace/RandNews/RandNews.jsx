import React from 'react'
import './RandNews.scss'
import RandNew from "./RandNew/RandNew";

const RandNews = (props) => {
    let randNewsList = props.randNews.rNews.map( (item) => <RandNew
        title={item.title}
        id ={item.id}
        date = {item.date}
    />);
    return <div className='randNews'>
        Рандомные новости
        {randNewsList}
    </div>
}

export default RandNews;
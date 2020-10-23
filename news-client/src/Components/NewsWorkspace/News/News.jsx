import React from 'react'
import './News.scss'
import NewsItem from "../NewsItem/NewsItem";

const News = (props) => {
    let news = props.newsList.news.map( (item) => <NewsItem
        text={item.text}
        title={item.title}
        user={item.user}
        id ={item.id}
        likescounts = {item.user}
        date = {item.date}
    />);
    return <div className='news'>
        Новости снизу
        {news}
    </div>
}

export default News;
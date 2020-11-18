import React from "react";

const NewsQueueGet = (props) => {
  return (
    <div className="NewsQueueGet">
        <div>
            <table className="NewsQueueGet-table">
                <tbody>
                    {props.items.map((news) => (
                        <tr key={news.newsId} onClick = {props.onSelect.bind(null, news)} >
                            <td>{news.title}</td>
                            <td>{news.publishDate}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    </div>
    );
};

export default NewsQueueGet;

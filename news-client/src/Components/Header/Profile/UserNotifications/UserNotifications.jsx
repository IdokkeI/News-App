import React, {Component} from 'react'
import './UserNotifications.scss'
import {getToken} from "../../../Utils/Common";

export default class UserNotifications extends Component {
    constructor(){
        super()
        this.state = {
            items: []
        }
    }

    componentDidMount= () => {
        fetch("http://localhost:5295/Notification/GetNotifications?page=1", {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                'Authorization': 'bearer ' + getToken(),
            },
        })
            .then((res) => res.json())
            .then((result) => {
                this.setState({
                    isLoaded: true,
                    items: result,
                });
            });
            console.log(this.state.items);
    }

    render(){
        const  news  = this.state.items,
            newUrl = 'http://localhost:3000/News/GetNewsById?newsId=',
            new_or_comment = (notif_item) => {
                return notif_item.alt === 'статья' ? 'http://localhost:3000/News/GetNewsById?newsId=': 1
        }

        return(
            <div>
                <p>Список пользователей </p>
                <ul>
                    НОТИФИКАЦИИ
                    {news.map((notif_item) =>
                        <div>
                            <div>
                                <h3><a href={newUrl + notif_item.id}>Ид</a></h3>
                                <p>{notif_item.id}</p>
                            </div>
                        </div>
                    )}
                </ul>
            </div>
        )
    }
}
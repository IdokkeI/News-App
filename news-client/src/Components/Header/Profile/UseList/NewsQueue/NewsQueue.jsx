import React, {Component} from "react";
import "./NewsQueue.scss"

import { getToken } from "../../../../Utils/Common";
import NewsQueueGet from "./NewsQueueGet";
import NextPrevPage from "../../../Profile/NextPrevPage/NextPrevPage";


export default class NewsQueue extends Component {
    constructor(props){
        super(props);
        this.state = {
            items: [],
            newsId: '',
            title: '',
            data: [],
            isLoaded: false,
            count: 1,
            url: "http://localhost:5295/Moderator/GetNotApprovedNews?page=",
        }
    }

    componentDidMount = () => {
        fetch(this.state.url + this.state.count, {
            method: "GET",
            headers: {
              "Content-Type": "application/json",
              Authorization: `Bearer ${getToken()}`,
            },
          })
            .then((res) => res.json())
            .then((result) => {
              this.setState({
                isLoaded: true,
                items: result,
              });
            });
    }

    componentDidUpdate(prevProps, prevState) {
        if (this.state.count !== prevState.count) {
          fetch(this.state.url + this.state.count, {
            method: "GET",
            headers: {
              "Content-Type": "application/json",
              Authorization: `Bearer ${getToken()}`,
            },
          })
            .then((res) => res.json())
            .then((result) => {
              this.setState({
                isLoaded: true,
                items: result,
              });
            });
        }
      }
    
    onSelect = (newsId) => {
        this.setState({ newsId: newsId.newsId,
        title: newsId.title});
      };

      handleClickApprove = () => {
        fetch("http://localhost:5295/Moderator/ApproveNews", {
            method: "POST",
            headers: {
              "Content-Type": "application/json",
              Authorization: `Bearer ${getToken()}`,
            },
            body: JSON.stringify(this.state.newsId),
          })
          .then((result) => {
            this.setState({
              data: result,
            });
            console.log(result)
          });
        alert(" News - " + this.state.title + "  -  is approve!");
        window.location.href = "/NewsQueue";
      }

      handleCountPlus = () => {
        this.setState({ count: this.state.count + 1 });
      };
    
      handleCountMinus = () => {
        this.setState({ count: this.state.count - 1 });
      };
    render(){
        return(
            <div className="newsQueue">
                <p>Список новостей в очереди на проверке</p>
                <input type="button" onClick={this.handleClickApprove} value="Approve News" />
                <NewsQueueGet  
                    items = {this.state.items} 
                    onSelect = {this.onSelect} 
                />
                <NextPrevPage 
                    itemLenght={this.state.items.length}
                    count={this.state.count}
                    handleCountMinus={this.handleCountMinus}
                    countClickPlus={this.handleCountPlus}
                />
               
            </div>
        )
    }
}

import React, {Component} from "react";
import "./UserList.scss";

export default class UserList extends Component {
    constructor(){
        super()
        this.state = {
            items: []
        }
    }

    componentDidMount= () => {
        fetch("http://localhost:5295/Admin/GetUsers?page=1", {
            method: "GET", 
            headers: {
              "Content-Type": "application/json",
              "Authorization": `Bearer ${ localStorage.getItem('token')}`,
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

render(){
    const  users  = this.state.items;
   
    return(
        <div>
            <p>Список пользователей </p>
            <ul>
                    {users.map((user) =>
                    
                        <li key={user.userName}>
                            {user.userName}
                        </li>
                    )}
                </ul>
        </div>
    )
}
}
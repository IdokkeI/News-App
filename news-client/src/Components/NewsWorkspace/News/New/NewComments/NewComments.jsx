import React, {Component} from 'react'
import './NewComments.scss'
import NewComment from "./NewComment/NewComment";
import CreateComment from "./CreateComment/CreateComment";

export default class NewComments extends Component {
    constructor(props){
        super(props)
        this.state = {
            items: [],
            id: props.id,
            params: {}
        }
    }

    componentDidMount= () => {
        fetch(`http://localhost:5295/Comment/GetCommentsByNewsId`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                page: 1,
                newsId: +this.state.id
            }),
        })
            .then((res) => res.json())
            .then((result) => {
                this.setState({
                    isLoaded: true,
                    items: result,
                    params: result.params
                });
            });
    }

    render()
    {
        let comments = this.state.items
        
        return <div className='newComments'>
            <div className='newComments-container'>
                Комментарии:
                {comments.map((comment_item) =>
                    <NewComment state={this.props.state} dispatch={this.props.dispatch} store={this.props.store} id = {comment_item.commentId} likeCount = {comment_item.params.likes} dislikeCount = {comment_item.params.dislikes} dateComment = {comment_item.dateComment} userName = {comment_item.userName} text = {comment_item.text}/>
                )}
                <CreateComment state={this.props.state} dispatch={this.props.dispatch} store={this.props.store} id = {this.state.id}/>
            </div>
        </div>
    }
}
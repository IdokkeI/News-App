import React, {Component} from 'react'
import './New.scss'
import NewHeader from "./NewHeader/NewHeader"
import NewBody from "./NewBody/NewBody"
import NewComments from "./NewComments/NewComments"

export default class New extends Component {
    constructor(props){
        super(props)
        this.state = {
            items: [],
            id: props.id,
            params: {}
        }
    }

    componentDidMount= () => {
        fetch(`http://localhost:5295/News/GetNewsById?newsId=${this.state.id}`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json"
            },
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

    render(){
        const newItemMap = this.state.items,
            newItemParams = this.state.params
        return(
            <div>
                <NewHeader state={this.props.state} dispatch={this.props.dispatch} store={this.props.store} new_id = {this.props.id} id = {newItemMap.newsId} views={newItemParams.views} dislikes={newItemParams.dislikes} likes={newItemParams.likes} publishDate={newItemMap.dislikes} title={newItemMap.title} user = {newItemMap.userName} sectionName = {newItemMap.sectionName}/>
                <NewBody text = {newItemMap.text} />
                <NewComments state={this.props.state} dispatch={this.props.dispatch} id = {this.state.id}  store={this.props.store}/>
            </div>

        )
    }
}
import React from "react";
import '../style/video.css';
const defaultLoad='COVID-19 Vaccine Podcast;';
class Searchbar extends React.Component {
    constructor(props) {
        super(props);
    }
    
    //by default inial load videos
    componentDidMount() {        
        this.props.handleFormSubmit(defaultLoad);
    }

    state = {
        term: ''
    };
    //to change the keying values for search
    handleChange = (event) => {
        this.setState({
            term: event.target.value
        });
    };
    //handle the enter button submission to search the videos
    handleSubmit = event => {
        event.preventDefault();
        this.props.handleFormSubmit(this.state.term);
    }
    //handle to search button to search the videos
    handleClick() {
        this.props.handleFormSubmit(this.state.term);
    }
    render() {
        return (
            <div className='search-bar ui segment'>
                <form onSubmit={this.handleSubmit} className='ui form'>
                    <div className='field'>
                        <input onChange={this.handleChange} name='video-search' placeholder="Search" style={{ width: '90%' }} type="text" value={this.state.term} />

                        <button aria-label="Search" className="header-search-btn" onClick={() => this.handleClick()}>
                            <span className="text">Search</span>
                        </button>
                    </div>
                </form>
            </div>
        )
    }
}
export default Searchbar;

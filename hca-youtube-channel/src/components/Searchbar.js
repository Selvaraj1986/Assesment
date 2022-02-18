import React from "react";
import '../style/video.css';
const defaultCovid19Videos = 'COVID-19 Vaccine Podcast';
const defaulAllVideos = 'HCA';
class Searchbar extends React.Component {
    constructor(props) {
        super(props);
    }

    //by default inial load videos
    componentDidMount() {
        this.props.handleFormSubmit(defaultCovid19Videos);
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
    filterCovid19Videos() {
        this.state.term = defaultCovid19Videos;
        this.props.handleFormSubmit(defaultCovid19Videos);
    }
    filterAllVideo() {
        this.state.term = defaulAllVideos;
        this.props.handleFormSubmit(defaulAllVideos);
    }
    render() {
        return (
            <div className="header-filter">

                <div className='search-bar ui segment'>

                    <form onSubmit={this.handleSubmit} className='ui form'>
                        <div style={{ marginRight: '10%' }}>
                            <button className="header-filter-btn" type='text' onClick={() => this.filterAllVideo()}>
                                <span className="text">All Videos</span>
                            </button>
                            <button className="header-filter-btn" type='text' onClick={() => this.filterCovid19Videos()}>
                                <span className="text">Covid-19 Videos</span>
                            </button>
                        </div>
                        <div className='field'>
                            <input onChange={this.handleChange} name='video-search' placeholder="Search" style={{ width: '90%' }} type="text" />
                            <button aria-label="Search" className="header-search-btn" onClick={() => this.handleClick()}>
                                <span className="text">Search</span>
                            </button>
                        </div>
                    </form>
                </div>
            </div >
        )
    }
}
export default Searchbar;

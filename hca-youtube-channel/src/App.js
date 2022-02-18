import React from 'react';
import Header from './components/Header';
import Footer from './components/Footer';
import SearchBar from './components/Searchbar';
import youtube from './apis/Youtube.js';
import VideoList from './components/VideoList';
import VideoDetail from './components/VideoDetail';
import './style/video.css';
const defaultLoad = 'COVID-19 Vaccine Podcast;';
class App extends React.Component {

  constructor(props) {
    super(props);
  }

  //initialize the state
  state = {
    videos: [],
    selectedVideo: null
  }
  handleVideoSelect = (video) => {
    this.setState({ selectedVideo: video })
  }
  //to search the video 
  handleSubmit = async (termFromSearchBar) => {
    if (!termFromSearchBar) {
      termFromSearchBar = defaultLoad;
    }
    const response = await youtube.get('/search', {
      params: {
        q: termFromSearchBar
      }
    })
    //to keep the response values
    this.setState({
      videos: response.data.items
    })
    this.handleVideoSelect(this.state.videos[0]);
  };
  render() {
    return (
      <div>
        <Header />
        <div className='ui container' style={{ marginTop: '1em' }}>
          <SearchBar handleFormSubmit={this.handleSubmit} />
          <div className='ui grid'>
            <div className="ui row">
              <div className="eleven wide column">
                <VideoDetail video={this.state.selectedVideo} />
              </div>
              <div className="five wide column">
                <VideoList handleVideoSelect={this.handleVideoSelect} videos={this.state.videos} />
              </div>
            </div>
          </div>
        </div>
        <Footer />
      </div>
    )
  }
}

export default App;

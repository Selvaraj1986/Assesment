import React from 'react';
import '../style/video.css';
import Moment from 'moment';
const VideoItem = ({ video, handleVideoSelect }) => {
    return (
        <div onClick={() => handleVideoSelect(video)} className=' video-item item'>
            <img className='ui image' src={video.snippet.thumbnails.medium.url} alt={video.snippet.description} />
            <div className='content'>
                <div className='header'>
                    <p>{video.snippet.title}</p>
                    <p className='date-label'>{Moment(video.snippet.publishedAt).format('MMM DD,yyyy')}</p>
                </div>
            </div>
        </div>
    )
};
export default VideoItem;
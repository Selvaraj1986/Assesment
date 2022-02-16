import React from 'react';
import Moment from 'moment';
const VideoDetail = ({ video }) => {

    if (video) {
        const videoSrc = `https://www.youtube.com/embed/${video.id.videoId}`;

        return (
            <div>
                <div className='ui embed'>
                    <iframe src={videoSrc} allowFullScreen title='Video player' />
                </div>
                <div className='ui segment'>
                    <h4 className='ui header'>{video.snippet.title}</h4>
                    <p className='date-label'>{Moment(video.snippet.publishedAt).format('MMM DD,yyyy')}</p>
                    <p>{video.snippet.description}</p>
                </div>
            </div>

        )
    } else {
        return '';
    }
}

export default VideoDetail;
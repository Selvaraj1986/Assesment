import axios from 'axios';
//youtube api credential key
const KEY = 'AIzaSyAVGpk51rphwRCcHaYFnJ5kyY1PGhNMA1U';
export default axios.create({
    baseURL: 'https://www.googleapis.com/youtube/v3/',
    params: {
        channelId: 'UCL03ygcTgIbe36o2Z7sReuQ',
        part: 'snippet',
        maxResults: 25,
        key: KEY
    }
})
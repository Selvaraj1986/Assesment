import axios from 'axios';
//youtube api credential key
//const KEY = 'AIzaSyAVGpk51rphwRCcHaYFnJ5kyY1PGhNMA1U';
//const KEY = 'AIzaSyAFUNYmE1gfydRFrlb3Q05gXlPSgQmiY6I';
//const KEY = 'AIzaSyAlfV8fFR5tT1LIrmeSID0WtgNzxZUQvJM';
const KEY = 'AIzaSyD_S6W0GH9GMVJKjMoGd6Ho1f_TO7CRJ0Q';

export default axios.create({
    baseURL: 'https://www.googleapis.com/youtube/v3/',
    params: {
        channelId: 'UCL03ygcTgIbe36o2Z7sReuQ',
             part: 'snippet',
        maxResults: 25,
        key: KEY
    }
})
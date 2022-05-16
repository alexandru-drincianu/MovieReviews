import { ADD_MOVIE, GET_MOVIES } from "../constants/actionTypes";

const moviesReducer = (movies = [], action) => {
    switch(action.type){
        case GET_MOVIES:
            return action.payload;
        case ADD_MOVIE:
            return [...movies, action.payload];
        default:
            return movies;
    }
}

export default moviesReducer;
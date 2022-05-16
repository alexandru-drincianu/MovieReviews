import { ADD_GENRE, GET_GENRES } from "../constants/actionTypes";

const genresReducer = (genres = [], action) => {
    switch(action.type){
        case GET_GENRES:
            return action.payload;
        case ADD_GENRE:
            return[...genres, action.payload];
        default:
            return genres;
    }
}

export default genresReducer;
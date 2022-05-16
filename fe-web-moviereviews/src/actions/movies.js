import * as api from '../api/index';
import { ADD_MOVIE, GET_MOVIES } from '../constants/actionTypes';

export const getMovies = () => async (dispatch) => {
    try {
        const {data} = await api.getMovies();
        dispatch({type: GET_MOVIES, payload: data});
    } catch(error){
        console.log(error);
    }
}

export const addMovie = (movie) => async (dispatch) => {
    try {
        const {data} = await api.addMovie(movie);
        dispatch({type: ADD_MOVIE, payload: data});
    } catch(error){
        console.log(error);
    }
}
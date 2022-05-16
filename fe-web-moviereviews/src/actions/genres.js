import * as api from '../api/index';
import { ADD_GENRE, GET_GENRES } from '../constants/actionTypes';

export const getGenres = () => async (dispatch) => {
    try{
        const {data} = await api.getGenres();
        dispatch({type: GET_GENRES, payload: data});
    } catch (error) {
        console.log(error);
    }
}

export const addGenre = (genre) => async (dispatch) => {
    try{
        const {data} = await api.addGenre(genre);
        dispatch({type: ADD_GENRE, payload: data});
    } catch (error) {
        console.log(error);
    }
}
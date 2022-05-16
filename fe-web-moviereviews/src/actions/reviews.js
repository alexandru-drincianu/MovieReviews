import * as api from '../api/index';
import { ADD_REVIEW, DELETE_REVIEW, GET_REVIEWS, UPDATE_REVIEW } from '../constants/actionTypes';

export const getReviews = () => async (dispatch) => {
    try {
        const {data} = await api.getReviews();
        dispatch({type: GET_REVIEWS, payload: data});
    } catch(error){
        console.log(error);
    }
}

export const addReview = (review) => async (dispatch) => {
    try {
        const {data} = await api.addReview(review);
        dispatch({type: ADD_REVIEW, payload: data});
    }catch(error){
        console.log(error);
    }
}

export const updateReview = (id, review) => async (dispatch) => {
    try{
        const {data} = await api.updateReview(id, review);
        dispatch({type: UPDATE_REVIEW, payload: data});
    } catch(error){
        console.log(error);
    }
}

export const deleteReview = (id) => async (dispatch) => {
    try {
        await api.deleteReview(id);
        dispatch({type: DELETE_REVIEW, payload: id});
    } catch(error){
        console.log(error);
    }
}
import { ADD_REVIEW, DELETE_REVIEW, GET_REVIEWS, UPDATE_REVIEW } from "../constants/actionTypes";

const reviewsReducer = (reviews = [], action) => {
    switch(action.type){
        case GET_REVIEWS:
            return action.payload;
        case ADD_REVIEW:
            return [...reviews, action.payload];
        case UPDATE_REVIEW:
            return reviews.map((review) => (review.id === action.payload.id ? action.payload : review));
        case DELETE_REVIEW:
            return reviews.filter((review) => review.id !== action.payload);
        default:
            return reviews;
    }
}

export default reviewsReducer;
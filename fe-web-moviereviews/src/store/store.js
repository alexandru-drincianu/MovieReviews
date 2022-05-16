import { configureStore } from '@reduxjs/toolkit';
import authReducer from '../reducers/auth';
import genresReducer from '../reducers/genres';
import moviesReducer from '../reducers/movies';
import reviewsReducer from '../reducers/reviews';

export const store = configureStore({
    reducer: {
        auth: authReducer,
        genres: genresReducer,
        movies: moviesReducer,
        reviews: reviewsReducer
    }
});
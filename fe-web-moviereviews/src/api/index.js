import axios from "axios";

export const api = axios.create({baseURL: 'https://localhost:7147/api/'});

export const signIn = (formData) => api.post('auth/login', formData);
export const signUp = (formData) => api.post('auth/register', formData);

export const getGenres = () => api.get('Genres');
export const addGenre = (formData) => api.post('Genres', formData);

export const addMovie = (formData) => api.post('Movies', formData);
export const getMovies = () => api.get('Movies');

export const addReview = (formData) => api.post('Reviews', formData);
export const getReviews = () => api.get('Reviews');
export const updateReview = (id, formData) => api.put(`Reviews/${id}`, formData);
export const deleteReview = (id) => api.delete(`Reviews/${id}`);

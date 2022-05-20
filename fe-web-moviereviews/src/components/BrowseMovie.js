import React, { useEffect, useState } from "react";
import { useDispatch } from "react-redux";
import { getGenres } from "../actions/genres";
import BrowseMovieCarousel from "./BrowseMovieCarousel";
import NavBar from "./NavBar/NavBar";

const userId = localStorage.getItem('id');

const BrowseMovie = () => {
    const [categoryList, setCategories] = useState([]);
    const dispatch = useDispatch();
    //const {categories, dispatch} = useContext(CategoriesContext);

    useEffect(() => {
        dispatch(getGenres())
        /*api.get('/v1/Category')
        .then((response) => {
            console.log(response.data);
            setCategories(response.data);
        })
        .catch(function (error) {
            console.log(error);
        });*/
    }, [dispatch]);
    
    return(
        <>
        <NavBar/>
        <BrowseMovieCarousel/>
        </>
    );
}

export default BrowseMovie;
import { CircularProgress, Grid } from "@mui/material";
import React from "react";
import { useSelector } from "react-redux";
import MovieCarousel from './MovieCarousel/MovieCarousel';

const BrowseMovieCarousel = () => {
    const categoryList = useSelector((state) => state.genres);
    console.log(categoryList);

    return(
        <>
        {!categoryList.length ? <CircularProgress /> :
            <div>
                <Grid container spacing={4} justifyContent="flex-start" style={{paddingLeft: '40px', paddingRight: '40px', paddingTop: '30px'}} >
                    {categoryList.map( (category) => {
                        return (
                            <MovieCarousel genre={category} key={category.id}/>
                        )
                    })}
                </ Grid>
            </div>
        }
        </>
    );
}

export default BrowseMovieCarousel;
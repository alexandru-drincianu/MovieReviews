import { Grid, Typography } from "@mui/material";
import React from "react";
import Carousel from 'react-elastic-carousel';
import MovieCard from "../MovieCard/MovieCard";

const MovieCarousel = ({genre}) => {
    return (
        <>
        <Typography variant="h5" style={{paddingTop: 10}}>{genre.genreName}</Typography>
        <Carousel itemsToShow={3} style={{marginBottom: 20}}>
            {genre.movies.map((movie) => {
                        return (
                            <Grid item key={movie.id}>
                                <MovieCard movie = {movie}/>
                            </Grid>
                        )
                    })}
        </Carousel>
        </>
    );
}

export default MovieCarousel;
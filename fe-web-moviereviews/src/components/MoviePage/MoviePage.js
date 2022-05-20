import { CircularProgress } from "@mui/material";
import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import NavBar from "../NavBar/NavBar";
import MovieDetails from "./MovieDetails";

const MoviePage = () => {
    const {id} = useParams();

    return (
        <>
        <NavBar />
        <MovieDetails id={id}/>
        </>
    );
} 

export default MoviePage;
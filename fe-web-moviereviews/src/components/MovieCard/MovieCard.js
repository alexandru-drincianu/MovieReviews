import { Paper, Typography } from "@mui/material";
import React from "react";
import { useNavigate } from "react-router-dom";

const MovieCard = ({movie}) => {
    const navigate = useNavigate();

    const handleClick = () => {
        navigate(`/movies/${movie.id}`);
    }

    return(
        <div style={{marginBottom: 20}} onClick={handleClick}>
        <Paper elevation={3} style={{padding: 5}}>
            <div style={{height: '250px', width: '150px'}}>
                <img src={movie.moviePicture} style={{height: '100%', width: '100%'}}/>
            </div>
            <div>
                <p>
                    <Typography component={'span'} variant="body2" style={{fontWeight: 550}}>{movie.title}</Typography>
                </p>
            </div>
        </Paper>
        </div>
    );
}

export default MovieCard;
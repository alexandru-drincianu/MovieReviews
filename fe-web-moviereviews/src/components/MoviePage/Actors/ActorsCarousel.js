import { Grid, Typography } from "@mui/material";
import React from "react";
import Carousel from 'react-elastic-carousel';
import ActorCard from "./ActorCard";


const ActorsCarousel = ({actors}) => {
    return (
        <Grid container style={{padding: '30px'}}>
        <Typography variant="h5" style={{paddingTop: 10}}>Actors</Typography>
        <Carousel itemsToShow={3} style={{marginBottom: 20}}>
            {actors.map((actor) => {
                        return (
                            <Grid item key={actor.id}>
                                <ActorCard actor={actor}/>
                            </Grid>
                        )
                    })}
        </Carousel>
        </Grid>
    );
}

export default ActorsCarousel;
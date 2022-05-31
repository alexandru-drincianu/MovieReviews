import { Paper, Typography } from "@mui/material";
import React from "react";

const ActorCard = ({actor}) => {

    return(
        <div style={{marginBottom: 20}}>
        <Paper elevation={3} style={{padding: 5}}>
            <div style={{height: '250px', width: '150px'}}>
                <img src={actor.image} style={{height: '100%', width: '100%'}}/>
            </div>
            <div>
                <p>
                    <Typography component={'span'} variant="body2" style={{fontWeight: 550}}>{actor.name}</Typography>
                </p>
            </div>
        </Paper>
        </div>
    );
}

export default ActorCard;
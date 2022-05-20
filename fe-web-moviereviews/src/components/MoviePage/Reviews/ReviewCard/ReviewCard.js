import { Divider, Rating, Typography } from "@mui/material";
import { Box } from "@mui/system";
import React from "react";

const ReviewCard = ({review}) => {

    return (
        <Box sx={{bgcolor: 'background.paper', color: 'black'}}>
            <Box sx={{display: 'flex', alignItems: 'center', width: 'fit-content',paddingTop: '20px', paddingLeft: '20px'}}>
                <Typography variant="h6">{review.userName}</Typography>
            </Box>
            
            <Rating name="half-rating" defaultValue={review.rating} style={{paddingLeft: '20px', color: '#C68A5D'}} readOnly />
            
            <Divider variant="middle" flexItem style={{background: 'black'}}/>
            
            <Typography variant="body1" style={{paddingBottom: '20px', paddingLeft: '20px'}}>{review.description}</Typography>
        </Box>
    );
}

export default ReviewCard;
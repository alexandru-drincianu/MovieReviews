import { Box, Grid, Typography } from "@mui/material";
import React from "react";
import StarIcon from '@mui/icons-material/Star';
import LinearNoReviews from "./LinearNoReviews";

const NoOfReviews = ({no, value, total}) => {
    console.log(total)
    return (
        <Box sx={{display: 'inline-flex', alignItems: 'center', }} >
            <Typography variant="body2">{no} stars</Typography>
            <StarIcon style={{color: '#C68A5D'}}/>
            <LinearNoReviews variant="determinate" value={value/total * 100} style={{marginRight: 5}}/>
            <Typography variant="body2">{value}</Typography>
        </Box>
    );
}

export default NoOfReviews;
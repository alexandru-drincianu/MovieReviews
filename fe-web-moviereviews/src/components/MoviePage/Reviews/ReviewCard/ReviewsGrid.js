import { CircularProgress, Grid, Typography } from "@mui/material";
import React from "react";
import ReviewCard from "./ReviewCard";

const ReviewsGrid = ({reviews}) => {
    return(
        <Grid container direction="row" alignItems="center" justifyContent="center" spacing={4} style={{paddingLeft: '10px', paddingRight: '40px', paddingTop: '30px', paddingBottom: '30px'}}>
            <Grid item xs={12}>
                <Typography variant="h5">Reviews</Typography>
            </Grid>
            {
                !reviews ? <Typography>No reviews</Typography> :
                    <Grid container>
                        {
                            reviews.map( (review) => {
                                return (
                                    <Grid item xs={12} key={review.userId}>
                                        <ReviewCard review={review} />
                                    </Grid>
                                )
                            })
                        }
                    </Grid>
            }
        </Grid>
    );
}

export default ReviewsGrid;
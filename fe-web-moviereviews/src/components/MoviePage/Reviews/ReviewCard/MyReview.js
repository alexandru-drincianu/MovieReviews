import { Button, Grid, IconButton, Rating, TextField, Typography } from "@mui/material";
import React, { useState } from "react";
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import ClearIcon from '@mui/icons-material/Clear';
import CheckIcon from '@mui/icons-material/Check';
import { Box } from "@mui/system";
import { useDispatch } from "react-redux";
import { deleteReview, updateReview } from "../../../../actions/reviews";

const userId = localStorage.getItem('id');

const MyReview = ({review, movieId}) => {
    const[editable, setEditable] = useState(false);
    const [reviewState, setReviewState] = useState({id: review.id, userId: review.userId, movieId: movieId, rating: review.rating, description: review.description});
    const dispatch = useDispatch();

    const handleReset = () => {
        console.log(review.rating);
        //setReviewState({...reviewState, reviewDescription: review.reviewDescription});
        //setReviewState({...reviewState, reviewDescription: review.reviewDescription});
        console.log(reviewState);
        setEditable(!editable);
    }

    const handleUpdateReview = () => {
        const reviewUpdate = {
            userId: reviewState.userId,
            movieId: reviewState.movieId,
            rating: reviewState.rating,
            description: reviewState.description
        };
        /*api.put(`/v1/Reviews/${reviewState.id}`, reviewUpdate)
        .then((response) => {
            console.log(response.data);
            //setReview(response.data);
        })
        .catch(function (error) {
            console.log(error);
        });*/
        dispatch(updateReview(reviewState.id, reviewUpdate));
        setEditable(!editable);
    }

    const handleDeleteReview = () => {
        /*api.delete(`/v1/Reviews/${reviewState.id}`)
        .then((response) => {
            console.log(response.data);
            //setReview(response.data);
        })
        .catch(function (error) {
            console.log(error);
        });*/
        dispatch(deleteReview(reviewState.id));
        //setEditable(!editable);
    }

    return (
        <Grid container spacing={2} style={{paddingRight: 30}}>
            <Grid item xs={12}>
                <Typography variant="h6">Your review</Typography>
            </Grid>
            <Grid item xs={12}>
            <Rating name="half-rating" value={reviewState.rating} readOnly={!editable} onChange={(e) => setReviewState({...reviewState, rating: Number(e.target.value)})} /> 
            </Grid>
            <Grid item xs={12}>
                <TextField variant="outlined" name="review" multiline rows={5} value={reviewState.description} fullWidth disabled={!editable} onChange={(e) => setReviewState({...reviewState, description: e.target.value})}/>
            </Grid>
            <Grid item xs={12}>
                <Box display="flex" justifyContent="flex-end">
                    {!editable && <IconButton onClick={() => setEditable(!editable)}>
                        <EditIcon style={{color: '#9F8069'}}/>
                    </IconButton>
                    }
                    {editable && 
                    <>
                    <IconButton onClick={handleUpdateReview}>
                        <CheckIcon style={{color: '9&8069'}} />
                    </IconButton>
                    <IconButton onClick={handleReset}>
                        <ClearIcon style={{color: '9&8069'}} />
                    </IconButton>
                    </>
                    }
                    <IconButton onClick={handleDeleteReview}>
                        <DeleteIcon style={{color: '#9F8069'}}/>
                    </IconButton>
                </Box>
            </Grid>
        </Grid>
    );
} 

export default MyReview;
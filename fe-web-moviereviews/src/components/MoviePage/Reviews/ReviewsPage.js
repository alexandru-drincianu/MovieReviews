import { CircularProgress, Grid } from "@mui/material";
import React, { useEffect, useState } from "react";
import GeneralReviews from "./ReviewCard/GeneralReviews";
import ReviewsGrid from "./ReviewCard/ReviewsGrid";

const userId = localStorage.getItem('id');

const ReviewsPage = ({noOfRatings, reviews, movieId, totalReviewsLength}) => {
    //const [reviews, setReviews] = useState([]);
    //const dispatch = useDispatch();

    /*useEffect(() => {
        api.get(`/v1/Reviews/withoutCurrUser?bookId=${bookId}&userId=${userId}`)
        .then((response) => {
            console.log(response.data);
            setReviews(response.data);
        })
        .catch(function (error) {
            console.log(error);
        });
    }, []);*/

    return (<>
        <Grid container justifyContent="center">
            <Grid item xs={6}>
                <GeneralReviews noOfRatings={noOfRatings} movieId={movieId} totalReviewsLength={totalReviewsLength}/>
            </Grid>
            <Grid item xs={6}>
                <ReviewsGrid reviews={reviews} />
            </Grid>
        </Grid>
        </>
    );
}

export default ReviewsPage;
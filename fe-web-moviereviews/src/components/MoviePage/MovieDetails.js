import { CircularProgress, Divider, Rating, Typography } from "@mui/material";
import React, { useEffect, useState } from "react";
import { useDispatch } from "react-redux";
import { api } from "../../api";
import ReviewsPage from "./Reviews/ReviewsPage";

const userId = localStorage.getItem('id');

const MovieDetails = ({id}) => {
    const [movie, setMovie] = useState(null);
    const [noOfRatings, setNoOfRatings] = useState([]);
    const dispatch = useDispatch();
    const [reviews, setReviews] = useState(null);
    const [totalReviewsLength, setTotalReviewsLenght] = useState(-1);
    const [genres, setGenres] = useState('');

    useEffect(() => {
        api.get(`Reviews/ratings/${id}`)
        .then((response) => {
            setNoOfRatings(response.data);
        })
        .catch(function (error) {
            console.log(error);
        });
    }, []);

    useEffect(() => {
        api.get(`Movies/${id}`)
        .then((response) => {
            console.log(response.data);
            setMovie(response.data);
            if (response.data.reviews.length !== 0){
                setReviews(response.data.reviews.filter( r => r.userId !== userId));
                setTotalReviewsLenght(response.data.reviews.length);
            }else{
                setTotalReviewsLenght(0);
            }
            const str = response.data.genres.map(({genreName }) => ` ${genreName}`).join(', ');
            console.log(str);
            setGenres(str);
        })
        .catch(function (error) {
            console.log(error);
        });
    }, []);

    function getRating(){
        const sum = noOfRatings.reduce((total, currVal) => total = total + Number(currVal.noRating) * Number(currVal.rating), 0);
        const totalReviews = noOfRatings.reduce((total, currVal) => total = total + Number(currVal.noRating), 0);
        return sum / totalReviews;
    }

    return(
        <>
        {!movie ? <CircularProgress /> :
            <>
            {noOfRatings && (totalReviewsLength !== -1) &&
            <>
            <div style={{display: 'flex', justifyContent: 'center', marginTop: 30, marginLeft: 70, marginRight: 70,}}>
                <div style={{height:400, width: 250, marginRight: 50}}>
                    <img src={movie.moviePicture} alt="" style={{height: '100%',width: '230px', fill: 'cover'}}/>
                </div>
                <div style={{display: 'flex', flexDirection: 'column',}}>
                    <div style={{marginBottom: 20}}>
                        <Typography variant="h5">{movie.title}</Typography>
                    </div>
                    <div style={{marginBottom: 20}}>
                        <Typography variant="h6">{genres}</Typography>
                    </div>
                    <div style={{marginBottom: 20}}>
                        <Rating precision={0.1} readOnly defaultValue={getRating()} style={{color: '#C68A5D'}} />
                    </div>
                    <div>
                        <Typography variant="body2">{movie.description}</Typography>
                    </div>
                </div>
            </div>
            <Divider variant="middle" flexItem style={{padding: 20}}/>
            <ReviewsPage noOfRatings={noOfRatings} movieId={id} reviews={reviews} totalReviewsLength={totalReviewsLength}/>
            </>
            }
            </>
        }
        </>
    );
}

export default MovieDetails;
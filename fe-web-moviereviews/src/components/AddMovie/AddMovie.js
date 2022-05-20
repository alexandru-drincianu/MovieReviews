import { Button, Grid, Paper, TextField, Typography } from "@mui/material";
import Autocomplete from "@mui/material/Autocomplete";
import { Box } from "@mui/system";
import React, { useState, useContext, useEffect } from "react";
import FileBase from 'react-file-base64';
import { useDispatch } from "react-redux";
import { addMovie, api } from "../../api";
import '@fontsource/roboto/500.css';
import IconButton from "@mui/material/IconButton";
import { ADD_MOVIE } from "../../constants/actionTypes";
import NavBar from "../NavBar/NavBar";
import { Navigate, useNavigate } from "react-router-dom";

const initialState = {
    title: '',
    description: '',
    moviePicture: '',
    genresIds: []};

const AddMovie = () => {
    //const {book, dispatch} = useContext(BooksContext);
    const [formData, setFormData] = useState(initialState);
    const dispatch = useDispatch();
    const [genres, setGenres] = useState([]);
    const [genresId, setGenresId] = useState([]);
    const [selected, setSelected] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        api.get('Genres')
        .then(response => {
            setGenres(response.data);
            console.log(response.data);
        })
        .catch(function (error) {
            console.log(error);
        })
    }, []);

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
        console.log(e.target.value);
        console.log(formData);
    }

    const sendNewMovie = () => {
        const movieInfo = {
            title: formData.title,
            description: formData.description,
            moviePicture: formData.moviePicture,
            genresIds: genresId
        }
        console.log(movieInfo);
        //console.log(genresId);
        //dispatch(addMovie(movieInfo));
        api.post('Movies', movieInfo)
          .then(function (response) {
            dispatch({type: ADD_MOVIE, payload: response.data });
            console.log(response.data);
            navigate(`/movies/${response.data.id}`);
          })
          .catch(function (error) {
            console.log(error);
          });
    }


    return(
        <>
        <NavBar />
        {
            genres &&
        
        <Grid container
        spacing={0}
        direction="column"
        alignItems="center"
        justifyContent="center"
        style={{ minHeight: '100vh' }}>
            <Grid item xs={12}>
                <Paper style={{width: '400px', padding: '20px'}} elevation={5}>
                    <Grid container spacing={2} alignItems="center">
                        <Grid item xs={12} align="center">
                            <Typography variant="h5">Add a movie</Typography>
                        </Grid>
                        <Grid item xs={12}>
                            <div>
                                <Typography variant="subtitle2">Choose book cover</Typography>
                                <FileBase type="file" multiple={false} onDone={({ base64 }) => setFormData({ ...formData, moviePicture: base64 })} />
                            </div>
                        </Grid>
                        <Grid item xs={12}>
                            <TextField name="title" label="Title" fullWidth variant="standard" onChange={handleChange}/>
                        </Grid>
                        <Grid item xs={12}>
                        <Autocomplete
                        disablePortal
                        id="combo-box-demo"
                        options={genres}
                        sx={{ width: 200 }}
                        getOptionLabel={(option) => option.genreName}
                        onChange={(event, newValue) => {var joined = genresId.concat(newValue.id); setGenresId(joined); var joinedString = selected.concat(newValue.genreName+" "); setSelected(joinedString)}}
                        renderOption={(props, option) => (
                            <Box component="li" sx={{ '& > img': { mr: 2, flexShrink: 0 } }} {...props}>
                                {option.genreName}
                            </Box>
                        )} 
                        renderInput={(params) => 
                            <TextField
                            {...params}
                            label="Choose a category"
                            inputProps={{
                                ...params.inputProps,
                                autoComplete: 'new-password', // disable autocomplete and autofill
                            }}
                            />
                        }
                        />
                        <Typography variant="body2">{selected}</Typography>
                        </Grid>
                        <Grid item xs={12}>
                            <TextField name="description" multiline minRows={5} label="Description" fullWidth variant="standard" onChange={handleChange}/>
                        </Grid>
                        <Grid item xs={12} align="center">
                            <Button variant="contained" onClick={sendNewMovie}>Submit</Button>
                        </Grid>
                    </Grid>
                </Paper>
            </Grid>
        </Grid>
}
        </>
    );
}

export default AddMovie;
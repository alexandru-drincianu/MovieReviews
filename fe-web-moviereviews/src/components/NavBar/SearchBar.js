import React, { useEffect, useState } from 'react';
import { Autocomplete, Box, TextField } from "@mui/material";
import { useNavigate } from "react-router-dom";
import { api } from '../../api/index';

const SearchBar = () => {
    const [movies, setMovies] = useState([]);
    const navigate = useNavigate();

    useEffect( () => {
        api.get('Movies/all')
        .then(response => {
            setMovies(response.data);
        })
        .catch(err => {
            console.log(err);
        })
    }, []);

    return(
        <Autocomplete
        freeSolo
        id="free-solo-2-demo"
        disableClearable
        options={movies}
        getOptionLabel={(option) => `${option.title}`}
        onChange={(event, newValue) => {navigate(`/movies/${newValue.id}`); window.location.reload()}}
        renderOption={(props, option) => (
            <Box component="li" sx={{ '& > img': { mr: 2, flexShrink: 0 } }} {...props}>
              <img
                loading="lazy"
                width="20"
                src={option.moviePicture}
                alt=""
              />
              {option.title} 
            </Box>
          )}

        renderInput={(params) => (
          <TextField
            variant="standard"
            style={{radius: '15px', width: '350px', border: 'none'}}
            {...params}
            label="Search movie"
            InputProps={{
              ...params.InputProps,
              type: 'search',
            }}
          />
        )}
      />
    );
}

export default SearchBar;
import { AppBar, Button, Container, Grid, IconButton, Toolbar, Typography } from "@mui/material";
import { Box } from "@mui/system";
import React from "react";
import { NavLink, useNavigate } from "react-router-dom";
import logo from '../../images/film-reel.png';
import '@fontsource/roboto/400.css';

const NavBar = () => {
    const pathname = window.location.pathname;
    console.log(pathname);
    const navigate = useNavigate();
    
    const handleAddMovie = () => {
        navigate('/addmovie');
    }

    return(
    <>
        <AppBar position="static" style={{background: '#AC9CC1', boxShadow: "none"}}>
            <Container maxWidth="xl">
                <Toolbar disableGutters>
                    <Grid container>
                        <Grid item xs={6}>
                        <NavLink to="/movies" style={{color: "white", textDecoration: "none"}}>
                            <Box sx={{display: 'inline-flex'}}>
                            <IconButton size="large"
                            edge="start"
                            color="inherit"
                            aria-label="menu"
                            sx={{ mr: 2 }}
                            height={50}>
                                <img src={logo} alt="" height={50} />
                            </IconButton>
                            <Typography variant='h5' style={{color: 'black', marginLeft: '80', paddingTop: '25px'}}>Movies</Typography>
                            </Box>
                            </NavLink>
                        </Grid>
                    </Grid>
                    <Button variant="text" style={pathname === '/addmovie' ? {fontWeight: 700, color: 'black' , width: 350, textDecoration: 'none'} : { color: 'black', width: 350, textDecoration: 'none'}} onClick={handleAddMovie}>Add a movie</Button>
                    <Button variant="text" style={pathname === '/search' ? {fontWeight: 700, color: 'black' , width: 350, textDecoration: 'none'} : { color: 'black', width: 350, textDecoration: 'none'}}>Search Your Movies</Button>
                    <Button variant="text" style={pathname === '/search' ? {fontWeight: 700, color: 'black' , width: 350, textDecoration: 'none'} : { color: 'black', width: 350, textDecoration: 'none'}}>Log out</Button>
                </Toolbar>
            </Container>
        </AppBar>
    </>
    );
}

export default NavBar;
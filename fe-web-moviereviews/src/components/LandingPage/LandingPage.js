import { Button } from "@mui/material";
import React from "react";
import './style.css';
import logo from '../../images/film-reel.png';
import bookshelf from '../../images/3d-glasses.png';
import { useNavigate } from "react-router-dom";

export default function LandingPage() {
    const navigate = useNavigate();

    const goToSingIn = () => {
        navigate('/signin');
    }

    const goToSignUp = () => {
        navigate('/signup');
    }

    return (
        <div class="eclipse">
            <div>
                <div class="name_container">
                    <div class="logo_container">
                        <img class="logo" src={logo} alt=""/>
                    </div>  
        
                    <div class="logo_name">Movies</div>
                </div>
            </div>
            <div class="grid">
                <div class="quotes">
                    <div class="par">
                    You saw a movie, tell us your opinion
                    </div>
                    <div class="subpar">
                    We are the movies, and the movies are us<br />
                                            -David Ansen-
                    </div>
                    <div class="grid">
                        
                        <Button variant="contained" className="register" style={{backgroundColor: "#61442E"}} onClick={goToSignUp}>Register</Button>
                        <Button variant="contained" className="login" style={{backgroundColor: "#C7936C"}} onClick={goToSingIn}>Login</Button>
                    </div>
                </div>
                <div class="bookshelf_container">
                    <img class="bookshelf" src={bookshelf} alt=""/>
                </div>
            </div>
        </div>
    );
}
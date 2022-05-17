import { Grid, TextField, Button, Paper, Typography } from "@mui/material";
import React, {useContext, useState} from "react";
import library from '../../images/cinema.jpg';
import { useNavigate } from 'react-router-dom';
import { useDispatch } from "react-redux";
import { signin } from "../../actions/auth";

const initialState = {email: '', password: ''};

const SignIn = () => {
    //const {user, dispatch} = useContext(AuthContext);
    const navigate = useNavigate();
    const [formData, setFormData] = useState(initialState);
    const dispatch = useDispatch();

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
        console.log(e.target.value);
        console.log(formData);
    }

    const sendSignInData = (e) => {
        const userInfo = {
            email: formData.email,
            password: formData.password,
        }
        e.preventDefault();
        dispatch(signin(userInfo, navigate));
    }

    const goToSignUp = () => {
        navigate('/signup');
    }

    return (
            <Grid container style={{
                minWidth: "100%",
                height: "100vh",
              }}>
                <Grid item xs={0} sm={6} md={6} lg={6} xl={6}>
                    <img src={library} alt="" style={{backgroundSize: 'contain', backgroundRepeat: 'no-repeat', width:'100%', height: '100%'}}/>
                </Grid>

                <Grid item xs={12} sm={6} md={6} lg={6} xl={6} display="flex" justifyContent="center" alignItems="center" minHeight="100vh">
                    <Paper class="paper" style={{width: '350px'}}>
                        <Grid container spacing={2}>
                            <Grid item xs={12}>
                                <Typography variant="subtitle1">Welcome back</Typography>
                            </Grid>
                            <Grid item xs={12}>
                                <Typography variant="h5">Login to your account</Typography>
                            </Grid>
                            <Grid item xs={12}>
                                <TextField name="email" type="text" label="Email" variant="standard" fullWidth onChange={handleChange}/>
                            </Grid>
                            <Grid item xs={12}>
                                <TextField name="password" type="password" label="Password" variant="standard" fullWidth onChange={handleChange}/>
                            </Grid>
                            <Grid item justifyContent="center" alignItems="center">
                                <Button variant="contained" style={{backgroundColor: "#E1C4AE"}} onClick={sendSignInData}>Login</Button>
                            </Grid>
                            <Grid item xs={12}>
                                <Button variant="text" size="small" onClick={goToSignUp}>Don't have an account? Sign Up</Button>
                            </Grid>
                        </Grid>
                    </Paper>
                </Grid>
            </Grid>
    );
}

export default SignIn;
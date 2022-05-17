import { Grid, TextField, Button, Paper, Typography } from "@mui/material";
import React, {useContext, useState} from "react";
import library from '../../images/cinema.jpg';
import { useNavigate } from "react-router-dom";
import { useDispatch } from "react-redux";
import { signup } from "../../actions/auth";

const initialState = {name: '', email: '', password: '', confirmPassword: ''};

export default function SignUp() {
    //const {user, dispatch} = useContext(AuthContext);
    const navigate = useNavigate();
    const [formData, setFormData] = useState(initialState);
    const dispatch = useDispatch();

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
        console.log(e.target.value);
        console.log(formData);
    }

    const sendSignUpData = (e) => {
        if (formData.password !== formData.confirmPassword){
            console.log("Password don't match.");
            return;
        }
        const userInfo = {
            name: formData.name,
            email: formData.email,
            password: formData.password,
        }
        /*api.post('/auth/register', userInfo)
          .then(function (response) {
            dispatch({type: 'SET_USER_INFO', payload: response.data })
          })
          .catch(function (error) {
            console.log(error);
          });*/
          e.preventDefault();
          dispatch(signup(userInfo, navigate));
    }

    const goToSignIn = () => {
        navigate('/signin');
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
                                <Typography variant="subtitle1">Welcome to Bookish</Typography>
                            </Grid>
                            <Grid item xs={12}>
                                <Typography variant="h5">Create your account</Typography>
                            </Grid>
                            <Grid item xs={12}>
                                <TextField name="email" type="text" label="Email" variant="standard" fullWidth onChange={handleChange}/>
                            </Grid>
                            <Grid item xs={12}>
                                <TextField name="name" type="text" label="Name" variant="standard" fullWidth onChange={handleChange}/>
                            </Grid>
                            <Grid item xs={12}>
                                <TextField name="password" type="password" label="Password" variant="standard" fullWidth onChange={handleChange}/>
                            </Grid>
                            <Grid item xs={12}>
                                <TextField name="confirmPassword" type="password" label="Confirm Password" variant="standard" fullWidth onChange={handleChange}/>
                            </Grid>
                            <Grid item xs={12}>
                                <Button variant="contained" style={{backgroundColor: "#E1C4AE"}} onClick={sendSignUpData}>Register</Button>
                            </Grid>
                            <Grid item xs={12}>
                                <Button variant="text" size="small" onClick={goToSignIn}>Already have an account?Sign In</Button>
                            </Grid>
                        </Grid>
                    </Paper>
                </Grid>
            </Grid>
    );
}
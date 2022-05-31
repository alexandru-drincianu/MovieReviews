import { Button, Grid, Paper, TextField, Typography } from "@mui/material";
import React, { useState } from "react";
import { api } from "../../api";
import NavBar from "../NavBar/NavBar";
import FileBase from 'react-file-base64';

const AddActor = () => {
    const [actor, setActor] = useState({name: '', image: ''});

    const handleSubmit = () => {
        api.post('Actors', actor)
        .then(response => {
            window.location.reload();
        })
        .catch(err => {
            console.log(err);
        })
    }

    return(
        <>
        <NavBar />
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
                            <Typography variant="h5">Add an actor</Typography>
                        </Grid>
                        <Grid item xs={12}>
                            <div>
                                <Typography variant="subtitle2">Choose image</Typography>
                                <FileBase type="file" multiple={false} onDone={({ base64 }) => setActor({ ...actor, image: base64 })} />
                            </div>
                        </Grid>
                        <Grid item xs={12}>
                            <TextField label='Name' name='name' onChange={(e) => setActor({ ...actor, [e.target.name]: e.target.value })}></TextField>
                        </Grid>
                        <Grid item xs={12}>
                            <Button onClick={handleSubmit} >Submit</Button>
                        </Grid>
                    </Grid>
                </Paper>
            </Grid>
        </Grid>
        </>
    );
}

export default AddActor;
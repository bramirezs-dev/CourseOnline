import { Button, Grid, TextField, Typography } from '@mui/material';
import { Container } from '@mui/system';
import React from 'react';
import style from '../tool/Style';
const UserProfile = () => {
    return (
        <Container component='main' maxWidth="md" >
            <div style={style.paper}>
                <Typography component='h1' variant='h5'>
                    Perfil Usuario
                </Typography>

                <Grid container spacing={2}>
                    <Grid item xs={12} md={6}>
                        <TextField name='name' variant='outlined' fullWidth label='Ingrese nombre'/>
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <TextField name='lastname' variant='outlined' fullWidth label='Ingrese apellidos'/>
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <TextField name='email' variant='outlined' fullWidth label='Ingrese email'/>
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <TextField name='password' variant='outlined' fullWidth label='Ingrese password'/>
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <TextField name='confirmpassword' variant='outlined' fullWidth label='Confirmar password'/>
                    </Grid>
                </Grid>
                <Grid container justifyContent='center'>
                    <Grid item xs={12} md={6}>
                        <Button type='submit' fullWidth variant='contained' size='large' color='primary' style={style.submit}>
                            Guardar Datos
                        </Button>
                    </Grid>
                </Grid>
            </div>
        </Container>
    );
};

export default UserProfile;
import { Button, Grid, TextField, Typography } from '@mui/material';
import { Container } from '@mui/system';
import React, { useEffect, useState } from 'react';

import { getCurrentUser, updateUser } from '../../actions/userAction';
import IUser from '../../interfaz/IUser';
import IUserProfile from '../../interfaz/IUserProfile';
import style from '../tool/Style';

const UserProfile = () => {
    const initialUser : IUserProfile = {
        nameComplete:"",
        email: "",
        password: "",
        confirmpassword: "",
        userName: "",
    } 

    useEffect(() => {
      getCurrentUser().then((response:any) => {
        const { data } = response;
        setUser(data);
      });
    
    }, [])
    

    const [user, setUser] = useState(initialUser);

    const handlerUserData = (e: React.ChangeEvent<HTMLInputElement>)=>{
        const { name, value } = e.target;
        setUser((beforeData) => ({
            ...beforeData,
            [name]: value,
          }));
    }

    const handlerSaveUser = (e: React.MouseEvent<HTMLButtonElement>) => {
        e.preventDefault();
        updateUser(user).then((response:any) => {
            const { data } = response;
            console.log('existoso', response)
            window.localStorage.setItem("token",data?.token)
        });
    }

    return (
        <Container component='main' maxWidth="md" >
            <div style={style.paper}>
                <Typography component='h1' variant='h5'>
                    Perfil Usuario
                </Typography>

                <Grid container spacing={2}>
                    <Grid item xs={12} md={12}>
                        <TextField name='nameComplete' value={user.nameComplete} onChange={handlerUserData} variant='outlined' fullWidth label='Ingrese nombre'/>
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <TextField name='email' value={user.email} onChange={handlerUserData} variant='outlined' fullWidth label='Ingrese email'/>
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <TextField name='username' value={user.userName} onChange={handlerUserData} variant='outlined' fullWidth label='Ingrese username'/>
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <TextField name='password' value={user.password} onChange={handlerUserData} variant='outlined' fullWidth label='Ingrese password'/>
                    </Grid>
                    <Grid item xs={12} md={6}>
                        <TextField name='confirmpassword' value={user.confirmpassword} onChange={handlerUserData} variant='outlined' fullWidth label='Confirmar password'/>
                    </Grid>
                </Grid>
                <Grid container justifyContent='center'>
                    <Grid item xs={12} md={6}>
                        <Button type='submit' onClick={handlerSaveUser} fullWidth variant='contained' size='large' color='primary' style={style.submit}>
                            Guardar Datos
                        </Button>
                    </Grid>
                </Grid>
            </div>
        </Container>
    );
};

export default UserProfile;
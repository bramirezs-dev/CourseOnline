import { LockOutlined } from '@mui/icons-material';
import { Avatar, Button, TextField, Typography } from '@mui/material';
import { Container } from '@mui/system';
import React from 'react';
import style from '../tool/Style';
const Login = () => {
    return (
        <Container maxWidth="xs">
            <div style={style.paper}>
                <Avatar style={style.avatar}>
                    <LockOutlined style={style.icon}/>
                </Avatar>
                <Typography component='h1' variant='h5'>
                    Login
                </Typography>
                <form>
                    <TextField variant='outlined' name='username' fullWidth label='Ingrese user' margin='normal'/>
                    <TextField variant='outlined' name='password' type='submit' fullWidth label='Ingrese password' margin='normal'/>
                    <Button type='submit' fullWidth variant='contained' color='primary' style={style.submit}>
                        Enviar
                    </Button>
                </form>
            </div>
        </Container>
    );
};

export default Login;
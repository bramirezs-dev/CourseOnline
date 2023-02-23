import { LockOutlined } from '@mui/icons-material';
import { Avatar, Button, TextField, Typography } from '@mui/material';
import { Container } from '@mui/system';
import React, { useState } from 'react';
import { loginUser } from '../../actions/userAction';
import ILogin from '../../interfaz/ILogin';
import style from '../tool/Style';

const initialLogin :ILogin ={
    email : '',
    password : ''
}

const Login = () => {
    
    const [login, setLogin] = useState(initialLogin)
    
    const handlerChangeData = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;
        setLogin((beforeData) => ({
          ...beforeData,
          [name]: value,
        }));
      };
    
      const handlerLogin = (e: React.MouseEvent<HTMLButtonElement>) => {
        e.preventDefault();
        loginUser(login).then(
            (response : any)  => {
                const { data } = response;
                console.log('existoso', response)
                window.localStorage.setItem("token", data)
            }
        )
      };

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
                    <TextField variant='outlined' name='email' value={login.email} onChange={handlerChangeData} fullWidth label='Ingrese email' margin='normal'/>
                    <TextField variant='outlined' name='password' value={login.password} onChange={handlerChangeData} type='password' fullWidth label='Ingrese password' margin='normal'/>
                    <Button type='submit' onClick={handlerLogin} fullWidth variant='contained' color='primary' style={style.submit}>
                        Enviar
                    </Button>
                </form>
            </div>
        </Container>
    );
};

export default Login;
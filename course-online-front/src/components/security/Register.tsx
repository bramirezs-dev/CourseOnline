import { Button, Container, Grid, TextField, Typography } from "@mui/material";
import { AxiosResponse } from "axios";
import React, { useState } from "react";

import { registerUser } from "../../actions/userAction";
import IUser from "../../interfaz/IUser";
import style from "../tool/Style";

/**xs for mobile, md for tables, sm for desktops */

const RegisterUser = () => {
    
    const initialUser : IUser = {
        name: "",
        lastname: "",
        email: "",
        password: "",
        confirmpassword: "",
        username: "",
    } 
    const [user, setUser] = useState(initialUser);

  const handleDataUser = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setUser((beforeData) => ({
      ...beforeData,
      [name]: value,
    }));
  };

  const handlerSubmit = (e: React.MouseEvent<HTMLButtonElement>) => {
    e.preventDefault();
    registerUser(user).then(
        (response : any)  => {
            
            console.log(response);
            //window.localStorage.setItem("token", <String>response.data.token)
        }
    )
  };

  return (
    <>
      <Typography component="h1" variant="h5" align="center">
        Register of User
      </Typography>
      <Container component="main" maxWidth="md">
        <div style={style.paper}>
          <form style={style.form}>
            <Grid container spacing={2}>
              <Grid item xs={12} md={6}>
                <TextField
                  name="name"
                  value={user.name}
                  onChange={handleDataUser}
                  variant="outlined"
                  fullWidth
                  label="Ingreses su nombre"
                />
              </Grid>
              <Grid item xs={12} md={6}>
                <TextField
                  name="lastname"
                  value={user.lastname}
                  onChange={handleDataUser}
                  variant="outlined"
                  fullWidth
                  label="Ingrese sus apellidos"
                />
              </Grid>
              <Grid item xs={12} md={6}>
                <TextField
                  name="email"
                  value={user.email}
                  onChange={handleDataUser}
                  variant="outlined"
                  fullWidth
                  label="Ingrese sus email"
                />
              </Grid>
              <Grid item xs={12} md={6}>
                <TextField
                  name="username"
                  value={user.username}
                  onChange={handleDataUser}
                  variant="outlined"
                  fullWidth
                  label="Ingrese sus usuario"
                />
              </Grid>
              <Grid item xs={12} md={6}>
                <TextField
                  name="password"
                  value={user.password}
                  onChange={handleDataUser}
                  type="password"
                  variant="outlined"
                  fullWidth
                  label="Ingrese su contraseña"
                />
              </Grid>
              <Grid item xs={12} md={6}>
                <TextField
                  name="confirmpassword"
                  value={user.confirmpassword}
                  onChange={handleDataUser}
                  type="password"
                  variant="outlined"
                  fullWidth
                  label="Confirme su contraseña"
                />
              </Grid>
            </Grid>
            <Grid container justifyContent="center">
              <Grid item xs={12} md={6}>
                <Button
                  type="submit"
                  fullWidth
                  variant="contained"
                  color="primary"
                  size="large"
                  style={style.submit}
                  onClick={handlerSubmit}
                >
                  Enviar
                </Button>
              </Grid>
            </Grid>
          </form>
        </div>
      </Container>
    </>
  );
};

export default RegisterUser;

import React from 'react';
import  ThemeProvider from '@mui/material/styles/ThemeProvider'
import {theme} from './theme/theme'
import RegisterUser from './components/security/Register';
import Login from './components/security/Login';
import UserProfile from './components/security/UserProfile';

function App() {
  return (
    <ThemeProvider theme={theme}>
      <RegisterUser></RegisterUser>
    </ThemeProvider>
  );
}

export default App;

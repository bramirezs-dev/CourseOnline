import { AxiosResponse } from "axios";
import ILogin from "../interfaz/ILogin";
import IUser from "../interfaz/IUser";
import IUserProfile from "../interfaz/IUserProfile";
import genericRequest from "../services/httpClient";

export const registerUser = (user : IUser) => {
    return new Promise ((resolve, eject) => {
        genericRequest.post('/Login/register',user).then(
            response  =>  {
                resolve(response);
            }
        )
    });
}

export const getCurrentUser = () => {
    return new Promise ((resolve, eject) => {
        genericRequest.get('/Login').then(
            response  =>  {
                resolve(response);
            }
        )
    });
}

export const updateUser = (updateUser: IUserProfile) => {
    return new Promise ((resolve, eject) => {
        genericRequest.put('/Login',updateUser).then(
            response  =>  {
                resolve(response);
            }
        )
    });
}


export const loginUser = (user: ILogin) => {
    return new Promise ((resolve, eject) => {
        genericRequest.post('/Login',user).then(
            response  =>  {
                resolve(response);
            }
        )
    });
}

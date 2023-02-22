import { AxiosResponse } from "axios";
import IUser from "../interfaz/IUser";
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
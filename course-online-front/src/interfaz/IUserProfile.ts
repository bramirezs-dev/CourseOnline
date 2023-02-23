import IUser from "./IUser";

interface IUserProfile extends Omit<IUser,'name' | 'lastname'> {
    nameComplete:string
}

 export default IUserProfile;
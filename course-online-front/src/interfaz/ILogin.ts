import IUser from "./IUser";

interface ILogin
  extends Omit<IUser, "name" | "lastname" | "confirmpassword" | "userName"> {}

export default ILogin;

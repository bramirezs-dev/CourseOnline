import axios from "axios";

axios.defaults.baseURL = "https://bramirezs.bsite.net/api/v1";
axios.interceptors.request.use(
  (config : any) => {
    const token = window.localStorage.getItem("token");
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
      return config;
    }
  },
  (error) => {
    return Promise.reject(error);
  }
);
const genericRequest = {
  get: (url: string) => axios.get(url),
  post: (url: string, body: Object) => axios.post(url, body),
  put: (url: string, body: Object) => axios.put(url, body),
  delete: (url: string) => axios.delete(url),
};

export default genericRequest;

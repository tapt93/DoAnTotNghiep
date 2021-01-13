import axios from 'axios'
const queryString = require('query-string');

const baseURL = process.env.REACT_APP_API_URL;
const baseAutURL = process.env.REACT_APP_AUTH_URL;

const instance = axios.create();
instance.interceptors.response.use(response => {
  return response.data;
}, error => {
  if (error.response && error.response.status === 401) {
    localStorage.removeItem("plw-current-user");
    window.location.reload();
  }
  return Promise.reject(error)
})

instance.interceptors.request.use(request => {
  let token = null
  if (localStorage.getItem(process.env.REACT_APP_Token_Name)) {
    token = JSON.parse(localStorage.getItem(process.env.REACT_APP_Token_Name));
  }
  if (token) {
    request.headers['Authorization'] = `Bearer ${token}`;

  }
  return request;
}, error => {
  console.error(error);
  return Promise.reject(error)
})


export const AuthenApi = {
  login: async (model) => {
    return await instance.post(baseAutURL, {
      username: model.username,
      password: model.password
    })
  }
}

export default AuthenApi

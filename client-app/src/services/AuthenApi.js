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
  let currentUser = null
  if (localStorage.getItem('plw-current-user')) {
    currentUser = JSON.parse(localStorage.getItem('plw-current-user'));
  }
  if (currentUser && currentUser.token) {
    request.headers['Authorization'] = `Bearer ${currentUser.token}`;

  }
  return request;
}, error => {
  console.error(error);
  return Promise.reject(error)
})


export const AuthenApi = {
  login: async (model) => {
    return await instance.post(baseAutURL, queryString.stringify({
      username: model.username,
      password: model.password,
      client_id: 'ro.client',
      client_secret: 'secret',
      grant_type: "password"
    }), {
      headers: {
        "Content-Type": "application/x-www-form-urlencoded"
      }
    })
  }
}

export default AuthenApi

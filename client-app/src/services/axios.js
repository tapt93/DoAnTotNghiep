import axios from 'axios';

const instance = axios.create({
  baseURL: process.env.REACT_APP_API_URL
});

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

instance.interceptors.response.use(response => {
  return response.data;
}, error => {
  if (error.response && error.response.status === 401) {
    localStorage.removeItem(process.env.REACT_APP_Token_Name);
    window.location.reload();
  }
  return Promise.reject(error)
})

export default instance;

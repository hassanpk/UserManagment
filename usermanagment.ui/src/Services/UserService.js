import axios from 'axios';
const { REACT_APP_API_ENDPOINT } = process.env;

const api = axios.create({
  baseURL:  REACT_APP_API_ENDPOINT
});


export const getUsers = () => api.get('/User');
export const getUser = (id) => api.get(`/User/${id}`);
export const createUser = (userDetails) => api.post('/User', userDetails, {
  headers: { 'Content-Type': 'multipart/form-data' }
});
export const updateUser = (id, userDetails) => api.put(`/User/${id}`, userDetails, {
  headers: { 'Content-Type': 'multipart/form-data' }
});
export const deleteUser = (id) => api.delete(`/User/${id}`);



import BaseApi from './BaseApi';

const UserApi = {
  list: async filter => {
    try {
      let result = await BaseApi.execute_post('/api/User/list', filter);
      return result;
    } catch (error) {
      console.error(error);
    }
  },

  delete: async id => {
    try {
      let result = await BaseApi.execute_delete('/api/User/delete?id=' + id);
      return result;
    } catch (error) {
      console.log(error);
    }
  },

  update: async item => {
    try {
      let result = await BaseApi.execute_post('/api/User/UpdateUser', item);
      return result;
    } catch (error) {
      console.log(error);
    }
  },

  updateUserRole: async item => {
    try {
      let result = await BaseApi.execute_post('/api/User/UpdateUserRole', item);
      return result;
    } catch (error) {
      console.log(error);
    }
  },

  register: async item => {
    try {
      let result = await BaseApi.execute_post('/api/User/register', item);
      return result;
    } catch (error) {
      console.log(error);
    }
  },

  getCurrentUserInfo: async () => {
    try {
      let result = await BaseApi.execute_get('/api/User/GetCurrentUserInfo');
      return result;
    } catch (error) {
      console.log(error);
    }
  },

  checkEmailExist: async item => {
    try {
      let result = await BaseApi.execute_get('/api/User/checkEmailExist?email=' + item);
      return result;
    } catch (error) {
      console.log(error);
    }
  },

  changePassword: async item => {
    try {
      let result = await BaseApi.execute_post('/api/User/changePassword', item);
      return result;
    } catch (error) {
      console.log(error);
    }
  }
}

export default UserApi

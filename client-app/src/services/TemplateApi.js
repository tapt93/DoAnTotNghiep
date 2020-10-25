import BaseApi from './BaseApi';

const TemplateApi = {
  list: async filter => {
    try {
      let result = await BaseApi.execute_post('/api/Template/list', filter);
      return result;
    } catch (error) {
      console.error(error);
    }
  },

  add: async item => {
    try {
      let result = await BaseApi.execute_post('/api/Template/add', item);
      return result;
    } catch (error) {
      console.log(error);
    }
  },

  delete: async id => {
    try {
      let result = await BaseApi.execute_delete('/api/Template/delete?id=' + id);
      return result;
    } catch (error) {
      console.log(error);
    }
  },

  update: async item => {
    try {
      let result = await BaseApi.execute_post('/api/Template/UpdateTemplate', item);
      return result;
    } catch (error) {
      console.log(error);
    }
  },

  createTemplate: async item => {
    try {
      let result = await BaseApi.execute_post('/api/Template/CreateTemplate', item);
      return result;
    } catch (error) {
      console.log(error);
    }
  }
}

export default TemplateApi
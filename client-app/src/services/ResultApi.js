import BaseApi from './BaseApi';

const ResultApi = {
  list: async filter => {
    try {
      let result = await BaseApi.execute_post('/api/Result/list', filter);
      return result;
    } catch (error) {
      console.error(error);
    }
  },

  add: async item => {
    try {
      let result = await BaseApi.execute_post('/api/Result/add', item);
      return result;
    } catch (error) {
      console.log(error);
    }
  },

  delete: async id => {
    try {
      let result = await BaseApi.execute_delete('/api/Result/delete?id=' + id);
      return result;
    } catch (error) {
      console.log(error);
    }
  },

  update: async item => {
    try {
      let result = await BaseApi.execute_post('/api/Result/UpdateResult', item);
      return result;
    } catch (error) {
      console.log(error);
    }
  },
}

export default ResultApi
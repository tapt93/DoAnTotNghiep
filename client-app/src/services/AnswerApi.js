import BaseApi from './BaseApi';

const AnswerApi = {
  list: async filter => {
    try {
      let result = await BaseApi.execute_post('/api/Answer/list', filter);
      return result;
    } catch (error) {
      console.error(error);
    }
  },

  add: async item => {
    try {
      let result = await BaseApi.execute_post('/api/Answer/add', item);
      return result;
    } catch (error) {
      console.log(error);
    }
  },

  delete: async id => {
    try {
      let result = await BaseApi.execute_delete('/api/Answer/delete?id=' + id);
      return result;
    } catch (error) {
      console.log(error);
    }
  },

  update: async item => {
    try {
      let result = await BaseApi.execute_post('/api/Answer/UpdateAnswer', item);
      return result;
    } catch (error) {
      console.log(error);
    }
  },
}

export default AnswerApi
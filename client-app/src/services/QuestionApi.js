import BaseApi from './BaseApi';

const QuestionApi = {
  list: async filter => {
    try {
      let result = await BaseApi.execute_post('/api/Question/list', filter);
      return result;
    } catch (error) {
      console.error(error);
    }
  },

  add: async item => {
    try {
      let result = await BaseApi.execute_post('/api/Question/add', item);
      return result;
    } catch (error) {
      console.log(error);
    }
  },

  delete: async id => {
    try {
      let result = await BaseApi.execute_delete('/api/Question/delete?id=' + id);
      return result;
    } catch (error) {
      console.log(error);
    }
  },

  update: async item => {
    try {
      let result = await BaseApi.execute_post('/api/Question/UpdateQuestion', item);
      return result;
    } catch (error) {
      console.log(error);
    }
  },
}

export default QuestionApi
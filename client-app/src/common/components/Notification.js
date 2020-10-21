import { notification } from "antd";

export const Notification = {
  success: (message) => {
    return notification.success({
      message: message,
      description: ''
    });
  },

  error: (message) => {
    return notification.error({
      message: message,
      description: ''
    });
  },

  info: (message) => {
    return notification.info({
      message: message,
      description: ''
    });
  }
}

export default Notification
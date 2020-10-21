import LazyLoad from "./common/LazyLoad";

const NotFound = LazyLoad(() =>
  import('./common/Error/NotFound')
)

const AccessDenied = LazyLoad(() =>
  import('./common/Error/AccessDenied')
);

const Login = LazyLoad(() =>
  import('./modules/Login/Login')
);

const Register = LazyLoad(() =>
  import('./modules/Login/Register')
);

const ForgotPassword = LazyLoad(() =>
  import('./modules/Login/ForgotPassword')
);

const Home = LazyLoad(() =>
  import('./modules/Home/Home')
);

const routes = [
  { path: '/', exact: true, render: Home },
  { path: '/Login', exact: true, render: Login },
  { path: '/Register', exact: true, render: Register },
  { path: '/ForgotPassword', exact: true, render: ForgotPassword },
  { path: '/NotFound', exact: true, render: NotFound },
  { path: '/AccessDenied', exact: true, render: AccessDenied },
  { path: '*', exact: true, render: NotFound },
]
export default routes
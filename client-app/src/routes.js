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

const CreateTest = LazyLoad(() =>
  import('./modules/CreateTest/CreateTest')
);

const Test = LazyLoad(() =>
  import('./modules/DoTest/Test')
);

const TestList = LazyLoad(() =>
  import('./modules/TestList/TestList')
);

const MyResult = LazyLoad(() =>
  import('./modules/Report/ReportResult')
);

const AllReport = LazyLoad(() =>
  import('./modules/Report/ReportAllResult')
);


const routes = [
  { path: '/', exact: true, render: Home },
  { path: '/Login', exact: true, render: Login },
  { path: '/Register', exact: true, render: Register },
  { path: '/ForgotPassword', exact: true, render: ForgotPassword },
  { path: '/MyReport', exact: true, render: MyResult },
  { path: '/AllReport', exact: true, render: AllReport },
  { path: '/CreateTest', exact: true, render: CreateTest },
  { path: '/TestList', exact: true, render: TestList },
  { path: '/MyResult', exact: true, render: MyResult },
  { path: '/Test', exact: true, render: Test },
  { path: '/Test/:id', exact: true, render: Test },
  { path: '/NotFound', exact: true, render: NotFound },
  { path: '/AccessDenied', exact: true, render: AccessDenied },
  { path: '*', exact: true, render: NotFound },
]
export default routes
// routes config
import config from '~/config';

// componenets
import HeaderOnly from '~/layouts/HeaderOnly';

// pages
import HomePage from '~/pages/Home/HomePage';
import LearningPaths from '~/pages/Home/LearningPaths';
import Search from '~/pages/Home/Search';

// chia lam 2 const Public va Private

// public Routes: những routes công khaim ko đăng nhặp cũng xem được
// lấy routes từ App.js -> lặp qua mảng này -> mặc định lấy Home đầu tiên -> lý do lấy được Home
const publicRoutes = [
    { path: config.routes.home, component: HomePage },
    { path: config.routes.learningpaths, component: LearningPaths },
    { path: config.routes.search, component: Search },
];

// private Routes: routes yêu cầu đăng nhập
const privateRoutes = [];

// export nó ra mới có thể sử dụng
export { publicRoutes, privateRoutes };

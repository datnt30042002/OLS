// layouts
import HeaderOnly from '~/components/Layouts/HeaderOnly';

// pages
import Home from '~/pages/Home';
import LearningPaths from '~/pages/LearningPaths';
import Search from '~/pages/Search';

// chia lam 2 const Public va Private

// public Routes: những routes công khaim ko đăng nhặp cũng xem được
const publicRoutes = [
    { path: '/', component: Home },
    { path: '/learningpaths', component: LearningPaths },
    { path: '/search', component: Search },
];

// private Routes: routes yêu cầu đăng nhập
const privateRoutes = [];

// export nó ra mới có thể sử dụng
export { publicRoutes, privateRoutes };

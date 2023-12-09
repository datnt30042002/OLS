// routes config
import config from '~/config';

// componenets
import HeaderOnly from '~/layouts/HeaderOnly';

// pages
import HomePage from '~/pages/Home/HomePage';
import LearningPaths from '~/pages/Home/LearningPaths';
import LearningPathDetails from '~/pages/Home/LearningPathDetails';
import Search from '~/pages/Home/Search';
import UserProfile from '~/pages/Home/UserProfile';
import Settings from '~/pages/Home/Settings';
import CourseDetails from '~/pages/Home/CourseDetails';
import CourseInProgress from '~/pages/Home/CourseInProgress';
import Payment from '~/pages/Home/Payment';

// chia lam 2 const Public va Private

// public Routes: những routes công khaim ko đăng nhặp cũng xem được
// lấy routes từ App.js -> lặp qua mảng này -> mặc định lấy Home đầu tiên -> lý do lấy được Home
const publicRoutes = [
    { path: config.routes.home, component: HomePage },
    { path: config.routes.learningpaths, component: LearningPaths },
    { path: config.routes.learningpathdetails, component: LearningPathDetails },
    { path: config.routes.search, component: Search },
    { path: config.routes.coursedetails, component: CourseDetails },
    { path: config.routes.courseinprogress, component: CourseInProgress },
    // đang test -> sau test sẽ đưa nó về privateRoutes
    { path: config.routes.userprofile, component: UserProfile },
    { path: config.routes.settings, component: Settings },
    { path: config.routes.payment, component: Payment },
];

// private Routes: routes yêu cầu đăng nhập
const privateRoutes = [];

// export nó ra mới có thể sử dụng
export { publicRoutes, privateRoutes };

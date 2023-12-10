// Home
const routes = {
    // public routes
    home: '/',
    learningpaths: '/learning-paths',
    learningpathdetails: '/learning-path-details',
    search: '/search',
    coursedetails: '/course-details',
    courseinprogress: '/course-in-progress',
    userprofile: '/user-profile',
    settings: '/settings',
    payment: '/payment',
    login: '/login',
    register: '/register',
    forgotpassword: '/forgot-password',
    resetpassword: '/reset-password',

    // private routes
};

// Admin
const adminRoutes = {
    dashboard: '/',
    learningpathsmanager: '/learning-paths-manager',
    chaptermanager: '/chapter-manager',
    coursemanager: '/course-manager',
    usermanager: '/user-manager',
    blogmanager: '/blog-manager',
};

export { routes, adminRoutes };

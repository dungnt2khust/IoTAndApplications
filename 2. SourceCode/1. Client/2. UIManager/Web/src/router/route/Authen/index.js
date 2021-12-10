const routes = [
    {
        path: '/login',
        name: "Login",
        component: () => import ("@/views/Authen/Login/Login.vue"),
        meta: {
            Title: "i18nMenu.Authen.Login",
            permission: []
        }
    },
    {
        path: '/register',
        name: "Register",
        component: () => import ("@/views/Authen/Register/Register.vue"),
        meta: {
            Title: "i18nMenu.Authen.Register",
            permission: []
        }
    },
    {
        path: '/no-permission',
        name: "NoPermision",
        component: () => import ("@/views/Authen/NoPermission/NoPermission.vue"),
        meta: {
            Title: "i18nMenu.Authen.NoPermission",
            permission: []
        }
    },
    {
        path: '/not-found',
        name: "NotFound",
        component: () => import ("@/views/Authen/NotFound/NotFound.vue"),
        meta: {
            Title: "i18nMenu.Authen.NotFound",
            permission: []
        }
    }
];

export default routes;

import Vue from 'vue' 
import Router from 'vue-router'
import {AccountType} from "@/models/enum/AccountType.js"

// Router
import User from './route/User'
// import Admin from './route/Admin'
import Authen from './route/Authen'

Vue.use(Router)

export default new Router({
    mode: "history",
    routes: [
        {path: "/", redirect: localStorage.getItem("AccountType") == AccountType.ADMIN ? '/admin/dashboard' : '/home'},
        ...Authen,
        ...User,
        // ...Admin,
        {path: "/*", redirect: "/not-found"}
    ]
})
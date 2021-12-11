import {AccountType} from "@/models/enum/AccountType.js"

var routes = [
  {
    path: "/admin/dashboard",
    name: "AdminDashboard",
    component: () => import("@/views/Admin/Dashboard/Dashboard.vue"),
    meta: {
      Title: "i18nMenu.Admin.Dashboard",
      permission: [AccountType.ADMIN]
    }
  }, 
  {
    path: "/admin/push-notify",
    name: "AdminPushNotify",
    component: () => import("@/views/Admin/PushNotify/PushNotify.vue"),
    meta: {
      Title: "i18nMenu.Admin.PushNotify",
      permission: [AccountType.ADMIN]
    }
  }
]
export default routes

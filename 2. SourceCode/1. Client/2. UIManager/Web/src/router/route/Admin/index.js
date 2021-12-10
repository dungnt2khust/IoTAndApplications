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
    path: "/admin/order",
    name: "AdminOrder",
    component: () => import("@/views/Admin/Order/Order.vue"),
    meta: {
      Title: "i18nMenu.Order",
      permission: [AccountType.ADMIN]
    }
  },
  {
    path: "/admin/product",
    name: "AdminProduct",
    component: () => import("@/views/Admin/Product/Product.vue"),
    meta: {
      Title: "i18nMenu.Product",
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
  },
  {
    path: "/admin/cart",
    name: "AdminCart",
    component: () => import("@/views/Admin/Cart/Cart.vue"),
    meta: {
      Title: "i18nMenu.Admin.Cart",
      permission: [AccountType.ADMIN]
    }
  },
  {
    path: "/admin/cart",
    name: "AdminCart",
    component: () => import("@/views/Admin/Cart/Cart.vue"),
    meta: {
      Title: "i18nMenu.Admin.Cart",
      permission: [AccountType.ADMIN]
    }
  },
  {
    path: "/admin/product",
    name: "AdminProduct",
    component: () => import("@/views/Admin/Product/Product.vue"),
    meta: {
      Title: "i18nMenu.Admin.Product",
      permission: [AccountType.ADMIN]
    }
  } 
]
export default routes

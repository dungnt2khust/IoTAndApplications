import {AccountType} from "@/models/enum/AccountType.js"

const routes = [
  {
    path: "/home",
    name: "Home",
    component: () => import("@/views/User/HomePage/HomePage.vue"),
    meta: {
      Title: "i18nMenu.Home",
      permission: [AccountType.USER, AccountType.GUEST]
    }
  },
  {
    path: "/order",
    name: "Order",
    component: () => import("@/views/User/Order/Order.vue"),
    meta: {
      Title: "i18nMenu.Order",
      permission: [AccountType.USER, AccountType.GUEST]
    }
  },
  {
    path: "/cart",
    name: "Cart",
    component: () => import("@/views/User/Cart/Cart.vue"),
    meta: {
      Title: "i18nMenu.Cart",
      permission: [AccountType.USER, AccountType.GUEST]
    }
  },
  {
    path: "/messenger",
    name: "Messenger",
    component: () => import("@/views/User/Messenger/Messenger.vue"),
    meta: {
      Title: "i18nMenu.Messenger",
      permission: [AccountType.USER]
    }
  },
  {
    path: "/product-detail/:ProductID",
    name: "ProductDetail",
    component: () => import("@/views/User/Product/ProductDetail.vue"),
    meta: {
      Title: "i18nMenu.ProductDetail",
      permission: [AccountType.USER, AccountType.GUEST]
    }
  }, 
]
export default routes

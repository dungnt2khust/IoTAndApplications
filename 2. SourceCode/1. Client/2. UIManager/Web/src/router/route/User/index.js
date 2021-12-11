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
    path: "/about",
    name: "About",
    component: () => import("@/views/User/About/About.vue"),
    meta: {
      Title: "i18nMenu.About",
      permission: [AccountType.USER, AccountType.GUEST]
    }
  }
]
export default routes

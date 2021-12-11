<template lang="">
  <div class="main">
    <router-view />
  </div>
</template>
<script>
// Library
import { AccountType } from "@/models/enum/AccountType.js";
import { ConnectionState } from "@/models/enum/ConnectionState.js";
import AdminNavbar from "@/router/menu/Admin";
import UserNavbar from "@/router/menu/User";
import GuestNavbar from "@/router/menu/Guest";
import Authen from "@/router/route/Authen";

export default {
  name: "Main",
  methods: { 
    /**
     * Kiểm tra phiên đăng nhập
     * CreatedBy: NTDUNG (19/11/2021)
     */
    checkSession(from) {
      // Bật loading
      this.$loading.showLoading();
      if (this._getLocalStorageNotParse("Session")) {
        this.$account
          .checkSession()
          .then(res => {
            if (res.data.Data.AccountType) {
              // Gán thông tin tài khoản
              this._setLocalStorage("AccountData", res.data.Data.Data);
              this._setLocalStorage("AccountType", res.data.Data.AccountType);
              // Kết nối với serrver
              this.connectServer(from);
              // Đặt ngôn ngữ
              this.setLanguage(res.data.Data.Data.Language);
            } else {
              // Cập nhật navbar
              this.updateNavbar();
              // Gán thông tin tài khoản
              this._setLocalStorage("AccountData", {});
              this._setLocalStorage("AccountType", AccountType.UNKNOWN);
              // Chuyển hướng đến login
              this.$router.replace("/login");
              // Đặt ngôn ngữ
              this.setLanguage();
            }
          })
          .catch(err => {
            console.log(err);
            this.$loading.hideLoading();
          });
      } else {
        // Cập nhật navbar
        this.updateNavbar();
        // Gán thông tin tài khoản
        this._setLocalStorage("AccountData", {});
        this._setLocalStorage("AccountType", AccountType.UNKNOWN);
        // Chuyển hướng đến login
        this.$router.replace("/login");
        // Đặt ngôn ngữ
        this.setLanguage();
      }
    },
    /**
     * Kết nối với server
     * CreatedBy: NTDUNG (13/11/2021)
     */
    connectServer(from) {
      // Cập nhật navbar
      this.updateNavbar();
      // Kết nối với server
      this.$SignalR
        .start()
        .then(() => {
          // Kết nối thành công => Cập nhật ConnectionID
          this.$SignalR
            .invoke("UpdateConnectionID", {
              AccountID: this._getLocalStorageNotParse("AccountID"),
              AccountType: this._getLocalStorage("AccountType"),
              Data: this._getLocalStorage("AccountData")
            })
            .then(res => {
              if (
                this.$route.path != "/home" &&
                this.$route.path != "/admin/dashboard" &&
                from.name == "Login"
              ) {
                switch (this._getLocalStorage("AccountType")) {
                  case AccountType.ADMIN:
                    this.$router.push("/admin/dashboard");
                    break;
                  case AccountType.USER:
                    this.$router.push("/home");
                }
              }
            });
        })
        .catch(error => {
          // Kết nối thất bại
          console.log(error);
          // Tắt loading
          this.$loading.hideLoading();
        });
    },
    /**
     * Cập nhật navbar
     * CreatedBy: NTDUNG (23/11/2021)
     */
    updateNavbar() {
      switch (this._getLocalStorage("AccountType")) {
        case AccountType.GUEST:
          this.$store.state.navBar = GuestNavbar;
          this._removeLocalStorage("AccountID");
          break;
        case AccountType.ADMIN:
          this.$store.state.navBar = AdminNavbar;
          this._setLocalStorageNotStringify("AccountID", this._getLocalStorage("AccountData").AdminID);
          break;
        case AccountType.USER:
          this.$store.state.navBar = UserNavbar;
          this._setLocalStorageNotStringify("AccountID", this._getLocalStorage("AccountData").UserID);
          break;
      }

      // Check permission
      this.checkPermission();
    },
    /**
     * Kiểm tra quyền truy cập
     * CreatedBy: NTDUNG (08/12/2021)
     */
    checkPermission() {
      var accountType = this._getLocalStorage("AccountType");
      var permissions = this.$route.meta.permission;

      if (permissions.length !== 0) {
        this.$loading.showLoading("Đường dẫn này không dành cho tất cả người dùng. Vui lòng đợi chúng tôi xác thực.");

        // Kiểm tra loại tài khoản có nằm trong danh sách cấp quyền không
        var foundIdx = permissions.findIndex(permission => permission == accountType);
        if (foundIdx === -1) {
          this.$loading.hideLoading();
          this.$router.push("/no-permission");
        }
      } 
      // Tắt loading
      this.$loading.hideLoading();
    },
    /**
     * Đặt ngôn ngữ
     * CreatedBy: NTDUNG (30/11/2021)
     */
    setLanguage(language) {
      if (language) {
        this.$store.dispatch('setLang', language);
        this._setLocalStorage("Language", language);
      } else { 
        var languageStorage = this._getLocalStorage("Language");
        if (languageStorage) {  
          this.$store.dispatch('setLang', languageStorage);
        }
      }
    }
  },
  watch: {
    $route: {
      deep: true,
      handler(to, from) {
        // Đặt title
        document.title = this.$t(to.meta.Title);
        // Kiểm tra session
        if (
          this.$SignalR.connection.connectionState ==
            ConnectionState.DISCONNECTED &&
          to
        ) {
          var isAuthen = Authen.findIndex(route => route.path == to.path);
          if (
            isAuthen === -1 &&
            this._getLocalStorage("AccountType") !== AccountType.GUEST
          )
            this.checkSession(from);
          else this.updateNavbar();
        }
      }
    }
  }
};
</script>
<style lang="scss">
@import "@/assets/scss/layouts/main/main.scss";
</style>

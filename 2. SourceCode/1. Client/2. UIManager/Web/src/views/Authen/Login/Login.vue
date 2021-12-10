<template lang="">
  <div class="login">
    <ed-popup :title="$t('i18nMenu.Authen.Login')" :autoScroll="false">
      <template v-slot:header>
        <ed-logo txtColor="#fff" txtSize="24px" bgColor="#12007B" />
      </template>
      <template v-slot:content>
        <div class="fx-wrap p-t-20 p-b-20 gut-8">
          <ed-row class="fx-col">
            <ed-label :value="$t('i18nAccount.AccountName')" />
            <ed-input v-model="accountName" :value="accountName" />
          </ed-row>
          <ed-row class="fx-col">
            <ed-label :value="$t('i18nAccount.PassWord')" />
            <ed-input v-model="password" :value="password" type="password" />
          </ed-row>
          <ed-row class="m-t-20">
            <ed-button
              class="m-r-10"
              :label="$t('i18nMenu.Authen.Login')"
              txtPos="center"
              @click.native="login"
              :type="2"
            >
            </ed-button>
            <ed-button
              :label="$t('i18nMenu.Authen.Guest')"
              @click.native="guestMode"
              :type="0"
            >
            </ed-button>
          </ed-row>
          <ed-row class="m-t-20">
            <ed-col>
              <router-link to="register">
                {{ $t("i18nMenu.Authen.Register") }}
              </router-link>
            </ed-col>
          </ed-row>
        </div>
      </template>
    </ed-popup>
  </div>
</template>
<script>
// Library
import { AccountType } from "@/models/enum/AccountType.js";
import { ConnectionState } from "@/models/enum/ConnectionState.js";

export default {
  name: "Login",
  data() {
    return {
      showPassword: false,
      password: "",
      accountName: ""
    };
  },
  mounted() {
    // Đóng kết nối cũ nếu có
    if (this.$SignalR.connection.connectionState == ConnectionState.CONNECTED) {
      this.$SignalR.stop();
    }
    // Reset lại thông tin tài khoản
    this._setLocalStorage("AccountData", {});
    this._setLocalStorage("AccountType", AccountType.UNKNOWN);
    this._removeLocalStorage("Session");
  },
  methods: {
    /**
     * Đăng nhập
     * CreatedBy: NTDUNG (22/11/2021)
     */
    login() {
      this.$account
        .checkValidAccount({ Name: this.accountName, PassWord: this.password })
        .then(res => {
          if (res.data.Data.AccountType) {
            var data = res.data.Data.Data;
            delete data.PassWord;
            this._setLocalStorage("AccountData", data);
            this._setLocalStorage("AccountType", res.data.Data.AccountType);
            this._setLocalStorageNotStringify(
              "Session",
              res.data.Data.Data.SessionID
            );
            if (
              this.$route.path != "/home" &&
              this.$route.path != "/admin/dashboard"
            ) {
              var _accountType = this._getLocalStorage("AccountType");

              switch (_accountType) {
                case AccountType.ADMIN:
                  this.$router.push("/admin/dashboard");
                  break;
                case AccountType.USER:
                  this.$router.push("/home");
                  break;
              }
            }
          } else {
            alert("Tài khoản hoặc mật khẩu không đúng. Vui lòng thử lại.");
          }
        })
        .catch(res => {
          console.log(res);
        });
    },
    /**
     * Chế độ khách
     * CreatedBy: NTDUNG (30/11/2021)
     */
    guestMode() {
      this.$router.push("/home");
      this._setLocalStorage("AccountData", {});
      this._setLocalStorage("AccountType", AccountType.GUEST);
    },
    /**
     * Đăng kí
     * CreatedBy: NTDUNG (30/11/2021)
     */
    register() {
      this.$router.push("/register");
    }
  }
};
</script>
<style lang="scss">
.test {
  height: 50px;
  width: 100%;
  background: red;
}
</style>

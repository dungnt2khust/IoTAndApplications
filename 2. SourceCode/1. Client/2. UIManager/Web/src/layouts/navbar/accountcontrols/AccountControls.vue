<template lang="">
  <div class="accountcontrols pos-relative">
    <div class="accountcontrols__icon fx-center cur-p" v-on="tooltipListeners($t('i18nAccount.Account'))">
      <i class="fas fa-user-circle"></i>
      <ed-blur id="accountcontrols" v-model="showAccountControls" />
    </div>
    <BaseContentFrame
      v-if="showAccountControls"
      :zIndex="10"
      tabindex="0"
      class="blurable pos-absolute p-10"
      width="220px"
      top="100%"
      right="0"
      border="1px solid #ccc"
    >
      <template v-slot:content>
        <ed-row class="fx-center">
          <div class="accountcontrols__avatar">
            <i class="fas fa-user-circle"></i>
          </div>
        </ed-row>
        <ed-row class="fx-center">
          <div class="accountcontrols__name">
            <span>{{ _getLocalStorage("AccountData").DisplayName }}</span>
          </div>
        </ed-row>
        <ed-row>
          <ed-button
            class="m-t-20"
            :method="$store.Language == 'vi' ? () => changeLanguage('en') : () => changeLanguage('vi')"
            :label="
              $store.Language == 'vi' ? 'Chuyển sang tiếng anh' : 'Change to VN'
            "
          />
        </ed-row>
        <ed-row class="m-t-30 fx-center">
          <ed-button
            v-if="_getLocalStorageNotParse('AccountID')"
            :label="$t('i18nMenu.Authen.Logout')"
            @click.native="logout"
            :type="1"
          />
          <div v-else class="fx-row">
            <ed-button
              :label="$t('i18nMenu.Authen.Login')"
              @click.native="login"
              :type="2"
            />
            <ed-button
              :label="$t('i18nMenu.Authen.Register')"
              @click.native="register"
              :type="1"
            />
          </div>
        </ed-row>
      </template>
    </BaseContentFrame>
  </div>
</template>
<script>
// Plugins
import { AccountType } from "@/models/enum/AccountType.js";
import UserAPI from "@/api/components/User/UserAPI.js";
import AdminAPI from "@/api/components/Admin/AdminAPI.js";

export default {
  name: "Account",
  data() {
    return {
      showAccountControls: false
    };
  },
  methods: {
    /**
     * Đăng xuất
     * CreatedBy: NTDUNG (23/11/2021)
     */
    logout() {
      this.showAccountControls = false;
      this.$router.push("/login");
    },
    /**
     * Đăng nhập
     * CreatedBy: NTDUNG (30/11/2021)
     */
    login() {
      this.showAccountControls = false;
      this.$router.push("/login");
    },
    /**
     * Đăng kí
     * CreatedBy: NTDUNG (30/11/2021)
     */
    register() {
      this.showAccountControls = false;
      this.$router.push("/register");
    },
    changeLanguage(language) {
        this.$store.dispatch("setLang", language);
        this._setLocalStorage("Language", language);

        switch(this._getLocalStorage("AccountType")) {
          case AccountType.GUEST:
            break;
          case AccountType.ADMIN:
            AdminAPI.updateColumns(this._getLocalStorageNotParse("AccountID"), {Language: language})
              .then(res => {
                console.log(res)
                alert("Cập nhật ngôn ngữ thành công")
              })
              .catch(err => {
                console.log(err)
                alert("Cập nhật ngôn ngữ thất bại")
              })
            break;
          case AccountType.USER:
            UserAPI.updateColumns(this._getLocalStorageNotParse("AccountID"), {Language: language})
              .then(res => {
                console.log(res)
                alert("Cập nhật ngôn ngữ thành công")
              })
              .catch(err => {
                console.log(err)
                alert("Cập nhật ngôn ngữ thất bại")
              })
            break;
        }
    }
  }
};
</script>
<style lang="scss">
@import "@/assets/scss/layouts/navbar/accountcontrols/accountcontrols.scss";
</style>

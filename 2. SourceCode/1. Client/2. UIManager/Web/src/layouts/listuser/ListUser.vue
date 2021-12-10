<template lang="">
  <BaseContentFrame class="m-l-30" width="400px" height="100%" bgColor="#ccc">
    <template v-slot:content>
      <div class="list-user defaultScrollbar">
        <div
          v-for="(user, index) in listUsers"
          class="list-user__item fx-row aln-i-center jus-c-sbtn m-10 p-l-10"
          :key="index"
        >
          <div class="fx-row flex-1">
            <div class="list-user__code m-r-10">{{ user.Code }}</div>
            <div class="list-user__name">{{ user.DisplayName }}</div>
          </div>
          <div @click="checkUser(index)">
            <div v-if="user.checked" class="mi-check cur-p m-10"></div>
            <div v-else class="mi-uncheck cur-p m-10"></div>
          </div>
        </div>
        <div v-if="!listUsers.length">
          Không có user nào
        </div>
      </div>
    </template>
  </BaseContentFrame>
</template>
<script>
// Library
import UserAPI from "@/api/components/User/UserAPI.js";

export default {
  name: "ListUser",
  data() {
    return {
      listUsers: []
    };
  },
  mounted() {
    // Lấy dữ liệu toàn bộ user
    this.getListUsers();
  },
  methods: {
    /**
     * Lấy danh sách users
     * CreatedBy: NTDUNG (24/11/2021)
     */
    getListUsers() {
      UserAPI.getAll()
        .then(res => {
          var users = res.data.Data;
          users = users.filter(user => {
            return user.UserID != this._getLocalStorageNotParse("AccountID");
          });
          this.listUsers = users;
        })
        .catch(err => {
          console.log(err);
        });
    },
    /**
     * Chọn user
     * CreatedBy: NTDUNG (24/11/2021)
     */
    checkUser(index) {
      this.$set(
        this.listUsers[index],
        "checked",
        !this.listUsers[index].checked
      );
      this.$emit("input", this.listUsers);
    }
  }
};
</script>
<style lang="scss">
@import "@/assets/scss/layouts/listuser/listuser.scss";
</style>

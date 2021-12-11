<template lang="">
  <div class="notify pos-relative">
    <ed-icon
      :size="30"
      iconCls="mi-notify-white"
      :tooltip="$t('i18nNotify.Notify')"
    >
      <ed-blur id="notify" v-model="showNotify" :zIndex="1" />
      <ed-icon
        v-if="listNotify.length"
        style="z-index: 0"
        class="pos-absolute"
        bgColor="red"
        top="0"
        right="0"
        translate="10%, -10%"
        borderRad="8px"
        txtSize="12px"
        txtColor="#fff"
        :size="18"
      >
        {{ listNotify.length }}
      </ed-icon>
    </ed-icon>
    <BaseContentFrame
      v-if="showNotify"
      :zIndex="100"
      class="blurable pos-absolute p-10"
      tabindex="0"
      width="300px"
      height="400px"
      top="100%"
      right="0"
      boxShadow="0px 0px 15px 10px rgba(162,228,76, 0.5)"
    >
      <template v-slot:content>
        <div class="list-notify defaultScrollbar">
          <div
            v-for="(notify, index) in listNotify.slice().reverse()"
            class="list-notify__item m-r-10 p-l-10"
            :key="index"
          >
            <div class="list-notify__title m-r-10">{{ notify.Title }}</div>
            <div class="list-notify__content">{{ notify.Content }}</div>
          </div>
          <div v-if="!listNotify.length">
            Không có thông báo
          </div>
        </div>
      </template>
    </BaseContentFrame>
  </div>
</template>
<script>
export default {
  name: "NotifyControls",
  data() {
    return {
      showNotify: false,
      listNotify: []
    };
  },
  mounted() {
    // KhởI tạo hàm nhận thông báo
    this.receiveNotify();
  },
  methods: {
    /**
     * Nhận thông báo
     * CreatedBy: NTDUNG (24/11/2021)
     */
    receiveNotify() {
      this.$SignalR.on("ReceiveNotify", (user, notify) => {
        console.log(user, notify);
        this.listNotify.push({
          User: user,
          Title: notify.Title,
          Content: notify.Content
        });
      });
    }
  }
};
</script>
<style lang="scss">
@import "@/assets/scss/layouts/navbar/notify/notify.scss";
</style>

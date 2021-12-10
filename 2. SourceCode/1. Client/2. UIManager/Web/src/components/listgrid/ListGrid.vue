<template lang="">
  <div class="listgrid w-full">
    <div class="listgrid__header">
      {{ title }}
      <slot name="header"></slot>
    </div>
    <div class="listgrid__content">
      <ul class="listgrid__list">
        <li
          v-for="(item, index) in listData"
          @dblclick="dblClick(item[itemID])"
          class="listgrid__item fx-row jus-c-sbtn p-v-16 p-h-16"
          tabindex="0"
          :key="index"
        >
          <div class="fx-row">
            <div class="listgrid__checkbox p-r-10">
              <ed-check-box v-model="listCheck[index]" />
            </div>
            {{ query ? item[query] : item }}
          </div>

          <div class="listgrid__function fx-row">
            <div class="mi-edit scale-1.3 m-h-16" v-on="tooltipListeners('Chỉnh sửa')"></div>
            <div class="mi-delete scale-1.3" v-on="tooltipListeners('Xoá')"></div>
          </div>
        </li>
      </ul>
      <slot name="content"></slot>
    </div>
    <div class="listgrid__footer">
      <slot name="footer"></slot>
    </div>
  </div>
</template>
<script>
export default {
  name: "ListGrid",
  props: {
    title: {
      type: [Number, String],
      default: null
    },
    listData: {
      type: Array,
      default: () => []
    },
    query: {
      type: String,
      default: null
    },
    dblClick: {
      type: Function,
      default: () => {}
    },
    itemID: {
      type: String,
      default: null
    }
  },
  data() {
    return {
      listCheck: []
    };
  }
};
</script>
<style lang="scss">
@import "@/assets/scss/components/listgrid/listgrid.scss";
</style>

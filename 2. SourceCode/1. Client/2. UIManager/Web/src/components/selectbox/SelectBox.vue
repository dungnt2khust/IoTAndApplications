<template lang="">
  <div class="selectbox pos-relative" :style="customizeStyle(styleWrapperCustom)">
    <div
      @click="toggleSelectBox"
      class="selectbox__curr p-h-16 p-v-8"
      :style="{ width: width }"
    >
      {{ query ? options[value][query] : options[value] }}
    </div>
    <ul
      v-if="selectBoxState"
      class="selectbox__list pos-absolute m-t-4"
      :style="customizeStyle(styleCustom)"
    >
      <li
        v-for="(option, index) in options"
        @click="handleChooseOption(index)"
        class="selectbox__item p-h-16 p-v-8"
        :class="{'selected': index == value}"
        :key="index"
      >
        {{ query ? option[query] : option }}
      </li>
    </ul>
  </div>
</template>
<script>
export default {
  name: "SelectBox",
  props: {
    value: {
      type: [Number, String],
      default: null
    },
    options: {
      type: Array,
      default: () => []
    },
    listStyle: {
      type: String,
      default: null
    },
    query: {
      type: String,
      default: ""
    },
    width: {
      type: String,
      default: null
    },
    bgColor: {
      type: String,
      default: "#fff"
    }
  },
  data() {
    return {
      styleCustom: {
        "list-style": this.listStyle,
        "width": this.width,
        "background-color": this.bgColor
      },
      styleWrapperCustom: {
        "background-color": this.bgColor
      },
      selectBoxState: false
    };
  },
  methods: {
    /**
     * Bật tắt selectbox
     * CreatedBy: NTDUNG (08/12/2021)
     */
    toggleSelectBox() {
      this.selectBoxState = !this.selectBoxState;
    },
    /**
     * Xử lý chọn lựa chọn mới
     * CreatedBy: NTDUNG (08/12/2021)
     */
    handleChooseOption(index) {
        this.$emit('input', index);
        this.selectBoxState = false;
    }
  }
};
</script>
<style lang="scss">
@import "@/assets/scss/components/selectbox/selectbox.scss";
</style>

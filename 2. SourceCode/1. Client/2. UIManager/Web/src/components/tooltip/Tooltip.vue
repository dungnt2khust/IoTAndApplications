<template lang="">
  <div
    v-show="tooltipState && tooltipContent"
    class="tooltip tooltip--arrow"
    :style="positionOfTooltip"
  >
    {{ tooltipContent }}
  </div>
</template>
<script>
export default {
  name: "Tooltip",
  data() {
    return {
      tooltipContent: null,
      tooltipState: false,
      tooltipTop: -100,
      tooltipLeft: -100,
      tooltipHeight: 23,
      tooltipWidth: 130
    };
  },
  computed: {
    /**
     * Tính toán vị trí của tooltip
     * @returns {object} vị trí của tooltip
     * CreatedBy: NTDUNG (29/08/2021)
     */
    positionOfTooltip() {
      // Kiểm tra nếu vượt quá màn hình
      var top,
        left,
        right = "unset";

      // Kiểm tra top
      if (this.tooltipTop + 20 + this.tooltipHeight > window.innerHeight)
        top = this.tooltipTop - 20 + "px";
      else {
        top = this.tooltipTop + 20 + "px";
      }

      // Kiểm tra left
      if (this.tooltipLeft + this.tooltipWidth > window.innerWidth) {
        left = "unset";
        right = 0;
      } else {
        left = this.tooltipLeft + "px";
      }

      return { top: top, left: left, right: right };
    }
  },
  created() {
    /**
     * Lắng nghe sự kiện hiển thị tooltip
     * CreatedBy: NTDUNG (28/08/2021)
     */
    this.$bus.$on("showTooltip", data => {
      this.tooltipState = true;
      this.tooltipContent = data["message"];
      this.tooltipTop = data["top"];
      this.tooltipLeft = data["left"];
    });
    /**
     * Lắng nghe sự kiện ẩn tooltip
     * CreatedBy: NTDUNG (28/08/2021)
     */
    this.$bus.$on("hideTooltip", () => {
      this.tooltipState = false;
    });
  },
  destroy() {
    // Huỷ các sự kiện
    this.$bus.$off("hideTooltip");
    this.$bus.$off("showTooltip");
  }
};
</script>
<style lang="scss">
@import "@/assets/scss/components/tooltip/tooltip.scss";
</style>

export default {
  methods: {
    /**
     * Lắng nghe sự kiện hiển thị và ẩn input (hover event)
     * @param {string} message
     * CreatedBy: NTDUNG (28/08/2021)
     */
    tooltipListeners(message) {
      return Object.assign({}, this.$listener, {
        mouseenter: event => {
          // Truyền nội dung và vị trí cho tooltip
          var tooltipStyle = {
            message: message,
            top: event.clientY,
            left: event.clientX
          };
          // Hiện tooltip
          this.$bus.$emit("showTooltip", tooltipStyle);
        },
        mouseleave: () => {
          // Ẩn tooltip
          this.$bus.$emit("hideTooltip");
        },
        mouseup: event => {
          setTimeout(() => {
            if (!this.isVisible(event.target)) {
              this.$bus.$emit("hideTooltip");
            }
          }, 100);
        }
      });
    },
    /**
     * Lắng nghe sự kiện hiển thị và ẩn input (hover event)
     * @param {string} message
     * CreatedBy: NTDUNG (02/12/2021)
     */
    tooltipListenersMove(message, delay) {
      var timeoutMove;
      var state = false;
      return Object.assign({}, this.$listener, {
        mousemove: event => {
          clearTimeout(timeoutMove);
          if (state == false)
            timeoutMove = setTimeout(() => {
              // Truyền nội dung và vị trí cho tooltip
              var tooltipStyle = {
                message: message,
                top: event.clientY,
                left: event.clientX
              };
              // Hiện tooltip
              this.$bus.$emit("showTooltip", tooltipStyle);
              state = true;
            }, delay);
        },
        mouseleave: () => {
          // Ẩn tooltip
          this.$bus.$emit("hideTooltip");
          state = false;
        },
        mouseup: event => {
          setTimeout(() => {
            if (!this.isVisible(event.target)) {
              this.$bus.$emit("hideTooltip");
              state = false;
            }
          }, 100);
        }
      });
    }
  }
};

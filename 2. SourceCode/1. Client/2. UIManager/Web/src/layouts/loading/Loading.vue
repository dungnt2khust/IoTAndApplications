<template lang="">
    <FullScreen v-if="loadingState">
        <span class="txt-smb-1 txt-s-30">
            {{ message }}
        </span>
    </FullScreen>
</template>
<script>
export default {
    name: "Loading",
    data() {
        return {
            loadingState: false,
            message: "Loading ..."
        }
    },
    created() {
        this.$bus.$on('showLoading', (message, duration) => {
            this.loadingState = true;
            this.message = message;

            if (duration) {
                setTimeout(() => {
                    this.loadingState = false;
                }, duration);
            }
        });
        this.$bus.$on('hideLoading', () => {
            this.loadingState = false;
        });
    },
    destroyed() {
        this.$bus.$off('showLoading');    
        this.$bus.$off('hideLoading');    
    }
}
</script>
<style lang="">
    
</style>
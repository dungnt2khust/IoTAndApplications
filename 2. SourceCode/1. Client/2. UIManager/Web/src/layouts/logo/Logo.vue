<template lang="">
    <div class="logo" :style="customizeStyle(styleCustom)" @click="handleClickLogo">
        <div class="logo__icon m-r-10">
            <!-- <i class="fas fa-store"></i> -->
            <i class="fas fa-microchip"></i>
        </div>
        <span class="logo__shop-name">
            {{ShopName}}
        </span>
        <div class="logo__icon m-l-10">
            <!-- <i class="fas fa-store"></i> -->
            <i class="fas fa-microchip"></i>
        </div>
    </div>
</template>
<script>
// Plugins 
import { AccountType } from "@/models/enum/AccountType.js"

export default {
    name: "Logo",
    props: {
        bgColor: {
            type: String,
            default: null
        },
        txtColor: {
            type: String,
            default: null
        },
        txtSize: {
            type: String,
            default: null
        }
    },
    data() {
        return {
            ShopName: "EddieShop",
            styleCustom: {
                "background-color": this.bgColor,
                "color": this.txtColor,
                "font-size": this.txtSize
            }
        }
    },
    methods: {
        /**
         * Xử lý khi click vào logo
         * CreatedBy: NTDUNG (01/12/2021)
         */
        handleClickLogo() {
            switch (this._getLocalStorage("AccountType")) {
                case AccountType.ADMIN:
                    if (this.$route.path != "/admin/dashboard")
                        this.$router.push("/admin/dashboard");
                    else
                        this.$router.go(0);
                    break;
                case AccountType.USER:
                case AccountType.GUEST:
                    if (this.$route.path != "/home")
                        this.$router.push("/home");
                    else
                        this.$router.go(0);
                    break;
            } 
        }   
    }
}
</script>
<style lang="scss" scoped>
    @import "@/assets/scss/layouts/logo/logo.scss";
</style>
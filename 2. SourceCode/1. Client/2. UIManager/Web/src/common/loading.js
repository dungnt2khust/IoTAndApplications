import App from "@/main.js"

class Loading {
    constructor(){};

    /**
     * Bật loading
     * @param {String} message 
     * @param {String} type 
     * CreatedBy: NTDUNG (08/12/2021)
     */
    showLoading(message, type) {
        App.$bus.$emit('showLoading', message);
    }

    /**
     * Tắt loading
     * CreatedBy: NTDUNG (08/12/2021)
     */
    hideLoading() {
        App.$bus.$emit('hideLoading');
    }
}
export default new Loading();
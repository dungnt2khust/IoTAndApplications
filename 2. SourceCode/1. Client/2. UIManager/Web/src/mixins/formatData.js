export default {
    methods: {
        /**
         * Định dạng tiền tệ
         * @param {String, Number} money 
         * CreatedBy: NTDUNG (01/12/2021)
         */
        formatMoney(money) {
            if (!Number.isNaN(+money))
                return money.toLocaleString('vi', {style : 'currency', currency : 'VND'});
            else 
                return null;
        }
    }
}
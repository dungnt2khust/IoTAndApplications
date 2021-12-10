import Vue from 'vue'
import commonFunction from '@/mixins/commonFunction.js'
import commonFunction2 from '@/mixins/commonFunction2.js'
import storage from '@/mixins/storage.js'
import product from '@/mixins/product.js'
import formatData from '@/mixins/formatData.js'
import globalListeners from '@/mixins/globalListeners.js'

Vue.mixin(commonFunction);
Vue.mixin(commonFunction2);
Vue.mixin(storage);
Vue.mixin(product);
Vue.mixin(formatData);
Vue.mixin(globalListeners);
export default Vue;
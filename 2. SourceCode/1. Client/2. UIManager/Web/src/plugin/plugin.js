import Vue from 'vue'

import FlagIcon from 'vue-flag-icon'
import EventBus from '@/bus/eventbusGlobal.js'
import Popup from '@/common/popup.js'
import Tooltip from '@/common/Tooltip.js'
import Notify from '@/common/Notify.js'
import Loading from '@/common/Loading.js'
import VTooltip from 'v-tooltip'
// Account Auth
import AccountAPI from '@/api/components/Account/AccountAPI.js'

Vue.use(FlagIcon);
Vue.use(VTooltip);

Vue.prototype.$bus = EventBus;
Vue.prototype.$popup = Popup;
Vue.prototype.$tooltip = Tooltip;
Vue.prototype.$notify = Notify;
Vue.prototype.$loading = Loading;
Vue.prototype.$account = AccountAPI;

export default Vue;
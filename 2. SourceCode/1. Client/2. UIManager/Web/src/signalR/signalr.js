import Vue from 'vue'
const signalR = require("@aspnet/signalr");
Vue.prototype.$SignalR = {};

function CreateHubConfig(name, route) {
      Vue.prototype.$SignalR[name] = new signalR.HubConnectionBuilder()
            .withUrl(`${process.env.BASE_URL}/hub/${route}`)
            .configureLogging(signalR.LogLevel.Information)
            .build();
}
// Messenger
// CreateHubConfig('Messenger', 'messenger');
// Notify
// CreateHubConfig('Notify', 'notify');
Vue.prototype.$SignalR = new signalR.HubConnectionBuilder()
      .withUrl(`${process.env.BASE_URL}/hub/signalr`)
      .configureLogging(signalR.LogLevel.Information)
      .build();

export default Vue;
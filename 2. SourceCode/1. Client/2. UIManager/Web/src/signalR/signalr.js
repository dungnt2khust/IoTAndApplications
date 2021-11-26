import Vue from 'vue'

const signalR = require("@aspnet/signalr");

Vue.prototype.$SignalR = new signalR.HubConnectionBuilder()
      // .withUrl("http://eddieonthecode.xyz/hub/chat")
      .withUrl("https://localhost:44328/hub/chat")
      .configureLogging(signalR.LogLevel.Information)
      .build();

export default Vue;
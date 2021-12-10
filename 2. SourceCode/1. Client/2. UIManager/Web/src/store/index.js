import Vue from 'vue'
import Vuex from 'vuex'
import Guest from '@/router/menu/Guest'
import app from '../main'

Vue.use(Vuex)

const store = new Vuex.Store({
  state: { 
      navBar: Guest,
      Language: 'vi'
  },
  mutations: {
    SET_LANG (state, payload) {
      app.$i18n.locale = payload;
      this.Language = payload;
    }
  },
  actions: {
    setLang({commit}, payload) {
      commit('SET_LANG', payload);
    }
  }
});

export default store;
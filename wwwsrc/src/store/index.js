import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    publicKeeps: [],
    activeKeep: {},
    userKeeps: [],
    userVaults: [],
  },
  mutations: {
    setPublicKeeps(state, data) {
      state.publicKeeps = data
      console.log(state.publicKeeps)
    },
    setUserKeeps(state, data) {
      state.userKeeps = data
      console.log(state.publicKeeps)
    },
    setActiveKeep(state, data) {
      state.activeKeep = data
    },
    setUserVaults(state, data){
      state.userVaults = data
      console.log(state.userVaults)
    },
  },
  actions: {
    setBearer({ }, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    async getPublicKeeps({ commit }) {
      try {
        let res = await api.get('keeps/')
        console.log("Getting Public Keeps");
        commit("setPublicKeeps", res.data)
      } catch (error) { console.error(error) }
    },
    async getUserKeeps({ commit }) {
      try {
        let res = await api.get('keeps/')
        console.log("Getting User Keeps");
        commit("setUserKeeps", res.data)
      } catch (error) { console.error(error) }
    },
    async getKeep({ commit, dispatch }, id) {
      try {
        let res = await api.get('keeps/' + id)
        commit("setActiveKeep", res.data)
      } catch (error) {
        console.error(error)
      }
    },
    async createKeep({commit, dispatch}, newKeep){
      try {
        let res = await api.post('keeps/', newKeep)
        dispatch("getPublicKeeps")
      }catch(error){
        console.error(error);
      }
    },
    async getVaults({commit}){
      try {
        let res = await api.get('Vaults/')
        console.log("Getting User Vaults");
        commit("setUserVaults", res.data)
      } catch (error) { console.error(error) }
    }
  },
});

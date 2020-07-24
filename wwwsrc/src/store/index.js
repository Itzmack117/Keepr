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
    activeVault: {},
    userKeeps: [],
    userVaults: [],
    vaultKeeps: [],
  },
  mutations: {
    setPublicKeeps(state, data) {
      state.publicKeeps = data
    },
    setUserKeeps(state, data) {
      state.userKeeps = data
      console.log(state.userKeeps)
    },
    setActiveKeep(state, data) {
      state.activeKeep = data
    },
    setActiveVault(state, data){
      state.activeVault = data
    },
    setUserVaults(state, data) {
      state.userVaults = data
    },
    setVaultKeeps(state, data) {
      state.vaultKeeps = data
      console.log(state.vaultKeeps)
    }
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
        let res = await api.get('keeps')
        console.log("Getting Public Keeps");
        commit("setPublicKeeps", res.data)
      } catch (error) { console.error(error) }
    },
    async getUserKeeps({ commit }) {
      try {
        let res = await api.get('keeps/user')
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
    async createKeep({ commit, dispatch }, newKeep) {
      try {
        let res = await api.post('keeps/', newKeep)
        dispatch("getPublicKeeps")
      } catch (error) {
        console.error(error);
      }
    },
    async deleteKeep({ commit }, id) {
      try {
        let res = await api.delete("keeps/" + id)
        router.push({ name: "Home" })
      } catch (error) { console.error(); }
    },
    async getVaults({ commit }) {
      try {
        let res = await api.get('Vaults/')
        console.log("Getting User Vaults");
        commit("setUserVaults", res.data)
      } catch (error) { console.error(error) }
    },
    async getVaultById({commit}, id){
      try { 
        let res = await api.get("vaults/"+ id)
      commit("setActiveVault", res.data)
    } catch (error) { console.error(error) }
    },
    async getKeepsByVaultId({ commit }, id) {
      try {
        let res = await api.get("vaults/" + id + "/keeps")
        commit("setVaultKeeps", res.data)
      } catch (error) { console.error(error); }
    },
    async createVault({commit, dispatch}, newVault){
      try {
        let res = await api.post('vaults/', newVault)
        dispatch("getVaults")
      } catch (error) {
        console.error(error);
      }
    },
    async deleteVault({ commit }, id) {
      try {
        let res = await api.delete("vaults/" + id)
        router.push({ name: "Home" })
      } catch (error) {
        console.error();
      }
    },
    async addKeeptoVault({ commit }, DTOKV){
      try{
        console.log(DTOKV)
        let res = await api.post ("vaultkeeps", DTOKV)
        console.log(DTOKV);
    } catch (error) {
      console.error();
    }
  }
}
});

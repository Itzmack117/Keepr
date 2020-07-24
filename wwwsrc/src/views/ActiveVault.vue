<template>
  <div class="container">
    <div class="row">
    <h1>{{vault.name}}</h1>
    <button class="btn btn-danger" @click="deleteVault">delete vault</button>
        <keepCard v-for="Keep in keeps" :key="Keep.id" :keepProp="Keep" />
      </div>
  </div>
</template>

<script>
import KeepCard from "@/components/CardComponent";
export default {
  name: "activeVault",

  mounted() {
    this.$store.dispatch("getKeepsByVaultId", this.$route.params.vaultId);
    this.$store.dispatch("getVaultById", this.$route.params.vaultId);
  },
  computed: {
    keeps() {
      return this.$store.state.vaultKeeps;
    },
    vault(){
      return this.$store.state.activeVault;
    }
  },
  methods: {
    deleteVault() {
      this.$store.dispatch("deleteVault", this.$route.params.vaultId);
    },
  },
  components:{
    KeepCard
  },
};
</script>

<style>
</style>
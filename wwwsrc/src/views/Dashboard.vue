<template>
  <div class="dashboard">
    <div class="text-center"><h1>Welcome {{this.$auth.user.name}}</h1>
    <div class="row">
      <div class="col-6">
        <h3 class="text-center">Your Keeps</h3>
        <keepCard v-for="Keep in keeps" :key="Keep.id" :keepProp="Keep" />
      </div>
      <div class="co-6">
        <h3>Your Vaults</h3>
      <vaultsComponent v-for="Vault in vaults" :key="Vault.id" :vaultProp="Vault"/>
      </div>
    </div>
    </div>

  </div>
</template>

<script>
import KeepCard from "@/components/CardComponent";
import VaultsComponent from "@/components/VaultsComponent";
export default {
  mounted() {
     this.$store.dispatch("getUserKeeps");
     this.$store.dispatch("getVaults")
  },
  computed: {
    keeps(){
      return this.$store.state.userKeeps;
    },
    vaults(){
      return this.$store.state.userVaults;
    }
  },
  components: {
    KeepCard,
    VaultsComponent,
  },
};
</script>

<style></style>

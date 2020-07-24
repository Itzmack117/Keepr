<template>
  <div class="vaultsDropdownComponent">
    <button class="btn" @click="addKeeptoVault(dropProp.id)">{{dropProp.name}}</button>
  </div>
</template>

<script>
export default {
  name: "vaultsDropdownComponent",
  props: ["dropProp"],
  mounted(){
    this.$store.dispatch("getVaults")
    let keepId = this.$store.state.activeKeep.id
    console.log(keepId)
  },
  methods: {
    addKeeptoVault: function(vaultId) {
       let keepId = this.$store.state.activeKeep.id
        let vaultKeep = {keepId, vaultId}
        this.$store.dispatch("addKeeptoVault", vaultKeep);
    },
    
  }
};
</script>

<style scoped>
</style>
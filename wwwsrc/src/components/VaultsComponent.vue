<template>
  <div class="vaultsComponent">
    <router-link :to="{name: 'activeVault', params:{vaultId: vaultProp.id}}">
      <td>{{vaultProp.name}}</td>
    </router-link>
  </div>
</template>

<script>
export default {
  name: "VaultsComponent",
  props: ["vaultProp"],
};
</script>
<style scoped>
.vaultsComponent {
  color: #212529;
}
</style>
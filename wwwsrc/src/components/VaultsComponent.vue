<template>
<tr class="vaultsComponent">
  <router-link :to="{name: 'ActiveVaultPage', params:{vaultId: vaultProp.id}}">
    <td>{{vaultProp.name}}</td>
</router-link>
</tr>
</template>

<script>
export default {
  name: "VaultsComponent",
  props: ["vaultProp"]
}
</script>
<style scoped>
.vaultsComponent{
color: #212529;
}
</style>
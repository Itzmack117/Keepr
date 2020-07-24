<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col">
        <div class="card active-keep">
          <div class="row">
            <div class="col-6">
              <img :src="keep.img" class="card-img" alt />
            </div>
            <div class="col">
              <div class="card-body">
                <h5 class="card-title">
                  {{keep.name}}
                  <button
                    class="btn btn-danger float-right"
                    v-if="isCreator"
                    @click="deleteKeep"
                  >Delete Keep</button>
                </h5>
                <p class="card-text">{{keep.description}}</p>
                <h1>add to Vault:</h1>
                <VaultsDropComponent v-for="Vault in vaults" :key="Vault.id" :dropProp="Vault"/>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import VaultsDropComponent from "@/components/VaultsDropComponent";
export default {
  name: "activeKeep",

  mounted() {
    this.$store.dispatch("getKeep", this.$route.params.keepId);
    this.$store.dispatch("getVaults");
  },
  computed: {
    keep() {
      return this.$store.state.activeKeep;
    },
    isCreator() {
      return this.$store.state.activeKeep.userId == this.$auth.user.sub;
    },
    vaults() {
      return this.$store.state.userVaults;
    },
  },
  methods: {
    deleteKeep() {
      console.log(this.$route.params.keepId),
        this.$store.dispatch("deleteKeep", this.$route.params.keepId);
    },
    addKeeptoVault(vaultId) {
      console.log("click")
      this.$store.dispatch(
        "addKeeptoVault", this.keep.id, vaultId);
    },
  },
      components: {
        VaultsDropComponent,
      },
};
</script>

<style scoped>
.active-card {
  width: 70%;
  height: 90%;
}
</style>>
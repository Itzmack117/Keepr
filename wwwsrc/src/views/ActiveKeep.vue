<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col">
        <div class="card active-keep">
          <div class="row">
            <div class="col-6">
              <img src class="card-img-top" alt />
            </div>
            <div class="col">
              <div class="card-body">
                <h5 class="card-title">{{keep.name}}</h5>
                <p class="card-text">{{keep.description}}</p>
                <a href="#" class="btn btn-primary">Go somewhere</a>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "activeKeep",

  mounted() {
    this.$store.dispatch("getKeep", this.$route.params.keepId);
  },
  computed: {
    keep(){
     return this.$store.state.activeKeep;
    }
  }
};
</script>

<style scoped>
.active-card {
  width: 70%;
  height: 90%;
}
</style>>
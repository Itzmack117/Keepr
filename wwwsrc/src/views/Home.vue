<template>
  <div class="home">
    <h1 class="text-center">Welcome to Keepr!</h1>
    <div class="row">
      <div class="col">
          <KeepCard class="KeepCard"/>
        </div>
        </div>
  </div>
</template>

<script>
import KeepCard from "@/components/CardComponent"
export default {
  name: "home",
  mounted(){
    // this.$store.dispatch("getKeeps")
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps(){
      return this.$store.state.cars
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  },
  components: {
    KeepCard
  }
};
</script>

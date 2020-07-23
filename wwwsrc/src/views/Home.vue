<template>
  <div class="home">
    <h1 class="text-center">Welcome to Keepr!</h1>
    <div class="container-fluid">
      <div class="row">
        <div class="col">
          <button class="btn btn-danger float-right">New Keep</button>
          <form v-if="$auth.isAuthenticated" @submit.prevent="createKeep">
            <div class="form-group row">
              <div class="col-4">
                <label for="exampleFormControlInput1">
                  <b>Name of New Keep</b>
                </label>
                <input
                  type="name"
                  class="form-control"
                  id="newKeep"
                  placeholder="Name of New Keep"
                  v-model="newKeep.name"
                />
                <input
                  type="name"
                  class="form-control mt-2"
                  id="keepImg"
                  placeholder="Image URL"
                  v-model="newKeep.img"
                />
                <div class="form-check">
                  <input class="form-check-input" type="checkbox" value id="isPrivate" v-model="newKeep.isPrivate"/>
                  <label class="form-check-label" for="defaultCheck1">Private Keep?</label>
                </div>
              </div>
              <div class="col">
                <div class="form-group">
                  <label for="newKeepDescription">
                    <b>Describe Your Keep</b>
                  </label>
                  <textarea
                    class="form-control"
                    id="exampleFormControlTextarea1"
                    rows="4"
                    v-model="newKeep.description"
                  ></textarea>
                </div>
              </div>
            </div>
            <button class="btn btn-success align-middle" type="submit">Submit Keep</button>
          </form>
        </div>
      </div>
      <div class="row">
        <keepCard v-for="Keep in keeps" :key="Keep.id" :keepProp="Keep" />
      </div>
    </div>
  </div>
</template>

<script>
import KeepCard from "@/components/CardComponent";
export default {
  name: "home",
  data() {
    return {
      newKeep: {
        name: "",
        description: "",
        img: "",
        isPrivate: Boolean
      },
    };
  },
  mounted() {
    this.$store.dispatch("getPublicKeeps");
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    createKeep() {
      this.$store.dispatch("createKeep", this.newKeep);
      console.log(this.newKeep);
    },
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.publicKeeps;
    },
  },
  components: {
    KeepCard,
  },
};
</script>

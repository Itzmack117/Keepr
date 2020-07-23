<template>
<div class="col-3" @click="$router.push({name: 'activeKeep', params: {keepId: keepProp.id}})"
>
<div class="keepCard">
  <img :src="keepProp.img" class="card-img-top" alt="ERROR LOADING IMAGE">
  <div class="card-body">
    <h5 class="card-title">{{keepProp.name}}</h5>
    <b v-if="keepProp.isPrivate == true">PRIVATE</b>
    <p class="card-text">{{keepProp.description}}</p>
    <a href="#" class="btn btn-primary">Go somewhere</a>
  </div>
  </div>
</div>
</template>

<script>
export default {
 name: "keepCard",
 props: ["keepProp"],

methods: {
  viewKeep(){
     this.$store.dispatch("getKeep", this.keepProp)
  }
}
}

</script>

<style scoped>
.keepCard{
background-color: aliceblue;
border-radius: 15px;
margin: 3rem;
width: 30vh;
}
</style>
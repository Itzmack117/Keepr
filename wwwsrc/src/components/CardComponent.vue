<template>
<div class="keepCard" style="width: 18rem;">
  <img src="https://unsplash.com/photos/4he2oHydgCs" class="card-img-top" alt="ERROR LOADING IMAGE">
  <div class="card-body">
    <h5 class="card-title">A Lovely Picture from Gdansk</h5>
    <p class="card-text">Mistakes have been made</p>
    <a href="#" class="btn btn-primary">Go somewhere</a>
  </div>
</div>
</template>

<script>
export default {
 name: "keepCard",
 props: ["keepData"]
}
</script>

<style scoped>
.keepCard{
background-color: aliceblue;
border-radius: 15px;
margin: 3rem;
}
</style>
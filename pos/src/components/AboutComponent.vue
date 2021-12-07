<template>
  <div class="aboutContainer">
    <h1>About!</h1>
    <p>POS system lavet i Vue3</p>
    <p>Routing lavet med vue Router som er importeret i main.js</p>
    <p>Produkter importeret fra API med Axios plugin, også importeret i main.js</p>
    <p>Produkter kommer fra C# API, <a href="https://localhost:5001/swagger">LINK</a></p>
    <p>POS funktionalitet ligger i components/POSCOmponent</p>
    <p>About ligger i components/AboutComponent</p>
    <p>Lavet af Michael Aggerholm</p>
    <p>beklager skuffelsen Simon.. jeg ved godt at det ikke lever 100% op til målpindende.</p>
    <p>Faget har været super spændende, men selve tiden til at lave POS system har været for knap efter min mening.</p>
  </div>
</template>

<script>
export default {
  props: {

  },
  data() {
    return{
      
    }
  },
  methods:{
    
  }
}
</script>

<style scoped>
  p{
    font-size: 18px;
  }
  .aboutContainer{
    display: flex;
    flex-direction: column;
    flex-wrap: nowrap;
    align-items: center;
  }
</style>

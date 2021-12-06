<template>
  <div class="home">
    <HelloWorld msg="Products"/>
    <div style="display: flex;">
      <ul>
        <div style="display:flex; background-color: lightgray;">
          <li class="productContainer" 
            v-for="prod in products" 
            :key="prod.productId">
            <div>
              <div>{{ prod.title }}</div>
              <div>{{ prod.price }}</div>
              <button @click="addAsObject(prod.title, prod.price)">Add</button>
              <button @click="removeObject(prod)">Remove</button>
            </div>
          </li>
      </div>
    </ul>
    <div class="inBasketContainer">
      <label>All products in basket: {{ ProductsInBasketArray }}</label>
    </div>
    <br>
    <p>Total: {{itemsTotal}}$</p>
    </div>
  </div>
</template>

<script>
import HelloWorld from '@/components/HelloWorld.vue'
import axios from 'axios'

export default {
  name: 'Home',
  components: {
    HelloWorld
  },
  data() {
    return{
      products: [],
      ProductsInBasketArray: [],
    }
  },
  mounted() {
    // henter produkter fra API via url.
    axios.get('https://localhost:5001/Product')
    .then(
      (response) => this.products = response.data
    )
    .catch(
      (message) => console.log(message)
    )
  },
  methods:{
    // Tilføjer produktet til ProductsInBasketArray som object.
    addAsObject(title,price){
      this.ProductsInBasketArray.push({title,price});
    },
    /* Finder det specifikke produkt object i ProductsInBasketArray, 
    hvis der findes et object i array'et som indeholder en titel der matcher 
    det vi forsøger at slette, bliver produktet fjernet fra array. */
    removeObject(prod) {
      let foundValue = this.ProductsInBasketArray.findIndex((v)=>prod.title === v.title)
      if(foundValue<0) return 
      this.ProductsInBasketArray.splice(foundValue,1)
    }
  },
  // https://v3.vuejs.org/guide/computed.html#computed-properties
  // viser summen af all produkt priser der er i array af objekter.
  computed: {
    itemsTotal() {
      return this.ProductsInBasketArray.reduce((a, c) => a + c.price, 0)
    }
  }
}
</script>

<style>
  .productContainer{
    width: 200px;
    height: 80px;
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding:10px;
    background-color: #ececec;
    margin: 5px;
    border: 1px solid gray;
  }
  .inBasketContainer{
    width: 300px;
    min-height: auto;
    background-color: lightgray;
    display: flex;
    margin-top: 16px;
    margin-left: 16px;
  }
</style>
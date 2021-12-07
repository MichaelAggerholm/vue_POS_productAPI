<template>
<p style="font-weight:600;">Total: {{itemsTotal}} Kr,-</p>
  <div style="display: flex;">
    <ul>
      <div style="display: flex;flex-direction: row;flex-wrap: wrap;max-width: 700px;">
        <li class="productContainer" 
          v-for="prod in products" 
          :key="prod.productId"
          @click="addAsObject(prod.title, prod.price)">
          <div>
            <div>{{ prod.title }}</div>
            <div>{{ prod.price }} Kr,-</div>
          </div>
        </li>
      </div>
    </ul>
  </div>

  <div style="display: flex;">
    <ul>
      <div style="display: flex;flex-direction: row;flex-wrap: wrap;max-width: 700px;">
        <li class="productContainer" 
          v-for="basketProd in ProductsInBasketArray" 
          :key="basketProd.title"
          @click="removeObject(basketProd)">
          <div>
            <div>{{ basketProd.title }}</div>
          </div>
        </li>
      </div>
    </ul>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  name: 'POSComponent',
  props: {
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

<style scoped>
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

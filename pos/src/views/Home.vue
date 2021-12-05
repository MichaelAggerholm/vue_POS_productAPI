<template>
  <div class="home">
    <HelloWorld msg="Products"/>
    <ul>
      <div style="display:flex;">
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
    <label>All products in basket: {{ ProductsInBasketArray }}</label>
    <br>
    <p>Total: {{itemsTotal}}$</p>
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
    axios.get('https://localhost:5001/Product')
    .then(
      (response) => this.products = response.data
    )
    .catch(
      (message) => console.log(message)
    )
  },
  methods:{
    addAsObject(title,price){
      this.ProductsInBasketArray.push({title,price});
    },
    removeObject(prod) {
      let idx = this.ProductsInBasketArray.findIndex((v)=>prod.title === v.title)
      if(idx<0) return 
      this.ProductsInBasketArray.splice(idx,1)
    }
  },
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
</style>
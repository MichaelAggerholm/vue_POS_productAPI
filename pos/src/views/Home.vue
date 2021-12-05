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
              <button @click="add(prod.price)">Add</button>
              <button @click="subtract(prod.price)">Subtract</button>
            </div>
          </li>
      </div>
    </ul>
    <label>{{ sum }}</label>
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
      products : [],
      sum : 0
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
    add:function(price){
        this.sum += price
    },
    subtract:function(price){
        this.sum -= price
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
<template>
  <div class="home">
    <ul>
      <li v-for="prod in products" :key="prod.productId">{{ prod.title }} - {{ prod.description }} - {{ prod.price }} - {{ prod.category }}</li>
    </ul>
    <HelloWorld msg="Welcome to Your Vue.js App"/>
  </div>
</template>

<script>
// @ is an alias to /src
import HelloWorld from '@/components/HelloWorld.vue'
import axios from 'axios'

export default {
  name: 'Home',
  components: {
    HelloWorld
  },
  data() {
    return{
      products : []
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
  }
}
</script>

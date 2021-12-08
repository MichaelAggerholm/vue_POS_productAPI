<template>
  <div style="display:flex;">
    <ProductsComponent v-on:add="add" v-bind:products="products" />
    <PriceComponent v-bind:ProductsInBasketArray="ProductsInBasketArray" />
    <BasketComponent v-on:remove="remove" v-bind:ProductsInBasketArray="ProductsInBasketArray" />
  </div>
</template>

<script>
import axios from 'axios'
import ProductsComponent from '@/components/ProductsComponent.vue'
import BasketComponent from '@/components/BasketComponent.vue'
import PriceComponent from '@/components/PriceComponent.vue'

export default {
  components: {
    ProductsComponent,
    BasketComponent,
    PriceComponent
  },
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
    add(prod){
      this.ProductsInBasketArray.push({title:prod.title,price:prod.price});
    },
    /* Finder det specifikke produkt object i ProductsInBasketArray, 
    hvis der findes et object i array'et som indeholder en titel der matcher 
    det vi forsøger at slette, bliver produktet fjernet fra array. */
    remove(prod) {
      let foundValue = this.ProductsInBasketArray.findIndex((v)=>prod.title === v.title)
      if(foundValue<0) return 
      this.ProductsInBasketArray.splice(foundValue,1)
    }
  }
}
</script>

<style>

</style>
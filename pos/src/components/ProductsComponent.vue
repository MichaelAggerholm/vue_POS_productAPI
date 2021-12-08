<template>
  <div style="display: flex;">
    <ul>
      <div class="productContainer" style="display: flex;flex-direction: row;flex-wrap: wrap;max-width: 700px;">
        <li v-bind:class="color(prod)"
          v-for="prod in products" 
          :key="prod.productId"
          @click="$emit('add', prod)">
          <div>
            <div>{{ prod.title }}</div>
            <div>{{ prod.price }} Kr,-</div>
          </div>
        </li>
      </div>
    </ul>
  </div>
</template>

<script>
export default {
  name: 'ProductsComponent',
  props: [
    'products'
  ],
  data() {
    return{
      
    }
  },
  methods: {
    color(prod) {
      switch (prod.category) {
          case "fruit": return "red";
          case "beverage": return "green";
          case "food": return "blue";
          default: return "";
      }
    }
  }
}
</script>

<style>
  .productContainer li{
    width: 200px;
    height: 80px;
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding:10px;
    margin: 5px;
    border: 1px solid gray;
  }
  li.red {
  background: #ff0000;
  }
  li.green {
    background: #00cc00;
  }
  li.blue {
    background: #0000ff;
  }
</style>

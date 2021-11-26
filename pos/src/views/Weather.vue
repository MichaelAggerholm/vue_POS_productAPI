<template>
  <div class="home">
    <Button>Click</Button>
    <ul>
      <li v-for="temp in temperatures" :key="temp.id">{{ temp.date }}: {{ temp.temperatureC }}</li>
    </ul>
    <HelloWorld msg="Welcome to Your Vue.js App"/>
  </div>
</template>

<script>
// @ is an alias to /src
import HelloWorld from '@/components/HelloWorld.vue'
import axios from 'axios'

export default {
  name: 'weather',
  components: {
    HelloWorld
  },
  data() {
    return{
      temperatures : []
    }
  },
  mounted() {
    axios.get('https://localhost:5001/WeatherForecast')
    .then(
      (response) => this.temperatures = response.data
    )
    .catch(
      (message) => console.log(message)
    )
  }
}
</script>

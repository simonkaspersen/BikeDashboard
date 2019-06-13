<template>
  <v-app>
    <v-content>
      <Station/>
    </v-content>
  </v-app>
</template>

<script>
import Station from './views/Station'

export default {
  name: 'App',
  components: {
    Station
  }
}
</script>

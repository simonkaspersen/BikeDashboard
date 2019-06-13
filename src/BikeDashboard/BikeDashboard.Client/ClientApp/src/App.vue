<!--suppress ALL -->
<template>
  <v-app>
    <v-toolbar dark color="primary">

      <v-toolbar-title class="white--text">Bike station dashboard</v-toolbar-title>

      <v-spacer></v-spacer>
      <v-spacer></v-spacer>
      <v-autocomplete
              v-model="selectedStationSearch"
              :items="availableStations"
              color="white"
              solo
              light
              hide-no-data
              hide-selected
              clearable
              item-text="name"
              item-val="name"
              label="Public APIs"
              placeholder="Start typing to Search"
              prepend-icon="mdi-database-search"
              return-object
      ></v-autocomplete>
    </v-toolbar>
    <v-content>
      <Station :selectedStation="selectedStation"/>
    </v-content>
  </v-app>
</template>

<script>
import Station from './views/Station'
import StationService from '../services/stationService';
export default {
  name: 'App',
  components: {
    Station
  },
  data() {
    return {
      selectedStation: null,
      availableStations: [],
      favoriteStation: null,
      selectedStationSearch: null
    }
  },
  watch: {
    selectedStationSearch () {
      this.favoriteStation = this.selectedStationSearch.name
      console.log(1, this.selectedStationSearch)
      console.log(2, this.favoriteStation)
      this.getStation();
    }
  },
  methods: {
    async getAvailableStations() {
      const response = await StationService.getAllAvailableStations();
      this.availableStations = response.data
    },
    async getStation() {
      const response = await StationService.getStation({favoriteStation: this.favoriteStation});
      this.selectedStation = response.data;
    }
  },
  mounted() {
    this.getAvailableStations();
    this.getStation();
  }
}
</script>

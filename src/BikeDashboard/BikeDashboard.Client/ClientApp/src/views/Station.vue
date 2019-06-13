<template>
    <v-container grid-list-md text-xs-center>
        <v-layout row wrap>
            <v-flex xs12>
                <v-alert
                        :value="selectedStation.showingClosestStationWithBikes"
                        type="info"
                >
                    {{selectedStation.originalStationName}} had no available bikes. Showing closest bikestation.
                </v-alert>
            </v-flex>
            <v-flex xs12>
                <div class="display-4 font-weight-light">{{ stationName }}</div>
            </v-flex>
            <v-flex xs12 md6 offset-md3>
                <v-card
                        class="mx-auto"
                        color="#26c6da"
                        dark
                >
                    <v-card-text class="headline font-weight-bold" style="margin-top: 30px">
                        <div class="display-3 font-weight-light"><v-icon style="font-size: 55px;" dark>directions_bike</v-icon> {{availableBikes}} / <v-icon style="font-size: 55px;" dark>lock</v-icon> {{availableLocks}}</div>
                    </v-card-text>
                </v-card>
            </v-flex>
        </v-layout>
    </v-container>
</template>

<script>
    import _ from 'lodash'
    export default {
        props: ['selectedStation', 'loadingStation'],
        computed: {
          stationName() {
              return _.get(this.selectedStation, 'station.name')
          },
            availableBikes() {
                return _.get(this.selectedStation, 'station.availableBikes')
            },
            availableLocks() {
                return _.get(this.selectedStation, 'station.availableLocks')
            }
        }
    }
</script>

<style scoped>

</style>
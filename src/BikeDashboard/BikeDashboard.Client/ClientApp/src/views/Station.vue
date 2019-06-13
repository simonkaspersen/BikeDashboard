<template>
    <v-container grid-list-md text-xs-center>
        <v-layout row wrap>
            <v-flex xs12>
                <v-alert
                        :value="stationData.showingClosestStationWithBikes"
                        type="info"
                >
                    {{stationData.originalStationName}} had no available bikes. Showing closest bikestation.
                </v-alert>
            </v-flex>
            <v-flex xs12>
                <div class="display-3 font-weight-light">{{stationData.station.name}}</div>
            </v-flex>
            <v-flex xs12 md6>
                <v-card
                        class="mx-auto"
                        color="#26c6da"
                        dark
                >
                    <v-card-title>
                        <span class="title font-weight-light">Tilgjengelige sykler</span>
                    </v-card-title>

                    <v-card-text class="headline font-weight-bold">
                        <v-icon dark>directions_bike</v-icon> {{stationData.station.availableBikes}}
                    </v-card-text>
                </v-card>
            </v-flex>
            <v-flex xs12 md6>
                <v-card
                        class="mx-auto"
                        color="#26c6da"
                        dark
                >
                    <v-card-title>
                        <span class="title font-weight-light">Sykkellåser</span>
                    </v-card-title>

                    <v-card-text class="headline font-weight-bold">
                        <v-icon dark>lock</v-icon> {{stationData.station.availableLocks}}
                    </v-card-text>
                </v-card>
            </v-flex>
        </v-layout>
    </v-container>
</template>

<script>
    import StationService from '../../services/stationService';

    export default {
        data() {
            return {
                favoriteStation: "gløshaugen",
                stationData: {},
            }
        },
        methods: {
            async getStation() {
                const response = await StationService.getStation({favoriteStation: this.favoriteStation});
                this.stationData = response.data
            }
        },
        created() {
            this.getStation();
        }
    }
</script>

<style scoped>

</style>
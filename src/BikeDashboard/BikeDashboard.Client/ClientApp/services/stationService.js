import api from './api'

export default {
    getStation (params) {
        return api().get('/api/FavoriteStation?stationName=' + params.favoriteStation)
    }
}
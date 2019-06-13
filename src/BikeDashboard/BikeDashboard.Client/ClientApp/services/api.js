import axios from 'axios'

export default() => {
    return axios.create({
        baseURL: process.env.VUE_APP_API_URL || 'http://localhost:5050',
        withCredentials: false,
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    })
}
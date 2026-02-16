import axios from "axios";

const API_BASE = "https://localhost:7266/api";

export default {
  getDestinations(origin) {
    return axios.get(`${API_BASE}/airports/destinations/${origin}`);
  },
  searchFlights(origin, destination) {
    return axios.get(`${API_BASE}/flights`, {
      params: { origin, destination }
    });
  }
};

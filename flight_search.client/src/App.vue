<template>
  <div class="search-form">
    <h2>Flight Search</h2>
    <label>Origin:</label>
    <select v-model="origin" @change="fetchDestinations">
      <option disabled value="">Select Origin</option>
      <option v-for="o in origins" :key="o">{{ o }}</option>
    </select>

    <label>Destination:</label>
    <select v-model="destination">
      <option disabled value="">Select Destination</option>
      <option v-for="d in destinations" :key="d">{{ d }}</option>
    </select>

    <button @click="searchFlights">Search</button>

    <div v-if="flights.length">
      <h3>Available Flights</h3>
      <ul>
        <li v-for="f in flights" :key="f.id">
          {{ f.origin }} → {{ f.destination }} - ${{ f.price }}
        </li>
      </ul>
    </div>
  </div>
</template>

<script>
  import api from "./services/api";

  export default {
    data() {
      return {
        origins: ["NYC", "LON", "BLR"],
        origin: "",
        destination: "",
        destinations: [],
        flights: []
      };
    },
    methods: {
      async fetchDestinations() {
        try {
          const res = await api.getDestinations(this.origin);
          this.destinations = res.data;
        } catch (err) {
          alert("Error fetching destinations");
        }
      },
      async searchFlights() {
        try {
          const res = await api.searchFlights(this.origin, this.destination);
          this.flights = res.data;
        } catch (err) {
          alert("Error fetching flights");
        }
      }
    }
  };
</script>

<style>
  /* Background and alignment */
  .search-form {
    max-width: 500px;
    margin: 2rem auto;
    padding: 2rem;
    background: linear-gradient(135deg, #f0f4ff, #dce3f7);
    border-radius: 10px;
    box-shadow: 0 4px 12px rgba(0,0,0,0.1);
    text-align: center;
    font-family: "Segoe UI", Arial, sans-serif;
  }

    /* Headings */
    .search-form h2 {
      color: #2c3e50;
      margin-bottom: 1rem;
    }

    /* Labels */
    .search-form label {
      display: block;
      margin: 0.5rem 0;
      font-weight: bold;
      color: #34495e;
    }

    /* Dropdowns */
    .search-form select {
      width: 80%;
      padding: 0.5rem;
      margin-bottom: 1rem;
      border: 1px solid #ccc;
      border-radius: 6px;
      font-size: 1rem;
    }

    /* Button */
    .search-form button {
      background-color: #3498db;
      color: white;
      font-size: 1rem;
      padding: 0.6rem 1.2rem;
      border: none;
      border-radius: 6px;
      cursor: pointer;
      transition: background 0.3s ease;
    }

      .search-form button:hover {
        background-color: #2980b9;
      }

  /* Error message */
  .error {
    color: #e74c3c;
    margin-top: 1rem;
    font-weight: bold;
  }

  /* Results */
  .results {
    margin-top: 2rem;
    text-align: left;
  }

    .results h3 {
      color: #2c3e50;
    }

    .results ul {
      list-style: none;
      padding: 0;
    }

    .results li {
      background: #ecf0f1;
      margin: 0.5rem 0;
      padding: 0.8rem;
      border-radius: 6px;
      font-size: 1rem;
    }
  /* Make the whole page centered */
  body, html {
    height: 100%;
    margin: 0;
  }

  #app {
    display: flex;
    justify-content: center; /* horizontal center */
    align-items: center; /* vertical center */
    height: 100vh; /* full viewport height */
    background: linear-gradient(135deg, #f0f4ff, #dce3f7);
  }


</style>


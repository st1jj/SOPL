import axios from "axios";

export const api = axios.create({
  baseURL: "https://localhost:7135/api", 
  headers: {
    "Content-Type": "application/json",
  },
});

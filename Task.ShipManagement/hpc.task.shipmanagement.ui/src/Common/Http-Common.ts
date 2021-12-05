import axios from "axios";
import { API_SERVER_PATH } from './Constants';

export default axios.create({
    baseURL: API_SERVER_PATH,
    headers: {
        "Content-type": "application/json"
    }
});
import { useState } from "react";

const API_URL = 'https://localhost:7182/api';

export function useFilter() {
    const [response, setResponse] = useState([]);

    const call = () => fetch(
        `${API_URL}/Book/filter`, {
            method: 'POST',
            headers: {'Content-Type':'application/json'},
            body: JSON.stringify( 
                {
                    filter: {
                        "title": "lord"
                    },
                    paging: {
                        pageSize: 10,
                        pageIndex: 0
                    }
                })
        }
    )
    .then(async r => setResponse(await r.json()));

    return [response.items, response.hasNextPage, call];
 }   

export default useFilter;
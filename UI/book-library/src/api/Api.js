import { useState } from "react";
import { BOOK_PAGE_SIZE } from '../constants'
import { handlerError } from './fetchHandler'

const API_URL = 'https://localhost:7182/api';

export function useFilter() {
    const [response, setResponse] = useState();

    const call = (key, value, pageIndex = 0) => fetch(
        `${API_URL}/Book/filter`, {
            method: 'POST',
            headers: {'Content-Type':'application/json'},
            body: JSON.stringify( 
                {
                    filter: {
                        [key]: value
                    },
                    paging: {
                        pageSize: BOOK_PAGE_SIZE,
                        pageIndex: pageIndex
                    }
                })
        }
    )
    .then(async r => setResponse(await r.json()))
    .catch(error => {
        handlerError(error);
    })

    return [response?.items, response?.totalCount, call];
 }   

export default useFilter;
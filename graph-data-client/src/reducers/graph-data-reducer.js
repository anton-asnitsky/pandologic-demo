import React from 'react';
import axios from 'axios';

function reducer(state = {data: []}, action){
    switch (action.type) {
        case "get-data":
            var fetchData = [];
            
            axios.get(`http://localhost:5001/api/v1/graphdata?from_date=${action.fromDate}&to_date=${action.toDate}`, {
                headers: {
                    'Access-Control-Allow-Origin': '*',
                    'Access-Control-Allow-Methods': 'GET,PUT,POST,DELETE,PATCH,OPTIONS',
                },
            })
                .then(res => {
                    console.log(res.data);
                    fetchData = res.data;
                })
            return {
                data: fetchData
            };
        default:
          return {
            data: []
        };
      }
    }
     
    export default reducer;
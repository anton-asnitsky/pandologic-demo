import {GET_DATA, DATA_ERROR} from '../types'
import axios from 'axios'

export const getGraphData = ({ fromDate, toDate }) => async dispatch => {
    
    try{
        const res = await axios.get(`http://localhost:5001/api/v1/graphdata?from_date=${fromDate}&to_date=${toDate}`, {
            headers: {
                'Access-Control-Allow-Origin': '*',
                'Access-Control-Allow-Methods': 'GET,PUT,POST,DELETE,PATCH,OPTIONS',
            },
        })
            .then(res => {
                let processedData = [];

                processedData.push(res.data[0]);

                for (let index = 1, maxIndex = res.data.length; index < maxIndex; index += 1) { 
                    let row = [];
                    for (let rowIndex = 0, maxRowIndex = res.data[index].length; rowIndex < maxRowIndex; rowIndex += 1) { 
                        if (rowIndex == 0) {
                            row.push(new Date(res.data[index][rowIndex]));
                        } else { 
                            row.push(res.data[index][rowIndex]);
                        }
                    }

                    processedData.push(row);
                }

                return {
                    data: processedData
                }; 
            })
        dispatch( {
            type: GET_DATA,
            payload: res.data
        })
    }
    catch(error){
        dispatch( {
            type: DATA_ERROR,
            payload: error,
        })
    }

}
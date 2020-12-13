import Chart from "react-google-charts";
import "./chart-container.scss";
import React from "react";
import { useEffect } from 'react';
import { useSelector } from "react-redux";
import { useDispatch } from "react-redux";
import moment  from 'moment';

const CahrtContainer = () => { 
    const data = useSelector(state => state.data);
    const dispatch = useDispatch();

    useEffect(() => { 
		dispatch({
            type: "get-data",
            fromDate: moment().add(-7, 'days').format('YYYY-MM-DD'),
            toDate: moment().format('YYYY-MM-DD'),
          })
    }, []);

    useEffect(() => { 
        console.log(data);

    }, [data]);
    
    
    return (
        <>
            <Chart
                width={'100%'}
                data={data}
                loader={<div>Loading Chart</div>}
                options={{
                    title: 'Cumulative job views vs. predixtions',
                    vAxis: { title: 'Jobs' },
                    hAxis: { title: 'Job views' },
                    seriesType: 'bars',
                    series: {
                        4: { type: 'line' },
                        3: { type: 'line' }
                    }
                }}
                chartType="ComboChart"
            />
        </>
    );
};

export default CahrtContainer;
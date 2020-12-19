import React, {useEffect} from 'react'
import {useDispatch, useSelector} from 'react-redux'
import {getGraphData} from '../store/actions/graphData'
import moment from 'moment';
import Chart from "react-google-charts";

const Graph = () => {
    const dispatch = useDispatch()
    const graphData = useSelector(state => { console.log(state); return (state.graphData) })
    const {loading, error, data} = graphData
    
    useEffect(() => {
        dispatch(getGraphData({
            fromDate: moment().add(-14, 'days').format('YYYY-MM-DD'),
            toDate: moment().add(-7, 'days').format('YYYY-MM-DD'),
        })) 
    }, [dispatch])

    useEffect(() => { 
        console.log(data)
    }, [data])
    
    return (
        <>
            {loading ? "Loading..." : error ? error.message : <Chart
            width={'100%'}
            data={data}
            loader={<div>Loading Chart</div>}
            options={{
                title: 'Cumulative job views vs. predixtions',
                vAxis: { title: 'Job views' },
                hAxis: { direction: -1, slantedText: true, slantedTextAngle: 60, format: 'dd MMM'  },
                seriesType: 'bars',
                pointSize: 10,
                colors: ['#DDDDDD', '#38AFC8', '#9BC345'],
                legend: { position: 'bottom' },
                series: {
                    1: { type: 'line', pointShape: { type: 'circle', fillColor: "#FFF"}, lineDashStyle: [2, 2], },
                    2: { type: 'line', pointShape: 'circle' }
                }
            }}
            chartType="ComboChart"
            rootProps={{ 'data-testid': '2' }}
            />}
        </>
    )
}

export default Graph

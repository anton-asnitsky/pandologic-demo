import { combineReducers } from 'redux'
import graphDataReducer from './graphDataReducer'

export default combineReducers({
  graphData: graphDataReducer
})
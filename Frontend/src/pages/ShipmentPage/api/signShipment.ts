import axios from 'axios'
import { IShipmentData } from '../types/shipmentTypes'

export const signShipment = async (data: IShipmentData) => {
    try {
        const response = await axios.delete(`http://localhost:3000/shipment/${data.id}`)
        return response.data
    } catch (error) {
        console.error('Error signing shipment:', error)
    }
}
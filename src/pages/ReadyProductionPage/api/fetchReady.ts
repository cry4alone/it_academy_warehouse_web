import axios from "axios";
import { IReadyData } from "../types/readyTypes";

export const fetchReady = async (params?: {
    dateFrom?: string;
    dateTo?: string;
    controlScheme?: string;
  }): Promise<IReadyData[]> => {
    try {
     // Запрашиваем ВСЕ данные с сервера
    const response = await axios.get('http://localhost:3000/readyProduction');
    
    // Фильтруем на клиенте, если переданы параметры дат
    let filteredData = response.data;
    
    filteredData = filteredData.filter((item: IReadyData) => 
        (params?.dateFrom === undefined || item.date >= params.dateFrom) &&
        (params?.dateTo === undefined || item.date <= params.dateTo)
      );
    if (params?.controlScheme !== undefined) {
        filteredData = filteredData.filter((item : IReadyData) => 
            item.controlScheme.includes(params.controlScheme as string)
        );
    }
      
    
    return filteredData;
    } catch (error) {
      console.error('Error fetching ready:', error);
      return []; 
    }
  };
import axios from "axios";
import { IReadyData } from "../types/readyTypes";

export const fetchControlSchemes = async (): Promise<string[]> => {
    try {
      const response = await axios.get<IReadyData[]>('http://localhost:3000/readyProduction');
      const allSchemes = response.data.map((item: IReadyData) => item.controlScheme);
      return [...new Set(allSchemes)];
    } catch (error) {
      console.error('Error fetching control schemes:', error);
      return [];
    }
  };
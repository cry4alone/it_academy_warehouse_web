import { Label } from '../types/printTypes'; // Импортируем интерфейс Label

export const fetchLabels = async (): Promise<Label[]> => {
  const response = await fetch('http://localhost:3000/labels');
  const data = await response.json();
  return data; // Убедитесь, что data соответствует интерфейсу Label[]
};
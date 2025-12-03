import axios from 'axios';
import { IUserData } from '../types/usersTypes';

export const fetchUsers = async (username: string): Promise<IUserData[]> => {
    try {
        const response = await axios.get<IUserData[]>('http://localhost:3000/users', {
            params: { username },
        });
        return response.data;
    } catch (error) {
        console.error('Error fetching users:', error);
        throw error;
    }
};

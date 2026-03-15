import axios from 'axios';
import type { Category, Product, CreateCategoryCommand, UpdateCategoryCommand, CreateProductCommand, UpdateProductCommand } from '../types';

const API_BASE_URL = 'http://localhost:5008/api';

const api = axios.create({
    baseURL: API_BASE_URL,
    headers: {
        'Content-Type': 'application/json',
    },
});

export const categoryService = {
    getAll: () => api.get<Category[]>('/Categories'),
    getById: (id: number) => api.get<Category>(`/Categories/${id}`),
    create: (command: CreateCategoryCommand) => api.post<number>('/Categories', command),
    update: (id: number, command: UpdateCategoryCommand) => api.put<boolean>(`/Categories/${id}`, command),
    delete: (id: number) => api.delete<boolean>(`/Categories/${id}`),
};

export const productService = {
    getAll: () => api.get<Product[]>('/Products'),
    getById: (id: number) => api.get<Product>(`/Products/${id}`),
    create: (command: CreateProductCommand) => api.post<number>('/Products', command),
    update: (id: number, command: UpdateProductCommand) => api.put<boolean>(`/Products/${id}`, command),
    delete: (id: number) => api.delete<boolean>(`/Products/${id}`),
};

export default api;

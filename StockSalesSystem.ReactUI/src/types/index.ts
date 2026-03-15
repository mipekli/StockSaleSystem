export interface Category {
    id: number;
    name: string;
}

export interface Product {
    id: number;
    name: string;
    description: string;
    price: number;
    stock: number;
    categoryId: number;
    categoryName: string;
}

export interface CreateCategoryCommand {
    name: string;
}

export interface UpdateCategoryCommand {
    id: number;
    name: string;
}

export interface CreateProductCommand {
    name: string;
    description: string;
    price: number;
    stock: number;
    categoryId: number;
}

export interface UpdateProductCommand {
    id: number;
    name: string;
    description: string;
    price: number;
    stock: number;
    categoryId: number;
}

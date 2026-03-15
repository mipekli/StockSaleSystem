import React, { useEffect, useState } from 'react';
import { categoryService } from '../services/api';
import type { Category } from '../types';
import { Edit2, Trash2, Plus, Tags } from 'lucide-react';

const CategoryList: React.FC = () => {
  const [categories, setCategories] = useState<Category[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    loadCategories();
  }, []);

  const loadCategories = async () => {
    try {
      const response = await categoryService.getAll();
      setCategories(response.data);
    } catch (error) {
      console.error('Kategoriler yüklenirken hata oluştu:', error);
    } finally {
      setLoading(false);
    }
  };

  const deleteCategory = async (id: number) => {
    if (window.confirm('Bu kategoriyi silmek istediğinize emin misiniz?')) {
      try {
        await categoryService.delete(id);
        loadCategories();
      } catch (error) {
        alert('Kategori silinirken bir hata oluştu.');
      }
    }
  };

  if (loading) {
    return (
      <div className="flex justify-center items-center h-64">
        <div className="animate-spin rounded-full h-12 w-12 border-b-2 border-indigo-600"></div>
      </div>
    );
  }

  return (
    <div className="bg-white shadow-xl rounded-2xl overflow-hidden border border-gray-100">
      <div className="p-6 border-b border-gray-50 flex justify-between items-center bg-white">
        <div>
          <h2 className="text-2xl font-bold text-gray-800 flex items-center">
            <Tags className="mr-3 text-indigo-600" />
            Kategori Yönetimi
          </h2>
          <p className="text-sm text-gray-500 mt-1">Ürünlerinizi gruplandırmak için kategorileri kullanın.</p>
        </div>
        <button className="bg-indigo-600 hover:bg-indigo-700 text-white font-semibold py-2.5 px-5 rounded-xl transition-all duration-200 shadow-md hover:shadow-lg flex items-center active:scale-95">
          <Plus className="w-5 h-5 mr-2" />
          Yeni Kategori Ekle
        </button>
      </div>

      <div className="overflow-x-auto">
        <table className="min-w-full divide-y divide-gray-200">
          <thead className="bg-gray-50">
            <tr>
              <th className="px-6 py-4 text-left text-xs font-bold text-gray-500 uppercase tracking-wider w-24">ID</th>
              <th className="px-6 py-4 text-left text-xs font-bold text-gray-500 uppercase tracking-wider">Kategori Adı</th>
              <th className="px-6 py-4 text-right text-xs font-bold text-gray-500 uppercase tracking-wider">İşlemler</th>
            </tr>
          </thead>
          <tbody className="bg-white divide-y divide-gray-100">
            {categories.map((category) => (
              <tr key={category.id} className="hover:bg-indigo-50/30 transition-colors">
                <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-400 font-mono">#{category.id}</td>
                <td className="px-6 py-4 whitespace-nowrap">
                  <div className="text-sm font-semibold text-gray-900">{category.name}</div>
                </td>
                <td className="px-6 py-4 whitespace-nowrap text-right text-sm font-medium">
                  <div className="flex justify-end space-x-2">
                    <button className="p-2 text-indigo-600 hover:bg-indigo-100 rounded-lg transition-colors">
                      <Edit2 className="w-4 h-4" />
                    </button>
                    <button 
                      onClick={() => deleteCategory(category.id)}
                      className="p-2 text-red-600 hover:bg-red-100 rounded-lg transition-colors"
                    >
                      <Trash2 className="w-4 h-4" />
                    </button>
                  </div>
                </td>
              </tr>
            ))}
          </tbody>
        </table>

        {categories.length === 0 && (
          <div className="text-center py-20 bg-gray-50/50">
             <div className="inline-flex items-center justify-center w-16 h-16 rounded-full bg-gray-100 mb-4">
              <Tags className="w-8 h-8 text-gray-400" />
            </div>
            <h3 className="text-lg font-medium text-gray-900">Kategori bulunamadı</h3>
            <p className="text-gray-500">Henüz hiç kategori tanımlanmamış.</p>
          </div>
        )}
      </div>
    </div>
  );
};

export default CategoryList;

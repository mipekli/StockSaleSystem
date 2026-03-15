import React, { useEffect, useState } from 'react';
import { productService } from '../services/api';
import type { Product } from '../types';
import { Edit2, Trash2, Plus, Package } from 'lucide-react';

const ProductList: React.FC = () => {
  const [products, setProducts] = useState<Product[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    loadProducts();
  }, []);

  const loadProducts = async () => {
    try {
      const response = await productService.getAll();
      setProducts(response.data);
    } catch (error) {
      console.error('Ürünler yüklenirken hata oluştu:', error);
    } finally {
      setLoading(false);
    }
  };

  const deleteProduct = async (id: number) => {
    if (window.confirm('Bu ürünü silmek istediğinize emin misiniz?')) {
      try {
        await productService.delete(id);
        loadProducts();
      } catch (error) {
        alert('Ürün silinirken bir hata oluştu.');
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
            <Package className="mr-3 text-indigo-600" />
            Ürün Listesi
          </h2>
          <p className="text-sm text-gray-500 mt-1">Sistemdeki tüm ürünleri buradan yönetebilirsiniz.</p>
        </div>
        <button className="bg-indigo-600 hover:bg-indigo-700 text-white font-semibold py-2.5 px-5 rounded-xl transition-all duration-200 shadow-md hover:shadow-lg flex items-center active:scale-95">
          <Plus className="w-5 h-5 mr-2" />
          Yeni Ürün Ekle
        </button>
      </div>

      <div className="overflow-x-auto">
        <table className="min-w-full divide-y divide-gray-200">
          <thead className="bg-gray-50">
            <tr>
              <th className="px-6 py-4 text-left text-xs font-bold text-gray-500 uppercase tracking-wider">ID</th>
              <th className="px-6 py-4 text-left text-xs font-bold text-gray-500 uppercase tracking-wider">Ürün Bilgisi</th>
              <th className="px-6 py-4 text-left text-xs font-bold text-gray-500 uppercase tracking-wider">Kategori</th>
              <th className="px-6 py-4 text-left text-xs font-bold text-gray-500 uppercase tracking-wider">Fiyat</th>
              <th className="px-6 py-4 text-left text-xs font-bold text-gray-500 uppercase tracking-wider">Stok</th>
              <th className="px-6 py-4 text-right text-xs font-bold text-gray-500 uppercase tracking-wider">İşlemler</th>
            </tr>
          </thead>
          <tbody className="bg-white divide-y divide-gray-100">
            {products.map((product) => (
              <tr key={product.id} className="hover:bg-indigo-50/30 transition-colors">
                <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-400 font-mono">#{product.id}</td>
                <td className="px-6 py-4 whitespace-nowrap">
                  <div className="text-sm font-semibold text-gray-900">{product.name}</div>
                  <div className="text-xs text-gray-500">{product.description}</div>
                </td>
                <td className="px-6 py-4 whitespace-nowrap">
                  <span className="px-3 py-1 inline-flex text-xs leading-5 font-semibold rounded-full bg-blue-100 text-blue-800 border border-blue-200">
                    {product.categoryName || 'Genel'}
                  </span>
                </td>
                <td className="px-6 py-4 whitespace-nowrap text-sm text-indigo-600 font-bold">
                  {new Intl.NumberFormat('tr-TR', { style: 'currency', currency: 'TRY' }).format(product.price)}
                </td>
                <td className="px-6 py-4 whitespace-nowrap">
                  <div className={`text-sm font-medium ${product.stock <= 10 ? 'text-red-600' : 'text-gray-900'}`}>
                    {product.stock} Adet
                  </div>
                  {product.stock <= 10 && <div className="text-[10px] text-red-500 font-bold uppercase tracking-tighter">Düşük Stok!</div>}
                </td>
                <td className="px-6 py-4 whitespace-nowrap text-right text-sm font-medium">
                  <div className="flex justify-end space-x-2">
                    <button className="p-2 text-indigo-600 hover:bg-indigo-100 rounded-lg transition-colors" title="Düzenle">
                      <Edit2 className="w-4 h-4" />
                    </button>
                    <button 
                      onClick={() => deleteProduct(product.id)}
                      className="p-2 text-red-600 hover:bg-red-100 rounded-lg transition-colors" 
                      title="Sil"
                    >
                      <Trash2 className="w-4 h-4" />
                    </button>
                  </div>
                </td>
              </tr>
            ))}
          </tbody>
        </table>

        {products.length === 0 && (
          <div className="text-center py-20 bg-gray-50/50">
            <div className="inline-flex items-center justify-center w-16 h-16 rounded-full bg-gray-100 mb-4">
              <Package className="w-8 h-8 text-gray-400" />
            </div>
            <h3 className="text-lg font-medium text-gray-900">Ürün bulunamadı</h3>
            <p className="text-gray-500">Henüz hiç ürün eklenmemiş veya API bağlantısı sağlanamamış olabilir.</p>
          </div>
        )}
      </div>
    </div>
  );
};

export default ProductList;

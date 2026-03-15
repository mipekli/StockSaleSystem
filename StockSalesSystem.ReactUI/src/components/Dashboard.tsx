import React, { useEffect, useState } from 'react';
import { productService, categoryService } from '../services/api';
import { Box, Tags, TrendingUp, AlertCircle } from 'lucide-react';
import { Link } from 'react-router-dom';

const Dashboard: React.FC = () => {
    const [stats, setStats] = useState({ products: 0, categories: 0, lowStock: 0 });

    useEffect(() => {
        const fetchStats = async () => {
            try {
                const [p, c] = await Promise.all([productService.getAll(), categoryService.getAll()]);
                setStats({
                    products: p.data.length,
                    categories: c.data.length,
                    lowStock: p.data.filter(item => item.stock <= 10).length
                });
            } catch (error) {
                console.error('Stats error:', error);
            }
        };
        fetchStats();
    }, []);

    const cards = [
        { name: 'Toplam Ürün', value: stats.products, icon: Box, color: 'bg-blue-500', link: '/products' },
        { name: 'Kategoriler', value: stats.categories, icon: Tags, color: 'bg-indigo-500', link: '/categories' },
        { name: 'Düşük Stok', value: stats.lowStock, icon: AlertCircle, color: 'bg-red-500', link: '/products' },
        { name: 'Satış Potansiyeli', value: '%85', icon: TrendingUp, color: 'bg-emerald-500', link: '#' },
    ];

    return (
        <div className="space-y-6">
            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-6">
                {cards.map((card) => (
                    <Link key={card.name} to={card.link} className="block group">
                        <div className="bg-white p-6 rounded-2xl shadow-sm border border-gray-100 hover:shadow-md transition-all duration-300 transform group-hover:-translate-y-1">
                            <div className="flex items-center">
                                <div className={`${card.color} p-3 rounded-xl shadow-lg`}>
                                    <card.icon className="text-white w-6 h-6" />
                                </div>
                                <div className="ml-4">
                                    <p className="text-sm font-medium text-gray-500 uppercase tracking-wider">{card.name}</p>
                                    <h3 className="text-2xl font-bold text-gray-900">{card.value}</h3>
                                </div>
                            </div>
                        </div>
                    </Link>
                ))}
            </div>

            <div className="grid grid-cols-1 lg:grid-cols-2 gap-6">
                <div className="bg-white p-6 rounded-2xl shadow-sm border border-gray-100 min-h-[300px] flex flex-col justify-center items-center text-center">
                     <TrendingUp className="w-12 h-12 text-indigo-200 mb-4" />
                     <h3 className="text-lg font-bold text-gray-800">Hoş Geldiniz!</h3>
                     <p className="text-gray-500 max-w-sm">StockSalesSystem üzerinden tüm envanterinizi anlık olarak takip edebilir ve yönetebilirsiniz.</p>
                </div>
                <div className="bg-indigo-600 p-8 rounded-2xl shadow-lg text-white relative overflow-hidden group">
                    <div className="relative z-10">
                        <h3 className="text-2xl font-bold mb-2">Hızlı İşlem</h3>
                        <p className="text-indigo-100 mb-6">Hemen yeni bir kategori veya ürün ekleyerek envanterinizi genişletmeye başlayın.</p>
                        <div className="flex space-x-4">
                            <Link to="/products" className="bg-white text-indigo-600 px-6 py-2 rounded-xl font-bold shadow-md hover:bg-indigo-50 transition-colors">Yönet</Link>
                        </div>
                    </div>
                    <Box className="absolute -right-8 -bottom-8 w-48 h-48 text-indigo-500 opacity-20 transform rotate-12 group-hover:scale-110 transition-transform duration-500" />
                </div>
            </div>
        </div>
    );
};

export default Dashboard;

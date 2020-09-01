using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace _01_wpf_mvvm
{
    class ProductViewModel : BaseViewModel
    {
        private Product selectedProduct;
        private ObservableCollection<Product> products;
       

        public Product SelectedProduct
        {
            get => selectedProduct;
            set
            {
                selectedProduct = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Product> Products
        {
            get => products;
            set
            {
                products = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public ProductViewModel()
        {
            initValues();
        }

        private void initValues()
        {
            Products = new ObservableCollection<Product>
            {
                new Product { Name = "Patate", Price = 2.99, Stock = 50},
                new Product { Name = "Pomme", Price = 2.99, Stock = 50},
                new Product { Name = "Poire", Price = 2.99, Stock = 50},
                new Product { Name = "Piment", Price = 2.99, Stock = 50},
            };


        }


    }
}

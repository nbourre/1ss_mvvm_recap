using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

namespace _01_wpf_mvvm
{
    class ProductViewModel : BaseViewModel
    {
        private Product selectedProduct;
        private ObservableCollection<Product> products;

        public DelegateCommand<string> AddProductCommand { get; set; }
        public DelegateCommand<string> ClearSelectedCommand { get; set; }

        public Product SelectedProduct
        {
            get => selectedProduct;
            set
            {
                selectedProduct = value;
                OnPropertyChanged();
                AddProductCommand.RaiseCanExecuteChanged();
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
            initCommands();
            initValues();
        }

        private void initCommands()
        {
            AddProductCommand = new DelegateCommand<string>(AddProduct, CanAddProduct);
            ClearSelectedCommand = new DelegateCommand<string>(ClearSelected);
        }

        private bool CanAddProduct(string obj)
        {
            return SelectedProduct == null;
        }

        private void ClearSelected(string obj)
        {
            SelectedProduct = null;
        }

        private void AddProduct(string obj)
        {
            var currProduct = new Product { Name = "Undefinded" };
            Products.Add(currProduct);
            SelectedProduct = currProduct;
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

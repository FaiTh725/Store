using Store.Dal.Implementation;
using Store.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Store.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Props

        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string description;
        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private string shortDescription;
        public string ShortDescription
        {
            get => shortDescription;
            set
            {
                shortDescription = value;
                OnPropertyChanged(nameof(ShortDescription));
            }
        }

        private double price;
        public double Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        private string error;
        public string Error
        {
            get => error;
            set
            {
                error = value;
                OnPropertyChanged(nameof(Error));
            }
        }

        private ProductRepository repository;

        #endregion

        public BaseViewModel()
        {
            repository = new();
        }

        private void ClearFields()
        {
            Name = Description = ShortDescription = string.Empty;
            price = 0.0;

        }

        #region Commands
        private RelayCommand addProductCommand;
        public RelayCommand AddProductCommand
        {
            get
            {
                return addProductCommand ?? new RelayCommand(async obj =>
                {
                    Error = string.Empty;

                    var product = new Product()
                    {
                        Name = this.Name,
                        Description = this.Description,
                        ShortDescription = this.ShortDescription,
                        Price = this.Price,
                        Path = "12"
                    };

                    var response = await repository.Create(product);

                    if(!response)
                    {
                        Error = "Неверные данные";
                        return;
                    }


                });
            }
        }

        private RelayCommand minimizeWindowCommand;
        public RelayCommand MinimizeWindowCommand
        {
            get
            {
                return minimizeWindowCommand ?? new RelayCommand(obj =>
                {
                    if(Application.Current.MainWindow.WindowState == WindowState.Normal)
                    {
                        Application.Current.MainWindow.WindowState = WindowState.Minimized;
                    }
                    else
                    {
                        Application.Current.MainWindow.WindowState = WindowState.Normal;
                    }
                });
            }
        }

        private RelayCommand maximizeWindowCommand;
        public RelayCommand MaximizewindowCommand
        {
            get
            {
                return maximizeWindowCommand ?? new RelayCommand(obj =>
                {
                    if(Application.Current.MainWindow.WindowState == WindowState.Normal)
                    {
                        Application.Current.MainWindow.WindowState = WindowState.Maximized;
                    }
                    else if(Application.Current.MainWindow.WindowState == WindowState.Maximized)
                    {
                        Application.Current.MainWindow.WindowState = WindowState.Normal;
                    }
                });
            }
        }

        private RelayCommand closeWindowCommand;
        public RelayCommand CloseWindowCommand
        {
            get
            {
                return closeWindowCommand ?? new RelayCommand(obj =>
                {
                    Application.Current.Shutdown();
                    Application.Current.MainWindow.Close();
                });
            }
        }

        #endregion

        #region INPC
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion
    }
}

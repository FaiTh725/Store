using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Win32;
using Store.Dal.Implementation;
using Store.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

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

        private const string DefaultPath = @"\View\Images\DefaultImg.png";
        private string path;
        public string Path
        {
            get => path;
            set
            {
                path = value;
                OnPropertyChanged(nameof(Path));
            }
        }

        private string searchString = "Поиск по названию";
        public string SearchString
        {
            get => searchString;
            set
            {
                searchString = value;
                OnPropertyChanged(nameof(SearchString));
            }
        }

        private List<Product> products;
        public List<Product> Products
        {
            get => products;
            set
            {
                products = value;
                OnPropertyChanged("Products");
            }
        }

        private Product selectedProduct;
        public Product SelectedProduct
        {
            get => selectedProduct;
            set
            {
                selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        private ImageFile imageFile;

        private ProductRepository repository = new();

        #endregion

        public BaseViewModel()
        {
            products = repository.GetAll().ToList<Product>();
            
            Path = DefaultPath;
            
        }

        private void ClearFields()
        {
            Name = Description = ShortDescription = string.Empty;
            price = 0.0;
        }

        private Image ByArrayToImage(byte[] data)
        {
            using (var stream = new MemoryStream(data))
            {
                return Image.FromStream(stream);
            }
        }

        #region Commands
        private RelayCommand redactProductCommand;
        public RelayCommand RedactProductCommand
        {
            get
            {
                return redactProductCommand ?? new RelayCommand(async obj =>
                {
                    var response = await repository.Update(SelectedProduct);

                    if(response == true)
                    {
                        Products = repository.GetAll();
                    }
                });
            }
        }

        private RelayCommand refreshCommand;
        public RelayCommand RefreshComamnd
        {
            get
            {
                return refreshCommand ?? new RelayCommand(obj =>
                {
                    SearchString = "Поиск по названию";
                    Products = repository.GetAll();
                });
            }
        }

        private RelayCommand searchCommand;
        public RelayCommand SearchCommand
        {
            get
            {
                return searchCommand ?? new RelayCommand(async obj =>
                {
                    if(SearchString == string.Empty)
                    {
                        Products = repository.GetAll();
                    }

                    if(SearchString != "Поиск по названию")
                    {
                        var res = await repository.GetByName(SearchString);

                        Products = res.ToList();
                    }
                });
            }
        }

        private RelayCommand deleteteProductCommand;
        public RelayCommand DeleteteProductCommand
        {
            get
            {
                return deleteteProductCommand ?? new RelayCommand(async obj =>
                {
                    if(SelectedProduct != null)
                    {
                        var response = await repository.Delete(SelectedProduct);

                        if(response)
                        {
                            Products = repository.GetAll();
                        }
                    }
                });
            }
        }

        private RelayCommand uploadFileCommand;
        public RelayCommand UploadFileCommand
        {
            get
            {
                return uploadFileCommand ?? new RelayCommand(obj =>
                {   
                    OpenFileDialog dialog = new OpenFileDialog();

                    dialog.Filter = "Изображения (*.png) | *.png";
                    dialog.Title = "Выберите фото товара";
                    bool? result = dialog.ShowDialog();

                    if (result == true)
                    {
                        Path = dialog.FileName;

                        imageFile = new ImageFile()
                        {
                            FileName = dialog.SafeFileName,
                            ImageData = File.ReadAllBytes(dialog.FileName)
                        };
                    }
                });
            }
        }

        private RelayCommand addProductCommand;
        public RelayCommand AddProductCommand
        {
            get
            {
                return addProductCommand ?? new RelayCommand(async obj =>
                {
                    Error = string.Empty;

                    if (Name == string.Empty)
                    {
                        Error = "Поле имя пустое";
                        return;
                    }
                    if(Price < 0)
                    {
                        Error = "Cумма отрицательная";
                        return;
                    }

                    var product = new Product()
                    {
                        Name = this.Name,
                        Description = this.Description,
                        ShortDescription = this.ShortDescription,
                        Price = this.Price,
                        ImageFile = imageFile ?? new ImageFile()
                        {
                            FileName = "Default",
                            ImageData = await repository.GetDefaultImage()
                        }
                    };

                    var response = await repository.Create(product);

                    if (!response)
                    {
                        Error = "Данный товар уже добавлен";
                        return;
                    }
                    else
                    {
                        ClearFields();
                        Path = DefaultPath;
                        imageFile = new ImageFile()
                        {
                            FileName = "Default",
                            ImageData = await repository.GetDefaultImage()
                        };

                        Products = repository.GetAll();
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

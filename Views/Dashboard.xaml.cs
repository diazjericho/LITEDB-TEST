using LITEDB_TEST.Data.Database;
using LITEDB_TEST.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LITEDB_TEST {
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : UserControl {
        private LiteDbService _dbService = new LiteDbService();
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();
        public Dashboard() {
            InitializeComponent();
            DataContext = this;
            LoadUsers();
        }

        private void LoadUsers() {
            Users.Clear();
            foreach (var user in _dbService.GetUsers()) {
                Users.Add(user);
            }
        }

        private void AddUser(object sender, RoutedEventArgs e) {
            var addWindow = new AddUserWindow();
            if (addWindow.ShowDialog() == true) {
                _dbService.InsertUser(addWindow.NewUser);
                LoadUsers();
            }
        }


        //public ICommand UpdateCommand => new RelayCommand<User>(UpdateUser);
        //private void UpdateUser(User user) {
        //    var updateWindow = new UpdateUserWindow(user);
        //    if (updateWindow.ShowDialog() == true) {
        //        _dbService.UpdateUser(user);
        //        LoadUsers();
        //    }
        //}


        //public ICommand DeleteCommand => new RelayCommand<User>(DeleteUser);
        //private void DeleteUser(User user) {
        //    _dbService.DeleteUser(user.Id);
        //    LoadUsers();
        //}

        private void UpdateUser(object sender, RoutedEventArgs e) {
            if ((sender as Button)?.DataContext is User user) {
                var updateWindow = new UpdateUserWindow(user);
                if (updateWindow.ShowDialog() == true) {
                    _dbService.UpdateUser(user);
                    LoadUsers();
                }
            }
        }

        private void DeleteUser(object sender, RoutedEventArgs e) {
            if ((sender as Button)?.DataContext is User user) {
                var result = MessageBox.Show($"Are you sure you want to delete item '{user.Name}'? This cannot be undone.",
                                             "Confirm Deletion",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes) {
                    _dbService.DeleteUser(user.Id);
                    LoadUsers();
                }
            }
        }
    }
}
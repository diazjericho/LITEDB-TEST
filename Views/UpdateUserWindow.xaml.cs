using LITEDB_TEST.Data.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace LITEDB_TEST {
    /// <summary>
    /// Interaction logic for UpdateUserWindow.xaml
    /// </summary>
    public partial class UpdateUserWindow : Window {
        private User _user;

        public UpdateUserWindow(User user) {
            InitializeComponent();
            _user = user;
            NameTextBox.Text = user.Name;
            AgeTextBox.Text = user.Age.ToString();
        }

        private void UpdateUser(object sender, RoutedEventArgs e) {
            _user.Name = NameTextBox.Text;
            _user.Age = int.Parse(AgeTextBox.Text);
            DialogResult = true;
            Close();
        }
    }
}

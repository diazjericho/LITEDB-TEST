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
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window {
        public User NewUser { get; private set; }

        public AddUserWindow() {
            InitializeComponent();
        }

        private void SaveUser(object sender, RoutedEventArgs e) {
            NewUser = new User {
                Name = NameTextBox.Text,
                Age = int.Parse(AgeTextBox.Text)
            };
            DialogResult = true;
            Close();
        }
    }
}

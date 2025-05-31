using LiteDB;
using LITEDB_TEST.Data.Models;
using System.Collections.ObjectModel;
using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        

        public MainWindow() {
            InitializeComponent();
        }

        private void ShowDashboard(object sender, RoutedEventArgs e) {
            MainContent.Content = new Dashboard();
        }

        private void ShowHistory(object sender, RoutedEventArgs e) {
            var historyView = new History();
            using (var db = new LiteDatabase("MyDatabase.db")) {
                historyView.HistoryGrid.ItemsSource = db.GetCollection<HistoryRecord>("history").Query().ToList();
            }
            MainContent.Content = historyView;
        }

    }
}
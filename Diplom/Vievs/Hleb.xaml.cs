using Diplom.Utilit;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Diplom.Vievs
{
    /// <summary>
    /// Логика взаимодействия для Hleb.xaml
    /// </summary>
    public partial class Hleb : Page
    {
        public Hleb()
        {
            InitializeComponent();
            DGridSklad.ItemsSource = KREntities.GetContext().Hlebi.ToList();
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddHleb());
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var HlebiForRemoving = DGridSklad.SelectedItems.Cast<Hlebi>();

            if (MessageBox.Show($"Вы точно хотите удалить слудующие {HlebiForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    KREntities.GetContext().Hlebi.RemoveRange(HlebiForRemoving);
                    KREntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridSklad.ItemsSource = KREntities.GetContext().Hlebi.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                KREntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridSklad.ItemsSource = KREntities.GetContext().Hlebi.ToList();
            }
        }
    }
}
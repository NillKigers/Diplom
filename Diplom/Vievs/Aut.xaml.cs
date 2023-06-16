
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
    /// Логика взаимодействия для Aut.xaml
    /// </summary>
    public partial class Aut : Page
    {
        public Aut()
        {
            InitializeComponent();
            DGridPeople.ItemsSource = KREntities.GetContext().People.ToList();
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Reg());
        }

        private void Delete1_Click(object sender, RoutedEventArgs e)
        {
            var peopleForRemoving = DGridPeople.SelectedItems.Cast<People>();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {peopleForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    KREntities.GetContext().People.RemoveRange(peopleForRemoving);
                    KREntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGridPeople.ItemsSource = KREntities.GetContext().People.ToList();
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
                DGridPeople.ItemsSource = KREntities.GetContext().People.ToList();
            }
        }

        private void DGridPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                KREntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridPeople.ItemsSource = KREntities.GetContext().People.ToList();
            }
        }
    }
}

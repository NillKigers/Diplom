
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
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Page
    {
        private People _currentPeople = new People();
        public Reg()
        {
            InitializeComponent();
            DataContext = _currentPeople;
        }

        private void Add1_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentPeople.FIO))
                errors.AppendLine("Введите название хлеба");
            if (string.IsNullOrWhiteSpace(_currentPeople.NumberTel))
                errors.AppendLine("Введите дату изготовления");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentPeople.IdPeople == 0)
                KREntities.GetContext().People.Add(_currentPeople);
            try
            {
                KREntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}

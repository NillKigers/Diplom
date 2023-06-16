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
    /// Логика взаимодействия для AddHleb.xaml
    /// </summary>
    public partial class AddHleb : Page
    {
        private Hlebi _currentHlebi = new Hlebi();
        public AddHleb()
        {
            InitializeComponent();
            DataContext = _currentHlebi;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentHlebi.Nazvanie))
                errors.AppendLine("Введите вид хлеба");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentHlebi.IdHleb == 0)
                KREntities.GetContext().Hlebi.Add(_currentHlebi);
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
            public string Cena
        {
            get
            {
                return Cena + " руб";
            }
        }
        


    }
}


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

namespace KazLab02
{
    /// <summary>
    /// Логика взаимодействия для ProceedControl.xaml
    /// </summary>
    public partial class ProceedControl : UserControl
    {
        public ProceedControl()
        {
            InitializeComponent();
        }

        private void BProcced_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TbName.Text) || String.IsNullOrWhiteSpace(TbSurname.Text) || String.IsNullOrWhiteSpace(TbEmail.Text) || String.IsNullOrWhiteSpace(TbBirth.Text))
            {
                MessageBox.Show("Name or Surname or Email or Date of Birth is Empty!");
                return;
            }
            MessageBox.Show("Good!");
            //todo navigate to main control
        }
    }
}

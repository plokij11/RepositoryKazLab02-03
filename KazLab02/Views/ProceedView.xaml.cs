using KazLab02.ViewModels;
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

namespace KazLab02.Views
{
    /// <summary>
    /// Логика взаимодействия для ProceedControl.xaml
    /// </summary>
    public partial class ProceedView : UserControl
    {
        private ProceedViewModel _viewModel;
        public ProceedView()
        {
            InitializeComponent();
            DataContext = _viewModel = new ProceedViewModel();
        }

    }
}

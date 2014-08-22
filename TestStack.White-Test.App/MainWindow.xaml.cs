using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace TestStack.White_Test.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var dc = new OurViewModel
            {
                Models = new ObservableCollection<OurModel>
                {
                    new OurModel("1", "2", "3"),
                    new OurModel("4", "5", "6"),
                    new OurModel("7", "8", "9")
                }
            };
            DataContext = dc;
            InitializeComponent();
        }
    }

    public class OurViewModel
    {
        public ObservableCollection<OurModel> Models { get; set; }
    }

    public class OurModel
    {
        public string One { get; set; }
        public string Two { get; set; }
        public string Three { get; set; }

        public ObservableCollection<OurModel> Details { get; set; }

        public OurModel(string one, string two, string three)
        {
            One = one;
            Two = two;
            Three = three;
            Details = new ObservableCollection<OurModel>();
            Details.Add(this);
        }
    }
}

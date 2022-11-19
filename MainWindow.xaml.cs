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
using System.IO;


namespace myApp
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            pdfs.ItemsSource = myget();
            List<string> list = new List<string>();
            list.Add("R ערך");
            list.Add("G ערך");
            list.Add("מדד צפיפות");
            list.Add("מדד חום");
            comb.ItemsSource = list;
        }
        private List<string> myget()
        {
            DirectoryInfo d = new DirectoryInfo(@"C:\Users\User\PycharmProjects\pythonProject\showpdf");
            FileInfo[] Files = d.GetFiles("*.pdf"); //Getting Text files
            string str = "";
            List<string> list = new List<string>();
            foreach (FileInfo file in Files)
            {
                if (file.Name.StartsWith("basic"))
                    list.Add(file.Name);
            }
            return list;
        }
        private void myget(int val, string name)
        {
            DirectoryInfo d = new DirectoryInfo(@"C:\Users\User\PycharmProjects\pythonProject\showpdf");
            FileInfo[] Files = d.GetFiles("*.pdf"); //Getting Text files
            List<string> list = new List<string>();
            string m = name.Replace("basic", "").Replace(".pdf", "");
            foreach (FileInfo file in Files)
            {
                if (file.Name[file.Name.Length - 5].ToString() == (val + 1).ToString() && file.FullName.Contains(m))
                {
                    System.Diagnostics.Process.Start(file.FullName);
                }
            }
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bbb.Visibility = Visibility.Hidden;
        }
        private void comb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int val = comb.SelectedIndex;
            if (bbb.Visibility != Visibility.Collapsed)
            {
                myget(val, (string)pdfs.SelectedItem);
            }

        }
    }
}

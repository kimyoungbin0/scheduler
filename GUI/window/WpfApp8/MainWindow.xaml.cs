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

namespace WpfApp8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 



    public class Process
    {
        public string Name
        {
            get; set;
        }

        public int AT
        {
            get; set;
        }

        public int BT
        {
            get; set;
        }


    }

    public partial class MainWindow : Window
    {
        int process_num = 0;
        List<Process> process_list = new List<Process>();
        public static Dictionary<string, Process> model_dict = new Dictionary<string, Process>();
        TableColumn newColumn = new TableColumn();
        public MainWindow()
        {
            InitializeComponent();
            setting();
            myDataGrid.ItemsSource = process_list;
        }

        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void setting()
        {
            string[] core_items = { "OFF", "P-Core", "E-Core" };
            core0.ItemsSource = core_items;
            core1.ItemsSource = core_items;
            core2.ItemsSource = core_items;
            core3.ItemsSource = core_items;
            string[] scheduling_items = { "FCFS", "RR", "SPN", "SRTN", "HRRRN", "OWN" };
            scheduling.ItemsSource = scheduling_items;
        }
        public void addProccess(string name, int at, int wl)
        {
            Process process = new Process { Name = name, AT = at, BT = wl };

            process_list.Add(process);

            myDataGrid.Items.Refresh();

            process_name.Clear();
            arrival_Time.Clear();
            workload.Clear();

        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            string name = process_name.Text;
            int at = int.Parse(arrival_Time.Text);
            int wl = int.Parse(workload.Text);
            addProccess(name, at, wl);
        }

        private void Run_Button_Click(object sender, RoutedEventArgs e)
        {
            string scheduling = core0.SelectedItem.ToString();
            string core_0 = core0.SelectedItem.ToString();
            string core_1 = core1.SelectedItem.ToString();
            string core_2 = core2.SelectedItem.ToString();
            string core_3 = core3.SelectedItem.ToString();
            for(int n=0; n < process_num; n++)
            {

            }
        }
    }
}

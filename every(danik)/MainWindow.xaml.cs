using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO.Enumeration;
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

namespace every_danik_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Construct> AllTips = new();
        List<Construct> SetTips = new();
        List<string> nameoftips = new(); 
        public int index_of_selected_item = 0;
        public string filename = "json1.json";
        public MainWindow()
        {
            InitializeComponent();
            DateList.SelectedDate = DateTime.Today;
            Construct tip = new(Name_input.Text, DateList.SelectedDate.Value, Value_input.Text);
            ListofTips.ItemsSource = SetTips;
            AllTips = jsonchik.Deser<List<Construct>>("json1.json");
        }

        private void Build_Tip_Click(object sender, RoutedEventArgs e)
        {
            Construct new_tip = new(Name_input.Text, DateList.SelectedDate.Value, Value_input.Text);
            AllTips.Add(new_tip);
            Name_input.Text = "";
            Value_input.Text = "";

        }

        private void ListofTips_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            index_of_selected_item = ListofTips.SelectedIndex;
            Name_input.Text= SetTips[index_of_selected_item].name;
            Value_input.Text= SetTips[index_of_selected_item].value;
        }
        private void Apply_Click(object sender, RoutedEventArgs e)
        {

           
            SetTips[index_of_selected_item].name = Name_input.Text;
            SetTips[index_of_selected_item].value= Value_input.Text;
            foreach(var c in AllTips)
            {
                if(c.name== Name.Text && c.value == Value.Text)
                {
                    c.name= Name_input.Text;
                    c.value= Value_input.Text;
                    break;
                }
            }
            jsonchik.Ser(AllTips, "json1.json");



        }

        private void Delete_Tip_Click(object sender, RoutedEventArgs e)
        {
            SetTips.RemoveAt(index_of_selected_item);
            foreach (var c in AllTips)
            {
                if (c.name == Name.Text && c.value == Value.Text)
                {
                    AllTips.Remove(c);
                    break;
                }
            }

            jsonchik.Ser(AllTips, filename );

        }


        private void DateList_SelectedDateChanged(object sender, SelectionChangedEventArgs e)

        {
            Construct tip = new(Name_input.Text, DateList.SelectedDate.Value, Value_input.Text);
            SetTips = AllTips.Where(x => x.date.Date == Convert.ToDateTime(DateList.Text)).ToList();
            ListofTips.ItemsSource = SetTips;





        }

    }
}

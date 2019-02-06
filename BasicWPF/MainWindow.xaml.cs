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

namespace BasicWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Student stu;

        public MainWindow()
        {
            InitializeComponent();

            //准备数据源
            stu = new Student();

            //准备Binding
            Binding binding = new Binding();
            binding.Source = stu;
            binding.Path = new PropertyPath("Name");

            //使用Binding连接数据源与Binding目标
            BindingOperations.SetBinding(this.textBoxName, TextBox.TextProperty, binding);

            List<string> stringList = new List<string> { "Tim", "Tom", "Blog" };
            //this.textBox2.SetBinding(TextBox.TextProperty, new Binding("/") { Source = stringList });
            //this.textBox3.SetBinding(TextBox.TextProperty, new Binding("/Length") { Source = stringList,Mode=BindingMode.OneWay });
            //this.textBox4.SetBinding(TextBox.TextProperty, new Binding("/[2]") { Source = stringList, Mode = BindingMode.OneWay });

            //binding
            City city = new City { Name = "成都" };
            Province province = new Province { Name = "四川省",CityList=new List<City> { city} };
            Country country = new Country { Name = "中国", ProvinceList = new List<Province> { province } };
            List<Country> countryList = new List<Country>() { country };

            textBox2.SetBinding(TextBox.TextProperty, new Binding("/Name") { Source = countryList });
            textBox3.SetBinding(TextBox.TextProperty, new Binding("/ProvinceList/Name") { Source = countryList });
            textBox4.SetBinding(TextBox.TextProperty, new Binding("/ProvinceList/CityList/Name") { Source = countryList });
            


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            stu.Name += "Name";
        }
    }
    //相关类型

    class City
    {
        public string Name { get; set; }
    }

    class Province
    {
        public string Name { get; set; }
        public List<City> CityList { get; set; }
    }

    class Country
    {
        public string Name { get; set; }
        public List<Province> ProvinceList { get; set; }
    }
}

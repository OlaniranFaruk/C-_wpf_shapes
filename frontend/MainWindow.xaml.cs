using System;
using System.Collections.ObjectModel;
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

using machine;
using cube;
using cylinder;
using sphere;
using System.IO;

namespace frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    

    public partial class MainWindow : Window
    {
        public ObservableCollection<Machine> listOfMachines{get; set;} = new ObservableCollection<Machine>();
        public String userInput {get; set;}
        public String searchParam {get; set;}
        

        public MainWindow()
        {
            InitializeComponent();
            currentStatus.Content = "Idle";

            AddCubeButton.Click += createNewCube;
            AddCylinderButton.Click += createNewCylinder;
            AddSphereButton.Click += createNewSphere;

            CalculatePriceButton.Click += calculatePrice;
            ShowInfoButton.Click += showInfo;
            CalculateTotalVolumeButton.Click += calculateTotalVolume;
            OrderAscButton.Click += sortAscending;
            OrderDescButton.Click += sortDecending;
            SearchButton.Click +=  search;
            SaveButton.Click += saveToFile;


            this.DataContext = this;
        }

        public async void saveToFile(object sender, RoutedEventArgs e)
        {
            // string allMachineToString;
            // StreamWriter file = new("Json.txt", append: true);
        
            // foreach (Machine m in listOfMachines)
            // {
            //     allMachineToString = m.ToString();
            //     await file.WriteLineAsync(allMachineToString);
            // }
            // MessageBox.Show("Saved successfully!");
        }
        public void search(object sender, RoutedEventArgs e)
        {
            Machine result = listOfMachines.Where(m => m.name.Equals(searchParam)).FirstOrDefault();
            MessageBox.Show("The volume of part for " + result.name + " is " + result.volume );
        }
        public void sortAscending(object sender, RoutedEventArgs e)
        {
            List<Machine> tmpList = new List<Machine>();
            for (int i = 0; i < listOfMachines.Count; i++)
            {
                tmpList[i] = listOfMachines[i];
            }
            tmpList.Sort();
            for (int i = 0; i < listOfMachines.Count; i++)
            {
                listOfMachines[i] = tmpList[i];
            }
        }
        public void sortDecending(object sender, RoutedEventArgs e)
        {
            List<Machine> tmpList = new List<Machine>();
            for (int i = 0; i < listOfMachines.Count; i++)
            {
                tmpList[i] = listOfMachines[i];
            }
            tmpList.Sort((x, y) => y.CompareTo(x));
            for (int i = 0; i < listOfMachines.Count; i++)
            {
                listOfMachines[i] = tmpList[i];
            }
        }



        public void calculateTotalVolume(object sender, RoutedEventArgs e)
        {
            double totalVolume = listOfMachines.Sum(m => m.volume);

            MessageBox.Show("The total volume is : " + totalVolume);
        }

        public void showInfo(object sender, RoutedEventArgs e)
        {
            String info = Parts.SelectedItems[0].ToString();
            MessageBox.Show(info);
        }

        public void calculatePrice(object sender, RoutedEventArgs e)
        {
            double totalPrice ;
            for(int i = 0; i < listOfMachines.Count ; i++)
            {
                if (Parts.SelectedItems[0].Equals(listOfMachines[i]))
                {
                    totalPrice = listOfMachines[i].price * listOfMachines[i].volume;
                    MessageBox.Show("The price is : " + totalPrice);
                }
                
            }
            
        }

        public void createNewCube(object sender, RoutedEventArgs e)
        {
            var inputData = userInput.Split(',');
            if (inputData[1].Equals(typeof(string)))
            {
                MessageBox.Show("\"Size\" is not a number");
            }else{
                Cube c = new Cube(inputData[0], Int32.Parse(inputData[1]) );
                listOfMachines.Add(c);
                MessageBox.Show("Part Ready");
            }

        }
        public void createNewCylinder(object sender, RoutedEventArgs e)
        {
            var inputData = userInput.Split(',');
            if (inputData.Length != 3 || inputData[1].Equals(typeof(string)) || inputData[2].Equals(typeof(string)))
            {
                MessageBox.Show("Invalid input, enter \"name , radius, height \" ");
            }else {
                Cylinder cl = new Cylinder(inputData[0], Int32.Parse(inputData[1]), Int32.Parse(inputData[2]));
                listOfMachines.Add(cl);
                MessageBox.Show("Part Ready");
            }

        }
        public void createNewSphere( object sender, RoutedEventArgs e)
        {
            var inputData = userInput.Split(',');
            if (inputData[1].Equals(typeof(string)))
            {
                MessageBox.Show("Radius is not a number");
            }else{
                Sphere s = new Sphere(inputData[0], Int32.Parse(inputData[1]));
                listOfMachines.Add(s);
                MessageBox.Show("Part Ready");
            }

        }


    }
}

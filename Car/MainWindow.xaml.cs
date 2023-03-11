using Car.DB;
using Car.Models;
using Microsoft.EntityFrameworkCore;
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

namespace Car
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SuperClass db = new SuperClass();

        public MainWindow()
        {
            InitializeComponent()
            var CartList = db.Carss.Include(x => x.CarShowroom).ToList();
            dataGridView1.ItemsSource = db.Carss.Local.ToBindingList();
        }

        public List<Cars> GetAllStudents()
        {
            return db.Carss.Include(e => e.CarShowroom).ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Name_textbox.Text.Length > 1 && Model_textbox.Text.Length > 1)
            {
                db.Students.Add(new Students { Name = Name_textbox.Text, Models = Model_textbox.Text });
                db.SaveChanges();
                dataGridView1.ItemsSource = GetAllStudents();
            }
            else
            {
                MessageBox.Show("Enter the name || surname");
            }

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            var selectedStudent = dataGridView1.SelectedItem as Cars;
            var findStudent = db.Carss.Find(selectedStudent.Id);
            findStudent!.Name = selectedStudent.Name;
            findStudent.Model = selectedStudent.Model;
            db.SaveChanges();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var selectedStudent = dataGridView1.SelectedItem as Cars;
            if (selectedStudent != null)
            {
                var student = db.Carss.Find(selectedStudent.Id);
                db.Carss.Remove(student!);
                db.SaveChanges();
                dataGridView1.ItemsSource = GetAllStudents();
            }
            else MessageBox.Show("Select a student");

        }
    }
}

using CRUD_Academy.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

namespace CRUD_Academy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SuperClass db = new SuperClass();

        public MainWindow()
        {
            InitializeComponent();
            dataGridView1.ItemsSource = db.Students.ToList();
        }

        public List<Academy> GetAllStudents()
        {
            return db.Students.ToList();
        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {
            //string.IsNullOrEmpty(Name_textbox.Text) && string.IsNullOrEmpty(Surname_textbox.Text)
            if (Name_textbox.Text.Length > 1 && Surname_textbox.Text.Length > 1)
            {
                db.Students.Add(new Academy { Name = Name_textbox.Text, Surname = Surname_textbox.Text });
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
            var selectedStudent = dataGridView1.SelectedItem as Academy;
            var findStudent = db.Students.Find(selectedStudent.Id);
            findStudent!.Name = selectedStudent.Name;
            findStudent.Surname = selectedStudent.Surname;
            db.SaveChanges();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var selectedStudent = dataGridView1.SelectedItem as Academy;
            if (selectedStudent != null)
            {
                var student = db.Students.Find(selectedStudent.Id);
                db.Students.Remove(student!);
                db.SaveChanges();
                dataGridView1.ItemsSource = GetAllStudents();
            }
            else MessageBox.Show("Select a student");
        }
    }
}

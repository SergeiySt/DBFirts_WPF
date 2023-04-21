using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Policy;
using System.Security.RightsManagement;
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

namespace LsitPhone
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        db_list_phoneEntities db;

        public MainWindow()
        {
            InitializeComponent();
           
            db = new db_list_phoneEntities();

            comboBoxCountry.ItemsSource = db.Country.ToList();

            db.ListPhone.Include(a => a.Country).Load();
            phonesGrid.ItemsSource = db.ListPhone.Local.ToBindingList();

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (phonesGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < phonesGrid.SelectedItems.Count; i++)
                {
                    ListPhone phone = phonesGrid.SelectedItems[i] as ListPhone;
                    if (phone != null)
                    {
                        db.ListPhone.Remove(phone);
                    }
                }
            }
            db.SaveChanges();
            phonesGrid.ItemsSource = db.ListPhone.ToList();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string surName = LSurName.Text;
            string name = LName.Text;
            string pobatkovi = LPobatkovi.Text;
            string email = LEmail.Text;
            int countryId = (int)comboBoxCountry.SelectedValue;
            int phone = int.Parse(LPhone.Text);

            DateTime? dateOfBirth = LDateBrith.SelectedDate;
           
            ListPhone listPhone = new ListPhone
            {
                LSurname = surName,
                LName = name,
                LPobatkovi = pobatkovi,
                LEmail = email,
                id_country = countryId,
                LPhone = phone,
                LDateBrith = (DateTime)dateOfBirth,
                LAddDate = DateTime.Today
            };

            using (var db = new db_list_phoneEntities())
            {
                db.ListPhone.Add(listPhone);
                db.SaveChanges();              
            }

            phonesGrid.ItemsSource = db.ListPhone.ToList();
        }   
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
            phonesGrid.ItemsSource = db.ListPhone.ToList();
        }
    }
}

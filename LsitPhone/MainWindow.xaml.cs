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
            if (phonesGrid.SelectedItems.Count == 0)
            {
                MessageBox.Show("Виберіть запис для видалення.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

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

            ClearFields();
            //id.Text = "";
            //LSurName.Text = "";
            //LName.Text = "";
            //LPobatkovi.Text = "";
            //LEmail.Text = "";
            //comboBoxCountry.SelectedIndex = 0;
            //LPhone.Text = "";
            //LDateBrith.Text = "";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (!CanAddPhone())
            {
                MessageBox.Show("Заповніть всі поля перед додаванням запису!", "Примітка", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            string surName = LSurName.Text;
            string name = LName.Text;
            string pobatkovi = LPobatkovi.Text;
            string email = LEmail.Text;
            int countryId = (int)comboBoxCountry.SelectedValue;
            int phone = int.Parse(LPhone.Text);

            DateTime? dateOfBirth = LDateBrith.SelectedDate;

            int phoneValue;
            if (!int.TryParse(LPhone.Text, out phoneValue))
            {
                MessageBox.Show("Введіть правильний номер телефона", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (db.ListPhone.Any(x => x.LSurname == LSurName.Text
                && x.LName == LName.Text
                && x.LPobatkovi == LPobatkovi.Text
                && x.LEmail == LEmail.Text
                && x.LPhone == phoneValue
                && x.Country.id_country == ((Country)comboBoxCountry.SelectedItem).id_country
                && x.LDateBrith == LDateBrith.SelectedDate))
                
            {
          
                MessageBox.Show("Запис із такими ж даними вже існує.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

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

            ClearFields();
            //id.Text = "";
            //LSurName.Text = "";
            //LName.Text = "";
            //LPobatkovi.Text = "";
            //LEmail.Text = "";
            //comboBoxCountry.SelectedIndex = 0;
            //LPhone.Text = "";
            //LDateBrith.Text = "";
        }   
        private void ClearFields()
        {
            id.Text = "";
            LSurName.Text = "";
            LName.Text = "";
            LPobatkovi.Text = "";
            LEmail.Text = "";
            comboBoxCountry.SelectedIndex = 0;
            LPhone.Text = "";
            LDateBrith.Text = "";
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (phonesGrid.SelectedItem != null && CanAddPhone())
            {
                ListPhone selectedPhone = phonesGrid.SelectedItem as ListPhone;

                selectedPhone.LSurname = LSurName.Text;
                selectedPhone.LName = LName.Text;
                selectedPhone.LPobatkovi = LPobatkovi.Text;
                selectedPhone.LEmail = LEmail.Text;
                selectedPhone.id_country = (int)comboBoxCountry.SelectedValue;
                selectedPhone.LPhone = int.Parse(LPhone.Text);
                selectedPhone.LDateBrith = (DateTime)LDateBrith.SelectedDate;

                db.SaveChanges();
                phonesGrid.ItemsSource = db.ListPhone.ToList();

                ClearFields();
                //id.Text = "";
                //LSurName.Text = "";
                //LName.Text = "";
                //LPobatkovi.Text = "";
                //LEmail.Text = "";
                //comboBoxCountry.SelectedIndex = 0;
                //LPhone.Text = "";
                //LDateBrith.Text = "";
            }
            else
            {
                MessageBox.Show("Неможливо оновити запис. Перевірте, чи всі поля заповнені та вибрано запис в таблиці.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool CanAddPhone()
        {
            return !string.IsNullOrEmpty(LSurName.Text)
                && !string.IsNullOrEmpty(LName.Text)
                && !string.IsNullOrEmpty(LPobatkovi.Text)
                && !string.IsNullOrEmpty(LEmail.Text)
                 && int.TryParse(LPhone.Text, out int phoneValue)
                && comboBoxCountry.SelectedValue != null;
        }
        private void phonesGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (phonesGrid.SelectedItem != null)
            {
                ListPhone selectedPhone = phonesGrid.SelectedItem as ListPhone;
                if (selectedPhone != null)
                {
                    id.Text = selectedPhone.id_listphone.ToString();
                    LSurName.Text = selectedPhone.LSurname;
                    LName.Text = selectedPhone.LName;
                    LPobatkovi.Text = selectedPhone.LPobatkovi;
                    LEmail.Text = selectedPhone.LEmail;
                    comboBoxCountry.SelectedItem = comboBoxCountry.Items.Cast<Country>().FirstOrDefault(x => x.id_country == selectedPhone.Country.id_country);
                    int phoneValue;
                    if (int.TryParse(selectedPhone.LPhone.ToString(), out phoneValue))
                    {
                        LPhone.Text = phoneValue.ToString();
                    }
                    else
                    {
                        // Обробка помилки перетворення
                    }
                    LDateBrith.SelectedDate = selectedPhone.LDateBrith;
                }
               
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            WAbout wAbout = new WAbout();
            wAbout.Owner = this;
            wAbout.ShowDialog();
        }
    }
}

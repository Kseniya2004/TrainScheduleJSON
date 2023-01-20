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
using TrainSchedule.Classes;
using System.IO;
using Newtonsoft.Json;

namespace TrainSchedule.Pages
{
    /// <summary>
    /// Логика взаимодействия для PagePessenger.xaml
    /// </summary>
    public partial class PagePessenger : Page
    {
        public PagePessenger()
        {
            InitializeComponent();
            DgridPes.ItemsSource = Train_scheduleEntities.GetTrain().Pessenger.ToList();
        }       

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new PagePesEdit(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var usersForRemoving = DgridPes.SelectedItems.Cast<Pessenger>().ToList();
            if (MessageBox.Show($"Удалить {usersForRemoving.Count()} пассажиров?", "Внимание!",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                try
                {
                    Train_scheduleEntities.GetTrain().Pessenger.RemoveRange(usersForRemoving);
                    Train_scheduleEntities.GetTrain().SaveChanges();
                    MessageBox.Show("Данные удалены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            DgridPes.ItemsSource = Train_scheduleEntities.GetTrain().Pessenger.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new PagePesEdit((sender as Button).DataContext as Pessenger));
        }

        private void BtnTicket_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new PageTicket());
        }

        private void BtnSchedule_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new PageTrain());
        }

        private void BtnSerialize_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("input.json", string.Empty); // Удаление содержимого файла
            foreach (var ps in Train_scheduleEntities.GetTrain().Pessenger)//Переберание записей в таблице Note
            {
                Pessenger p = new Pessenger()
                {
                    fio = ps.fio,
                    passport = ps.passport,
                    phone = ps.phone
                };
                File.AppendAllText("input.json", JsonConvert.SerializeObject(p)); //Запись Записи в файл

            }
                

            if("input.json" == null)
            {
                MessageBox.Show("Данные не записаны", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }            
            MessageBox.Show("Данные записаны", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void BtnDeserialize_Click(object sender, RoutedEventArgs e)
        {
            List<Pessenger> ntttt = new List<Pessenger>();//Список записок
            JsonTextReader reader = new JsonTextReader(new StreamReader("input.json"));//Открытие файла
            reader.SupportMultipleContent = true;
            while (reader.Read())//Пока не закончатся записи
            {
                JsonSerializer serializer = new JsonSerializer();
                Pessenger temp_point = serializer.Deserialize<Pessenger>(reader); // 1 записка
                if (temp_point.fio.Contains(tbFilt.Text)) //Отображение по совпадению с поиском
                    ntttt.Add(temp_point);
            }
            string s = "";
            foreach (Pessenger p in ntttt)
            {
                s +=p.fio + ": " + p.phone + "\n";
            }
            MessageBox.Show(s);

        }
    }
}

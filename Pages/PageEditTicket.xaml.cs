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

namespace TrainSchedule.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageEditTicket.xaml
    /// </summary>
    public partial class PageEditTicket : Page
    {
        private Ticket Ticket = new Ticket();
        public PageEditTicket(Ticket selectesTicket)
        {
            InitializeComponent();
            if (selectesTicket != null)
                Ticket = selectesTicket;
            DataContext = Ticket;

            CmbNum.ItemsSource = Train_scheduleEntities.GetTrain().Train.ToList();
            CmbNum.SelectedValuePath = "id";
            CmbNum.DisplayMemberPath = "num";

            CmbPassenger.ItemsSource = Train_scheduleEntities.GetTrain().Pessenger.ToList();
            CmbPassenger.SelectedValuePath = "id";
            CmbPassenger.DisplayMemberPath = "fio";
        }

        private void BtnSave1_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();//Объект ошибка

            if (string.IsNullOrWhiteSpace(Ticket.price.ToString()))
                error.AppendLine("Укажите стоимость");
            if (string.IsNullOrWhiteSpace(Ticket.idTrain.ToString()))
                error.AppendLine("Укажите номер поезда");
            if (string.IsNullOrWhiteSpace(Ticket.idPassenger.ToString()))
                error.AppendLine("Укажите ФИО пассажира");                       
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            //Если пользователь новый
            if (Ticket.id == 0)
                Train_scheduleEntities.GetTrain().Ticket.Add(Ticket);//Добавить его 
            try
            {
                Train_scheduleEntities.GetTrain().SaveChanges(); //Сохранить изменения
                                                                 //ZooparkEntities.GetZoopark().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                MessageBox.Show("Данные сохранены");
                ClassFrame.frmObj.Navigate(new PageTicket());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}

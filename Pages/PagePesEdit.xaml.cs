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
    /// Логика взаимодействия для PagePesEdit.xaml
    /// </summary>
    public partial class PagePesEdit : Page
    {
        private Pessenger Pessenger = new Pessenger();
        public PagePesEdit(Pessenger selectesPes)
        {
            InitializeComponent();
            if (selectesPes != null)
                Pessenger = selectesPes;
            DataContext = Pessenger;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();//Объект ошибка

            if (string.IsNullOrWhiteSpace(Pessenger.fio))
                error.AppendLine("Укажите стоимость");
            if (string.IsNullOrWhiteSpace(Pessenger.passport))
                error.AppendLine("Укажите номер поезда");
            if (string.IsNullOrWhiteSpace(Pessenger.phone))
                error.AppendLine("Укажите ФИО пассажира");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            //Если пользователь новый
            if (Pessenger.id == 0)
                Train_scheduleEntities.GetTrain().Pessenger.Add(Pessenger);//Добавить его 
            try
            {
                Train_scheduleEntities.GetTrain().SaveChanges(); //Сохранить изменения
                                                                 //ZooparkEntities.GetZoopark().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                MessageBox.Show("Данные сохранены");
                ClassFrame.frmObj.Navigate(new PagePessenger());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}

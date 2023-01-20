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
    /// Логика взаимодействия для PageEdit.xaml
    /// </summary>
    public partial class PageEdit : Page
    {
        private Train Train = new Train();
        public PageEdit(Train selectedTrain)
        {
            InitializeComponent();
            if (selectedTrain != null)
                Train = selectedTrain;
            DataContext = Train;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();//Объект ошибка

            if (string.IsNullOrWhiteSpace(Train.des))
                error.AppendLine("Укажите пункт назначения");
            if (string.IsNullOrWhiteSpace(Train.dep_point))
                error.AppendLine("Укажите пункт отправления");
            if (string.IsNullOrWhiteSpace(Train.num.ToString()))
                error.AppendLine("Укажите номер поезда");
            if (string.IsNullOrWhiteSpace(Train.dep_time.ToString()))
                error.AppendLine("Укажите время отправления");
            if (string.IsNullOrWhiteSpace(Train.trav_time.ToString()))
                error.AppendLine("Укажите время в пути");
            if (string.IsNullOrWhiteSpace(Train.stations))
                error.AppendLine("Укажите станции");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            //Если пользователь новый
            if (Train.id == 0)
                Train_scheduleEntities.GetTrain().Train.Add(Train);//Добавить его 
            try
            {
                Train_scheduleEntities.GetTrain().SaveChanges(); //Сохранить изменения
                                                        //ZooparkEntities.GetZoopark().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            MessageBox.Show("Данные сохранены");
            ClassFrame.frmObj.Navigate(new PageTrain());
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
}
    }
}

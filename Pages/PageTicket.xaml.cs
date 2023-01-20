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
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace TrainSchedule.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageTicket.xaml
    /// </summary>
    public partial class PageTicket : Page
    {
        public PageTicket()
        {
            InitializeComponent();
            //привязка таблицы            
            DgridTicket.ItemsSource = Train_scheduleEntities.GetTrain().Ticket.ToList();
        }

        private void BtnExcel_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook wb = excelApp.Workbooks.Open($"{Directory.GetCurrentDirectory()}\\Отчёт по продажам.xlsx");
            Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[1];
            ws.Cells[1, 6] = DateTime.Now.ToString();            
            int indexRows = 1;
            
            //ячейка
            ws.Cells[1][indexRows] = "Номер";            
            ws.Cells[2][indexRows] = "Номер поезда";
            ws.Cells[3][indexRows] = "ФИО";    
            ws.Cells[4][indexRows] = "Цена";

            //список пользователей из таблицы после фильтрации и поиска
            var printItems = DgridTicket.Items;
            //цикл по данным из списка для печати
            foreach (Ticket item in printItems)
            {
                ws.Cells[1][indexRows + 1] = indexRows;   
                ws.Cells[2][indexRows + 1] = item.Train.num.ToString();                
                ws.Cells[3][indexRows + 1] = item.Pessenger.fio;                
                ws.Cells[4][indexRows + 1] = item.price;
                

                indexRows++;
            }
            Excel.Range range = ws.Range[ws.Cells[2][indexRows + 1], ws.Cells[5][indexRows + 1]];
            range.ColumnWidth = 15; //ширина столбцов
            range.Font.Italic = true;
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;//выравнивание по левому краю

            ws.Cells[3, 6] = "Итого:";
            ws.Cells[3, 7].Formula = $"=SUM(D:D)";
            ws.Cells[indexRows + 2, 3] = "Подпись";
            ws.Cells[indexRows + 2, 5] = "Немтырёва К.А.";
            excelApp.Visible = true;
        }

        private void BtnAdd1_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new PageEditTicket(null));
        }

        private void BtnDelete1_Click(object sender, RoutedEventArgs e)
        {
            var usersForRemoving1 = DgridTicket.SelectedItems.Cast<Ticket>().ToList();
            if (MessageBox.Show($"Удалить {usersForRemoving1.Count()} билеты?", "Внимание!",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                try
                {
                    Train_scheduleEntities.GetTrain().Ticket.RemoveRange(usersForRemoving1);
                    Train_scheduleEntities.GetTrain().SaveChanges();
                    MessageBox.Show("Данные удалены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            DgridTicket.ItemsSource = Train_scheduleEntities.GetTrain().Ticket.ToList();
        }

        private void BtnEdit1_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new PageEditTicket((sender as Button).DataContext as Ticket));
        }

        private void BtnPessenger_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new PagePessenger());
        }

        private void BtnSchedule_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.frmObj.Navigate(new PageTrain());
        }       
    }
}

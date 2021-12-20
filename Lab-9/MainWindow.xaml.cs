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

namespace Lab_9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Movies[] movies;
        string[,] matrix;
        public MainWindow()
        {
            InitializeComponent();
            movies = new Movies[8];
            matrix = new string[7,4];

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    matrix[i, j] = string.Empty; 
                }
            }
        }

        private void Добавить_Click(object sender, RoutedEventArgs e)
        {

            if (int.TryParse(Id.Text, out int id) && Name.Text != string.Empty &&
                Type.Text != string.Empty && int.TryParse(Year.Text, out int year) &&
                int.TryParse(Time.Text, out int time) && id > 0 && id <= 7)
            {
                for (int j = 0; j <= 7; j++)
                {
                    movies[j]._name = Name.Text;
                    movies[j]._type = Type.Text;
                    movies[j]._year = year;
                    movies[j]._time = time;
                }

                matrix[id-1, 0] = movies[id-1]._name;
                matrix[id-1, 1] = movies[id-1]._type;
                matrix[id-1, 2] = movies[id-1]._year.ToString();
                matrix[id-1, 3] = movies[id-1]._time.ToString();
                dataGrid.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
                dataGrid.Columns[0].Header = "Название";
                dataGrid.Columns[1].Header = "Жанр";
                dataGrid.Columns[2].Header = "Год выпуска";
                dataGrid.Columns[3].Header = "Продолжительность";
            }
            else
            {
              MessageBox.Show("Поля не запонены или заполнены с ошибками");
            }

        }

        private void Удалить_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Id.Text, out int id) && id > 0 && id <= 7)
            {
                matrix[id - 1, 0] = string.Empty;
                matrix[id - 1, 1] = string.Empty;
                matrix[id - 1, 2] = string.Empty;
                matrix[id - 1, 3] = string.Empty;
                dataGrid.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
                dataGrid.Columns[0].Header = "Название";
                dataGrid.Columns[1].Header = "Жанр";
                dataGrid.Columns[2].Header = "Год выпуска";
                dataGrid.Columns[3].Header = "Продолжительность";
            }
            else
            {
                MessageBox.Show("Номер строки не выбран  или выбран неправильно");
            }
        }

        private void Поиск_Click(object sender, RoutedEventArgs e)
        {
            string rez = string.Empty;

            if (SearchType.Text != string.Empty)
            {

                for (int i = 0; i < 7; i++)
                {

                    if (matrix[i, 1] == SearchType.Text)
                    {
                        Rez.Text += $" {matrix[i, 0]} {matrix[i, 1]} {matrix[i, 2]} {matrix[i, 3]} \n";
                    }

                }

            }
            else
            {
                MessageBox.Show("Поле не заполнено");
            }
        }

        private void Сброи_Click(object sender, RoutedEventArgs e)
        {
            Rez.Clear();
            SearchType.Clear();
        }

        private void Id_TextChanged(object sender, TextChangedEventArgs e)
        {
            Name.Clear();
            Type.Clear();
            Year.Clear();
            Time.Clear();
        }

        private void Rez_TextChanged(object sender, TextChangedEventArgs e)
        {
            Rez.Clear();
        }

        private void Выход_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void О_программе_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Заполнить таблицу фильмотеки на 7 кассет с полями: фильм, жанр, год выпуска," +
                "продолжительность просмотра.Вывести результат на экран.Вывести список фильмов заданного жанра.");
        }
    }
}

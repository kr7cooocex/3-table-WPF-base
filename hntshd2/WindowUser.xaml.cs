using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace hntshd
{
    /// <summary>
    /// Логика взаимодействия для WindowUser.xaml
    /// </summary>
    /// 

    class FirstRecord2

    {

        public int TourID { get; set; }

        public string Destination { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Decimal Price { get; set; }


        public FirstRecord2(int TourID, string Destination, DateTime StartDate, DateTime EndDate, Decimal Price)

        {
            this.TourID = TourID;

            this.Destination = Destination;

            this.StartDate = StartDate;

            this.EndDate = EndDate;

            this.Price = Price;
        }
    }
    public partial class WindowUser : Window
    {
        SqlConnection conn;

        SqlCommand cmd;

        SqlDataAdapter adapter;

        DataTable dt;

        String ConnStr = $"Data Source= {GetSomeRest.datasourse} ; Database=Melnichenko; Integrated Security=True; TrustServerCertificate=True";

        String SelectText = "Select * From Tours ";
        String InsertText = "Insert Into Tours Values " +
             " ( @TourID , @Destination , @StartDate , @EndDate, @Price ) ";
        String UpdateText = "Update Tours Set " +
                  " Destination = @Destination , " +
                  " StartDate = @StartDate , " +
                  " EndDate = @EndDate , " +
                  " Price = @Price " +
                  " Where TourID = @TourID ";
        String DeleteText = "Delete From Tours " +
                    " Where TourID = @TourID";





        List<FirstRecord2> FirstRecordList;

        int i, n;
        public WindowUser()
        {
            InitializeComponent();
        }
        void Refresh()
        {

            dg.ItemsSource = null;

            conn = new SqlConnection();

            conn.ConnectionString = ConnStr;

            cmd = new SqlCommand();

            cmd.Connection = conn;

            cmd.CommandText = SelectText;

            adapter = new SqlDataAdapter();

            adapter.SelectCommand = cmd;

            dt = new DataTable();

            FirstRecordList = new List<FirstRecord2>();

            adapter.Fill(dt);

            for (i = 0; i <= dt.Rows.Count - 1; i++)

                FirstRecordList.Add(new FirstRecord2((int)dt.Rows[i][0],
                                            (string)dt.Rows[i][1],
                                            (DateTime)dt.Rows[i][2],
                                            (DateTime)dt.Rows[i][3],
                                            (Decimal)dt.Rows[i][4]
                                          )
                              );

            dg.ItemsSource = FirstRecordList;

            FirstRecordList = null;

            GC.Collect();
        }
        private void ESelect_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
        private void EInsert_Click(object sender, RoutedEventArgs e)
        {
            conn = new SqlConnection();

            conn.ConnectionString = ConnStr;

            cmd = new SqlCommand();

            cmd.Connection = conn;

            cmd.CommandText = SelectText;

            adapter = new SqlDataAdapter();

            adapter.SelectCommand = cmd;

            cmd.CommandText = InsertText;

            cmd.Parameters.Add("@TourID", SqlDbType.Int).Value = int.Parse(tb_TourID.Text);
            cmd.Parameters.Add("@Destination", SqlDbType.VarChar, 50).Value = tb_Destination.Text;
            cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = DP_StartDate.Text;
            cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = DP_EndDate.Text;
            cmd.Parameters.Add("@Price", SqlDbType.VarChar, 50).Value = tb_Price.Text;
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                adapter.InsertCommand = cmd;
                adapter.Update(dt);
            }
        }


        private void EUpdate_Click(object sender, RoutedEventArgs e)

        {

            conn = new SqlConnection();

            conn.ConnectionString = ConnStr;

            cmd = new SqlCommand();

            cmd.Connection = conn;

            cmd.CommandText = UpdateText;

            adapter = new SqlDataAdapter();

            adapter.SelectCommand = cmd;

            dt = new DataTable();

            cmd.Parameters.Add("@TourID", SqlDbType.Int).Value = int.Parse(tb_TourID.Text);
            cmd.Parameters.Add("@Destination", SqlDbType.VarChar, 50).Value = tb_Destination.Text;
            if (DP_StartDate.SelectedDate.HasValue)
            {
                cmd.Parameters.Add("@StartDate", SqlDbType.DateTime).Value = DP_StartDate.SelectedDate.Value;
            }
            else
            {
                throw new ArgumentException("Укажите дату в поле StartDate");
            }
            if (DP_EndDate.SelectedDate.HasValue)
            {
                cmd.Parameters.Add("@EndDate", SqlDbType.DateTime).Value = DP_EndDate.SelectedDate.Value;
            }
            else
            {
                throw new ArgumentException("Укажите дату в поле EndDate");
            }

            adapter.Fill(dt);

            int selectedIndex = dg.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < dt.Rows.Count)
            {
                DataRow row = dt.Rows[selectedIndex];


                row["TourID"] = int.Parse(tb_TourID.Text);
                row["Destination"] = tb_Destination.Text;
                row["StartDate"] = DP_StartDate.Text;
                row["EndDate"] = (DP_EndDate.SelectedDate.Value).ToString();


                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd)) //пасхалко
                {
                    adapter.Fill(dt);
                }


                using (SqlDataAdapter adapter = new SqlDataAdapter()) // пасхалко
                {
                    adapter.InsertCommand = cmd;
                    adapter.Update(dt);
                }


                Refresh();
            }
            else
            {
                MessageBox.Show("Изменения внесены.");
            }
        }
        private void EDelete_Click(object sender, RoutedEventArgs e)
        {
            conn = new SqlConnection();

            conn.ConnectionString = ConnStr;

            cmd = new SqlCommand();

            cmd.Connection = conn;

            cmd.CommandText = SelectText;

            adapter = new SqlDataAdapter();

            adapter.SelectCommand = cmd;

            dt = new DataTable();

            adapter.Fill(dt);

            cmd.CommandText = DeleteText;

            cmd.Parameters.Add("@TourID", SqlDbType.Int, 4, "TourID");

            n = dg.SelectedIndex;

            dt.Rows[n].Delete();

            adapter.DeleteCommand = cmd;

            adapter.Update(dt);

            Refresh();

        }
        private void dg_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            n = dg.SelectedIndex;
            if (n == -1) return;

            tb_TourID.Text = Convert.ToString(dt.Rows[n][0]);

            tb_Destination.Text = (string)dt.Rows[n][1];

            DP_StartDate.SelectedDate = (DateTime)dt.Rows[n][2];

            DP_EndDate.SelectedDate = (DateTime)dt.Rows[n][3];

            tb_Price.Text = Convert.ToString(dt.Rows[n][4]);

        }
        private void EAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Data base Петренко 03-1ИСП", "Туристическая фирма");
        }

        private void EBookings_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Windows.OfType<Clients>().Any())
            {
                Bookings window = Application.Current.Windows.OfType<Bookings>().First();
                window.Activate();
            }
            else
            {
                Bookings window = new Bookings();
                window.Show();
            }
        }

        private void EClients_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Windows.OfType<Clients>().Any())
            {
                Clients window = Application.Current.Windows.OfType<Clients>().First();
                window.Activate();
            }
            else
            {
                Clients window = new Clients();
                window.Show();
            }
        }
    }

}


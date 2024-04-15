using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace hntshd
{
    /// <summary>
    /// Логика взаимодействия для Bookings.xaml
    /// </summary>
    /// 
    class FirstRecord3

    {

        public int BookingID { get; set; }

        public int ClientID { get; set; }

        public int TourID { get; set; }

        public DateTime BookingDate { get; set; }


        public FirstRecord3(int BookingID, int ClientID, int TourID, DateTime BookingDate)

        {
            this.BookingID = TourID;

            this.ClientID = ClientID;

            this.TourID = TourID;

            this.BookingDate = BookingDate;

        }
    }
    public partial class Bookings : Window
    {
        SqlConnection conn;

        SqlCommand cmd;

        SqlDataAdapter adapter;

        DataTable dt;

        String ConnStr = $"Data Source= DESKTOP-1RVQ73F ; Database=Melnichenko; Integrated Security=True; TrustServerCertificate=True";

        String SelectText = "Select * From Bookings ";
        String InsertText = "Insert Into Bookings Values " +
             " ( @BookingID , @ClientID , @TourID , @BookingDate ) ";
        String UpdateText = "Update Melnichenko Set " +
                  " ClientID = @ClientID , " +
                  " TourID = @TourID , " +
                  " BookingDate = @BookingDate , " +
                  " Where BookingID = @BookingID ";
        String DeleteText = "Delete From Bookings " +
                    " Where BookingID = @BookingID";





        List<FirstRecord3> FirstRecordList;

        int i, n;
        public Bookings()
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

            FirstRecordList = new List<FirstRecord3>();

            adapter.Fill(dt);

            for (i = 0; i <= dt.Rows.Count - 1; i++)

                FirstRecordList.Add(new FirstRecord3((int)dt.Rows[i][0],
                                            (int)dt.Rows[i][1],
                                            (int)dt.Rows[i][2],
                                            (DateTime)dt.Rows[i][3]
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

            cmd.Parameters.Add("@BookingID", SqlDbType.Int).Value = int.Parse(tb_ClientID.Text);
            cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = int.Parse(tb_ClientID.Text);
            cmd.Parameters.Add("@TourID", SqlDbType.Int).Value = int.Parse(tb_ClientID.Text);
            cmd.Parameters.Add("@BookingDate", SqlDbType.Date).Value = DP_BookingDate.Text;
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

            cmd.Parameters.Add("@BookingID", SqlDbType.Int).Value = int.Parse(tb_BookingID.Text);
            cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = int.Parse(tb_ClientID.Text);
            cmd.Parameters.Add("@TourID", SqlDbType.Int).Value = int.Parse(tb_ClientID.Text);
            cmd.Parameters.Add("@BookingDate", SqlDbType.Date).Value = DP_BookingDate.Text;

            adapter.Fill(dt);

            int selectedIndex = dg.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < dt.Rows.Count)
            {
                DataRow row = dt.Rows[selectedIndex];


                row["BookingID"] = int.Parse(tb_BookingID.Text);
                row["ClientID"] = int.Parse(tb_ClientID.Text);
                row["TourID"] = int.Parse(tb_TourID.Text);
                row["BookingDate"] = DP_BookingDate.Text;


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

            cmd.Parameters.Add("@BookingID", SqlDbType.Int, 4, "BookingID");

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

            tb_BookingID.Text = Convert.ToString(dt.Rows[n][0]);

            tb_ClientID.Text = Convert.ToString(dt.Rows[n][1]);

            tb_TourID.Text = Convert.ToString(dt.Rows[n][2]);

            DP_BookingDate.SelectedDate = (DateTime)dt.Rows[n][3];

        }
        private void EAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Data base Петренко 03-1ИСП", "Туристическая фирма");
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

        private void ETours_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Windows.OfType<WindowUser>().Any())
            {
                WindowUser window = Application.Current.Windows.OfType<WindowUser>().First();
                window.Activate();
            }
            else
            {
                WindowUser window = new WindowUser();
                window.Show();
            }
        }
    }

}

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
    /// Логика взаимодействия для Clients.xaml
    /// </summary>
    /// 

    class FirstRecord1

    {

        public int ClientID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }


        public FirstRecord1(int ClientID, string Name, string Email, string Phone)

        {
            this.ClientID = ClientID;

            this.Name = Name;

            this.Email = Email;

            this.Phone = Phone;

        }
    }
    public partial class Clients : Window
    {
        SqlConnection conn;

        SqlCommand cmd;

        SqlDataAdapter adapter;

        DataTable dt;

        String ConnStr = $"Data Source= DESKTOP-1RVQ73F ; Database=Melnichenko; Integrated Security=True; TrustServerCertificate=True";

        String SelectText = "Select * From Clients ";
        String InsertText = "Insert Into Clients Values " +
             " ( @TourID , @Destination , @StartDate , @EndDate, @Price ) ";
        String UpdateText = "Update Clients Set " +
                  " Name = @Name , " +
                  " Email = @Email , " +
                  " Phone = @Phone , " +
                  " Where ClientID = @ClientID ";
        String DeleteText = "Delete From Clients " +
                    " Where ClientID = @ClientID";





        List<FirstRecord1> FirstRecordList;

        int i, n;
        public Clients()
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

            FirstRecordList = new List<FirstRecord1>();

            adapter.Fill(dt);

            for (i = 0; i <= dt.Rows.Count - 1; i++)

                FirstRecordList.Add(new FirstRecord1((int)dt.Rows[i][0],
                                            dt.Rows[i][1].ToString(),
                                            dt.Rows[i][2].ToString(),
                                            dt.Rows[i][3].ToString()
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

            cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = int.Parse(tb_ClientID.Text);
            cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = tb_Name.Text;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = tb_Email.Text;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 15).Value = tb_Phone.Text;
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

            cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = int.Parse(tb_ClientID.Text);
            cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = tb_Name.Text;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = tb_Email.Text;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 15).Value = tb_Phone.Text;

            adapter.Fill(dt);

            int selectedIndex = dg.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < dt.Rows.Count)
            {
                DataRow row = dt.Rows[selectedIndex];


                row["ClientID"] = int.Parse(tb_ClientID.Text);
                row["Name"] = tb_Name.Text;
                row["Email"] = tb_Email.Text;
                row["Phone"] = tb_Phone.Text;


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

            cmd.Parameters.Add("@ClientID", SqlDbType.Int, 4, "ClientID");

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

            tb_ClientID.Text = Convert.ToString(dt.Rows[n][0]);

            tb_Name.Text = (string)dt.Rows[n][1];

            tb_Email.Text = (string)dt.Rows[n][2];

            tb_Phone.Text = (string)dt.Rows[n][3];

        }
        private void EAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Data base Петренко 03-1ИСП", "Туристическая фирма");
        }

        private void EBookings_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Windows.OfType<Bookings>().Any())
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

        private void EWindowUser_Click(object sender, RoutedEventArgs e)
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



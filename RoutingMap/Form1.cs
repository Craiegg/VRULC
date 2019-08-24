using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;

namespace RoutingMap
{
    public partial class Form1 : Form
    {
        string keyWord;
        double d;
        List<PointLatLng> points = new List<PointLatLng>();

        //Database Connection String

        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Craiegg\source\repos\RoutingMap\Database\CustomerDB.mdf;Integrated Security=True;Connect Timeout=30");
        public Form1()
        {
            InitializeComponent();
        }
        // Saving Data to Database on Save button click
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                // Opening a stored procedure command instance

                SqlCommand sqlCmd = new SqlCommand("AddOrEdit", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                // Adding values from form into database

                sqlCmd.Parameters.AddWithValue("@mode", "Add");
                sqlCmd.Parameters.AddWithValue("@ContactID", "0");
                sqlCmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@NumberOfProd", txtProducts.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Success");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }

            // Closing connection on completion

            finally
            {
                sqlCon.Close();
            }
        }

        private void GMapControl1_Load(object sender, EventArgs e)
        {

        }
    }
}

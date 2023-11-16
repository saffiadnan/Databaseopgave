using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Databaseopgave
{
    public partial class FacilitiesFacilityIDlbl : Form
    {
        SqlConnection conn;
        SqlCommand cmd;

        public FacilitiesFacilityIDlbl()
        {
            InitializeComponent();
        }







        private void FacilitiesFacilityIDlbl_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=LAPTOP-UEO6NG04;Initial Catalog=MyDatabase;Integrated Security=True");
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }

        private void InsertFacilitiesBtn_Click(object sender, EventArgs e)
        {
            string query = $"insert into Facilities values('{txtFacilityId.Text.ToString()}','{txtHotelNo.Text}','{txtFacilityName.Text}','{txtDescription.Text.ToString()}')";
            cmd.CommandText = query;
            conn.Open();
            cmd.ExecuteNonQuery();
            cleardata();
            conn.Close();
            displaydata();
        }
        private void cleardata()
        {
            txtFacilityId.Clear();
            txtHotelNo.Clear();
            txtFacilityName.Clear();
            txtDescription.Clear();
        }

        private void UpdateFacilitiesBtn_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Facility set Facility Id='" + txtFacilityId.Text + "',Hotel No='" + txtHotelNo.Text + "',Facility Name='" + txtFacilityName.Text.ToString() + "' where Description='" + txtDescription.Text.ToString() + "' ";
            cmd.ExecuteNonQuery();
            conn.Close();
            displaydata();
            cleardata();
        }

        private void ShowAllFacilitiesBtn_Click(object sender, EventArgs e)
        {
            displaydata();
        }
        private void displaydata()
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Facilities";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewFacilities.DataSource = dt;
            conn.Close();
        }

        private void DeleteFacilitiesBtn_Click(object sender, EventArgs e)
        {
            string query = $"delete Facilities where Facility Id='{txtFacilityId.Text.ToString()}'";
            cmd.CommandText = query;
            conn.Open();
            cmd.ExecuteNonQuery();
            dataGridViewFacilities.DataSource= query;
            cleardata();
            conn.Close();
            displaydata();
        }

        private void FindFacilitiesBtn_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Facilities where Facility Id='" + FindBarFacilities.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            txtHotelNo.Text = dt.ToString();
            txtFacilityName.Text = dt.ToString();
            txtDescription.Text = dt.ToString();
            dataGridViewFacilities.DataSource = dt;
            conn.Close();
        }

        private void ExitFacilitiesBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    }


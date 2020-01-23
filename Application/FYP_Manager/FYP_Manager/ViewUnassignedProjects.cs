﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FYP_Manager
{
    public partial class ViewUnassignedProjects : Form
    {
        SqlConnection Connection = new SqlConnection(@"Data Source=DESKTOP-DA331OV\SQLEXPRESS;Initial Catalog=FYP_ProjectDB;Integrated Security=True");
        int Fac_ID = -1;
        public ViewUnassignedProjects(int F_ID)
        {
            InitializeComponent();
            Fac_ID = F_ID;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void ViewUnassignedProjects_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection.Open();
            SqlCommand CMD = new SqlCommand("sp_Faculty_See_His_Unassigned_Project", Connection);
            CMD.Parameters.AddWithValue("@F_ID", SqlDbType.Int).Value = Fac_ID;
            CMD.CommandType = CommandType.StoredProcedure;
            DataTable DT = new DataTable();
            DT.Load(CMD.ExecuteReader());
            dataGridView_1.DataSource = DT;
            Connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

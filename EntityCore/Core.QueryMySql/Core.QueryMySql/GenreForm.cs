using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Core.QueryMySql
{
    public partial class GenreForm : Form
    {
        private bool NewMode;

        public GenreForm()
        {
            InitializeComponent();
            LoadTable();
            NewMode = false;
        }

        private void LoadTable()
        {
            using (MySqlConnection con = new MySqlConnection(Tools.GetConnectionString()))
            {
                // Calling stored procedure
                String storedProcedure = "select_all_genres";
                MySqlCommand cmd = new MySqlCommand(storedProcedure, con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Get data
                DataTable dataTable = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
                adapter.Update(dataTable);

                // Load table
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dgvGenre.DataSource = bindingSource;

                // Select first row
                dgvGenre.Rows[0].Selected = true;
            }
        }

        private void dgvGenre_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvGenre.SelectedRows)
            {
                txtId.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
            }
            NewMode = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewMode = true;
            txtId.Text = "";
            txtName.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string genreId = txtId.Text;
            string genreName = txtName.Text;
            if (!string.IsNullOrEmpty(genreName))
            {
                if (NewMode)
                {
                    // Create
                    using (MySqlConnection con = new MySqlConnection(Tools.GetConnectionString()))
                    {
                        con.Open();
                        MySqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "insert into genre(GenreName) VALUES(@genreName)";
                        cmd.Parameters.AddWithValue("@genreName", genreName);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                else
                {
                    // Update, using transaction
                    using (MySqlConnection con = new MySqlConnection(Tools.GetConnectionString()))
                    {
                        con.Open();
                        using (MySqlTransaction tran = con.BeginTransaction())
                        {
                            MySqlCommand cmd = con.CreateCommand();
                            cmd.Transaction = tran;
                            cmd.CommandText = "update genre set GenreName=@genreName where GenreId=@genreId";
                            cmd.Parameters.AddWithValue("@genreId", genreId);
                            cmd.Parameters.AddWithValue("@genreName", genreName);
                            cmd.ExecuteNonQuery();
                            tran.Commit();
                        }
                        con.Close();
                    }
                }
                LoadTable();
            }
        }
    }
}

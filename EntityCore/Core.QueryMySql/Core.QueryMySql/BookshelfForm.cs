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
    public partial class BookshelfForm : Form
    {
        private bool NewMode;

        public BookshelfForm()
        {
            InitializeComponent();
            LoadTable();
            NewMode = false;
        }

        private void LoadTable()
        {
            using (MySqlConnection con = new MySqlConnection(Tools.GetConnectionString()))
            {
                // Create sql
                String sql = "select * from bookshelf";
                MySqlCommand cmd = new MySqlCommand(sql, con);

                // Get data
                DataTable dataTable = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(dataTable);
                adapter.Update(dataTable);

                // Load table
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dgvBookshelf.DataSource = bindingSource;

                // Select first row
                dgvBookshelf.Rows[0].Selected = true;
            }
        }

        private void bookshelfGridView_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvBookshelf.SelectedRows)
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
            string bookshelfId = txtId.Text;
            string bookshelfName = txtName.Text;
            if (!string.IsNullOrEmpty(bookshelfName))
            {
                if (NewMode)
                {
                    // Create
                    using (MySqlConnection con = new MySqlConnection(Tools.GetConnectionString()))
                    {
                        con.Open();
                        MySqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "insert into bookshelf(BookShelfName) VALUES(@bookshelfName)";
                        cmd.Parameters.AddWithValue("@bookshelfName", bookshelfName);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                else
                {
                    // Update
                    using (MySqlConnection con = new MySqlConnection(Tools.GetConnectionString()))
                    {
                        con.Open();
                        MySqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "update bookshelf set BookShelfName=@bookshelfName where BookShelfId=@bookshelfId";
                        cmd.Parameters.AddWithValue("@bookshelfId", bookshelfId);
                        cmd.Parameters.AddWithValue("@bookshelfName", bookshelfName);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                LoadTable();
            }
        }
    }
}

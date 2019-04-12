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
    public partial class LibraryManagementForm : Form
    {
        public LibraryManagementForm()
        {
            InitializeComponent();
        }

        private void bookshelfBtn_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["BookshelfForm"] as BookshelfForm) == null)
            {
                BookshelfForm form = new BookshelfForm();
                form.Show();
            }
        }

        private void bookBtn_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["BookForm"] as BookForm) == null)
            {
                BookForm form = new BookForm();
                form.Show();
            }
        }

        private void genreBtn_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["GenreForm"] as GenreForm) == null)
            {
                GenreForm form = new GenreForm();
                form.Show();
            }
        }

        private void btnDemoAsync_Click(object sender, EventArgs e)
        {
            if ((Application.OpenForms["SyncAsyncForm"] as SyncAsyncForm) == null)
            {
                SyncAsyncForm form = new SyncAsyncForm();
                form.Show();
            }
        }
    }
}

using Core.QueryMySql.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using static Core.QueryMySql.Tools;

namespace Core.QueryMySql
{
    public partial class BookForm : Form
    {
        private bool NewMode;

        public BookForm()
        {
            InitializeComponent();
            LoadTable();
            LoadBookShelf();
            NewMode = false;
        }

        private void LoadBookShelf()
        {
            using (var context = new LibraryDbContext())
            {
                var bookshelfList = from bookshelf in context.BookShelf select bookshelf;
                var bookshelfCbList = bookshelfList.ToList().Select(bs => new ComboboxItem()
                {
                    Value = bs.BookShelfId,
                    Text = bs.BookShelfName
                }).ToList();
                cbBookShelf.DataSource = bookshelfCbList;
            }
        }

        private void LoadTable()
        {
            using (var context = new LibraryDbContext())
            {
                var bookList = from book in context.Book select book;
                dgvBook.DataSource = bookList.ToList();

                // Select first row
                dgvBook.Rows[0].Selected = true;
            }
        }

        private void dgvBook_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvBook.SelectedRows)
            {
                txtId.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtGrade.Text = row.Cells[2].Value.ToString();
                dtpPuslishedDate.Value = DateTime.ParseExact(
                    row.Cells[3].Value.ToString(), "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);

                // Set bookshelf
                var bookId = Convert.ToInt32(row.Cells[0].Value.ToString());
                this.SetBookShelf(bookId);

                // Set genres
                SetGenres(bookId);
            }
            NewMode = false;
        }

        private void SetBookShelf(int bookId)
        {
            using (var context = new LibraryDbContext())
            {
                var query = from b in context.Book join bs in context.BookShelf
                                on b.BookShelfId equals bs.BookShelfId
                            where b.BookId == bookId
                            select bs;

                var bookshelf = query.FirstOrDefault();
                cbBookShelf.SelectedIndex = cbBookShelf.FindStringExact(bookshelf.BookShelfName);
            }
        }

        private void SetGenres(int bookId)
        {
            List<Genre> availableList = SetSelectedListBox(bookId);
            SetAvailableListBox(availableList);
        }

        private List<Genre> SetSelectedListBox(int bookId)
        {
            using (var context = new LibraryDbContext())
            {
                var query = from b in context.Book
                            join bg in context.BookGenre
                                on b.BookId equals bg.BookId
                            join g in context.Genre
                                on bg.GenreId equals g.GenreId
                            where b.BookId == bookId
                            orderby g.GenreName
                            select g;
                var selectedList = query.ToList();

                var list = new List<ListBoxItem>();
                foreach (var genre in selectedList)
                {
                    list.Add(new ListBoxItem()
                    {
                        Value = genre.GenreId,
                        Text = genre.GenreName
                    });
                }
                lbGenre2.DataSource = list;

                return selectedList;
            } 
        }

        private void SetAvailableListBox(List<Genre> selectedList)
        {
            using (var context = new LibraryDbContext())
            {
                IQueryable<Genre> query = null;
                if (selectedList != null && selectedList.Any())
                {
                    query = from g in context.Genre
                            where !selectedList.Select(a => a.GenreId).Contains(g.GenreId)
                            orderby g.GenreName
                            select g;
                }
                else
                {
                    query = from g in context.Genre
                            orderby g.GenreName select g;
                }
                
                var availableList = query.ToList();

                var list = new List<ListBoxItem>();
                foreach (var genre in availableList)
                {
                    list.Add(new ListBoxItem()
                    {
                        Value = genre.GenreId,
                        Text = genre.GenreName
                    });
                }
                lbGenre1.DataSource = list;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var selectedItem = (ListBoxItem) lbGenre1.SelectedItem;
            if (selectedItem != null)
            {
                var availableList = (List<ListBoxItem>)lbGenre1.DataSource;
                availableList.Remove(selectedItem);
                lbGenre1.DataSource = null;
                lbGenre1.DataSource = availableList.OrderBy(g => g.Text).ToList();

                var selectedList = (List<ListBoxItem>)lbGenre2.DataSource;
                selectedList.Add(selectedItem);
                lbGenre2.DataSource = null;
                lbGenre2.DataSource = selectedList.OrderBy(g => g.Text).ToList();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var selectedItem = (ListBoxItem)lbGenre2.SelectedItem;
            if (selectedItem != null)
            {
                var selectedList = (List<ListBoxItem>)lbGenre2.DataSource;
                selectedList.Remove(selectedItem);
                lbGenre2.DataSource = null;
                lbGenre2.DataSource = selectedList.OrderBy(g => g.Text).ToList();

                var availableList = (List<ListBoxItem>)lbGenre1.DataSource;
                availableList.Add(selectedItem);
                lbGenre1.DataSource = null;
                lbGenre1.DataSource = availableList.OrderBy(g => g.Text).ToList();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewMode = true;
            txtId.Text = "";
            txtName.Text = "";
            txtGrade.Text = "";
            dtpPuslishedDate.Value = DateTime.Now;
            cbBookShelf.SelectedIndex = 0;

            SetAvailableListBox(null);
            List<ListBoxItem> newList = new List<ListBoxItem>();
            lbGenre2.DataSource = newList;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string bookId = txtId.Text;
            string bookName = txtName.Text;
            
            if (!string.IsNullOrEmpty(bookName))
            {
                if (NewMode)
                {
                    using (var context = new LibraryDbContext())
                    {
                        // Create book
                        Model.Book book = new Model.Book();
                        book.BookName = bookName;
                        book.Grade = Decimal.Parse(txtGrade.Text);
                        book.PublishedDate = dtpPuslishedDate.Value;
                        book.BookShelfId = Convert.ToInt32(((ComboboxItem)cbBookShelf.SelectedItem).Value);
                        context.Book.Add(book);

                        // Create BookGenre
                        var genreList = (List<ListBoxItem>)lbGenre2.DataSource;
                        foreach (var genre in genreList)
                        {
                            context.BookGenre.Add(new BookGenre()
                            {
                                Book = book,
                                GenreId = Convert.ToInt32(genre.Value)
                            });
                        }

                        context.SaveChanges();
                    }
                }
                else
                {
                    using (var context = new LibraryDbContext())
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {
                            // Update book
                            var book = (from b in context.Book where b.BookId == Convert.ToInt32(bookId) select b).FirstOrDefault();
                            book.BookName = bookName;
                            book.Grade = Decimal.Parse(txtGrade.Text);
                            book.PublishedDate = dtpPuslishedDate.Value;
                            book.BookShelfId = Convert.ToInt32(((ComboboxItem)cbBookShelf.SelectedItem).Value);

                            // Update BookGenre
                            var deletedList = context.BookGenre.Where(bg => bg.BookId == book.BookId);
                            foreach (var item in deletedList)
                            {
                                context.BookGenre.Remove(item);
                            }

                            var genreList = (List<ListBoxItem>)lbGenre2.DataSource;
                            foreach (var genre in genreList)
                            {
                                context.BookGenre.Add(new BookGenre()
                                {
                                    Book = book,
                                    GenreId = Convert.ToInt32(genre.Value)
                                });
                            }

                            context.SaveChanges();
                            
                            scope.Complete();
                        }
                    }
                }
                LoadTable();
            }
        }

    }
}

namespace Core.QueryMySql
{
    partial class BookForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSave = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.dgvBook = new System.Windows.Forms.DataGridView();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.titleLbl = new System.Windows.Forms.Label();
            this.txtGrade = new System.Windows.Forms.TextBox();
            this.lblGrade = new System.Windows.Forms.Label();
            this.lblPublishedDate = new System.Windows.Forms.Label();
            this.dtpPuslishedDate = new System.Windows.Forms.DateTimePicker();
            this.lvlBookshelf = new System.Windows.Forms.Label();
            this.cbBookShelf = new System.Windows.Forms.ComboBox();
            this.gbGenre = new System.Windows.Forms.GroupBox();
            this.lbGenre1 = new System.Windows.Forms.ListBox();
            this.lbGenre2 = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBook)).BeginInit();
            this.gbGenre.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(299, 211);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(121, 52);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(126, 20);
            this.txtId.TabIndex = 17;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(39, 54);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(17, 15);
            this.lblId.TabIndex = 16;
            this.lblId.Text = "Id";
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(217, 211);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 15;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // dgvBook
            // 
            this.dgvBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBook.Location = new System.Drawing.Point(42, 251);
            this.dgvBook.MultiSelect = false;
            this.dgvBook.Name = "dgvBook";
            this.dgvBook.ReadOnly = true;
            this.dgvBook.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBook.Size = new System.Drawing.Size(517, 142);
            this.dgvBook.TabIndex = 14;
            this.dgvBook.SelectionChanged += new System.EventHandler(this.dgvBook_SelectionChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(121, 82);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(126, 20);
            this.txtName.TabIndex = 13;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(39, 84);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 15);
            this.lblName.TabIndex = 12;
            this.lblName.Text = "Name";
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.Font = new System.Drawing.Font("Book Antiqua", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLbl.Location = new System.Drawing.Point(262, 11);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(57, 23);
            this.titleLbl.TabIndex = 11;
            this.titleLbl.Text = "Book";
            // 
            // txtGrade
            // 
            this.txtGrade.Location = new System.Drawing.Point(121, 112);
            this.txtGrade.Name = "txtGrade";
            this.txtGrade.Size = new System.Drawing.Size(126, 20);
            this.txtGrade.TabIndex = 20;
            // 
            // lblGrade
            // 
            this.lblGrade.AutoSize = true;
            this.lblGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrade.Location = new System.Drawing.Point(39, 114);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(41, 15);
            this.lblGrade.TabIndex = 19;
            this.lblGrade.Text = "Grade";
            // 
            // lblPublishedDate
            // 
            this.lblPublishedDate.AutoSize = true;
            this.lblPublishedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPublishedDate.Location = new System.Drawing.Point(39, 144);
            this.lblPublishedDate.Name = "lblPublishedDate";
            this.lblPublishedDate.Size = new System.Drawing.Size(79, 15);
            this.lblPublishedDate.TabIndex = 21;
            this.lblPublishedDate.Text = "Published on";
            // 
            // dtpPuslishedDate
            // 
            this.dtpPuslishedDate.CustomFormat = "yyyy/MM/dd";
            this.dtpPuslishedDate.Location = new System.Drawing.Point(121, 142);
            this.dtpPuslishedDate.Name = "dtpPuslishedDate";
            this.dtpPuslishedDate.Size = new System.Drawing.Size(126, 20);
            this.dtpPuslishedDate.TabIndex = 22;
            // 
            // lvlBookshelf
            // 
            this.lvlBookshelf.AutoSize = true;
            this.lvlBookshelf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvlBookshelf.Location = new System.Drawing.Point(39, 174);
            this.lvlBookshelf.Name = "lvlBookshelf";
            this.lvlBookshelf.Size = new System.Drawing.Size(61, 15);
            this.lvlBookshelf.TabIndex = 23;
            this.lvlBookshelf.Text = "Bookshelf";
            // 
            // cbBookShelf
            // 
            this.cbBookShelf.FormattingEnabled = true;
            this.cbBookShelf.Location = new System.Drawing.Point(121, 172);
            this.cbBookShelf.Name = "cbBookShelf";
            this.cbBookShelf.Size = new System.Drawing.Size(126, 21);
            this.cbBookShelf.TabIndex = 24;
            // 
            // gbGenre
            // 
            this.gbGenre.Controls.Add(this.btnRemove);
            this.gbGenre.Controls.Add(this.btnAdd);
            this.gbGenre.Controls.Add(this.lbGenre2);
            this.gbGenre.Controls.Add(this.lbGenre1);
            this.gbGenre.Location = new System.Drawing.Point(272, 52);
            this.gbGenre.Name = "gbGenre";
            this.gbGenre.Size = new System.Drawing.Size(287, 141);
            this.gbGenre.TabIndex = 25;
            this.gbGenre.TabStop = false;
            this.gbGenre.Text = "Genre";
            // 
            // lbGenre1
            // 
            this.lbGenre1.FormattingEnabled = true;
            this.lbGenre1.Location = new System.Drawing.Point(16, 19);
            this.lbGenre1.Name = "lbGenre1";
            this.lbGenre1.Size = new System.Drawing.Size(110, 108);
            this.lbGenre1.TabIndex = 0;
            // 
            // lbGenre2
            // 
            this.lbGenre2.FormattingEnabled = true;
            this.lbGenre2.Location = new System.Drawing.Point(161, 19);
            this.lbGenre2.Name = "lbGenre2";
            this.lbGenre2.Size = new System.Drawing.Size(110, 108);
            this.lbGenre2.TabIndex = 26;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(131, 39);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 27);
            this.btnAdd.TabIndex = 27;
            this.btnAdd.Text = ">";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(131, 72);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(24, 27);
            this.btnRemove.TabIndex = 28;
            this.btnRemove.Text = "<";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // BookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 414);
            this.Controls.Add(this.gbGenre);
            this.Controls.Add(this.cbBookShelf);
            this.Controls.Add(this.lvlBookshelf);
            this.Controls.Add(this.dtpPuslishedDate);
            this.Controls.Add(this.lblPublishedDate);
            this.Controls.Add(this.txtGrade);
            this.Controls.Add(this.lblGrade);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dgvBook);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.titleLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(650, 200);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BookForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Book";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBook)).EndInit();
            this.gbGenre.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridView dgvBook;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label titleLbl;
        private System.Windows.Forms.TextBox txtGrade;
        private System.Windows.Forms.Label lblGrade;
        private System.Windows.Forms.Label lblPublishedDate;
        private System.Windows.Forms.DateTimePicker dtpPuslishedDate;
        private System.Windows.Forms.Label lvlBookshelf;
        private System.Windows.Forms.ComboBox cbBookShelf;
        private System.Windows.Forms.GroupBox gbGenre;
        private System.Windows.Forms.ListBox lbGenre2;
        private System.Windows.Forms.ListBox lbGenre1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
    }
}
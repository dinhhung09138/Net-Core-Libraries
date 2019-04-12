namespace Core.QueryMySql
{
    partial class LibraryManagementForm
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
            this.titleLbl = new System.Windows.Forms.Label();
            this.bookshelfBtn = new System.Windows.Forms.Button();
            this.bookBtn = new System.Windows.Forms.Button();
            this.genreBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDemoAsync = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.Font = new System.Drawing.Font("Book Antiqua", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLbl.Location = new System.Drawing.Point(56, 29);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(197, 23);
            this.titleLbl.TabIndex = 0;
            this.titleLbl.Text = "Library Management";
            // 
            // bookshelfBtn
            // 
            this.bookshelfBtn.Location = new System.Drawing.Point(82, 75);
            this.bookshelfBtn.Name = "bookshelfBtn";
            this.bookshelfBtn.Size = new System.Drawing.Size(141, 31);
            this.bookshelfBtn.TabIndex = 1;
            this.bookshelfBtn.Text = "Bookshelf";
            this.bookshelfBtn.UseVisualStyleBackColor = true;
            this.bookshelfBtn.Click += new System.EventHandler(this.bookshelfBtn_Click);
            // 
            // bookBtn
            // 
            this.bookBtn.Location = new System.Drawing.Point(82, 126);
            this.bookBtn.Name = "bookBtn";
            this.bookBtn.Size = new System.Drawing.Size(141, 31);
            this.bookBtn.TabIndex = 2;
            this.bookBtn.Text = "Book";
            this.bookBtn.UseVisualStyleBackColor = true;
            this.bookBtn.Click += new System.EventHandler(this.bookBtn_Click);
            // 
            // genreBtn
            // 
            this.genreBtn.Location = new System.Drawing.Point(82, 179);
            this.genreBtn.Name = "genreBtn";
            this.genreBtn.Size = new System.Drawing.Size(141, 31);
            this.genreBtn.TabIndex = 3;
            this.genreBtn.Text = "Genre";
            this.genreBtn.UseVisualStyleBackColor = true;
            this.genreBtn.Click += new System.EventHandler(this.genreBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(91, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sync / Async";
            // 
            // btnDemoAsync
            // 
            this.btnDemoAsync.Location = new System.Drawing.Point(82, 272);
            this.btnDemoAsync.Name = "btnDemoAsync";
            this.btnDemoAsync.Size = new System.Drawing.Size(141, 31);
            this.btnDemoAsync.TabIndex = 5;
            this.btnDemoAsync.Text = "Demo";
            this.btnDemoAsync.UseVisualStyleBackColor = true;
            this.btnDemoAsync.Click += new System.EventHandler(this.btnDemoAsync_Click);
            // 
            // LibraryManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 336);
            this.Controls.Add(this.btnDemoAsync);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.genreBtn);
            this.Controls.Add(this.bookBtn);
            this.Controls.Add(this.bookshelfBtn);
            this.Controls.Add(this.titleLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(300, 200);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LibraryManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Library";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLbl;
        private System.Windows.Forms.Button bookshelfBtn;
        private System.Windows.Forms.Button bookBtn;
        private System.Windows.Forms.Button genreBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDemoAsync;
    }
}


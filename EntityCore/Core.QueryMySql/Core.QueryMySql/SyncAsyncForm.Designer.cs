namespace Core.QueryMySql
{
    partial class SyncAsyncForm
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
            this.btnSync = new System.Windows.Forms.Button();
            this.btnAsync = new System.Windows.Forms.Button();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.btnAsync2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(12, 12);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(469, 38);
            this.btnSync.TabIndex = 0;
            this.btnSync.Text = "Sync Execute";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // btnAsync
            // 
            this.btnAsync.Location = new System.Drawing.Point(12, 60);
            this.btnAsync.Name = "btnAsync";
            this.btnAsync.Size = new System.Drawing.Size(469, 38);
            this.btnAsync.TabIndex = 1;
            this.btnAsync.Text = "Async Execute";
            this.btnAsync.UseVisualStyleBackColor = true;
            this.btnAsync.Click += new System.EventHandler(this.btnAsync_Click);
            // 
            // txtResults
            // 
            this.txtResults.Location = new System.Drawing.Point(12, 157);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.Size = new System.Drawing.Size(469, 171);
            this.txtResults.TabIndex = 2;
            // 
            // btnAsync2
            // 
            this.btnAsync2.Location = new System.Drawing.Point(12, 109);
            this.btnAsync2.Name = "btnAsync2";
            this.btnAsync2.Size = new System.Drawing.Size(469, 38);
            this.btnAsync2.TabIndex = 3;
            this.btnAsync2.Text = "Async Execute (Fast)";
            this.btnAsync2.UseVisualStyleBackColor = true;
            this.btnAsync2.Click += new System.EventHandler(this.btnAsync2_Click);
            // 
            // SyncAsyncForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 339);
            this.Controls.Add(this.btnAsync2);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.btnAsync);
            this.Controls.Add(this.btnSync);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(650, 200);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SyncAsyncForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Demo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Button btnAsync;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.Button btnAsync2;
    }
}
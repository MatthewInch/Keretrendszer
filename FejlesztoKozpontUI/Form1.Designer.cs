namespace FejlesztoKozpontUI
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnAddGyerek = new System.Windows.Forms.Button();
            this.gridGyerekek = new System.Windows.Forms.DataGridView();
            this.enumGyermekBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridGyerekek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enumGyermekBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddGyerek
            // 
            resources.ApplyResources(this.btnAddGyerek, "btnAddGyerek");
            this.btnAddGyerek.Name = "btnAddGyerek";
            this.btnAddGyerek.UseVisualStyleBackColor = true;
            this.btnAddGyerek.Click += new System.EventHandler(this.btnAddGyerek_Click);
            // 
            // gridGyerekek
            // 
            resources.ApplyResources(this.gridGyerekek, "gridGyerekek");
            this.gridGyerekek.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridGyerekek.Name = "gridGyerekek";
            // 
            // enumGyermekBindingSource
            // 
            this.enumGyermekBindingSource.DataSource = typeof(CurrentTasks.Fejlesztőközpont.EnumGyermek);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridGyerekek);
            this.Controls.Add(this.btnAddGyerek);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridGyerekek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enumGyermekBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddGyerek;
        private System.Windows.Forms.BindingSource enumGyermekBindingSource;
        private System.Windows.Forms.DataGridView gridGyerekek;
    }
}


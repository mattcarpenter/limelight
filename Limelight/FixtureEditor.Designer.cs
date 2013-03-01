namespace Limelight
{
    partial class FixtureEditor
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
            this.btnAddFixture = new System.Windows.Forms.Button();
            this.btnDeleteFixture = new System.Windows.Forms.Button();
            this.tvFixtures = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddFixture
            // 
            this.btnAddFixture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddFixture.BackgroundImage = global::Limelight.Properties.Resources.button_1_up;
            this.btnAddFixture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddFixture.ForeColor = System.Drawing.Color.Silver;
            this.btnAddFixture.Location = new System.Drawing.Point(12, 485);
            this.btnAddFixture.Name = "btnAddFixture";
            this.btnAddFixture.Size = new System.Drawing.Size(75, 32);
            this.btnAddFixture.TabIndex = 1;
            this.btnAddFixture.Text = "Add Fixture";
            this.btnAddFixture.UseVisualStyleBackColor = true;
            this.btnAddFixture.Click += new System.EventHandler(this.btnAddFixture_Click);
            // 
            // btnDeleteFixture
            // 
            this.btnDeleteFixture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteFixture.BackgroundImage = global::Limelight.Properties.Resources.button_1_up;
            this.btnDeleteFixture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeleteFixture.ForeColor = System.Drawing.Color.Silver;
            this.btnDeleteFixture.Location = new System.Drawing.Point(155, 485);
            this.btnDeleteFixture.Name = "btnDeleteFixture";
            this.btnDeleteFixture.Size = new System.Drawing.Size(75, 32);
            this.btnDeleteFixture.TabIndex = 2;
            this.btnDeleteFixture.Text = "Delete";
            this.btnDeleteFixture.UseVisualStyleBackColor = true;
            // 
            // tvFixtures
            // 
            this.tvFixtures.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tvFixtures.ForeColor = System.Drawing.Color.White;
            this.tvFixtures.Location = new System.Drawing.Point(12, 28);
            this.tvFixtures.Name = "tvFixtures";
            this.tvFixtures.Size = new System.Drawing.Size(218, 451);
            this.tvFixtures.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fixtures";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(237, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(501, 150);
            this.dataGridView1.TabIndex = 5;
            // 
            // FixtureEditor
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(750, 529);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tvFixtures);
            this.Controls.Add(this.btnDeleteFixture);
            this.Controls.Add(this.btnAddFixture);
            this.Name = "FixtureEditor";
            this.Text = "Fixture Editor";
            this.Load += new System.EventHandler(this.FixtureEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddFixture;
        private System.Windows.Forms.Button btnDeleteFixture;
        private System.Windows.Forms.TreeView tvFixtures;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;

    }
}
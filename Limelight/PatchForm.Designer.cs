namespace Limelight
{
    partial class PatchForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.tvFixtures = new System.Windows.Forms.TreeView();
            this.btnPatchFixture = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgPatch = new System.Windows.Forms.DataGridView();
            this.universe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.channels = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fixture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.programmer = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatch)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Fixtures";
            // 
            // tvFixtures
            // 
            this.tvFixtures.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvFixtures.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tvFixtures.ForeColor = System.Drawing.Color.White;
            this.tvFixtures.Location = new System.Drawing.Point(12, 37);
            this.tvFixtures.Name = "tvFixtures";
            this.tvFixtures.Size = new System.Drawing.Size(218, 442);
            this.tvFixtures.TabIndex = 5;
            // 
            // btnPatchFixture
            // 
            this.btnPatchFixture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPatchFixture.BackgroundImage = global::Limelight.Properties.Resources.button_1_up;
            this.btnPatchFixture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPatchFixture.ForeColor = System.Drawing.Color.Silver;
            this.btnPatchFixture.Location = new System.Drawing.Point(12, 487);
            this.btnPatchFixture.Name = "btnPatchFixture";
            this.btnPatchFixture.Size = new System.Drawing.Size(102, 32);
            this.btnPatchFixture.TabIndex = 7;
            this.btnPatchFixture.Text = "Patch Fixture";
            this.btnPatchFixture.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(238, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "Patch";
            // 
            // dgPatch
            // 
            this.dgPatch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPatch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgPatch.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgPatch.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.dgPatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPatch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.universe,
            this.channels,
            this.fixture,
            this.programmer});
            this.dgPatch.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgPatch.Location = new System.Drawing.Point(237, 37);
            this.dgPatch.Name = "dgPatch";
            this.dgPatch.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.dgPatch.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgPatch.Size = new System.Drawing.Size(612, 442);
            this.dgPatch.TabIndex = 9;
            // 
            // universe
            // 
            this.universe.HeaderText = "Universe";
            this.universe.Name = "universe";
            this.universe.ReadOnly = true;
            // 
            // channels
            // 
            this.channels.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.channels.HeaderText = "Channels";
            this.channels.Name = "channels";
            this.channels.ReadOnly = true;
            this.channels.Width = 285;
            // 
            // fixture
            // 
            this.fixture.HeaderText = "Fixture Name";
            this.fixture.Name = "fixture";
            this.fixture.ReadOnly = true;
            // 
            // programmer
            // 
            this.programmer.HeaderText = "Add to Programmer";
            this.programmer.Name = "programmer";
            // 
            // PatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(861, 531);
            this.Controls.Add(this.dgPatch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPatchFixture);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tvFixtures);
            this.Name = "PatchForm";
            this.Text = "PatchForm";
            this.Load += new System.EventHandler(this.PatchForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPatch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView tvFixtures;
        private System.Windows.Forms.Button btnPatchFixture;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgPatch;
        private System.Windows.Forms.DataGridViewTextBoxColumn universe;
        private System.Windows.Forms.DataGridViewTextBoxColumn channels;
        private System.Windows.Forms.DataGridViewTextBoxColumn fixture;
        private System.Windows.Forms.DataGridViewCheckBoxColumn programmer;
    }
}
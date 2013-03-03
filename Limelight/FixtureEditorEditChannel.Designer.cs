namespace Limelight
{
    partial class FixtureEditorEditChannel
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.ddlType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudChannelNumber = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.ddlResolution = new System.Windows.Forms.ComboBox();
            this.btnDone = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.ddlPresidence = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudChannelNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Channel Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(51, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Type";
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtTitle.ForeColor = System.Drawing.Color.White;
            this.txtTitle.Location = new System.Drawing.Point(88, 10);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(254, 20);
            this.txtTitle.TabIndex = 2;
            // 
            // ddlType
            // 
            this.ddlType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlType.FormattingEnabled = true;
            this.ddlType.Items.AddRange(new object[] {
            "Default",
            "Pan",
            "Tilt",
            "Red",
            "Green",
            "Blue",
            "White",
            "Amber"});
            this.ddlType.Location = new System.Drawing.Point(89, 40);
            this.ddlType.Name = "ddlType";
            this.ddlType.Size = new System.Drawing.Size(143, 21);
            this.ddlType.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(37, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Address";
            // 
            // nudChannelNumber
            // 
            this.nudChannelNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.nudChannelNumber.ForeColor = System.Drawing.Color.White;
            this.nudChannelNumber.Location = new System.Drawing.Point(88, 71);
            this.nudChannelNumber.Name = "nudChannelNumber";
            this.nudChannelNumber.Size = new System.Drawing.Size(55, 20);
            this.nudChannelNumber.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(25, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Resolution";
            // 
            // ddlResolution
            // 
            this.ddlResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlResolution.FormattingEnabled = true;
            this.ddlResolution.Items.AddRange(new object[] {
            "8",
            "16"});
            this.ddlResolution.Location = new System.Drawing.Point(88, 100);
            this.ddlResolution.Name = "ddlResolution";
            this.ddlResolution.Size = new System.Drawing.Size(55, 21);
            this.ddlResolution.TabIndex = 7;
            // 
            // btnDone
            // 
            this.btnDone.BackgroundImage = global::Limelight.Properties.Resources.button_1_up;
            this.btnDone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDone.ForeColor = System.Drawing.Color.Silver;
            this.btnDone.Location = new System.Drawing.Point(191, 166);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 32);
            this.btnDone.TabIndex = 8;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(25, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Presidence";
            // 
            // ddlPresidence
            // 
            this.ddlPresidence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPresidence.FormattingEnabled = true;
            this.ddlPresidence.Items.AddRange(new object[] {
            "HTP",
            "LTP"});
            this.ddlPresidence.Location = new System.Drawing.Point(88, 131);
            this.ddlPresidence.Name = "ddlPresidence";
            this.ddlPresidence.Size = new System.Drawing.Size(55, 21);
            this.ddlPresidence.TabIndex = 10;
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = global::Limelight.Properties.Resources.button_1_up;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.Color.Silver;
            this.btnCancel.Location = new System.Drawing.Point(272, 166);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 32);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FixtureEditorEditChannel
            // 
            this.AcceptButton = this.btnDone;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(355, 210);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.ddlPresidence);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.ddlResolution);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudChannelNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ddlType);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FixtureEditorEditChannel";
            this.Text = "Edit Channel";
            this.Load += new System.EventHandler(this.FixtureEditorEditChannel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudChannelNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.ComboBox ddlType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudChannelNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ddlResolution;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ddlPresidence;
        private System.Windows.Forms.Button btnCancel;
    }
}
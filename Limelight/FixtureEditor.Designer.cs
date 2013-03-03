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
            this.lblFixtureName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlAttribute = new System.Windows.Forms.Panel();
            this.btnDeleteChannel = new System.Windows.Forms.Button();
            this.btnEditChannel = new System.Windows.Forms.Button();
            this.btnAddChannel = new System.Windows.Forms.Button();
            this.lbAttributeChannels = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ddlAttributeType = new System.Windows.Forms.ComboBox();
            this.txtAttributeTitle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDeleteAttribute = new System.Windows.Forms.Button();
            this.btnAddAttribute = new System.Windows.Forms.Button();
            this.lbAttributes = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSaveFixture = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlAttribute.SuspendLayout();
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
            this.btnAddFixture.Size = new System.Drawing.Size(102, 32);
            this.btnAddFixture.TabIndex = 1;
            this.btnAddFixture.Text = "New Fixture";
            this.btnAddFixture.UseVisualStyleBackColor = true;
            this.btnAddFixture.Click += new System.EventHandler(this.btnAddFixture_Click);
            // 
            // btnDeleteFixture
            // 
            this.btnDeleteFixture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteFixture.BackgroundImage = global::Limelight.Properties.Resources.button_1_up;
            this.btnDeleteFixture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeleteFixture.ForeColor = System.Drawing.Color.Silver;
            this.btnDeleteFixture.Location = new System.Drawing.Point(120, 485);
            this.btnDeleteFixture.Name = "btnDeleteFixture";
            this.btnDeleteFixture.Size = new System.Drawing.Size(110, 32);
            this.btnDeleteFixture.TabIndex = 2;
            this.btnDeleteFixture.Text = "Delete Selected";
            this.btnDeleteFixture.UseVisualStyleBackColor = true;
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
            this.tvFixtures.TabIndex = 3;
            this.tvFixtures.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFixtures_AfterSelect);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fixtures";
            // 
            // lblFixtureName
            // 
            this.lblFixtureName.AutoSize = true;
            this.lblFixtureName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFixtureName.ForeColor = System.Drawing.Color.Silver;
            this.lblFixtureName.Location = new System.Drawing.Point(232, 9);
            this.lblFixtureName.Name = "lblFixtureName";
            this.lblFixtureName.Size = new System.Drawing.Size(177, 24);
            this.lblFixtureName.TabIndex = 6;
            this.lblFixtureName.Text = "No Fixture Selected";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pnlAttribute);
            this.panel1.Controls.Add(this.btnDeleteAttribute);
            this.panel1.Controls.Add(this.btnAddAttribute);
            this.panel1.Controls.Add(this.lbAttributes);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(236, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(502, 442);
            this.panel1.TabIndex = 7;
            // 
            // pnlAttribute
            // 
            this.pnlAttribute.Controls.Add(this.btnDeleteChannel);
            this.pnlAttribute.Controls.Add(this.btnEditChannel);
            this.pnlAttribute.Controls.Add(this.btnAddChannel);
            this.pnlAttribute.Controls.Add(this.lbAttributeChannels);
            this.pnlAttribute.Controls.Add(this.label6);
            this.pnlAttribute.Controls.Add(this.ddlAttributeType);
            this.pnlAttribute.Controls.Add(this.txtAttributeTitle);
            this.pnlAttribute.Controls.Add(this.label5);
            this.pnlAttribute.Controls.Add(this.label4);
            this.pnlAttribute.Location = new System.Drawing.Point(-1, 162);
            this.pnlAttribute.Name = "pnlAttribute";
            this.pnlAttribute.Size = new System.Drawing.Size(502, 279);
            this.pnlAttribute.TabIndex = 4;
            // 
            // btnDeleteChannel
            // 
            this.btnDeleteChannel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteChannel.BackgroundImage = global::Limelight.Properties.Resources.button_1_up;
            this.btnDeleteChannel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeleteChannel.ForeColor = System.Drawing.Color.Silver;
            this.btnDeleteChannel.Location = new System.Drawing.Point(396, 146);
            this.btnDeleteChannel.Name = "btnDeleteChannel";
            this.btnDeleteChannel.Size = new System.Drawing.Size(102, 32);
            this.btnDeleteChannel.TabIndex = 7;
            this.btnDeleteChannel.Text = "Delete Selected";
            this.btnDeleteChannel.UseVisualStyleBackColor = true;
            this.btnDeleteChannel.Click += new System.EventHandler(this.btnDeleteChannel_Click);
            // 
            // btnEditChannel
            // 
            this.btnEditChannel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditChannel.BackgroundImage = global::Limelight.Properties.Resources.button_1_up;
            this.btnEditChannel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditChannel.ForeColor = System.Drawing.Color.Silver;
            this.btnEditChannel.Location = new System.Drawing.Point(396, 108);
            this.btnEditChannel.Name = "btnEditChannel";
            this.btnEditChannel.Size = new System.Drawing.Size(102, 32);
            this.btnEditChannel.TabIndex = 6;
            this.btnEditChannel.Text = "Edit Selected";
            this.btnEditChannel.UseVisualStyleBackColor = true;
            this.btnEditChannel.Click += new System.EventHandler(this.btnEditChannel_Click);
            // 
            // btnAddChannel
            // 
            this.btnAddChannel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddChannel.BackgroundImage = global::Limelight.Properties.Resources.button_1_up;
            this.btnAddChannel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddChannel.ForeColor = System.Drawing.Color.Silver;
            this.btnAddChannel.Location = new System.Drawing.Point(397, 70);
            this.btnAddChannel.Name = "btnAddChannel";
            this.btnAddChannel.Size = new System.Drawing.Size(102, 32);
            this.btnAddChannel.TabIndex = 5;
            this.btnAddChannel.Text = "Add Channel";
            this.btnAddChannel.UseVisualStyleBackColor = true;
            this.btnAddChannel.Click += new System.EventHandler(this.btnAddChannel_Click);
            // 
            // lbAttributeChannels
            // 
            this.lbAttributeChannels.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lbAttributeChannels.ForeColor = System.Drawing.Color.White;
            this.lbAttributeChannels.FormattingEnabled = true;
            this.lbAttributeChannels.Location = new System.Drawing.Point(80, 70);
            this.lbAttributeChannels.Name = "lbAttributeChannels";
            this.lbAttributeChannels.Size = new System.Drawing.Size(310, 199);
            this.lbAttributeChannels.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Silver;
            this.label6.Location = new System.Drawing.Point(23, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Channels";
            // 
            // ddlAttributeType
            // 
            this.ddlAttributeType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ddlAttributeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlAttributeType.ForeColor = System.Drawing.Color.White;
            this.ddlAttributeType.FormattingEnabled = true;
            this.ddlAttributeType.Items.AddRange(new object[] {
            "Position",
            "Intensity",
            "Color",
            "Gobo",
            "Other"});
            this.ddlAttributeType.Location = new System.Drawing.Point(80, 39);
            this.ddlAttributeType.Name = "ddlAttributeType";
            this.ddlAttributeType.Size = new System.Drawing.Size(178, 21);
            this.ddlAttributeType.TabIndex = 3;
            this.ddlAttributeType.SelectedIndexChanged += new System.EventHandler(this.ddlAttributeType_SelectedIndexChanged);
            // 
            // txtAttributeTitle
            // 
            this.txtAttributeTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtAttributeTitle.ForeColor = System.Drawing.Color.White;
            this.txtAttributeTitle.Location = new System.Drawing.Point(80, 6);
            this.txtAttributeTitle.Name = "txtAttributeTitle";
            this.txtAttributeTitle.Size = new System.Drawing.Size(178, 20);
            this.txtAttributeTitle.TabIndex = 2;
            this.txtAttributeTitle.TextChanged += new System.EventHandler(this.txtAttributeTitle_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(43, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(5, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Attribute Title";
            // 
            // btnDeleteAttribute
            // 
            this.btnDeleteAttribute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteAttribute.BackgroundImage = global::Limelight.Properties.Resources.button_1_up;
            this.btnDeleteAttribute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeleteAttribute.ForeColor = System.Drawing.Color.Silver;
            this.btnDeleteAttribute.Location = new System.Drawing.Point(395, 46);
            this.btnDeleteAttribute.Name = "btnDeleteAttribute";
            this.btnDeleteAttribute.Size = new System.Drawing.Size(102, 32);
            this.btnDeleteAttribute.TabIndex = 3;
            this.btnDeleteAttribute.Text = "Delete Selected";
            this.btnDeleteAttribute.UseVisualStyleBackColor = true;
            this.btnDeleteAttribute.Click += new System.EventHandler(this.btnDeleteAttribute_Click);
            // 
            // btnAddAttribute
            // 
            this.btnAddAttribute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddAttribute.BackgroundImage = global::Limelight.Properties.Resources.button_1_up;
            this.btnAddAttribute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddAttribute.ForeColor = System.Drawing.Color.Silver;
            this.btnAddAttribute.Location = new System.Drawing.Point(395, 8);
            this.btnAddAttribute.Name = "btnAddAttribute";
            this.btnAddAttribute.Size = new System.Drawing.Size(102, 32);
            this.btnAddAttribute.TabIndex = 2;
            this.btnAddAttribute.Text = "Add Attribute";
            this.btnAddAttribute.UseVisualStyleBackColor = true;
            this.btnAddAttribute.Click += new System.EventHandler(this.btnAddAttribute_Click);
            // 
            // lbAttributes
            // 
            this.lbAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAttributes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lbAttributes.ForeColor = System.Drawing.Color.White;
            this.lbAttributes.FormattingEnabled = true;
            this.lbAttributes.Location = new System.Drawing.Point(79, 8);
            this.lbAttributes.Name = "lbAttributes";
            this.lbAttributes.Size = new System.Drawing.Size(310, 147);
            this.lbAttributes.TabIndex = 1;
            this.lbAttributes.SelectedIndexChanged += new System.EventHandler(this.lbAttributes_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(22, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Attributes";
            // 
            // btnSaveFixture
            // 
            this.btnSaveFixture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveFixture.BackgroundImage = global::Limelight.Properties.Resources.button_1_up;
            this.btnSaveFixture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaveFixture.ForeColor = System.Drawing.Color.Silver;
            this.btnSaveFixture.Location = new System.Drawing.Point(628, 485);
            this.btnSaveFixture.Name = "btnSaveFixture";
            this.btnSaveFixture.Size = new System.Drawing.Size(110, 32);
            this.btnSaveFixture.TabIndex = 8;
            this.btnSaveFixture.Text = "Save Fixture";
            this.btnSaveFixture.UseVisualStyleBackColor = true;
            this.btnSaveFixture.Click += new System.EventHandler(this.btnSaveFixture_Click);
            // 
            // FixtureEditor
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(750, 529);
            this.Controls.Add(this.btnSaveFixture);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblFixtureName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tvFixtures);
            this.Controls.Add(this.btnDeleteFixture);
            this.Controls.Add(this.btnAddFixture);
            this.Name = "FixtureEditor";
            this.Text = "Fixture Editor";
            this.Load += new System.EventHandler(this.FixtureEditor_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlAttribute.ResumeLayout(false);
            this.pnlAttribute.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddFixture;
        private System.Windows.Forms.Button btnDeleteFixture;
        private System.Windows.Forms.TreeView tvFixtures;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFixtureName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lbAttributes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddAttribute;
        private System.Windows.Forms.Button btnDeleteAttribute;
        private System.Windows.Forms.Panel pnlAttribute;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ddlAttributeType;
        private System.Windows.Forms.TextBox txtAttributeTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lbAttributeChannels;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDeleteChannel;
        private System.Windows.Forms.Button btnEditChannel;
        private System.Windows.Forms.Button btnAddChannel;
        private System.Windows.Forms.Button btnSaveFixture;

    }
}
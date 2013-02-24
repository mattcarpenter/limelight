namespace Limelight
{
    partial class PlaybackControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.fader = new AVFader.AVFader();
            this.buttonBump = new System.Windows.Forms.Button();
            this.buttonRelease = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.labelFaderPct = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.controlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.labelFaderPct);
            this.panel4.Controls.Add(this.labelStatus);
            this.panel4.Controls.Add(this.labelTitle);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(85, 70);
            this.panel4.TabIndex = 6;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.labelStatus.Location = new System.Drawing.Point(-2, 24);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(52, 13);
            this.labelStatus.TabIndex = 1;
            this.labelStatus.Text = "Released";
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(238)))), ((int)(((byte)(153)))));
            this.labelTitle.Location = new System.Drawing.Point(-1, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(85, 23);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "PB1";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // controlPanel
            // 
            this.controlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.controlPanel.Controls.Add(this.fader);
            this.controlPanel.Controls.Add(this.buttonBump);
            this.controlPanel.Controls.Add(this.buttonRelease);
            this.controlPanel.Controls.Add(this.buttonPlay);
            this.controlPanel.Controls.Add(this.buttonSelect);
            this.controlPanel.Location = new System.Drawing.Point(18, 70);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(50, 258);
            this.controlPanel.TabIndex = 5;
            // 
            // fader
            // 
            this.fader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.fader.Location = new System.Drawing.Point(3, 110);
            this.fader.Margin = new System.Windows.Forms.Padding(4, 3, 3, 3);
            this.fader.Name = "fader";
            this.fader.Size = new System.Drawing.Size(40, 110);
            this.fader.TabIndex = 9;
            this.fader.TickColor = System.Drawing.Color.DimGray;
            this.fader.TickFrequency = 6;
            // 
            // buttonBump
            // 
            this.buttonBump.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBump.BackgroundImage = global::Limelight.Properties.Resources.button_1_up;
            this.buttonBump.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonBump.ForeColor = System.Drawing.Color.Silver;
            this.buttonBump.Location = new System.Drawing.Point(3, 226);
            this.buttonBump.Name = "buttonBump";
            this.buttonBump.Size = new System.Drawing.Size(40, 32);
            this.buttonBump.TabIndex = 8;
            this.buttonBump.UseVisualStyleBackColor = true;
            // 
            // buttonRelease
            // 
            this.buttonRelease.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRelease.BackgroundImage = global::Limelight.Properties.Resources.button_1_up;
            this.buttonRelease.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRelease.ForeColor = System.Drawing.Color.Silver;
            this.buttonRelease.Location = new System.Drawing.Point(3, 42);
            this.buttonRelease.Name = "buttonRelease";
            this.buttonRelease.Size = new System.Drawing.Size(40, 32);
            this.buttonRelease.TabIndex = 7;
            this.buttonRelease.Text = "Rel";
            this.buttonRelease.UseVisualStyleBackColor = true;
            // 
            // buttonPlay
            // 
            this.buttonPlay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPlay.BackgroundImage = global::Limelight.Properties.Resources.button_1_up;
            this.buttonPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPlay.ForeColor = System.Drawing.Color.Silver;
            this.buttonPlay.Location = new System.Drawing.Point(3, 80);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(40, 32);
            this.buttonPlay.TabIndex = 6;
            this.buttonPlay.Text = ">";
            this.buttonPlay.UseVisualStyleBackColor = true;
            // 
            // buttonSelect
            // 
            this.buttonSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelect.BackgroundImage = global::Limelight.Properties.Resources.button_1_up;
            this.buttonSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSelect.ForeColor = System.Drawing.Color.Silver;
            this.buttonSelect.Location = new System.Drawing.Point(3, 4);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(40, 32);
            this.buttonSelect.TabIndex = 5;
            this.buttonSelect.Text = "Sel";
            this.buttonSelect.UseVisualStyleBackColor = true;
            // 
            // labelFaderPct
            // 
            this.labelFaderPct.AutoSize = true;
            this.labelFaderPct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.labelFaderPct.Location = new System.Drawing.Point(-2, 54);
            this.labelFaderPct.Name = "labelFaderPct";
            this.labelFaderPct.Size = new System.Drawing.Size(21, 13);
            this.labelFaderPct.TabIndex = 2;
            this.labelFaderPct.Text = "0%";
            // 
            // PlaybackControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.controlPanel);
            this.Name = "PlaybackControl";
            this.Size = new System.Drawing.Size(85, 330);
            this.Load += new System.EventHandler(this.PlaybackControl_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.controlPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelStatus;
        public System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel controlPanel;
        public AVFader.AVFader fader;
        private System.Windows.Forms.Button buttonBump;
        private System.Windows.Forms.Button buttonRelease;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonSelect;
        public System.Windows.Forms.Label labelFaderPct;
    }
}

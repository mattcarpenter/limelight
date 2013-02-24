using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Limelight
{
    public partial class ParentForm : Form
    {
        private Core.Application coreApp;
        private Timer updateTimer;
        private PlaybackForm playbackForm;

        /// <summary>
        /// Constructor
        /// </summary>
        public ParentForm()
        {
            InitializeComponent();
        
            // Create a Limelight Core Application instance
            coreApp = new Core.Application();
        }

        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ParentForm_Load(object sender, EventArgs e)
        {
            // Set the MDI window's background color
            foreach (Control control in this.Controls)
            {
                MdiClient client = control as MdiClient;
                if (!(client == null))
                {
                    client.BackColor = this.BackColor;
                    break;
                }
            }
            
            // Create some playbacks
            for (int i = 0; i < 80; i++)
                coreApp.Playbacks.Add(new Core.Playback("PB" + (i+1).ToString()));

            // Add playback window
            playbackForm = new PlaybackForm(coreApp);
            playbackForm.MdiParent = this;
            playbackForm.Show();

            // Start the update timer
            updateTimer = new Timer();
            updateTimer.Interval = 5;
            updateTimer.Tick += Update;
            updateTimer.Start();
        }

        /// <summary>
        /// Master update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update(object sender, EventArgs e)
        {
            coreApp.Update();

            // Update labels on the playback form
            if (playbackForm != null)
                playbackForm.UpdateLabels();
        }
    }
}

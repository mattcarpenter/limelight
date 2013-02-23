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
        /// <summary>
        /// Constructor
        /// </summary>
        public ParentForm()
        {
            InitializeComponent();
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

            // Add playback window
            PlaybackForm pbf = new PlaybackForm();
            pbf.MdiParent = this;
            pbf.Show();
        }
    }
}

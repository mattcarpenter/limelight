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
    public partial class PlaybackForm : Form
    {
        List<PlaybackControl> playbackControls;

        public PlaybackForm()
        {
            InitializeComponent();
            
        }

        private void PlaybackForm_Load(object sender, EventArgs e)
        {
            playbackControls = new List<PlaybackControl>();
            for (int i = 0; i < 8; i++)
            {
                PlaybackControl pbc = new PlaybackControl();
                pbc.Anchor = (AnchorStyles.Bottom | AnchorStyles.Top);
                pbc.Left = i * (pbc.Width+5);
                playbackControls.Add(pbc);
            }

            playbackPanel.Controls.AddRange(playbackControls.ToArray());
        }

        private void fader_ValueChanged(object sender, System.EventArgs e)
        {
       
        }
    }
}

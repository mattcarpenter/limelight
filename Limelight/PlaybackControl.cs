using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Limelight
{
    public partial class PlaybackControl : UserControl
    {
        #region Public Events
        [Category("Action"), Description("Occurs when the slider is moved")]
        public event EventHandler OnChange;
        #endregion

        public PlaybackControl()
        {
            InitializeComponent();
        }

        private void PlaybackControl_Load(object sender, EventArgs e)
        {
            fader.ValueChanged += fader_ValueChange;
        }

        private void fader_ValueChange(object sender, EventArgs e)
        {
            OnChange(this,new EventArgs());
        }
    }
}

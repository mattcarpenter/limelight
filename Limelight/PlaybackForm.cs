﻿using System;
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
        protected List<PlaybackControl> playbackControls;
        protected Core.Application coreApp;
        public event EventHandler OnFaderChange;
        public int currentPage;
        
        public const int MAX_PAGES = 10;

        /// <summary>
        /// Constructor
        /// </summary>
        public PlaybackForm(Core.Application app)
        {
            InitializeComponent();
            coreApp = app;

            currentPage = 1;
        }

        /// <summary>
        /// Playback form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlaybackForm_Load(object sender, EventArgs e)
        {
            // Create eight playback controls and add them to the form
            playbackControls = new List<PlaybackControl>();
            for (int i = 0; i < 8; i++)
            {
                PlaybackControl pbc = new PlaybackControl();
                pbc.Height = playbackPanel.Height;
                pbc.Anchor = (AnchorStyles.Bottom | AnchorStyles.Top);
                pbc.Left = i * (pbc.Width+5);
                pbc.OnChange += FaderChange;
                playbackControls.Add(pbc);

                // Tag will be the offset used for calcuating the actual playback
                // not relative to the current page.
                pbc.Tag = i;
            }
            
            // Add to the form
            playbackPanel.Controls.AddRange(playbackControls.ToArray());

            UpdateFaderPositions();
        }

        /// <summary>
        /// Updates the fader positions based on the the cuestacks' fader values
        /// Should be called after a MIDI control event or after a page has changed
        /// </summary>
        public void UpdateFaderPositions()
        {
            foreach (PlaybackControl playbackControl in playbackControls)
            {
                Core.Playback corePlayback = coreApp.Playbacks[(currentPage * 8) - 8 + (int)playbackControl.Tag];
                if (corePlayback.Stack != null)
                    playbackControl.fader.Value = Convert.ToInt32(corePlayback.Stack.FaderValue * 100);
                else
                    playbackControl.fader.Value = 0 ;

            }
        }

        /// <summary>
        /// Updates labels based on cuestack and playback values
        /// </summary>
        public void UpdateLabels()
        {
            lblPage.Text = "Page: " + currentPage.ToString();

            // Update the playbacks
            foreach (PlaybackControl playbackControl in playbackControls)
            {
                Core.Playback corePlayback = coreApp.Playbacks[(currentPage*8) - 8 + (int)playbackControl.Tag];

                playbackControl.labelTitle.Text = corePlayback.Label;
                playbackControl.labelFaderPct.Text = playbackControl.fader.Value.ToString() + "%";
                
            }
        }

        /// <summary>
        /// Advances to the next page of playbacks
        /// </summary>
        public void NextPage()
        {
            if (currentPage == MAX_PAGES)
                return;
            currentPage++;
            UpdateFaderPositions();
            InvokeOnFaderChangeForAll();
        }

        /// <summary>
        /// Goes to the previous page of playbacks
        /// </summary>
        public void PrevPage()
        {
            if (currentPage == 1)
                return;
            currentPage--;
            UpdateFaderPositions();
            InvokeOnFaderChangeForAll();
        }

        /// <summary>
        /// Event handler for next page button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            NextPage();
        }

        /// <summary>
        /// Event handler for previous page button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            PrevPage();
        }

        /// <summary>
        /// Event handler for a fader change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FaderChange(object sender, EventArgs e)
        {
            Core.Playback corePlayback = coreApp.Playbacks[(currentPage * 8) - 8 + (int)((PlaybackControl)sender).Tag];

            if (corePlayback.Stack != null)
                corePlayback.Stack.FaderValue = (double)((PlaybackControl)sender).fader.Value / 100;
            if(OnFaderChange!=null)
                OnFaderChange.Invoke(sender, new EventArgs());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            coreApp.BreakMe = true;
        }

        private void InvokeOnFaderChangeForAll()
        {
            if (OnFaderChange == null)
                return;
            foreach (PlaybackControl plc in this.playbackPanel.Controls.OfType<PlaybackControl>())
            {
                OnFaderChange.Invoke(plc, new EventArgs());
            }
        }
    }
}

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
            coreApp.Universes.Add(new Core.Universe());
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

            // Add some shizz for testing
            Core.Fixture f = new Core.Fixture(0);
            f.PatchAddress = 1;
            Core.FixtureAttribute a = new Core.FixtureAttribute();
            a.Type = Core.FixtureAttributeType.Intensity;
            Core.FixtureAttributeChannel c = new Core.FixtureAttributeChannel();
            c.Value = 1;
            c.RelativeChannelNumber = 1;
            c.Type = Core.FixtureAttributeChannelType.Default;
            a.Channels.Add(c);
            f.Attributes.Add(a);

            Core.Fixture f2 = f.Clone();
            f2.Master = f;

            Core.Cue cue = new Core.Cue();
            cue.AddFixture(f2);
            cue.FadeInTime = 0;
            cue.DwellTime = null;
            cue.FadeOutTime = 0;

            Core.CueStack cs = new Core.CueStack();
            cs.AddCue(cue);
            cs.ExecuteNextCue();

            coreApp.CueStacks.Add(cs);

            coreApp.Playbacks[0].Stack = cs;

            // Start DMX
            OpenDMX.start();
        }

        /// <summary>
        /// Master update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update(object sender, EventArgs e)
        {
            // Render channel values
            coreApp.Update();
            
            // Write to DMX
            WriteDMX();

            // Update labels on the playback form
            if (playbackForm != null)
                playbackForm.UpdateLabels();
        }

        /// <summary>
        /// Writes fixtures to OpenDMX
        /// </summary>
        /// <param name="fixtures"></param>
        public void WriteDMX()
        {
            this.Text = coreApp.Universes[0].Channels[0].Value + " - " + coreApp.Universes[0].Channels[0].Value + " - " + coreApp.CueStacks[0].Cues[0].Status.ToString() + " - " + coreApp.CueStacks[0].Fixtures[0].Attributes[0].Channels[0].RenderedValue;
            /*for (int i = 0; i < 512; i++)
            {
                Byte DMXValue = Convert.ToByte(coreApp.Universes[0].Channels[i].Value * 255.0f);
                OpenDMX.setDmxValue(i+1, DMXValue);
            }*/

            foreach (Core.Fixture fixture in coreApp.Fixtures)
            {
                Byte DMXValue = Convert.ToByte(fixture.Attributes[0].Channels[0].RenderedValue * 255.0f);
               OpenDMX.setDmxValue(fixture.PatchAddress, DMXValue);
            }
        }
    }
}

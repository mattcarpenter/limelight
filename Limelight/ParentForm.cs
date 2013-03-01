using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;

namespace Limelight
{
    public partial class ParentForm : Form
    {
        private Core.Application coreApp;
        private System.Timers.Timer updateTimer;
        private PlaybackForm playbackForm;
        private BCF2000 bcf2000;

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

            // Midi control
            bcf2000 = new BCF2000(coreApp,playbackForm);

            // Add some shizz for testing
            Core.Fixture f = new Core.Fixture(0);
            f.PatchAddress = 1;
            Core.FixtureAttribute a = new Core.FixtureAttribute();
            a.Type = Core.FixtureAttributeType.Intensity;
            Core.FixtureAttributeChannel c = new Core.FixtureAttributeChannel();
            c.Value = 1;
            c.Presidence = Core.ChannelPresidence.LTP;
            c.RelativeChannelNumber = 1;
            c.Type = Core.FixtureAttributeChannelType.Default;
            a.Channels.Add(c);
            f.Attributes.Add(a);

            Core.Fixture f2 = f.Clone();
            f2.Master = f;

            Core.Fixture f3 = f.Clone();
            f3.Master = f;

            // Cue 1
            Core.Cue cue = new Core.Cue();
            cue.AddFixture(f2);
            cue.FadeInTime = 0;
            cue.DwellTime = null;
            cue.FadeOutTime = 0;

            Core.CueStack cs = new Core.CueStack();
            cs.Label = "cs1";
            cs.AddCue(cue);
            cs.ExecuteNextCue();

            coreApp.CueStacks.Add(cs);

            // Cue 2
            Core.Cue cue2 = new Core.Cue();
            cue2.AddFixture(f3);
            cue2.FadeInTime = 0;
            cue2.DwellTime = null;
            cue2.FadeOutTime = 0;

            Core.CueStack cs2 = new Core.CueStack();
            cs2.AddCue(cue2);
            cs2.Label = "cs2";
            cs2.ExecuteNextCue();

            coreApp.CueStacks.Add(cs2);

            coreApp.Playbacks[0].Stack = cs;
            coreApp.Playbacks[1].Stack = cs2;

            // Start DMX
            try
            {
                OpenDMX.start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // Start the update timer
            updateTimer = new System.Timers.Timer();
            updateTimer.Interval = 1;
            updateTimer.Elapsed += Update;

            updateTimer.Start();
        }

        /// <summary>
        /// Master update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate()
            {
            // Render channel values
            coreApp.Update();
            
            // Write to DMX
            WriteDMX();

            // Update labels on the playback form
            if (playbackForm != null)
                playbackForm.UpdateLabels();
            }));
        }

        /// <summary>
        /// Writes fixtures to OpenDMX
        /// </summary>
        /// <param name="fixtures"></param>
        public void WriteDMX()
        {
            //this.Text = coreApp.CueStacks[0].Fixtures[0].Attributes[0].Channels[0].LastUpdated + " - " + coreApp.CueStacks[1].Fixtures[0].Attributes[0].Channels[0].LastUpdated;
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void fIleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fixtureEditorToolStripFixtureEditor_Click(object sender, EventArgs e)
        {
            FixtureEditor editor = new FixtureEditor();
            editor.MdiParent = this;
            editor.Show();
        }
    }
}

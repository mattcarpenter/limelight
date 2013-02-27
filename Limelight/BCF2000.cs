using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Midi;
using System.Windows;
using System.Windows.Forms;

namespace Limelight
{
    /// <summary>
    /// Simple Behringer BCF2000 control
    /// </summary>
    class BCF2000
    {
        private InputDevice inputDevice;
        private OutputDevice outputDevice;
        private Core.Application coreApp;
        private PlaybackForm playbackForm;
        private Channel[] outChannels;

        /// <summary>
        /// Constructor. Instantiate and set up the MIDI I/O
        /// </summary>
        public BCF2000(Core.Application app, PlaybackForm pbf)
        {
            // Need references to the core application and the playback form (for paging stuff)
            coreApp = app;
            playbackForm = pbf;

            for (int i = 0; i < InputDevice.InstalledDevices.Count; i++)
                if (InputDevice.InstalledDevices[i].Name == "BCF2000")
                {
                    inputDevice = InputDevice.InstalledDevices[i];
                    MessageBox.Show("found BCF2000 input device");
                }
            for (int i = 0; i < OutputDevice.InstalledDevices.Count; i++)
                if (OutputDevice.InstalledDevices[i].Name == "BCF2000")
                    outputDevice = OutputDevice.InstalledDevices[i];

            // Populate outChannels
            outChannels = new Channel[16];
            outChannels[0] = Channel.Channel1;
            outChannels[1] = Channel.Channel2;
            outChannels[2] = Channel.Channel3;
            outChannels[3] = Channel.Channel4;
            outChannels[4] = Channel.Channel5;
            outChannels[5] = Channel.Channel6;
            outChannels[6] = Channel.Channel7;
            outChannels[7] = Channel.Channel8;

            inputDevice.Open();
            outputDevice.Open();
            
            inputDevice.NoteOn += noteOn;
            inputDevice.NoteOff += noteOff;
            inputDevice.ProgramChange += new InputDevice.ProgramChangeHandler(programChange);
            inputDevice.ControlChange += new InputDevice.ControlChangeHandler(controlChange);
            inputDevice.PitchBend += new InputDevice.PitchBendHandler(pitchBend);
            inputDevice.StartReceiving(null);

            // We'll want to move the motorized faders when they change on screen too..
            playbackForm.OnFaderChange += UpdateFaderPosition;
        }

        private void UpdateFaderPosition(Object sender, EventArgs e)
        {
            playbackForm.Invoke(new MethodInvoker(delegate()
            {
                int channel = (playbackForm.currentPage * 8) - 8 + (int)((PlaybackControl)sender).Tag + 1;
                int max = 16256 - 128;
                Core.Playback corePlayback = coreApp.Playbacks[channel-1];
                
                if (corePlayback.Stack != null)
                    outputDevice.SendPitchBend(outChannels[channel-1], Convert.ToInt32((max * corePlayback.Stack.FaderValue) + 128));
            }));
        }

        private void noteOn(NoteOnMessage msg)
        {
            playbackForm.Text = msg.Time.ToString();
        }

        private void noteOff(NoteOffMessage msg)
        {

        }

        public void programChange(ProgramChangeMessage msg)
        {
            Core.Playback corePlayback = coreApp.Playbacks[(playbackForm.currentPage * 8) - 8 + Convert.ToInt32(msg.Channel.ToString()) - 1];
            //playbackForm.Text = msg.Channel.ToString();
        }

        private void controlChange(ControlChangeMessage msg)
        {
            playbackForm.Invoke(new MethodInvoker(delegate()
            {
                // Previous Page
                if (msg.Control.ToString() == "20" && msg.Value == 127)
                {
                    playbackForm.PrevPage();
                }

                // Next Page
                if (msg.Control.ToString() == "21" && msg.Value == 127)
                {
                    playbackForm.NextPage();
                }
            }));
        }

        private void pitchBend(PitchBendMessage msg)
        {
            playbackForm.Invoke(new MethodInvoker(delegate()
            {
                Core.Playback corePlayback = coreApp.Playbacks[(playbackForm.currentPage * 8) - 8 + Convert.ToInt32(msg.Channel.ToString().Replace("Channel", "")) - 1];
                if (corePlayback.Stack != null)
                {
                    int max = 16256 - 128;
                    Double value = (double)(msg.Value - 128) / max;
                    corePlayback.Stack.FaderValue = value;
                    playbackForm.UpdateFaderPositions();
                }
            }));
        }
    }
}

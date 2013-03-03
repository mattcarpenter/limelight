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
    public partial class FixtureEditorEditChannel : Form
    {
        private Core.FixtureAttributeChannel currentChannel;

        public FixtureEditorEditChannel(Core.FixtureAttributeChannel channel)
        {
            currentChannel = channel;
            InitializeComponent();
        }

        private void FixtureEditorEditChannel_Load(object sender, EventArgs e)
        {
            // Set title
            txtTitle.Text = currentChannel.Title;

            // Type
            switch (currentChannel.Type)
            {
                case Core.FixtureAttributeChannelType.Default:
                    ddlType.SelectedIndex = 0;
                    break;
                case Core.FixtureAttributeChannelType.Red:
                    ddlType.SelectedIndex = 3;
                    break;
                case Core.FixtureAttributeChannelType.Green:
                    ddlType.SelectedIndex = 4;
                    break;
                case Core.FixtureAttributeChannelType.Blue:
                    ddlType.SelectedIndex = 5;
                    break;
                case Core.FixtureAttributeChannelType.Amber:
                    ddlType.SelectedIndex = 7;
                    break;
                case Core.FixtureAttributeChannelType.White:
                    ddlType.SelectedIndex = 6;
                    break;
                case Core.FixtureAttributeChannelType.Pan:
                    ddlType.SelectedIndex = 1;
                    break;
                case Core.FixtureAttributeChannelType.Tilt:
                    ddlType.SelectedIndex = 2;
                    break;
            }

            // Resolution
            if (currentChannel.Resolution == 8)
                ddlResolution.SelectedIndex = 0;
            else
                ddlResolution.SelectedIndex = 1;

            // Presidence
            if (currentChannel.Presidence == Core.ChannelPresidence.HTP)
                ddlPresidence.SelectedIndex = 0;
            else
                ddlPresidence.SelectedIndex = 1;

            // Channel
            nudChannelNumber.Value = currentChannel.RelativeChannelNumber;
        }

        /// <summary>
        /// Save the channel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDone_Click(object sender, EventArgs e)
        {
            currentChannel.Title = txtTitle.Text;
            currentChannel.Type = (Core.FixtureAttributeChannelType)Enum.Parse(typeof(Core.FixtureAttributeChannelType), ddlType.SelectedItem.ToString());
            currentChannel.Presidence = (Core.ChannelPresidence)Enum.Parse(typeof(Core.ChannelPresidence), ddlPresidence.SelectedItem.ToString());
            currentChannel.RelativeChannelNumber = (int)nudChannelNumber.Value;
            currentChannel.Resolution = Convert.ToInt32(ddlResolution.SelectedItem.ToString());

            ((FixtureEditor)this.Owner).ReloadChannels();
            this.Close();
        }

        // Close form and don't save changes
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

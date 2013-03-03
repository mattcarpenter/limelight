using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Limelight
{
    public partial class FixtureEditor : Form
    {
        public Core.Fixture currentFixture;

        public FixtureEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Show the "add fixture" dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddFixture_Click(object sender, EventArgs e)
        {
            FixtureEditorAddFixture af = new FixtureEditorAddFixture();
            af.Owner = this;
            af.ShowDialog();
        }

        /// <summary>
        /// Form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FixtureEditor_Load(object sender, EventArgs e)
        {
            loadFixtures();
        }

        /// <summary>
        /// Loads fixtures from [app_dir]\fixtures\ and adds them to the tree view
        /// </summary>
        public void loadFixtures()
        {
            DirectoryInfo di = new DirectoryInfo(Directory.GetCurrentDirectory() + @"\fixtures\");
            var dirs = di.EnumerateDirectories();

            foreach (var dir in dirs)
            {
                TreeNode mfrNode = tvFixtures.Nodes.Add(dir.Name);
                
                DirectoryInfo di2 = new DirectoryInfo(dir.FullName);
                var files = di2.EnumerateFiles("*.xml");

                foreach (var file in files)
                {
                    TreeNode fixNode = mfrNode.Nodes.Add(file.Name.Replace(".xml", ""));
                    fixNode.Tag = file.FullName;
                }
            }
        }

        /// <summary>
        /// Adds an attribute to the selected fixture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddAttribute_Click(object sender, EventArgs e)
        {
            if (currentFixture == null)
                return;

            Core.FixtureAttribute fa = new Core.FixtureAttribute();
            fa.Title = "New Attribute";
            currentFixture.Attributes.Add(fa);

            reloadAttributes();
        }

        /// <summary>
        /// Reloads attributes list box from fixture's attributes collection
        /// </summary>
        public void reloadAttributes()
        {
            lbAttributes.DataSource = null;
            lbAttributes.DataSource = currentFixture.Attributes;
            lbAttributes.DisplayMember = "Title";
        }

        /// <summary>
        /// Reloads the channels list box from the selected attribute's channels collection
        /// </summary>
        public void ReloadChannels()
        {
            if (currentFixture == null || lbAttributes.SelectedItem == null)
                return;

            Core.FixtureAttribute fa = (Core.FixtureAttribute)lbAttributes.SelectedItem;

            lbAttributeChannels.DataSource = null;
            lbAttributeChannels.DataSource = fa.Channels;
            lbAttributeChannels.DisplayMember = "Title";
        }

        /// <summary>
        /// Fixture selected in the tree view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvFixtures_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvFixtures.SelectedNode.Tag != null)
            {
                // Selected a fixture
                currentFixture = Core.Fixture.LoadFromFile(tvFixtures.SelectedNode.Tag.ToString());
                lblFixtureName.Text = currentFixture.Title;

                reloadAttributes();
                
            }
            else
            {
                // Selected an MFR instead of a fixture
                lblFixtureName.Text = "No Fixture Selected";
                currentFixture = null;
            }
        }

        /// <summary>
        /// Selected a new attribute
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbAttributes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentFixture == null || ((ListBox)sender).SelectedItem==null)
                return;

            Core.FixtureAttribute fa = (Core.FixtureAttribute)((ListBox)sender).SelectedItem;

            txtAttributeTitle.Text = fa.Title;
            ddlAttributeType.SelectedItem = fa.Type.ToString();

            ReloadChannels();

        }

        /// <summary>
        /// Textbox TextChanged event handler. Update the core attribute title
        /// then refresh the attributes listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAttributeTitle_TextChanged(object sender, EventArgs e)
        {
            if (currentFixture == null || lbAttributes.SelectedItem == null)
                return;

            Core.FixtureAttribute fa = (Core.FixtureAttribute)lbAttributes.SelectedItem;

            fa.Title = ((TextBox)sender).Text;

            reloadAttributes();
        }

        /// <summary>
        /// Fires when the attribute type dropdown is changed. Sets the attribute type.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlAttributeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentFixture == null || (Core.FixtureAttribute)lbAttributes.SelectedItem == null
                || ((ComboBox)sender).SelectedItem == null || ((ComboBox)sender).SelectedItem.ToString() == "")
                return;
            
            Core.FixtureAttribute fa = (Core.FixtureAttribute)lbAttributes.SelectedItem;

            switch (((ComboBox)sender).SelectedItem.ToString())
            {
                case "Intensity":
                    fa.Type = Core.FixtureAttributeType.Intensity;
                    break;
                case "Position":
                    fa.Type = Core.FixtureAttributeType.Position;
                    break;
                case "Color":
                    fa.Type = Core.FixtureAttributeType.Color;
                    break;
                case "Gobo":
                    fa.Type = Core.FixtureAttributeType.Gobo;
                    break;
                case "Other":
                    fa.Type = Core.FixtureAttributeType.Other;
                    break;
            }
        }

        /// <summary>
        /// Add a channel to the selected attribute
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddChannel_Click(object sender, EventArgs e)
        {
            if (currentFixture == null || (Core.FixtureAttribute)lbAttributes.SelectedItem == null)
                return;

            Core.FixtureAttribute fa = (Core.FixtureAttribute)lbAttributes.SelectedItem;
            Core.FixtureAttributeChannel c = new Core.FixtureAttributeChannel();
            c.Title = "New Channel";
            c.Type = Core.FixtureAttributeChannelType.Default;
            c.Resolution = 8;
            c.Presidence = Core.ChannelPresidence.HTP;
            c.RelativeChannelNumber = 1;
            fa.Channels.Add(c);

            FixtureEditorEditChannel ecf = new FixtureEditorEditChannel(c);
            ecf.Owner = this;
            ecf.ShowDialog();
        }

        /// <summary>
        /// Load existing channel into editor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditChannel_Click(object sender, EventArgs e)
        {
            if(currentFixture == null || lbAttributeChannels.SelectedItem == null)
                return;

            Core.FixtureAttributeChannel c = (Core.FixtureAttributeChannel)lbAttributeChannels.SelectedItem;

            FixtureEditorEditChannel ecf = new FixtureEditorEditChannel(c);
            ecf.Owner = this;
            ecf.ShowDialog();
        }

        /// <summary>
        /// Delete the selected attribute
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteAttribute_Click(object sender, EventArgs e)
        {
            if (currentFixture == null || lbAttributes.SelectedItem == null)
                return;

            currentFixture.Attributes.Remove((Core.FixtureAttribute)lbAttributes.SelectedItem);

            lbAttributeChannels.DataSource = null;
            lbAttributeChannels.Refresh();

            reloadAttributes();
        }

        /// <summary>
        /// Deletes the selected channel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteChannel_Click(object sender, EventArgs e)
        {
            if (currentFixture == null || lbAttributeChannels.SelectedItem == null || lbAttributes.SelectedItem == null)
                return;

            Core.FixtureAttribute fa = (Core.FixtureAttribute)lbAttributes.SelectedItem;

            fa.Channels.Remove((Core.FixtureAttributeChannel)lbAttributeChannels.SelectedItem);

            ReloadChannels();
        }

        private void btnSaveFixture_Click(object sender, EventArgs e)
        {
            if (currentFixture == null || tvFixtures.SelectedNode.Tag == null)
                return;

            if (!currentFixture.SaveToFile(tvFixtures.SelectedNode.Tag.ToString()))
                MessageBox.Show(this, "There was an error saving the fixture.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(this, "The fixture has been saved.", "Fixture Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

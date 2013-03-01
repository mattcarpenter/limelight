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
    public partial class FixtureEditorAddFixture : Form
    {
        public FixtureEditorAddFixture()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Add Fixture
            if (txtFixtureName.Text == "")
            {
                MessageBox.Show(this, "Please enter a name for the fixture.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtFixtureMfr.Text == "")
            {
                MessageBox.Show(this, "Please enter the fixture manufacturer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Instantiate a basic fixture
            Core.Fixture fixture = new Core.Fixture();
            fixture.Title = txtFixtureName.Text;
            fixture.Manufacturer = txtFixtureMfr.Text;

            // Get the fixtures directory
            string path = Directory.GetCurrentDirectory() + @"\fixtures\";

            // Does the MFR directory exist?
            if (!Directory.Exists(path + fixture.Manufacturer))
                Directory.CreateDirectory(path + fixture.Manufacturer);

            if(!fixture.SaveToFile(path + fixture.Manufacturer + "\\" + fixture.Title + ".xml"))
                MessageBox.Show(this,"There was an error saving the fixture.", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);

            this.Close();
        }
    }
}

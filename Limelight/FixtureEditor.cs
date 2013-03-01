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
        public FixtureEditor()
        {
            InitializeComponent();
        }

        private void btnAddFixture_Click(object sender, EventArgs e)
        {
            FixtureEditorAddFixture af = new FixtureEditorAddFixture();
            af.Owner = this;
            af.ShowDialog();
        }

        private void FixtureEditor_Load(object sender, EventArgs e)
        {
            loadFixtures();
        }

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
                    fixNode.Tag = 1;
                }
            }
        }
    }
}

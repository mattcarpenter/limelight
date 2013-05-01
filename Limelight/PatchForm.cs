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
    public partial class PatchForm : Form
    {
        public PatchForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PatchForm_Load(object sender, EventArgs e)
        {
            loadFixtures();

            setupGrid();
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
        /// Set up the datagrid columns
        /// </summary>
        public void setupGrid()
        {
            dgPatch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgPatch.RowHeadersVisible = false;
        }
    }
}

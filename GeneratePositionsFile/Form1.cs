using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JR.Utils.GUI.Forms;

namespace GeneratePositionsFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadPositionsButton_Click(object sender, EventArgs e)
        {
            if (openPositionsFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openPositionsFileDialog.FileName;
                    positionsFile = PositionsFileLoader.LoadPositions(filePath);
                    positionsDataGrid.DataSource = positionsFile.positions;
                    updatesDataGrid.DataSource = null;
                    updatesFile = null;
                    resultsDataGrid.DataSource = null;
                    updatedFile = null;

                    loadUpdateButton.Enabled = true;
                    generateFileButton.Enabled = false;
                    saveAsButton.Enabled = false;
                    dataTabs.SelectedIndex = 0;

                    if (positionsFile.loadExceptions.Count > 0)
                    {
                        FlexibleMessageBox.Show(positionsFile.loadExceptions.Aggregate("", (current, next) => current + "\n" + next), "There were errors loading the positions file.");
                    }
                }
                catch (Exception ex)
                {
                    FlexibleMessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void LoadUpdateButton_Click(object sender, EventArgs e)
        {
            if (openUpdateFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openUpdateFileDialog.FileName;
                    updatesFile = UpdatesFileLoader.GenerateUpdatesFile(filePath);
                    updatesDataGrid.DataSource = updatesFile.updates;
                    resultsDataGrid.DataSource = null;
                    updatedFile = null;

                    generateFileButton.Enabled = true;
                    saveAsButton.Enabled = false;
                    dataTabs.SelectedIndex = 1;

                    if (updatesFile.loadExceptions.Count > 0)
                    {
                        FlexibleMessageBox.Show(updatesFile.loadExceptions.Aggregate("", (current, next) => current + "\n" + next), "There were errors loading the updates file.");
                    }
                }
                catch (Exception ex)
                {
                    FlexibleMessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void generateFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                updatedFile = PositionsFileGenerator.UpdatePositionsFile(positionsFile, updatesFile);
                resultsDataGrid.DataSource = updatedFile.positions;

                saveAsButton.Enabled = true;
                dataTabs.SelectedIndex = 2;

                if (updatedFile.loadExceptions.Count > 0)
                {
                    FlexibleMessageBox.Show(updatedFile.loadExceptions.Aggregate("", (current, next) => current + "\n" + next), "There were errors generating the results.");
                }
            }
            catch (Exception ex)
            {
                FlexibleMessageBox.Show(ex.Message, "Error");
            }
        }

        private void saveAsButton_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                var generatedPositionFile = PositionsFileGenerator.GeneratePositionsFile(updatedFile);
                System.IO.File.WriteAllText(saveFileDialog.FileName, generatedPositionFile);
            }
        }
    }
}

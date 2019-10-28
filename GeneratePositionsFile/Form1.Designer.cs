namespace GeneratePositionsFile
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoadPositionsButton = new System.Windows.Forms.Button();
            this.loadUpdateButton = new System.Windows.Forms.Button();
            this.generateFileButton = new System.Windows.Forms.Button();
            this.saveAsButton = new System.Windows.Forms.Button();
            this.dataTabs = new System.Windows.Forms.TabControl();
            this.positionsTab = new System.Windows.Forms.TabPage();
            this.positionsDataGrid = new System.Windows.Forms.DataGridView();
            this.updateTab = new System.Windows.Forms.TabPage();
            this.updatesDataGrid = new System.Windows.Forms.DataGridView();
            this.resultsTab = new System.Windows.Forms.TabPage();
            this.resultsDataGrid = new System.Windows.Forms.DataGridView();
            this.openPositionsFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.openUpdateFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.dataTabs.SuspendLayout();
            this.positionsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionsDataGrid)).BeginInit();
            this.updateTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updatesDataGrid)).BeginInit();
            this.resultsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadPositionsButton
            // 
            this.LoadPositionsButton.Location = new System.Drawing.Point(12, 12);
            this.LoadPositionsButton.Name = "LoadPositionsButton";
            this.LoadPositionsButton.Size = new System.Drawing.Size(73, 43);
            this.LoadPositionsButton.TabIndex = 0;
            this.LoadPositionsButton.Text = "Load Positions";
            this.LoadPositionsButton.UseVisualStyleBackColor = true;
            this.LoadPositionsButton.Click += new System.EventHandler(this.LoadPositionsButton_Click);
            // 
            // loadUpdateButton
            // 
            this.loadUpdateButton.Enabled = false;
            this.loadUpdateButton.Location = new System.Drawing.Point(91, 12);
            this.loadUpdateButton.Name = "loadUpdateButton";
            this.loadUpdateButton.Size = new System.Drawing.Size(73, 43);
            this.loadUpdateButton.TabIndex = 1;
            this.loadUpdateButton.Text = "Load Update";
            this.loadUpdateButton.UseVisualStyleBackColor = true;
            this.loadUpdateButton.Click += new System.EventHandler(this.LoadUpdateButton_Click);
            // 
            // generateFileButton
            // 
            this.generateFileButton.Enabled = false;
            this.generateFileButton.Location = new System.Drawing.Point(170, 12);
            this.generateFileButton.Name = "generateFileButton";
            this.generateFileButton.Size = new System.Drawing.Size(73, 43);
            this.generateFileButton.TabIndex = 2;
            this.generateFileButton.Text = "Generate File";
            this.generateFileButton.UseVisualStyleBackColor = true;
            this.generateFileButton.Click += new System.EventHandler(this.generateFileButton_Click);
            // 
            // saveAsButton
            // 
            this.saveAsButton.Enabled = false;
            this.saveAsButton.Location = new System.Drawing.Point(711, 12);
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.saveAsButton.Size = new System.Drawing.Size(73, 43);
            this.saveAsButton.TabIndex = 3;
            this.saveAsButton.Text = "Save File";
            this.saveAsButton.UseVisualStyleBackColor = true;
            this.saveAsButton.Click += new System.EventHandler(this.saveAsButton_Click);
            // 
            // dataTabs
            // 
            this.dataTabs.Controls.Add(this.positionsTab);
            this.dataTabs.Controls.Add(this.updateTab);
            this.dataTabs.Controls.Add(this.resultsTab);
            this.dataTabs.Location = new System.Drawing.Point(12, 74);
            this.dataTabs.Name = "dataTabs";
            this.dataTabs.SelectedIndex = 0;
            this.dataTabs.Size = new System.Drawing.Size(776, 364);
            this.dataTabs.TabIndex = 4;
            // 
            // positionsTab
            // 
            this.positionsTab.Controls.Add(this.positionsDataGrid);
            this.positionsTab.Location = new System.Drawing.Point(4, 22);
            this.positionsTab.Name = "positionsTab";
            this.positionsTab.Padding = new System.Windows.Forms.Padding(3);
            this.positionsTab.Size = new System.Drawing.Size(768, 338);
            this.positionsTab.TabIndex = 0;
            this.positionsTab.Text = "Positions";
            this.positionsTab.UseVisualStyleBackColor = true;
            // 
            // positionsDataGrid
            // 
            this.positionsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.positionsDataGrid.Location = new System.Drawing.Point(4, 7);
            this.positionsDataGrid.Name = "positionsDataGrid";
            this.positionsDataGrid.Size = new System.Drawing.Size(758, 325);
            this.positionsDataGrid.TabIndex = 0;
            // 
            // updateTab
            // 
            this.updateTab.Controls.Add(this.updatesDataGrid);
            this.updateTab.Location = new System.Drawing.Point(4, 22);
            this.updateTab.Name = "updateTab";
            this.updateTab.Padding = new System.Windows.Forms.Padding(3);
            this.updateTab.Size = new System.Drawing.Size(768, 338);
            this.updateTab.TabIndex = 1;
            this.updateTab.Text = "Update";
            this.updateTab.UseVisualStyleBackColor = true;
            // 
            // updatesDataGrid
            // 
            this.updatesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.updatesDataGrid.Location = new System.Drawing.Point(4, 7);
            this.updatesDataGrid.Name = "updatesDataGrid";
            this.updatesDataGrid.Size = new System.Drawing.Size(758, 326);
            this.updatesDataGrid.TabIndex = 1;
            // 
            // resultsTab
            // 
            this.resultsTab.Controls.Add(this.resultsDataGrid);
            this.resultsTab.Location = new System.Drawing.Point(4, 22);
            this.resultsTab.Name = "resultsTab";
            this.resultsTab.Padding = new System.Windows.Forms.Padding(3);
            this.resultsTab.Size = new System.Drawing.Size(768, 338);
            this.resultsTab.TabIndex = 2;
            this.resultsTab.Text = "Results";
            this.resultsTab.UseVisualStyleBackColor = true;
            // 
            // resultsDataGrid
            // 
            this.resultsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultsDataGrid.Location = new System.Drawing.Point(4, 7);
            this.resultsDataGrid.Name = "resultsDataGrid";
            this.resultsDataGrid.Size = new System.Drawing.Size(758, 326);
            this.resultsDataGrid.TabIndex = 2;
            // 
            // openPositionsFileDialog
            // 
            this.openPositionsFileDialog.Filter = "txt files (*.txt)|*.txt";
            // 
            // openUpdateFileDialog
            // 
            this.openUpdateFileDialog.Filter = "excel files (*.xls)|*.xls";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "text file|*.txt";
            this.saveFileDialog.Title = "Save Positions File";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataTabs);
            this.Controls.Add(this.saveAsButton);
            this.Controls.Add(this.generateFileButton);
            this.Controls.Add(this.loadUpdateButton);
            this.Controls.Add(this.LoadPositionsButton);
            this.Name = "Form1";
            this.Text = "Update Positions File";
            this.dataTabs.ResumeLayout(false);
            this.positionsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.positionsDataGrid)).EndInit();
            this.updateTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.updatesDataGrid)).EndInit();
            this.resultsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoadPositionsButton;
        private System.Windows.Forms.Button loadUpdateButton;
        private System.Windows.Forms.Button generateFileButton;
        private System.Windows.Forms.Button saveAsButton;
        private System.Windows.Forms.TabControl dataTabs;
        private System.Windows.Forms.TabPage positionsTab;
        private System.Windows.Forms.TabPage updateTab;
        private System.Windows.Forms.TabPage resultsTab;
        private System.Windows.Forms.OpenFileDialog openPositionsFileDialog;
        private System.Windows.Forms.OpenFileDialog openUpdateFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.DataGridView positionsDataGrid;
        private PositionsFile positionsFile;
        private UpdatesFile updatesFile;
        private PositionsFile updatedFile;
        private System.Windows.Forms.DataGridView updatesDataGrid;
        private System.Windows.Forms.DataGridView resultsDataGrid;
    }
}


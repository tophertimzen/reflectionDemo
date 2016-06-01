namespace reflectionDemoGUI
{
    partial class reflection
    {
        #region Component Designer generated code

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView hierarchyViewer_TN;
        private System.Windows.Forms.Button refreshDomain_BT;

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.hierarchyViewer_TN = new System.Windows.Forms.TreeView();
            this.refreshDomain_BT = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.hierarchyViewer_TN);
            this.panel1.Controls.Add(this.refreshDomain_BT);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 150);
            this.panel1.TabIndex = 2;
            // 
            // hierarchyViewer_TN
            // 
            this.hierarchyViewer_TN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hierarchyViewer_TN.Location = new System.Drawing.Point(0, 25);
            this.hierarchyViewer_TN.Name = "hierarchyViewer_TN";
            this.hierarchyViewer_TN.Size = new System.Drawing.Size(150, 125);
            this.hierarchyViewer_TN.TabIndex = 0;
            this.hierarchyViewer_TN.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.hierarchyViewer_TN_AfterSelect_1);
            // 
            // refreshDomain_BT
            // 
            this.refreshDomain_BT.Dock = System.Windows.Forms.DockStyle.Top;
            this.refreshDomain_BT.Location = new System.Drawing.Point(0, 0);
            this.refreshDomain_BT.Name = "refreshDomain_BT";
            this.refreshDomain_BT.Size = new System.Drawing.Size(150, 25);
            this.refreshDomain_BT.TabIndex = 0;
            this.refreshDomain_BT.Text = "Refresh Domain";
            this.refreshDomain_BT.UseVisualStyleBackColor = true;
            this.refreshDomain_BT.Click += new System.EventHandler(this.refreshDomain_BT_Click_1);
            // 
            // reflection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "reflection";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion
    }
}

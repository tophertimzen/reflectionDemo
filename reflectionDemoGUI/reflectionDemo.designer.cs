namespace reflectionDemoGUI
{
    partial class ReflectionDemo
    {
        #region Windows Form Designer generated code
        private reflection reflection1;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReflectionDemo));
            this.reflection1 = new reflectionDemoGUI.reflection();
            this.SuspendLayout();
            // 
            // reflection1
            // 
            this.reflection1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reflection1.Location = new System.Drawing.Point(0, 0);
            this.reflection1.Name = "reflection1";
            this.reflection1.Size = new System.Drawing.Size(284, 262);
            this.reflection1.TabIndex = 0;
            this.reflection1.Load += new System.EventHandler(this.reflection1_Load);
            // 
            // ReflectionDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.reflection1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReflectionDemo";
            this.Text = "Reflection Demo ";
            this.ResumeLayout(false);
        }
        #endregion
    }
}


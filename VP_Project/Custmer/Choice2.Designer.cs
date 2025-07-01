namespace VP_Project
{
    partial class Choice2
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
            this.btncats = new System.Windows.Forms.Button();
            this.btnproducts = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btncats
            // 
            this.btncats.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btncats.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncats.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btncats.Location = new System.Drawing.Point(552, 452);
            this.btncats.Name = "btncats";
            this.btncats.Size = new System.Drawing.Size(231, 96);
            this.btncats.TabIndex = 0;
            this.btncats.Text = "Categories";
            this.btncats.UseVisualStyleBackColor = false;
            this.btncats.Click += new System.EventHandler(this.btncats_Click);
            // 
            // btnproducts
            // 
            this.btnproducts.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnproducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnproducts.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnproducts.Location = new System.Drawing.Point(1030, 452);
            this.btnproducts.Name = "btnproducts";
            this.btnproducts.Size = new System.Drawing.Size(241, 96);
            this.btnproducts.TabIndex = 1;
            this.btnproducts.Text = "Products";
            this.btnproducts.UseVisualStyleBackColor = false;
            this.btnproducts.Click += new System.EventHandler(this.btnproducts_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Goudy Stout", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(718, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 66);
            this.label1.TabIndex = 2;
            this.label1.Text = "Shop By";
            // 
            // Choice2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::VP_Project.Properties.Resources.backgrond;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1725, 812);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnproducts);
            this.Controls.Add(this.btncats);
            this.Name = "Choice2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choice2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Choice2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btncats;
        private System.Windows.Forms.Button btnproducts;
        private System.Windows.Forms.Label label1;
    }
}
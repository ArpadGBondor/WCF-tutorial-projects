namespace WindowsClient
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
            this.btnGet1 = new System.Windows.Forms.Button();
            this.btnGet2 = new System.Windows.Forms.Button();
            this.btnGet3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGet1
            // 
            this.btnGet1.Location = new System.Drawing.Point(13, 13);
            this.btnGet1.Name = "btnGet1";
            this.btnGet1.Size = new System.Drawing.Size(424, 23);
            this.btnGet1.TabIndex = 0;
            this.btnGet1.Text = "Get Message - Not Signed and Not Encrypted";
            this.btnGet1.UseVisualStyleBackColor = true;
            this.btnGet1.Click += new System.EventHandler(this.btnGet1_Click);
            // 
            // btnGet2
            // 
            this.btnGet2.Location = new System.Drawing.Point(12, 47);
            this.btnGet2.Name = "btnGet2";
            this.btnGet2.Size = new System.Drawing.Size(424, 23);
            this.btnGet2.TabIndex = 1;
            this.btnGet2.Text = "Get Message - Signed and Not Encrypted";
            this.btnGet2.UseVisualStyleBackColor = true;
            this.btnGet2.Click += new System.EventHandler(this.btnGet2_Click);
            // 
            // btnGet3
            // 
            this.btnGet3.Location = new System.Drawing.Point(13, 76);
            this.btnGet3.Name = "btnGet3";
            this.btnGet3.Size = new System.Drawing.Size(424, 23);
            this.btnGet3.TabIndex = 2;
            this.btnGet3.Text = "Get Message - Signed and Encrypted";
            this.btnGet3.UseVisualStyleBackColor = true;
            this.btnGet3.Click += new System.EventHandler(this.btnGet3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 117);
            this.Controls.Add(this.btnGet3);
            this.Controls.Add(this.btnGet2);
            this.Controls.Add(this.btnGet1);
            this.Name = "Form1";
            this.Text = "Windows Client";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGet1;
        private System.Windows.Forms.Button btnGet2;
        private System.Windows.Forms.Button btnGet3;
    }
}


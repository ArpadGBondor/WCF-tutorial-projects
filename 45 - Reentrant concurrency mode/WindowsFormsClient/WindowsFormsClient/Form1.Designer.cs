namespace WindowsFormsClient
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
            this.btnServiceCall = new System.Windows.Forms.Button();
            this.lblPercentageDone = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnServiceCall
            // 
            this.btnServiceCall.Location = new System.Drawing.Point(13, 13);
            this.btnServiceCall.Name = "btnServiceCall";
            this.btnServiceCall.Size = new System.Drawing.Size(259, 23);
            this.btnServiceCall.TabIndex = 0;
            this.btnServiceCall.Text = "Call Report Service";
            this.btnServiceCall.UseVisualStyleBackColor = true;
            this.btnServiceCall.Click += new System.EventHandler(this.btnServiceCall_Click);
            // 
            // lblPercentageDone
            // 
            this.lblPercentageDone.AutoSize = true;
            this.lblPercentageDone.Location = new System.Drawing.Point(13, 43);
            this.lblPercentageDone.Name = "lblPercentageDone";
            this.lblPercentageDone.Size = new System.Drawing.Size(0, 13);
            this.lblPercentageDone.TabIndex = 1;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(13, 60);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 13);
            this.lblResult.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 92);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblPercentageDone);
            this.Controls.Add(this.btnServiceCall);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnServiceCall;
        private System.Windows.Forms.Label lblPercentageDone;
        private System.Windows.Forms.Label lblResult;
    }
}
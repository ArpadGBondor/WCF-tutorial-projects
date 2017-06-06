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
            this.btnGetEven = new System.Windows.Forms.Button();
            this.btnGetOdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.listBoxEvenNumbers = new System.Windows.Forms.ListBox();
            this.listBoxOddNumbers = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // btnGetEven
            // 
            this.btnGetEven.Location = new System.Drawing.Point(13, 13);
            this.btnGetEven.Name = "btnGetEven";
            this.btnGetEven.Size = new System.Drawing.Size(176, 23);
            this.btnGetEven.TabIndex = 0;
            this.btnGetEven.Text = "Get Even Numbers";
            this.btnGetEven.UseVisualStyleBackColor = true;
            this.btnGetEven.Click += new System.EventHandler(this.btnGetEven_Click);
            // 
            // btnGetOdd
            // 
            this.btnGetOdd.Location = new System.Drawing.Point(196, 13);
            this.btnGetOdd.Name = "btnGetOdd";
            this.btnGetOdd.Size = new System.Drawing.Size(176, 23);
            this.btnGetOdd.TabIndex = 1;
            this.btnGetOdd.Text = "Get Odd Numbers";
            this.btnGetOdd.UseVisualStyleBackColor = true;
            this.btnGetOdd.Click += new System.EventHandler(this.btnGetOdd_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(12, 327);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(360, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear Results";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // listBoxEvenNumbers
            // 
            this.listBoxEvenNumbers.FormattingEnabled = true;
            this.listBoxEvenNumbers.Location = new System.Drawing.Point(13, 43);
            this.listBoxEvenNumbers.Name = "listBoxEvenNumbers";
            this.listBoxEvenNumbers.Size = new System.Drawing.Size(176, 277);
            this.listBoxEvenNumbers.TabIndex = 3;
            // 
            // listBoxOddNumbers
            // 
            this.listBoxOddNumbers.FormattingEnabled = true;
            this.listBoxOddNumbers.Location = new System.Drawing.Point(196, 43);
            this.listBoxOddNumbers.Name = "listBoxOddNumbers";
            this.listBoxOddNumbers.Size = new System.Drawing.Size(176, 277);
            this.listBoxOddNumbers.TabIndex = 4;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 362);
            this.Controls.Add(this.listBoxOddNumbers);
            this.Controls.Add(this.listBoxEvenNumbers);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnGetOdd);
            this.Controls.Add(this.btnGetEven);
            this.Name = "Form1";
            this.Text = "Windows Forms Client";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetEven;
        private System.Windows.Forms.Button btnGetOdd;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ListBox listBoxEvenNumbers;
        private System.Windows.Forms.ListBox listBoxOddNumbers;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}


namespace Facial_Gesture_Recognition
{
    partial class TestForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_PW = new System.Windows.Forms.RadioButton();
            this.rb_Boot = new System.Windows.Forms.RadioButton();
            this.rb_knn = new System.Windows.Forms.RadioButton();
            this.rb_Bays = new System.Windows.Forms.RadioButton();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.BtnBrowse = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.Pbox_Img = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rb_pnn = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pbox_Img)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_pnn);
            this.groupBox1.Controls.Add(this.rb_PW);
            this.groupBox1.Controls.Add(this.rb_Boot);
            this.groupBox1.Controls.Add(this.rb_knn);
            this.groupBox1.Controls.Add(this.rb_Bays);
            this.groupBox1.Location = new System.Drawing.Point(7, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 146);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Algorithm";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // rb_PW
            // 
            this.rb_PW.AutoSize = true;
            this.rb_PW.Location = new System.Drawing.Point(17, 76);
            this.rb_PW.Name = "rb_PW";
            this.rb_PW.Size = new System.Drawing.Size(144, 17);
            this.rb_PW.TabIndex = 3;
            this.rb_PW.TabStop = true;
            this.rb_PW.Text = "Parzen Window Classifier";
            this.rb_PW.UseVisualStyleBackColor = true;
            // 
            // rb_Boot
            // 
            this.rb_Boot.AutoSize = true;
            this.rb_Boot.Location = new System.Drawing.Point(17, 122);
            this.rb_Boot.Name = "rb_Boot";
            this.rb_Boot.Size = new System.Drawing.Size(130, 17);
            this.rb_Boot.TabIndex = 2;
            this.rb_Boot.TabStop = true;
            this.rb_Boot.Text = "Bootstrap Aggregating";
            this.rb_Boot.UseVisualStyleBackColor = true;
            // 
            // rb_knn
            // 
            this.rb_knn.AutoSize = true;
            this.rb_knn.Location = new System.Drawing.Point(17, 53);
            this.rb_knn.Name = "rb_knn";
            this.rb_knn.Size = new System.Drawing.Size(162, 17);
            this.rb_knn.TabIndex = 1;
            this.rb_knn.TabStop = true;
            this.rb_knn.Text = "K-Nearest Neighbor Classifier";
            this.rb_knn.UseVisualStyleBackColor = true;
            // 
            // rb_Bays
            // 
            this.rb_Bays.AutoSize = true;
            this.rb_Bays.Location = new System.Drawing.Point(17, 30);
            this.rb_Bays.Name = "rb_Bays";
            this.rb_Bays.Size = new System.Drawing.Size(112, 17);
            this.rb_Bays.TabIndex = 0;
            this.rb_Bays.TabStop = true;
            this.rb_Bays.Text = "Bayesian Classifier";
            this.rb_Bays.UseVisualStyleBackColor = true;
            // 
            // txt_path
            // 
            this.txt_path.Location = new System.Drawing.Point(9, 19);
            this.txt_path.Name = "txt_path";
            this.txt_path.Size = new System.Drawing.Size(265, 20);
            this.txt_path.TabIndex = 3;
            // 
            // BtnBrowse
            // 
            this.BtnBrowse.Location = new System.Drawing.Point(286, 17);
            this.BtnBrowse.Name = "BtnBrowse";
            this.BtnBrowse.Size = new System.Drawing.Size(75, 23);
            this.BtnBrowse.TabIndex = 4;
            this.BtnBrowse.Text = "Browse";
            this.BtnBrowse.UseVisualStyleBackColor = true;
            this.BtnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnBrowse);
            this.groupBox2.Controls.Add(this.txt_path);
            this.groupBox2.Location = new System.Drawing.Point(7, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(370, 56);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Choose Image";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(293, 125);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Pbox_Img
            // 
            this.Pbox_Img.Location = new System.Drawing.Point(6, 19);
            this.Pbox_Img.Name = "Pbox_Img";
            this.Pbox_Img.Size = new System.Drawing.Size(295, 222);
            this.Pbox_Img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Pbox_Img.TabIndex = 7;
            this.Pbox_Img.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Pbox_Img);
            this.groupBox3.Location = new System.Drawing.Point(34, 219);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(307, 247);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tested Image";
            // 
            // rb_pnn
            // 
            this.rb_pnn.AutoSize = true;
            this.rb_pnn.Location = new System.Drawing.Point(17, 99);
            this.rb_pnn.Name = "rb_pnn";
            this.rb_pnn.Size = new System.Drawing.Size(207, 17);
            this.rb_pnn.TabIndex = 4;
            this.rb_pnn.TabStop = true;
            this.rb_pnn.Text = "Probabilistic Neural Networks Classifier";
            this.rb_pnn.UseVisualStyleBackColor = true;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 478);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pbox_Img)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_Bays;
        private System.Windows.Forms.RadioButton rb_knn;
        private System.Windows.Forms.RadioButton rb_Boot;
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.Button BtnBrowse;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.PictureBox Pbox_Img;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rb_PW;
        private System.Windows.Forms.RadioButton rb_pnn;
    }
}
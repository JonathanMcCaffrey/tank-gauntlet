namespace Button
{
    partial class SaveAndLoad
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
            this.saveInput = new System.Windows.Forms.TextBox();
            this.helper_1 = new System.Windows.Forms.Label();
            this.helper_2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.saveLable = new System.Windows.Forms.Label();
            this.loadLevel = new System.Windows.Forms.Label();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.SuspendLayout();
            // 
            // saveInput
            // 
            this.saveInput.Location = new System.Drawing.Point(12, 31);
            this.saveInput.Name = "saveInput";
            this.saveInput.Size = new System.Drawing.Size(100, 20);
            this.saveInput.TabIndex = 0;
            // 
            // helper_1
            // 
            this.helper_1.AutoSize = true;
            this.helper_1.Location = new System.Drawing.Point(113, 37);
            this.helper_1.Name = "helper_1";
            this.helper_1.Size = new System.Drawing.Size(25, 13);
            this.helper_1.TabIndex = 1;
            this.helper_1.Text = ".xml";
            // 
            // helper_2
            // 
            this.helper_2.AutoSize = true;
            this.helper_2.Location = new System.Drawing.Point(113, 127);
            this.helper_2.Name = "helper_2";
            this.helper_2.Size = new System.Drawing.Size(25, 13);
            this.helper_2.TabIndex = 3;
            this.helper_2.Text = ".xml";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 121);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // saveLable
            // 
            this.saveLable.AutoSize = true;
            this.saveLable.Location = new System.Drawing.Point(12, 12);
            this.saveLable.Name = "saveLable";
            this.saveLable.Size = new System.Drawing.Size(61, 13);
            this.saveLable.TabIndex = 4;
            this.saveLable.Text = "Save Level";
            // 
            // loadLevel
            // 
            this.loadLevel.AutoSize = true;
            this.loadLevel.Location = new System.Drawing.Point(12, 105);
            this.loadLevel.Name = "loadLevel";
            this.loadLevel.Size = new System.Drawing.Size(60, 13);
            this.loadLevel.TabIndex = 5;
            this.loadLevel.Text = "Load Level";
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(12, 148);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 6;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 57);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // openFileDialog3
            // 
            this.openFileDialog3.FileName = "openFileDialog3";
            // 
            // SaveAndLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(165, 188);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.loadLevel);
            this.Controls.Add(this.saveLable);
            this.Controls.Add(this.helper_2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.helper_1);
            this.Controls.Add(this.saveInput);
            this.Name = "SaveAndLoad";
            this.Text = "File";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox saveInput;
        private System.Windows.Forms.Label helper_1;
        private System.Windows.Forms.Label helper_2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label saveLable;
        private System.Windows.Forms.Label loadLevel;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.OpenFileDialog openFileDialog3;
        private System.Windows.Forms.FontDialog fontDialog1;
    }
}
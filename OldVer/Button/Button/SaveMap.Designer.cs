namespace Button
{
    partial class SaveMap
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this._Save = new System.Windows.Forms.Button();
            this._FileNameInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this._Sample = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Name:";
            // 
            // _Save
            // 
            this._Save.Location = new System.Drawing.Point(97, 43);
            this._Save.Name = "_Save";
            this._Save.Size = new System.Drawing.Size(75, 23);
            this._Save.TabIndex = 1;
            this._Save.Text = "Save";
            this._Save.UseVisualStyleBackColor = true;
            this._Save.Click += new System.EventHandler(this._Save_Click);
            // 
            // _FileNameInput
            // 
            this._FileNameInput.Location = new System.Drawing.Point(72, 17);
            this._FileNameInput.Name = "_FileNameInput";
            this._FileNameInput.Size = new System.Drawing.Size(100, 20);
            this._FileNameInput.TabIndex = 2;
            this._FileNameInput.TextChanged += new System.EventHandler(this._FileNameInput_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = ".xml";
            // 
            // _Sample
            // 
            this._Sample.AutoSize = true;
            this._Sample.Location = new System.Drawing.Point(72, 1);
            this._Sample.Name = "_Sample";
            this._Sample.Size = new System.Drawing.Size(35, 13);
            this._Sample.TabIndex = 4;
            this._Sample.Text = "label3";
            // 
            // SaveMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 77);
            this.Controls.Add(this._Sample);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._FileNameInput);
            this.Controls.Add(this._Save);
            this.Controls.Add(this.label1);
            this.Name = "SaveMap";
            this.Text = "SaveMap";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _Save;
        private System.Windows.Forms.TextBox _FileNameInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label _Sample;
    }
}
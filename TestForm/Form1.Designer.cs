namespace TestForm
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cboBaseMaterial = new System.Windows.Forms.ComboBox();
            this.txtConstructor = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(415, 190);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(373, 248);
            this.textBox1.TabIndex = 1;
            // 
            // cboBaseMaterial
            // 
            this.cboBaseMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBaseMaterial.FormattingEnabled = true;
            this.cboBaseMaterial.Location = new System.Drawing.Point(12, 12);
            this.cboBaseMaterial.Name = "cboBaseMaterial";
            this.cboBaseMaterial.Size = new System.Drawing.Size(315, 21);
            this.cboBaseMaterial.TabIndex = 2;
            this.cboBaseMaterial.SelectedIndexChanged += new System.EventHandler(this.cboBaseMaterial_SelectedIndexChanged);
            // 
            // txtConstructor
            // 
            this.txtConstructor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConstructor.Location = new System.Drawing.Point(415, 12);
            this.txtConstructor.Multiline = true;
            this.txtConstructor.Name = "txtConstructor";
            this.txtConstructor.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConstructor.Size = new System.Drawing.Size(373, 172);
            this.txtConstructor.TabIndex = 1;
            this.txtConstructor.TextChanged += new System.EventHandler(this.txtConstructor_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cboBaseMaterial);
            this.Controls.Add(this.txtConstructor);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cboBaseMaterial;
        private System.Windows.Forms.TextBox txtConstructor;
    }
}


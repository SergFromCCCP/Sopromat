namespace TestForm
{
    partial class formEditor
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkSubstract = new System.Windows.Forms.CheckBox();
            this.cboBaseShapes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtData1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtData2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtRotate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtY = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtX = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMaterial = new System.Windows.Forms.ComboBox();
            this.shapeList = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkSubstract);
            this.groupBox2.Controls.Add(this.cboBaseShapes);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtData1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtData2);
            this.groupBox2.Location = new System.Drawing.Point(325, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 134);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Базовая фигура";
            // 
            // checkSubstract
            // 
            this.checkSubstract.AutoSize = true;
            this.checkSubstract.Location = new System.Drawing.Point(15, 101);
            this.checkSubstract.Name = "checkSubstract";
            this.checkSubstract.Size = new System.Drawing.Size(69, 17);
            this.checkSubstract.TabIndex = 3;
            this.checkSubstract.Text = "Вычесть";
            this.checkSubstract.UseVisualStyleBackColor = true;
            // 
            // cboBaseShapes
            // 
            this.cboBaseShapes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBaseShapes.FormattingEnabled = true;
            this.cboBaseShapes.Location = new System.Drawing.Point(6, 19);
            this.cboBaseShapes.Name = "cboBaseShapes";
            this.cboBaseShapes.Size = new System.Drawing.Size(207, 21);
            this.cboBaseShapes.TabIndex = 0;
            this.cboBaseShapes.SelectedIndexChanged += new System.EventHandler(this.cboBaseShapes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // txtData1
            // 
            this.txtData1.Location = new System.Drawing.Point(113, 46);
            this.txtData1.Name = "txtData1";
            this.txtData1.Size = new System.Drawing.Size(100, 20);
            this.txtData1.TabIndex = 1;
            this.txtData1.Text = "100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "label1";
            // 
            // txtData2
            // 
            this.txtData2.Location = new System.Drawing.Point(113, 72);
            this.txtData2.Name = "txtData2";
            this.txtData2.Size = new System.Drawing.Size(100, 20);
            this.txtData2.TabIndex = 2;
            this.txtData2.Text = "200";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(334, 279);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Добавить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(93, 250);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "button1";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // txtRotate
            // 
            this.txtRotate.Location = new System.Drawing.Point(154, 47);
            this.txtRotate.Name = "txtRotate";
            this.txtRotate.Size = new System.Drawing.Size(36, 20);
            this.txtRotate.TabIndex = 2;
            this.txtRotate.Text = "360";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Материал";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Угол поворота (градусов)";
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(129, 19);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(61, 20);
            this.txtY.TabIndex = 1;
            this.txtY.Text = "200";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(174, 250);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "button1";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(109, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Y";
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(31, 19);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(59, 20);
            this.txtX.TabIndex = 0;
            this.txtX.Text = "100";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRotate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtY);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtX);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboMaterial);
            this.groupBox1.Location = new System.Drawing.Point(325, 152);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 103);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Конкретизация";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "X";
            // 
            // cboMaterial
            // 
            this.cboMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaterial.FormattingEnabled = true;
            this.cboMaterial.Location = new System.Drawing.Point(90, 73);
            this.cboMaterial.Name = "cboMaterial";
            this.cboMaterial.Size = new System.Drawing.Size(100, 21);
            this.cboMaterial.TabIndex = 3;
            // 
            // shapeList
            // 
            this.shapeList.FormattingEnabled = true;
            this.shapeList.Location = new System.Drawing.Point(12, 12);
            this.shapeList.Name = "shapeList";
            this.shapeList.Size = new System.Drawing.Size(291, 225);
            this.shapeList.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 250);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "button1";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // formEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 352);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.shapeList);
            this.Controls.Add(this.btnAdd);
            this.Name = "formEditor";
            this.Text = "formEditor";
            this.Load += new System.EventHandler(this.formEditor_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkSubstract;
        private System.Windows.Forms.ComboBox cboBaseShapes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtData1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtData2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtRotate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboMaterial;
        private System.Windows.Forms.ListBox shapeList;
        private System.Windows.Forms.Button btnAdd;
    }
}
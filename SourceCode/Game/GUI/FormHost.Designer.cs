namespace EPAM.TicTacToe
{
    partial class FormHost
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHost));
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownNumberFields = new System.Windows.Forms.NumericUpDown();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonHumvsAlg = new System.Windows.Forms.RadioButton();
            this.radioButtonAlgvsAlg = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.numericUpDownWinSquares = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.labelField = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.playGround = new System.Windows.Forms.PictureBox();
            this.listViewParameters = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberFields)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWinSquares)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playGround)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(16, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите количество полей:";
            // 
            // numericUpDownNumberFields
            // 
            this.numericUpDownNumberFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownNumberFields.Location = new System.Drawing.Point(25, 81);
            this.numericUpDownNumberFields.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownNumberFields.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownNumberFields.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownNumberFields.Name = "numericUpDownNumberFields";
            this.numericUpDownNumberFields.Size = new System.Drawing.Size(136, 23);
            this.numericUpDownNumberFields.TabIndex = 2;
            this.numericUpDownNumberFields.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownNumberFields.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownNumberFields.ValueChanged += new System.EventHandler(this.numericUpDownNumberFields_ValueChanged);
            // 
            // buttonPlay
            // 
            this.buttonPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPlay.Location = new System.Drawing.Point(503, 590);
            this.buttonPlay.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(151, 60);
            this.buttonPlay.TabIndex = 6;
            this.buttonPlay.Text = "Играть";
            this.buttonPlay.UseVisualStyleBackColor = false;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox1.Controls.Add(this.radioButtonHumvsAlg);
            this.groupBox1.Controls.Add(this.radioButtonAlgvsAlg);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxPath);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(8, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(323, 512);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Хост";
            // 
            // radioButtonHumvsAlg
            // 
            this.radioButtonHumvsAlg.AutoSize = true;
            this.radioButtonHumvsAlg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonHumvsAlg.Location = new System.Drawing.Point(12, 199);
            this.radioButtonHumvsAlg.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonHumvsAlg.Name = "radioButtonHumvsAlg";
            this.radioButtonHumvsAlg.Size = new System.Drawing.Size(154, 21);
            this.radioButtonHumvsAlg.TabIndex = 6;
            this.radioButtonHumvsAlg.Text = "Human vs algorithm";
            this.radioButtonHumvsAlg.UseVisualStyleBackColor = true;
            this.radioButtonHumvsAlg.CheckedChanged += new System.EventHandler(this.radioButtonHumvsAlg_CheckedChanged);
            // 
            // radioButtonAlgvsAlg
            // 
            this.radioButtonAlgvsAlg.AutoSize = true;
            this.radioButtonAlgvsAlg.Checked = true;
            this.radioButtonAlgvsAlg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonAlgvsAlg.Location = new System.Drawing.Point(12, 171);
            this.radioButtonAlgvsAlg.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonAlgvsAlg.Name = "radioButtonAlgvsAlg";
            this.radioButtonAlgvsAlg.Size = new System.Drawing.Size(168, 21);
            this.radioButtonAlgvsAlg.TabIndex = 5;
            this.radioButtonAlgvsAlg.TabStop = true;
            this.radioButtonAlgvsAlg.Text = "Algorithm vs algorithm";
            this.radioButtonAlgvsAlg.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(8, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(255, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Введите путь к папке с алгоритмами:";
            // 
            // textBoxPath
            // 
            this.textBoxPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPath.Location = new System.Drawing.Point(8, 66);
            this.textBoxPath.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPath.Multiline = true;
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(307, 68);
            this.textBoxPath.TabIndex = 0;
            this.textBoxPath.Tag = "";
            this.textBoxPath.Text = "C:\\Users\\Mikhail_Golubtcov\\Documents\\TicTacToe\\Assemblies\\TestAlgorithms";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox2.Controls.Add(this.buttonInsert);
            this.groupBox2.Controls.Add(this.numericUpDownWinSquares);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.dateTimePicker);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.labelField);
            this.groupBox2.Controls.Add(this.numericUpDownNumberFields);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(339, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(323, 512);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Данные для игры";
            // 
            // buttonInsert
            // 
            this.buttonInsert.Location = new System.Drawing.Point(80, 438);
            this.buttonInsert.Margin = new System.Windows.Forms.Padding(4);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(141, 44);
            this.buttonInsert.TabIndex = 11;
            this.buttonInsert.Text = "Занести в таблицу";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // numericUpDownWinSquares
            // 
            this.numericUpDownWinSquares.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownWinSquares.Location = new System.Drawing.Point(20, 150);
            this.numericUpDownWinSquares.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownWinSquares.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownWinSquares.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownWinSquares.Name = "numericUpDownWinSquares";
            this.numericUpDownWinSquares.Size = new System.Drawing.Size(136, 23);
            this.numericUpDownWinSquares.TabIndex = 10;
            this.numericUpDownWinSquares.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownWinSquares.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(16, 122);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(283, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "Введите количество выигрышных клеток:";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker.Location = new System.Drawing.Point(20, 224);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.ShowUpDown = true;
            this.dateTimePicker.Size = new System.Drawing.Size(139, 23);
            this.dateTimePicker.TabIndex = 6;
            this.dateTimePicker.Value = new System.DateTime(2017, 10, 20, 0, 0, 0, 0);
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(16, 196);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "Введите время сражения:";
            // 
            // labelField
            // 
            this.labelField.AutoSize = true;
            this.labelField.Location = new System.Drawing.Point(185, 85);
            this.labelField.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelField.Name = "labelField";
            this.labelField.Size = new System.Drawing.Size(43, 17);
            this.labelField.TabIndex = 3;
            this.labelField.Text = "3 x 3";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.playGround);
            this.panel1.Location = new System.Drawing.Point(675, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(749, 683);
            this.panel1.TabIndex = 14;
            // 
            // playGround
            // 
            this.playGround.BackColor = System.Drawing.Color.White;
            this.playGround.Location = new System.Drawing.Point(4, 4);
            this.playGround.Margin = new System.Windows.Forms.Padding(4);
            this.playGround.Name = "playGround";
            this.playGround.Size = new System.Drawing.Size(5721, 5281);
            this.playGround.TabIndex = 16;
            this.playGround.TabStop = false;
            this.playGround.Paint += new System.Windows.Forms.PaintEventHandler(this.playGround_Paint);
            this.playGround.MouseMove += new System.Windows.Forms.MouseEventHandler(this.playGround_MouseMove);
            // 
            // listViewParameters
            // 
            this.listViewParameters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewParameters.Location = new System.Drawing.Point(8, 545);
            this.listViewParameters.Margin = new System.Windows.Forms.Padding(4);
            this.listViewParameters.Name = "listViewParameters";
            this.listViewParameters.Size = new System.Drawing.Size(468, 155);
            this.listViewParameters.TabIndex = 15;
            this.listViewParameters.UseCompatibleStateImageBehavior = false;
            this.listViewParameters.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "";
            this.columnHeader1.Text = "Количество полей";
            this.columnHeader1.Width = 105;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Кол. выигрышных клеток";
            this.columnHeader2.Width = 140;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Время сражения";
            this.columnHeader3.Width = 102;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Image = ((System.Drawing.Image)(resources.GetObject("buttonDelete.Image")));
            this.buttonDelete.Location = new System.Drawing.Point(477, 672);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(33, 31);
            this.buttonDelete.TabIndex = 16;
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // FormHost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1441, 716);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.listViewParameters);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonPlay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormHost";
            this.Text = "Крестики-нолики";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberFields)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWinSquares)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.playGround)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownNumberFields;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.RadioButton radioButtonHumvsAlg;
        private System.Windows.Forms.RadioButton radioButtonAlgvsAlg;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelField;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.NumericUpDown numericUpDownWinSquares;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listViewParameters;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.PictureBox playGround;
        private System.Windows.Forms.Button buttonDelete;
    }
}


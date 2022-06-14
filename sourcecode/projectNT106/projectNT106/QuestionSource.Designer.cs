namespace projectNT106
{
    partial class QuestionSource
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestionSource));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_macauhoi = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddImg = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_Dapandung = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_Cauhoi = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_DapanA = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_DapanB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_DapanC = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_DapanD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbn_Update = new System.Windows.Forms.Button();
            this.tb_Stt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(845, 44);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(455, 273);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 21);
            this.label2.TabIndex = 19;
            this.label2.Text = "Chọn loại câu hỏi";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox1.DropDownHeight = 100;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.Items.AddRange(new object[] {
            "Câu hỏi kiến thức luật",
            "Câu hỏi biển báo",
            "Câu hỏi sa hình"});
            this.comboBox1.Location = new System.Drawing.Point(270, 44);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(292, 29);
            this.comboBox1.TabIndex = 18;
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(28, 131);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(801, 521);
            this.dataGridView1.TabIndex = 16;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 21);
            this.label1.TabIndex = 15;
            this.label1.Text = "Nhập mã câu hỏi";
            // 
            // tb_macauhoi
            // 
            this.tb_macauhoi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_macauhoi.Location = new System.Drawing.Point(270, 89);
            this.tb_macauhoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_macauhoi.Name = "tb_macauhoi";
            this.tb_macauhoi.Size = new System.Drawing.Size(292, 28);
            this.tb_macauhoi.TabIndex = 14;
            this.tb_macauhoi.TextChanged += new System.EventHandler(this.tb_macauhoi_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnAddImg);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_macauhoi);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(19, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1341, 687);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // btnAddImg
            // 
            this.btnAddImg.BackColor = System.Drawing.Color.Transparent;
            this.btnAddImg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddImg.BackgroundImage")));
            this.btnAddImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddImg.Location = new System.Drawing.Point(857, 58);
            this.btnAddImg.Name = "btnAddImg";
            this.btnAddImg.Size = new System.Drawing.Size(36, 31);
            this.btnAddImg.TabIndex = 42;
            this.btnAddImg.UseVisualStyleBackColor = false;
            this.btnAddImg.Click += new System.EventHandler(this.btnAddImg_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tb_Dapandung);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.tb_Cauhoi);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.tb_DapanA);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tb_DapanB);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.tb_DapanC);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tb_DapanD);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbn_Update);
            this.groupBox2.Controls.Add(this.tb_Stt);
            this.groupBox2.Location = new System.Drawing.Point(845, 299);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(455, 353);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 21);
            this.label4.TabIndex = 54;
            this.label4.Text = "Đáp án đúng:";
            // 
            // tb_Dapandung
            // 
            this.tb_Dapandung.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_Dapandung.Location = new System.Drawing.Point(156, 247);
            this.tb_Dapandung.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_Dapandung.Name = "tb_Dapandung";
            this.tb_Dapandung.Size = new System.Drawing.Size(260, 28);
            this.tb_Dapandung.TabIndex = 53;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(22, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 21);
            this.label11.TabIndex = 52;
            this.label11.Text = "Câu hỏi:";
            // 
            // tb_Cauhoi
            // 
            this.tb_Cauhoi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_Cauhoi.Location = new System.Drawing.Point(156, 71);
            this.tb_Cauhoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_Cauhoi.Name = "tb_Cauhoi";
            this.tb_Cauhoi.Size = new System.Drawing.Size(260, 28);
            this.tb_Cauhoi.TabIndex = 51;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(22, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 21);
            this.label10.TabIndex = 50;
            this.label10.Text = "Đáp án A:";
            // 
            // tb_DapanA
            // 
            this.tb_DapanA.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_DapanA.Location = new System.Drawing.Point(156, 106);
            this.tb_DapanA.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_DapanA.Name = "tb_DapanA";
            this.tb_DapanA.Size = new System.Drawing.Size(260, 28);
            this.tb_DapanA.TabIndex = 49;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(22, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 21);
            this.label9.TabIndex = 48;
            this.label9.Text = "Đáp án B:";
            // 
            // tb_DapanB
            // 
            this.tb_DapanB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_DapanB.Location = new System.Drawing.Point(156, 141);
            this.tb_DapanB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_DapanB.Name = "tb_DapanB";
            this.tb_DapanB.Size = new System.Drawing.Size(260, 28);
            this.tb_DapanB.TabIndex = 47;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(22, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 21);
            this.label8.TabIndex = 46;
            this.label8.Text = "Đáp án C:";
            // 
            // tb_DapanC
            // 
            this.tb_DapanC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_DapanC.Location = new System.Drawing.Point(156, 175);
            this.tb_DapanC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_DapanC.Name = "tb_DapanC";
            this.tb_DapanC.Size = new System.Drawing.Size(260, 28);
            this.tb_DapanC.TabIndex = 45;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(22, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 21);
            this.label7.TabIndex = 44;
            this.label7.Text = "Đáp án D:";
            // 
            // tb_DapanD
            // 
            this.tb_DapanD.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_DapanD.Location = new System.Drawing.Point(156, 211);
            this.tb_DapanD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_DapanD.Name = "tb_DapanD";
            this.tb_DapanD.Size = new System.Drawing.Size(260, 28);
            this.tb_DapanD.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 21);
            this.label3.TabIndex = 42;
            this.label3.Text = "STT:";
            // 
            // tbn_Update
            // 
            this.tbn_Update.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbn_Update.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.tbn_Update.Location = new System.Drawing.Point(196, 288);
            this.tbn_Update.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbn_Update.Name = "tbn_Update";
            this.tbn_Update.Size = new System.Drawing.Size(112, 50);
            this.tbn_Update.TabIndex = 41;
            this.tbn_Update.Text = "Cập nhật";
            this.tbn_Update.UseVisualStyleBackColor = true;
            this.tbn_Update.Click += new System.EventHandler(this.tbn_Update_Click);
            // 
            // tb_Stt
            // 
            this.tb_Stt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_Stt.Enabled = false;
            this.tb_Stt.Location = new System.Drawing.Point(156, 36);
            this.tb_Stt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_Stt.Name = "tb_Stt";
            this.tb_Stt.Size = new System.Drawing.Size(260, 28);
            this.tb_Stt.TabIndex = 40;
            // 
            // QuestionSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1372, 689);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QuestionSource";
            this.Text = "QuestionSource";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GradientPanel gradientPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_macauhoi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_Dapandung;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_Cauhoi;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_DapanA;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_DapanB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_DapanC;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_DapanD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_Stt;
        private System.Windows.Forms.Button tbn_Update;
        private System.Windows.Forms.Button btnAddImg;
    }
}
namespace projectNT106
{
    partial class RankingServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RankingServer));
            this.gradientPanel1 = new projectNT106.GradientPanel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.roundedPanel3 = new projectNT106.Graph.RoundedPanel();
            this.ptbTop3 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.roundedPanel2 = new projectNT106.Graph.RoundedPanel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.ptbTop2 = new System.Windows.Forms.PictureBox();
            this.roundedPanel1 = new projectNT106.Graph.RoundedPanel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.ptbTop1 = new System.Windows.Forms.PictureBox();
            this.gradientPanel1.SuspendLayout();
            this.roundedPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTop3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.roundedPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTop2)).BeginInit();
            this.roundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTop1)).BeginInit();
            this.SuspendLayout();
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Angle = 90F;
            this.gradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gradientPanel1.BottomColor = System.Drawing.Color.Transparent;
            this.gradientPanel1.Controls.Add(this.listView1);
            this.gradientPanel1.Controls.Add(this.label1);
            this.gradientPanel1.Controls.Add(this.btnCreate);
            this.gradientPanel1.Controls.Add(this.button2);
            this.gradientPanel1.Controls.Add(this.roundedPanel3);
            this.gradientPanel1.Controls.Add(this.roundedPanel2);
            this.gradientPanel1.Controls.Add(this.roundedPanel1);
            this.gradientPanel1.Location = new System.Drawing.Point(86, 24);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(1048, 643);
            this.gradientPanel1.TabIndex = 1;
            this.gradientPanel1.TopColor = System.Drawing.Color.White;
            this.gradientPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.gradientPanel1_Paint);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(400, 66);
            this.listView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(614, 439);
            this.listView1.TabIndex = 19;
            this.listView1.TileSize = new System.Drawing.Size(180, 90);
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Rank";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "User Name";
            this.columnHeader2.Width = 300;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Total Mark";
            this.columnHeader3.Width = 150;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 28F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.label1.Location = new System.Drawing.Point(34, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 106);
            this.label1.TabIndex = 18;
            this.label1.Text = "Result";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.Green;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCreate.Location = new System.Drawing.Point(400, 534);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(204, 86);
            this.btnCreate.TabIndex = 17;
            this.btnCreate.Text = "Tạo phòng mới";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Firebrick;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Location = new System.Drawing.Point(818, 534);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 86);
            this.button2.TabIndex = 16;
            this.button2.Text = "Thoát";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // roundedPanel3
            // 
            this.roundedPanel3.Angle = 180F;
            this.roundedPanel3.BottomColor = System.Drawing.Color.Wheat;
            this.roundedPanel3.Controls.Add(this.ptbTop3);
            this.roundedPanel3.Controls.Add(this.pictureBox6);
            this.roundedPanel3.Location = new System.Drawing.Point(-40, 405);
            this.roundedPanel3.Name = "roundedPanel3";
            this.roundedPanel3.Size = new System.Drawing.Size(264, 98);
            this.roundedPanel3.TabIndex = 2;
            this.roundedPanel3.TopColor = System.Drawing.Color.Chocolate;
            // 
            // ptbTop3
            // 
            this.ptbTop3.BackColor = System.Drawing.Color.Transparent;
            this.ptbTop3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ptbTop3.Location = new System.Drawing.Point(46, 0);
            this.ptbTop3.Name = "ptbTop3";
            this.ptbTop3.Size = new System.Drawing.Size(116, 97);
            this.ptbTop3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbTop3.TabIndex = 3;
            this.ptbTop3.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(120, -20);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(166, 123);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 2;
            this.pictureBox6.TabStop = false;
            // 
            // roundedPanel2
            // 
            this.roundedPanel2.Angle = 180F;
            this.roundedPanel2.BottomColor = System.Drawing.Color.FloralWhite;
            this.roundedPanel2.Controls.Add(this.pictureBox5);
            this.roundedPanel2.Controls.Add(this.ptbTop2);
            this.roundedPanel2.Location = new System.Drawing.Point(-50, 280);
            this.roundedPanel2.Name = "roundedPanel2";
            this.roundedPanel2.Size = new System.Drawing.Size(296, 97);
            this.roundedPanel2.TabIndex = 2;
            this.roundedPanel2.TopColor = System.Drawing.Color.Silver;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(176, -37);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(98, 134);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 2;
            this.pictureBox5.TabStop = false;
            // 
            // ptbTop2
            // 
            this.ptbTop2.BackColor = System.Drawing.Color.Transparent;
            this.ptbTop2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ptbTop2.Location = new System.Drawing.Point(56, 5);
            this.ptbTop2.Name = "ptbTop2";
            this.ptbTop2.Size = new System.Drawing.Size(126, 92);
            this.ptbTop2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbTop2.TabIndex = 0;
            this.ptbTop2.TabStop = false;
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.Angle = 180F;
            this.roundedPanel1.BottomColor = System.Drawing.Color.Cornsilk;
            this.roundedPanel1.Controls.Add(this.pictureBox4);
            this.roundedPanel1.Controls.Add(this.ptbTop1);
            this.roundedPanel1.Location = new System.Drawing.Point(-50, 155);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Size = new System.Drawing.Size(324, 102);
            this.roundedPanel1.TabIndex = 0;
            this.roundedPanel1.TopColor = System.Drawing.Color.Gold;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(184, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(128, 100);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 2;
            this.pictureBox4.TabStop = false;
            // 
            // ptbTop1
            // 
            this.ptbTop1.BackColor = System.Drawing.Color.Transparent;
            this.ptbTop1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ptbTop1.Location = new System.Drawing.Point(56, 0);
            this.ptbTop1.Name = "ptbTop1";
            this.ptbTop1.Size = new System.Drawing.Size(134, 98);
            this.ptbTop1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbTop1.TabIndex = 0;
            this.ptbTop1.TabStop = false;
            // 
            // RankingServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1221, 690);
            this.Controls.Add(this.gradientPanel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RankingServer";
            this.Text = "RankingServer";
            this.Load += new System.EventHandler(this.RankingServer_Load);
            this.gradientPanel1.ResumeLayout(false);
            this.roundedPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbTop3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.roundedPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTop2)).EndInit();
            this.roundedPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTop1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbTop1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox ptbTop2;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox ptbTop3;
        private Graph.RoundedPanel roundedPanel3;
        private Graph.RoundedPanel roundedPanel2;
        private Graph.RoundedPanel roundedPanel1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private GradientPanel gradientPanel1;
    }
}
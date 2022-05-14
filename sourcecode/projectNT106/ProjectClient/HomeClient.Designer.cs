namespace ProjectClient
{
    partial class HomeClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeClient));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRevision = new System.Windows.Forms.Button();
            this.btnCreateRoom = new System.Windows.Forms.Button();
            this.btnEnterRoom = new System.Windows.Forms.Button();
            this.button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnJoin = new System.Windows.Forms.Button();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtRoomID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnRevision);
            this.groupBox1.Controls.Add(this.btnCreateRoom);
            this.groupBox1.Controls.Add(this.btnEnterRoom);
            this.groupBox1.Controls.Add(this.button);
            this.groupBox1.Location = new System.Drawing.Point(345, 397);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(636, 169);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(15, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "      ";
            // 
            // btnRevision
            // 
            this.btnRevision.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRevision.Location = new System.Drawing.Point(421, 49);
            this.btnRevision.Name = "btnRevision";
            this.btnRevision.Size = new System.Drawing.Size(193, 77);
            this.btnRevision.TabIndex = 12;
            this.btnRevision.Text = "Ôn tập";
            this.btnRevision.UseVisualStyleBackColor = false;
            // 
            // btnCreateRoom
            // 
            this.btnCreateRoom.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCreateRoom.Location = new System.Drawing.Point(222, 49);
            this.btnCreateRoom.Name = "btnCreateRoom";
            this.btnCreateRoom.Size = new System.Drawing.Size(193, 77);
            this.btnCreateRoom.TabIndex = 11;
            this.btnCreateRoom.Text = "Tạo phòng";
            this.btnCreateRoom.UseVisualStyleBackColor = false;
            this.btnCreateRoom.Click += new System.EventHandler(this.btnCreateRoom_Click);
            // 
            // btnEnterRoom
            // 
            this.btnEnterRoom.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEnterRoom.Location = new System.Drawing.Point(19, 49);
            this.btnEnterRoom.Name = "btnEnterRoom";
            this.btnEnterRoom.Size = new System.Drawing.Size(193, 77);
            this.btnEnterRoom.TabIndex = 10;
            this.btnEnterRoom.Text = "Vào phòng";
            this.btnEnterRoom.UseVisualStyleBackColor = false;
            this.btnEnterRoom.Click += new System.EventHandler(this.btnEnterRoom_Click);
            // 
            // button
            // 
            this.button.BackColor = System.Drawing.Color.Transparent;
            this.button.Location = new System.Drawing.Point(28, 20);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(10, 10);
            this.button.TabIndex = 8;
            this.button.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(679, 153);
            this.label1.TabIndex = 5;
            this.label1.Text = "Application";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Script", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(302, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 70);
            this.label2.TabIndex = 6;
            this.label2.Text = "Client";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(155, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1030, 271);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(752, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(278, 266);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnJoin);
            this.groupBox3.Controls.Add(this.txtUserID);
            this.groupBox3.Controls.Add(this.txtRoomID);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(443, 594);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(458, 133);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            // 
            // btnJoin
            // 
            this.btnJoin.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnJoin.Location = new System.Drawing.Point(335, 49);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(105, 50);
            this.btnJoin.TabIndex = 9;
            this.btnJoin.Text = "Tham gia";
            this.btnJoin.UseVisualStyleBackColor = false;
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(168, 82);
            this.txtUserID.Multiline = true;
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(100, 26);
            this.txtUserID.TabIndex = 3;
            // 
            // txtRoomID
            // 
            this.txtRoomID.Location = new System.Drawing.Point(168, 34);
            this.txtRoomID.Multiline = true;
            this.txtRoomID.Name = "txtRoomID";
            this.txtRoomID.Size = new System.Drawing.Size(100, 26);
            this.txtRoomID.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Nhập ID người chơi:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nhập ID phòng:";
            // 
            // HomeClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1337, 845);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Name = "HomeClient";
            this.Text = "HomeClient";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRevision;
        private System.Windows.Forms.Button btnCreateRoom;
        private System.Windows.Forms.Button btnEnterRoom;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtRoomID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}
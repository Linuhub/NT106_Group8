namespace projectNT106
{
    partial class Room
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Room));
            this.labelIP = new System.Windows.Forms.Label();
            this.labelIDRoom = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtNumMember = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnLock = new projectNT106.Graph.CircularButton();
            this.SuspendLayout();
            // 
            // labelIP
            // 
            this.labelIP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelIP.AutoSize = true;
            this.labelIP.BackColor = System.Drawing.Color.SlateGray;
            this.labelIP.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelIP.Location = new System.Drawing.Point(948, 44);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(75, 20);
            this.labelIP.TabIndex = 12;
            this.labelIP.Text = "IP server:";
            // 
            // labelIDRoom
            // 
            this.labelIDRoom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelIDRoom.AutoSize = true;
            this.labelIDRoom.BackColor = System.Drawing.Color.SlateGray;
            this.labelIDRoom.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelIDRoom.Location = new System.Drawing.Point(948, 14);
            this.labelIDRoom.Name = "labelIDRoom";
            this.labelIDRoom.Size = new System.Drawing.Size(79, 20);
            this.labelIDRoom.TabIndex = 11;
            this.labelIDRoom.Text = "ID phòng:";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox2.Location = new System.Drawing.Point(623, 40);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 26);
            this.textBox2.TabIndex = 18;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStart.BackColor = System.Drawing.Color.SeaGreen;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(623, 418);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(184, 86);
            this.btnStart.TabIndex = 17;
            this.btnStart.Text = "Bắt đầu";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExit.BackColor = System.Drawing.Color.Firebrick;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnExit.Location = new System.Drawing.Point(985, 418);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(178, 86);
            this.btnExit.TabIndex = 16;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.buttonX_Click);
            // 
            // txtNumMember
            // 
            this.txtNumMember.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNumMember.Enabled = false;
            this.txtNumMember.Location = new System.Drawing.Point(1024, 286);
            this.txtNumMember.Multiline = true;
            this.txtNumMember.Name = "txtNumMember";
            this.txtNumMember.Size = new System.Drawing.Size(126, 38);
            this.txtNumMember.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label2.Location = new System.Drawing.Point(997, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 46);
            this.label2.TabIndex = 13;
            this.label2.Text = "Số người tham gia: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Silver;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(623, 105);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(540, 116);
            this.flowLayoutPanel1.TabIndex = 12;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // listView1
            // 
            this.listView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listView1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.listView1.ForeColor = System.Drawing.Color.Gray;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(22, 40);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(563, 464);
            this.listView1.TabIndex = 11;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.SmallIcon;
            // 
            // btnLock
            // 
            this.btnLock.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLock.BackColor = System.Drawing.Color.DarkOrange;
            this.btnLock.FlatAppearance.BorderSize = 0;
            this.btnLock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLock.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLock.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLock.Location = new System.Drawing.Point(929, 268);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(62, 63);
            this.btnLock.TabIndex = 15;
            this.btnLock.Text = "Lock";
            this.btnLock.UseVisualStyleBackColor = false;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // Room
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1184, 528);
            this.Controls.Add(this.labelIP);
            this.Controls.Add(this.labelIDRoom);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLock);
            this.Controls.Add(this.txtNumMember);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.listView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Room";
            this.Text = "Room";
            this.Load += new System.EventHandler(this.Room_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.Label labelIDRoom;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnExit;
        private Graph.CircularButton btnLock;
        private System.Windows.Forms.TextBox txtNumMember;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ListView listView1;
    }
}
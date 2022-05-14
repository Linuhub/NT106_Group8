namespace ProjectClient
{
    partial class CreateRoom
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Gói câu hỏi hình ảnh");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Gói câu hỏi chữ");
            this.label4 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtRoomID = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.lvQuestionList = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNumOfParticipant = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.gradientPanel1 = new ProjectClient.Graph.GradientPanel();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(395, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "ID người chơi";
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.Gold;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Location = new System.Drawing.Point(557, 503);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(121, 51);
            this.btnCreate.TabIndex = 20;
            this.btnCreate.Text = "Tạo";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtRoomID
            // 
            this.txtRoomID.BackColor = System.Drawing.SystemColors.Window;
            this.txtRoomID.Enabled = false;
            this.txtRoomID.Location = new System.Drawing.Point(558, 170);
            this.txtRoomID.Multiline = true;
            this.txtRoomID.Name = "txtRoomID";
            this.txtRoomID.Size = new System.Drawing.Size(230, 26);
            this.txtRoomID.TabIndex = 15;
            // 
            // txtUserID
            // 
            this.txtUserID.Enabled = false;
            this.txtUserID.Location = new System.Drawing.Point(557, 224);
            this.txtUserID.Multiline = true;
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(230, 26);
            this.txtUserID.TabIndex = 22;
            this.txtUserID.Text = " ";
            // 
            // lvQuestionList
            // 
            this.lvQuestionList.HideSelection = false;
            this.lvQuestionList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.lvQuestionList.Location = new System.Drawing.Point(558, 332);
            this.lvQuestionList.Name = "lvQuestionList";
            this.lvQuestionList.Size = new System.Drawing.Size(230, 29);
            this.lvQuestionList.TabIndex = 17;
            this.lvQuestionList.UseCompatibleStateImageBehavior = false;
            this.lvQuestionList.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(396, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "ID phòng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(610, 398);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 20);
            this.label6.TabIndex = 19;
            this.label6.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(395, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Số người tối đa";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(631, 395);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(47, 26);
            this.textBox1.TabIndex = 14;
            this.textBox1.Text = "00";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(396, 341);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Chọn gói câu hỏi";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(402, 381);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 40);
            this.label7.TabIndex = 18;
            this.label7.Text = "Thời gian tối đa \r\nmột câu";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNumOfParticipant
            // 
            this.txtNumOfParticipant.Location = new System.Drawing.Point(557, 274);
            this.txtNumOfParticipant.Multiline = true;
            this.txtNumOfParticipant.Name = "txtNumOfParticipant";
            this.txtNumOfParticipant.Size = new System.Drawing.Size(230, 26);
            this.txtNumOfParticipant.TabIndex = 16;
            this.txtNumOfParticipant.Text = "16";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(557, 395);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(47, 26);
            this.textBox2.TabIndex = 12;
            this.textBox2.Text = "01";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Angle = 0F;
            this.gradientPanel1.BottomColor = System.Drawing.Color.Empty;
            this.gradientPanel1.Location = new System.Drawing.Point(187, 63);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(792, 525);
            this.gradientPanel1.TabIndex = 23;
            this.gradientPanel1.TopColor = System.Drawing.Color.Empty;
            this.gradientPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.gradientPanel1_Paint);
            // 
            // CreateRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1183, 725);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txtRoomID);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.lvQuestionList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNumOfParticipant);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.gradientPanel1);
            this.Name = "CreateRoom";
            this.Text = "CreateRoom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtRoomID;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.ListView lvQuestionList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNumOfParticipant;
        private System.Windows.Forms.TextBox textBox2;
        private Graph.GradientPanel gradientPanel1;
    }
}
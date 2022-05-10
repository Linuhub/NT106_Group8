namespace projectNT106
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
            this.gradientPanel1 = new projectNT106.GradientPanel();
            this.roundedPanel1 = new projectNT106.Graph.RoundedPanel();
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtRoomID = new System.Windows.Forms.TextBox();
            this.lvQuestionList = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNumOfParticipant = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.gradientPanel1.SuspendLayout();
            this.roundedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Angle = 90F;
            this.gradientPanel1.BottomColor = System.Drawing.Color.AliceBlue;
            this.gradientPanel1.Controls.Add(this.roundedPanel1);
            this.gradientPanel1.Location = new System.Drawing.Point(-1, 0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(1376, 872);
            this.gradientPanel1.TabIndex = 0;
            this.gradientPanel1.TopColor = System.Drawing.Color.LightSkyBlue;
            this.gradientPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.gradientPanel1_Paint);
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.Angle = 0F;
            this.roundedPanel1.BackColor = System.Drawing.Color.Transparent;
            this.roundedPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.roundedPanel1.BottomColor = System.Drawing.Color.Empty;
            this.roundedPanel1.Controls.Add(this.btnCreate);
            this.roundedPanel1.Controls.Add(this.txtRoomID);
            this.roundedPanel1.Controls.Add(this.lvQuestionList);
            this.roundedPanel1.Controls.Add(this.label1);
            this.roundedPanel1.Controls.Add(this.label6);
            this.roundedPanel1.Controls.Add(this.label2);
            this.roundedPanel1.Controls.Add(this.textBox1);
            this.roundedPanel1.Controls.Add(this.label3);
            this.roundedPanel1.Controls.Add(this.label7);
            this.roundedPanel1.Controls.Add(this.txtNumOfParticipant);
            this.roundedPanel1.Controls.Add(this.textBox2);
            this.roundedPanel1.ForeColor = System.Drawing.Color.Black;
            this.roundedPanel1.Location = new System.Drawing.Point(448, 197);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Size = new System.Drawing.Size(524, 362);
            this.roundedPanel1.TabIndex = 1;
            this.roundedPanel1.TopColor = System.Drawing.Color.Empty;
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.Gold;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Location = new System.Drawing.Point(209, 281);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(121, 51);
            this.btnCreate.TabIndex = 7;
            this.btnCreate.Text = "Tạo";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtRoomID
            // 
            this.txtRoomID.BackColor = System.Drawing.SystemColors.Window;
            this.txtRoomID.Enabled = false;
            this.txtRoomID.Location = new System.Drawing.Point(210, 37);
            this.txtRoomID.Multiline = true;
            this.txtRoomID.Name = "txtRoomID";
            this.txtRoomID.Size = new System.Drawing.Size(230, 26);
            this.txtRoomID.TabIndex = 2;
            // 
            // lvQuestionList
            // 
            this.lvQuestionList.HideSelection = false;
            this.lvQuestionList.Location = new System.Drawing.Point(210, 152);
            this.lvQuestionList.Name = "lvQuestionList";
            this.lvQuestionList.Size = new System.Drawing.Size(230, 29);
            this.lvQuestionList.TabIndex = 4;
            this.lvQuestionList.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(48, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID phòng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(262, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(48, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số người tối đa";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(283, 215);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(47, 26);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "00";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(48, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Chọn gói câu hỏi";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(54, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 40);
            this.label7.TabIndex = 5;
            this.label7.Text = "Thời gian tối đa \r\nmột câu";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNumOfParticipant
            // 
            this.txtNumOfParticipant.Location = new System.Drawing.Point(210, 94);
            this.txtNumOfParticipant.Multiline = true;
            this.txtNumOfParticipant.Name = "txtNumOfParticipant";
            this.txtNumOfParticipant.Size = new System.Drawing.Size(230, 26);
            this.txtNumOfParticipant.TabIndex = 3;
            this.txtNumOfParticipant.Text = "16";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(209, 215);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(47, 26);
            this.textBox2.TabIndex = 0;
            this.textBox2.Text = "01";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CreateRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 852);
            this.Controls.Add(this.gradientPanel1);
            this.Name = "CreateRoom";
            this.Text = "CreateRoom";
            this.gradientPanel1.ResumeLayout(false);
            this.roundedPanel1.ResumeLayout(false);
            this.roundedPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GradientPanel gradientPanel1;
        private Graph.RoundedPanel roundedPanel1;
        private System.Windows.Forms.TextBox txtRoomID;
        private System.Windows.Forms.ListView lvQuestionList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNumOfParticipant;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnCreate;
    }
}
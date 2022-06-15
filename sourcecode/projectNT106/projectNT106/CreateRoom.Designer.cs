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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateRoom));
            this.gradientPanel1 = new projectNT106.GradientPanel();
            this.roundedPanel1 = new projectNT106.Graph.RoundedPanel();
            this.cbQuestionPackage = new System.Windows.Forms.ComboBox();
            this.txtIPLocal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtRoomID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumOfParticipant = new System.Windows.Forms.TextBox();
            this.gradientPanel1.SuspendLayout();
            this.roundedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gradientPanel1.Angle = 90F;
            this.gradientPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gradientPanel1.BottomColor = System.Drawing.Color.AliceBlue;
            this.gradientPanel1.Controls.Add(this.roundedPanel1);
            this.gradientPanel1.Location = new System.Drawing.Point(-1, 0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(683, 539);
            this.gradientPanel1.TabIndex = 0;
            this.gradientPanel1.TopColor = System.Drawing.Color.LightSkyBlue;
            this.gradientPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.gradientPanel1_Paint);
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedPanel1.Angle = 0F;
            this.roundedPanel1.BackColor = System.Drawing.Color.Transparent;
            this.roundedPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.roundedPanel1.BottomColor = System.Drawing.Color.Empty;
            this.roundedPanel1.Controls.Add(this.cbQuestionPackage);
            this.roundedPanel1.Controls.Add(this.txtIPLocal);
            this.roundedPanel1.Controls.Add(this.label4);
            this.roundedPanel1.Controls.Add(this.btnCreate);
            this.roundedPanel1.Controls.Add(this.txtRoomID);
            this.roundedPanel1.Controls.Add(this.label1);
            this.roundedPanel1.Controls.Add(this.label2);
            this.roundedPanel1.Controls.Add(this.label3);
            this.roundedPanel1.Controls.Add(this.txtNumOfParticipant);
            this.roundedPanel1.ForeColor = System.Drawing.Color.Black;
            this.roundedPanel1.Location = new System.Drawing.Point(109, 50);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Size = new System.Drawing.Size(472, 386);
            this.roundedPanel1.TabIndex = 1;
            this.roundedPanel1.TopColor = System.Drawing.Color.Empty;
            // 
            // cbQuestionPackage
            // 
            this.cbQuestionPackage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbQuestionPackage.FormattingEnabled = true;
            this.cbQuestionPackage.Location = new System.Drawing.Point(183, 200);
            this.cbQuestionPackage.Name = "cbQuestionPackage";
            this.cbQuestionPackage.Size = new System.Drawing.Size(230, 28);
            this.cbQuestionPackage.TabIndex = 10;
            // 
            // txtIPLocal
            // 
            this.txtIPLocal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIPLocal.BackColor = System.Drawing.SystemColors.Window;
            this.txtIPLocal.Enabled = false;
            this.txtIPLocal.Location = new System.Drawing.Point(183, 40);
            this.txtIPLocal.Multiline = true;
            this.txtIPLocal.Name = "txtIPLocal";
            this.txtIPLocal.ReadOnly = true;
            this.txtIPLocal.Size = new System.Drawing.Size(230, 26);
            this.txtIPLocal.TabIndex = 9;
            this.txtIPLocal.Text = " ";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(20, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Địa chỉ IP của server:";
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCreate.BackColor = System.Drawing.Color.Gold;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Location = new System.Drawing.Point(184, 280);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(121, 51);
            this.btnCreate.TabIndex = 7;
            this.btnCreate.Text = "Tạo";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtRoomID
            // 
            this.txtRoomID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtRoomID.BackColor = System.Drawing.SystemColors.Window;
            this.txtRoomID.Enabled = false;
            this.txtRoomID.Location = new System.Drawing.Point(184, 91);
            this.txtRoomID.Multiline = true;
            this.txtRoomID.Name = "txtRoomID";
            this.txtRoomID.Size = new System.Drawing.Size(230, 26);
            this.txtRoomID.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(21, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID phòng";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(21, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số người tối đa";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(22, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Chọn gói câu hỏi";
            // 
            // txtNumOfParticipant
            // 
            this.txtNumOfParticipant.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNumOfParticipant.Location = new System.Drawing.Point(183, 141);
            this.txtNumOfParticipant.Multiline = true;
            this.txtNumOfParticipant.Name = "txtNumOfParticipant";
            this.txtNumOfParticipant.Size = new System.Drawing.Size(230, 26);
            this.txtNumOfParticipant.TabIndex = 3;
            this.txtNumOfParticipant.Text = "10";
            // 
            // CreateRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(681, 520);
            this.Controls.Add(this.gradientPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateRoom";
            this.Text = "CreateRoom";
            this.Load += new System.EventHandler(this.CreateRoom_Load);
            this.gradientPanel1.ResumeLayout(false);
            this.roundedPanel1.ResumeLayout(false);
            this.roundedPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GradientPanel gradientPanel1;
        private Graph.RoundedPanel roundedPanel1;
        private System.Windows.Forms.TextBox txtRoomID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumOfParticipant;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIPLocal;
        private System.Windows.Forms.ComboBox cbQuestionPackage;
    }
}
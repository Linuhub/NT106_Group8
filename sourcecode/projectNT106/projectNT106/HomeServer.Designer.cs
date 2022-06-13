namespace projectNT106
{
    partial class HomeServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeServer));
            this.gradientPanel1 = new projectNT106.GradientPanel();
            this.btnManageQuestionList = new projectNT106.Graph.RoundedButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCreateRoom = new projectNT106.Graph.RoundedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.gradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gradientPanel1.Angle = 90F;
            this.gradientPanel1.BottomColor = System.Drawing.Color.Transparent;
            this.gradientPanel1.Controls.Add(this.btnManageQuestionList);
            this.gradientPanel1.Controls.Add(this.label2);
            this.gradientPanel1.Controls.Add(this.btnCreateRoom);
            this.gradientPanel1.Controls.Add(this.label1);
            this.gradientPanel1.Location = new System.Drawing.Point(152, 46);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(1099, 590);
            this.gradientPanel1.TabIndex = 0;
            this.gradientPanel1.TopColor = System.Drawing.Color.DimGray;
            this.gradientPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.gradientPanel1_Paint);
            // 
            // btnManageQuestionList
            // 
            this.btnManageQuestionList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnManageQuestionList.BackColor = System.Drawing.Color.SteelBlue;
            this.btnManageQuestionList.FlatAppearance.BorderSize = 0;
            this.btnManageQuestionList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageQuestionList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageQuestionList.Location = new System.Drawing.Point(620, 406);
            this.btnManageQuestionList.Name = "btnManageQuestionList";
            this.btnManageQuestionList.Size = new System.Drawing.Size(266, 116);
            this.btnManageQuestionList.TabIndex = 3;
            this.btnManageQuestionList.Text = "Quản lý bộ câu hỏi";
            this.btnManageQuestionList.UseVisualStyleBackColor = false;
            this.btnManageQuestionList.Click += new System.EventHandler(this.btnManageQuestionList_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightBlue;
            this.label2.Location = new System.Drawing.Point(462, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 67);
            this.label2.TabIndex = 1;
            this.label2.Text = "Server";
            // 
            // btnCreateRoom
            // 
            this.btnCreateRoom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCreateRoom.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCreateRoom.FlatAppearance.BorderSize = 0;
            this.btnCreateRoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateRoom.Location = new System.Drawing.Point(243, 406);
            this.btnCreateRoom.Name = "btnCreateRoom";
            this.btnCreateRoom.Size = new System.Drawing.Size(266, 116);
            this.btnCreateRoom.TabIndex = 2;
            this.btnCreateRoom.Text = "Tạo phòng";
            this.btnCreateRoom.UseVisualStyleBackColor = false;
            this.btnCreateRoom.Click += new System.EventHandler(this.btnCreateRoom_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 48F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightBlue;
            this.label1.Location = new System.Drawing.Point(243, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(660, 119);
            this.label1.TabIndex = 0;
            this.label1.Text = "Application";
            // 
            // HomeServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1368, 687);
            this.Controls.Add(this.gradientPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HomeServer";
            this.Text = "HomeServer";
            this.Load += new System.EventHandler(this.HomeServer_Load);
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private GradientPanel gradientPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Graph.RoundedButton btnCreateRoom;
        private Graph.RoundedButton btnManageQuestionList;
    }
}
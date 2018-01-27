namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxGrade = new System.Windows.Forms.ComboBox();
            this.labelGrade = new System.Windows.Forms.Label();
            this.labelNum = new System.Windows.Forms.Label();
            this.comboBoxNum = new System.Windows.Forms.ComboBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelRun = new System.Windows.Forms.Label();
            this.textBoxNameList = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBoxGrade
            // 
            this.comboBoxGrade.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxGrade.FormattingEnabled = true;
            this.comboBoxGrade.Items.AddRange(new object[] {
            "特等奖",
            "一等奖",
            "二等奖",
            "三等奖",
            "阳光普照",
            "特别奖"});
            this.comboBoxGrade.Location = new System.Drawing.Point(169, 59);
            this.comboBoxGrade.Name = "comboBoxGrade";
            this.comboBoxGrade.Size = new System.Drawing.Size(121, 28);
            this.comboBoxGrade.TabIndex = 0;
            // 
            // labelGrade
            // 
            this.labelGrade.AutoSize = true;
            this.labelGrade.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelGrade.Location = new System.Drawing.Point(62, 62);
            this.labelGrade.Name = "labelGrade";
            this.labelGrade.Size = new System.Drawing.Size(89, 20);
            this.labelGrade.TabIndex = 1;
            this.labelGrade.Text = "选择奖项";
            // 
            // labelNum
            // 
            this.labelNum.AutoSize = true;
            this.labelNum.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelNum.Location = new System.Drawing.Point(62, 126);
            this.labelNum.Name = "labelNum";
            this.labelNum.Size = new System.Drawing.Size(89, 20);
            this.labelNum.TabIndex = 2;
            this.labelNum.Text = "选择数量";
            // 
            // comboBoxNum
            // 
            this.comboBoxNum.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxNum.FormattingEnabled = true;
            this.comboBoxNum.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboBoxNum.Location = new System.Drawing.Point(169, 123);
            this.comboBoxNum.Name = "comboBoxNum";
            this.comboBoxNum.Size = new System.Drawing.Size(121, 28);
            this.comboBoxNum.TabIndex = 3;
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonStart.Location = new System.Drawing.Point(476, 59);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(182, 92);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "开始";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelRun
            // 
            this.labelRun.AutoSize = true;
            this.labelRun.Font = new System.Drawing.Font("宋体", 30F);
            this.labelRun.Location = new System.Drawing.Point(87, 224);
            this.labelRun.Name = "labelRun";
            this.labelRun.Size = new System.Drawing.Size(137, 40);
            this.labelRun.TabIndex = 6;
            this.labelRun.Text = "中奖人";
            // 
            // textBoxNameList
            // 
            this.textBoxNameList.Font = new System.Drawing.Font("宋体", 15F);
            this.textBoxNameList.Location = new System.Drawing.Point(144, 331);
            this.textBoxNameList.Multiline = true;
            this.textBoxNameList.Name = "textBoxNameList";
            this.textBoxNameList.ReadOnly = true;
            this.textBoxNameList.Size = new System.Drawing.Size(457, 198);
            this.textBoxNameList.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.textBoxNameList);
            this.Controls.Add(this.labelRun);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.comboBoxNum);
            this.Controls.Add(this.labelNum);
            this.Controls.Add(this.labelGrade);
            this.Controls.Add(this.comboBoxGrade);
            this.Name = "Form1";
            this.Text = "抽奖";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxGrade;
        private System.Windows.Forms.Label labelGrade;
        private System.Windows.Forms.Label labelNum;
        private System.Windows.Forms.ComboBox comboBoxNum;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelRun;
        private System.Windows.Forms.TextBox textBoxNameList;
    }
}


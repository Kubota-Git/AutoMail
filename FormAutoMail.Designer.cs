
namespace AutoMail
{
    partial class FormAutoMail
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonMailCreate = new System.Windows.Forms.Button();
            this.labelTotay = new System.Windows.Forms.Label();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonToday = new System.Windows.Forms.RadioButton();
            this.radioButtonOtherDay = new System.Windows.Forms.RadioButton();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.labelSendTo = new System.Windows.Forms.Label();
            this.labelSendCC1 = new System.Windows.Forms.Label();
            this.labelSendCC2 = new System.Windows.Forms.Label();
            this.comboBoxSendTo = new System.Windows.Forms.ComboBox();
            this.comboBoxSendCC1 = new System.Windows.Forms.ComboBox();
            this.comboBoxSendCC2 = new System.Windows.Forms.ComboBox();
            this.buttonSendUserAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.buttonFromUserAdd = new System.Windows.Forms.Button();
            this.buttonExcel = new System.Windows.Forms.Button();
            this.labelSelectDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxSendTimer = new System.Windows.Forms.CheckBox();
            this.numericUpDownSendTimerH = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownSendTimerM = new System.Windows.Forms.NumericUpDown();
            this.panelTimer = new System.Windows.Forms.Panel();
            this.timerSendTiming = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSendTimerH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSendTimerM)).BeginInit();
            this.panelTimer.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonMailCreate
            // 
            this.buttonMailCreate.Location = new System.Drawing.Point(244, 437);
            this.buttonMailCreate.Name = "buttonMailCreate";
            this.buttonMailCreate.Size = new System.Drawing.Size(233, 23);
            this.buttonMailCreate.TabIndex = 11;
            this.buttonMailCreate.Text = "メール配信";
            this.buttonMailCreate.UseVisualStyleBackColor = true;
            this.buttonMailCreate.Click += new System.EventHandler(this.ButtonCreate_Click);
            // 
            // labelTotay
            // 
            this.labelTotay.AutoSize = true;
            this.labelTotay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelTotay.Location = new System.Drawing.Point(83, 13);
            this.labelTotay.Name = "labelTotay";
            this.labelTotay.Size = new System.Drawing.Size(41, 12);
            this.labelTotay.TabIndex = 1;
            this.labelTotay.Text = "年月日";
            // 
            // textBoxMail
            // 
            this.textBoxMail.Location = new System.Drawing.Point(16, 258);
            this.textBoxMail.Multiline = true;
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(460, 170);
            this.textBoxMail.TabIndex = 10;
            this.textBoxMail.TextChanged += new System.EventHandler(this.TextBoxMail_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "定型文";
            // 
            // radioButtonToday
            // 
            this.radioButtonToday.AutoSize = true;
            this.radioButtonToday.Location = new System.Drawing.Point(16, 11);
            this.radioButtonToday.Name = "radioButtonToday";
            this.radioButtonToday.Size = new System.Drawing.Size(47, 16);
            this.radioButtonToday.TabIndex = 0;
            this.radioButtonToday.TabStop = true;
            this.radioButtonToday.Text = "今日";
            this.radioButtonToday.UseVisualStyleBackColor = true;
            this.radioButtonToday.CheckedChanged += new System.EventHandler(this.RadioButtonToday_CheckedChanged);
            // 
            // radioButtonOtherDay
            // 
            this.radioButtonOtherDay.AutoSize = true;
            this.radioButtonOtherDay.Location = new System.Drawing.Point(16, 30);
            this.radioButtonOtherDay.Name = "radioButtonOtherDay";
            this.radioButtonOtherDay.Size = new System.Drawing.Size(59, 16);
            this.radioButtonOtherDay.TabIndex = 1;
            this.radioButtonOtherDay.TabStop = true;
            this.radioButtonOtherDay.Text = "指定日";
            this.radioButtonOtherDay.UseVisualStyleBackColor = true;
            this.radioButtonOtherDay.CheckedChanged += new System.EventHandler(this.RadioButtonOtherDay_CheckedChanged);
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(257, 13);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 2;
            this.monthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.MonthCalendar_DateChanged);
            // 
            // labelSendTo
            // 
            this.labelSendTo.AutoSize = true;
            this.labelSendTo.Location = new System.Drawing.Point(14, 61);
            this.labelSendTo.Name = "labelSendTo";
            this.labelSendTo.Size = new System.Drawing.Size(24, 12);
            this.labelSendTo.TabIndex = 7;
            this.labelSendTo.Text = "To：";
            // 
            // labelSendCC1
            // 
            this.labelSendCC1.AutoSize = true;
            this.labelSendCC1.Location = new System.Drawing.Point(16, 99);
            this.labelSendCC1.Name = "labelSendCC1";
            this.labelSendCC1.Size = new System.Drawing.Size(33, 12);
            this.labelSendCC1.TabIndex = 7;
            this.labelSendCC1.Text = "CC1：";
            // 
            // labelSendCC2
            // 
            this.labelSendCC2.AutoSize = true;
            this.labelSendCC2.Location = new System.Drawing.Point(14, 140);
            this.labelSendCC2.Name = "labelSendCC2";
            this.labelSendCC2.Size = new System.Drawing.Size(33, 12);
            this.labelSendCC2.TabIndex = 7;
            this.labelSendCC2.Text = "CC2：";
            // 
            // comboBoxSendTo
            // 
            this.comboBoxSendTo.FormattingEnabled = true;
            this.comboBoxSendTo.Location = new System.Drawing.Point(16, 76);
            this.comboBoxSendTo.Name = "comboBoxSendTo";
            this.comboBoxSendTo.Size = new System.Drawing.Size(215, 20);
            this.comboBoxSendTo.TabIndex = 3;
            this.comboBoxSendTo.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSendTo_SelectedIndexChanged);
            // 
            // comboBoxSendCC1
            // 
            this.comboBoxSendCC1.FormattingEnabled = true;
            this.comboBoxSendCC1.Location = new System.Drawing.Point(16, 117);
            this.comboBoxSendCC1.Name = "comboBoxSendCC1";
            this.comboBoxSendCC1.Size = new System.Drawing.Size(215, 20);
            this.comboBoxSendCC1.TabIndex = 4;
            // 
            // comboBoxSendCC2
            // 
            this.comboBoxSendCC2.FormattingEnabled = true;
            this.comboBoxSendCC2.Location = new System.Drawing.Point(16, 155);
            this.comboBoxSendCC2.Name = "comboBoxSendCC2";
            this.comboBoxSendCC2.Size = new System.Drawing.Size(215, 20);
            this.comboBoxSendCC2.TabIndex = 5;
            // 
            // buttonSendUserAdd
            // 
            this.buttonSendUserAdd.Location = new System.Drawing.Point(120, 179);
            this.buttonSendUserAdd.Name = "buttonSendUserAdd";
            this.buttonSendUserAdd.Size = new System.Drawing.Size(111, 23);
            this.buttonSendUserAdd.TabIndex = 6;
            this.buttonSendUserAdd.Text = "送り先情報の追加";
            this.buttonSendUserAdd.UseVisualStyleBackColor = true;
            this.buttonSendUserAdd.Click += new System.EventHandler(this.ButtonSendUserAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "From：";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(16, 214);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(98, 19);
            this.textBoxUserName.TabIndex = 7;
            this.textBoxUserName.TextChanged += new System.EventHandler(this.TextBoxFromName_TextChanged);
            // 
            // buttonFromUserAdd
            // 
            this.buttonFromUserAdd.Location = new System.Drawing.Point(120, 212);
            this.buttonFromUserAdd.Name = "buttonFromUserAdd";
            this.buttonFromUserAdd.Size = new System.Drawing.Size(111, 23);
            this.buttonFromUserAdd.TabIndex = 8;
            this.buttonFromUserAdd.Text = "送信者の変更";
            this.buttonFromUserAdd.UseVisualStyleBackColor = true;
            this.buttonFromUserAdd.Click += new System.EventHandler(this.ButtonFromUserAdd_Click);
            // 
            // buttonExcel
            // 
            this.buttonExcel.Location = new System.Drawing.Point(256, 212);
            this.buttonExcel.Name = "buttonExcel";
            this.buttonExcel.Size = new System.Drawing.Size(220, 23);
            this.buttonExcel.TabIndex = 9;
            this.buttonExcel.Text = "日報編集(Excel)";
            this.buttonExcel.UseVisualStyleBackColor = true;
            this.buttonExcel.Click += new System.EventHandler(this.ButtonExcel_Click);
            // 
            // labelSelectDate
            // 
            this.labelSelectDate.AutoSize = true;
            this.labelSelectDate.Location = new System.Drawing.Point(83, 32);
            this.labelSelectDate.Name = "labelSelectDate";
            this.labelSelectDate.Size = new System.Drawing.Size(41, 12);
            this.labelSelectDate.TabIndex = 1;
            this.labelSelectDate.Text = "年月日";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(237, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "様";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(237, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "様";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(237, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "様";
            // 
            // checkBoxSendTimer
            // 
            this.checkBoxSendTimer.AutoSize = true;
            this.checkBoxSendTimer.Location = new System.Drawing.Point(10, 6);
            this.checkBoxSendTimer.Name = "checkBoxSendTimer";
            this.checkBoxSendTimer.Size = new System.Drawing.Size(90, 16);
            this.checkBoxSendTimer.TabIndex = 12;
            this.checkBoxSendTimer.Text = "送信タイマー：";
            this.checkBoxSendTimer.UseVisualStyleBackColor = true;
            this.checkBoxSendTimer.CheckedChanged += new System.EventHandler(this.CheckBoxSendTimer_CheckedChanged_1);
            // 
            // numericUpDownSendTimerH
            // 
            this.numericUpDownSendTimerH.Location = new System.Drawing.Point(102, 5);
            this.numericUpDownSendTimerH.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDownSendTimerH.Name = "numericUpDownSendTimerH";
            this.numericUpDownSendTimerH.Size = new System.Drawing.Size(39, 19);
            this.numericUpDownSendTimerH.TabIndex = 13;
            this.numericUpDownSendTimerH.Value = new decimal(new int[] {
            17,
            0,
            0,
            0});
            this.numericUpDownSendTimerH.ValueChanged += new System.EventHandler(this.NumericUpDownSendTimerH_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(146, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "：";
            // 
            // numericUpDownSendTimerM
            // 
            this.numericUpDownSendTimerM.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownSendTimerM.Location = new System.Drawing.Point(161, 5);
            this.numericUpDownSendTimerM.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownSendTimerM.Name = "numericUpDownSendTimerM";
            this.numericUpDownSendTimerM.Size = new System.Drawing.Size(50, 19);
            this.numericUpDownSendTimerM.TabIndex = 14;
            this.numericUpDownSendTimerM.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownSendTimerM.ValueChanged += new System.EventHandler(this.NumericUpDownSendTimerM_ValueChanged);
            // 
            // panelTimer
            // 
            this.panelTimer.Controls.Add(this.checkBoxSendTimer);
            this.panelTimer.Controls.Add(this.numericUpDownSendTimerM);
            this.panelTimer.Controls.Add(this.label6);
            this.panelTimer.Controls.Add(this.numericUpDownSendTimerH);
            this.panelTimer.Location = new System.Drawing.Point(16, 434);
            this.panelTimer.Name = "panelTimer";
            this.panelTimer.Size = new System.Drawing.Size(222, 27);
            this.panelTimer.TabIndex = 15;
            // 
            // timerSendTiming
            // 
            this.timerSendTiming.Interval = 30000;
            this.timerSendTiming.Tick += new System.EventHandler(this.TimerSendTiming_Tick);
            // 
            // FormAutoMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 469);
            this.Controls.Add(this.panelTimer);
            this.Controls.Add(this.buttonExcel);
            this.Controls.Add(this.buttonFromUserAdd);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonSendUserAdd);
            this.Controls.Add(this.comboBoxSendCC2);
            this.Controls.Add(this.comboBoxSendCC1);
            this.Controls.Add(this.comboBoxSendTo);
            this.Controls.Add(this.labelSendCC2);
            this.Controls.Add(this.labelSendCC1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelSendTo);
            this.Controls.Add(this.monthCalendar);
            this.Controls.Add(this.radioButtonOtherDay);
            this.Controls.Add(this.radioButtonToday);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxMail);
            this.Controls.Add(this.labelSelectDate);
            this.Controls.Add(this.labelTotay);
            this.Controls.Add(this.buttonMailCreate);
            this.Name = "FormAutoMail";
            this.Text = "メール自動作成ツール";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSendTimerH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSendTimerM)).EndInit();
            this.panelTimer.ResumeLayout(false);
            this.panelTimer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonMailCreate;
        private System.Windows.Forms.Label labelTotay;
        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonToday;
        private System.Windows.Forms.RadioButton radioButtonOtherDay;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.Label labelSendTo;
        private System.Windows.Forms.Label labelSendCC1;
        private System.Windows.Forms.Label labelSendCC2;
        private System.Windows.Forms.ComboBox comboBoxSendTo;
        private System.Windows.Forms.ComboBox comboBoxSendCC1;
        private System.Windows.Forms.ComboBox comboBoxSendCC2;
        private System.Windows.Forms.Button buttonSendUserAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Button buttonFromUserAdd;
        private System.Windows.Forms.Button buttonExcel;
        private System.Windows.Forms.Label labelSelectDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxSendTimer;
        private System.Windows.Forms.NumericUpDown numericUpDownSendTimerH;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownSendTimerM;
        private System.Windows.Forms.Panel panelTimer;
        private System.Windows.Forms.Timer timerSendTiming;
    }
}


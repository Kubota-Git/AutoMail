
namespace AutoMail
{
    partial class FormSendTimer
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
            this.components = new System.ComponentModel.Container();
            this.labelTimeLimits = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.timerSendTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTimeLimits
            // 
            this.labelTimeLimits.AutoSize = true;
            this.labelTimeLimits.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelTimeLimits.Location = new System.Drawing.Point(12, 28);
            this.labelTimeLimits.Name = "labelTimeLimits";
            this.labelTimeLimits.Size = new System.Drawing.Size(75, 24);
            this.labelTimeLimits.TabIndex = 1;
            this.labelTimeLimits.Text = "00：00";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(102, 29);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "キャンセル";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // timerSendTimer
            // 
            this.timerSendTimer.Interval = 20000;
            this.timerSendTimer.Tick += new System.EventHandler(this.TimerSendTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "残り";
            // 
            // FormSendTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(189, 58);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelTimeLimits);
            this.Name = "FormSendTimer";
            this.Text = "送信待機中";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormSendTimer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTimeLimits;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Timer timerSendTimer;
        private System.Windows.Forms.Label label1;
    }
}
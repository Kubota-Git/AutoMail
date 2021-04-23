
namespace AutoMail
{
    partial class FormAddMember
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAddName = new System.Windows.Forms.TextBox();
            this.labelAddSama = new System.Windows.Forms.Label();
            this.textBoxAddAddress = new System.Windows.Forms.TextBox();
            this.buttonAddMember = new System.Windows.Forms.Button();
            this.buttonCansel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "氏名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "メールアドレス：";
            // 
            // textBoxAddName
            // 
            this.textBoxAddName.Location = new System.Drawing.Point(13, 29);
            this.textBoxAddName.Name = "textBoxAddName";
            this.textBoxAddName.Size = new System.Drawing.Size(149, 19);
            this.textBoxAddName.TabIndex = 0;
            // 
            // labelAddSama
            // 
            this.labelAddSama.AutoSize = true;
            this.labelAddSama.Location = new System.Drawing.Point(168, 32);
            this.labelAddSama.Name = "labelAddSama";
            this.labelAddSama.Size = new System.Drawing.Size(17, 12);
            this.labelAddSama.TabIndex = 3;
            this.labelAddSama.Text = "様";
            // 
            // textBoxAddAddress
            // 
            this.textBoxAddAddress.Location = new System.Drawing.Point(12, 77);
            this.textBoxAddAddress.Name = "textBoxAddAddress";
            this.textBoxAddAddress.Size = new System.Drawing.Size(319, 19);
            this.textBoxAddAddress.TabIndex = 1;
            // 
            // buttonAddMember
            // 
            this.buttonAddMember.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonAddMember.Location = new System.Drawing.Point(12, 118);
            this.buttonAddMember.Name = "buttonAddMember";
            this.buttonAddMember.Size = new System.Drawing.Size(222, 23);
            this.buttonAddMember.TabIndex = 2;
            this.buttonAddMember.Text = "追加";
            this.buttonAddMember.UseVisualStyleBackColor = true;
            this.buttonAddMember.Click += new System.EventHandler(this.ButtonAddMember_Click);
            // 
            // buttonCansel
            // 
            this.buttonCansel.Location = new System.Drawing.Point(256, 118);
            this.buttonCansel.Name = "buttonCansel";
            this.buttonCansel.Size = new System.Drawing.Size(75, 23);
            this.buttonCansel.TabIndex = 3;
            this.buttonCansel.Text = "キャンセル";
            this.buttonCansel.UseVisualStyleBackColor = true;
            this.buttonCansel.Click += new System.EventHandler(this.ButtonCansel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(246, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "※半角スペースを姓と名前の間に使用してください。";
            // 
            // FormAddMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 156);
            this.Controls.Add(this.buttonCansel);
            this.Controls.Add(this.buttonAddMember);
            this.Controls.Add(this.textBoxAddAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelAddSama);
            this.Controls.Add(this.textBoxAddName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormAddMember";
            this.Text = "アドレスの追加";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxAddName;
        private System.Windows.Forms.Label labelAddSama;
        private System.Windows.Forms.TextBox textBoxAddAddress;
        private System.Windows.Forms.Button buttonAddMember;
        private System.Windows.Forms.Button buttonCansel;
        private System.Windows.Forms.Label label3;
    }
}
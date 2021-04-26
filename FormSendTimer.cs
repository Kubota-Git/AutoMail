using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoMail
{
    public partial class FormSendTimer : Form
    {

        public FormSendTimer()
        {
            InitializeComponent();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FormSendTimer_Load(object sender, EventArgs e)
        {
            labelTimeLimits.Text = "待機中";
            timerSendTimer.Start();//表示用タイマー開始
        }

        private void TimerSendTimer_Tick(object sender, EventArgs e)
        {
            //ラベル表示の更新
            labelTimeLimits.Text = FormAutoMail.counterTimerH.ToString() + "時"
                                + FormAutoMail.counterTimerM.ToString() + "分";

            if (FormAutoMail.counterTimerH == 0 && FormAutoMail.counterTimerM ==0)
            {
                //カウンターが0になったらフォームを閉じる
                timerSendTimer.Stop();
                this.Close();
            }


        }
    }
}

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
    public partial class FormAddMember : Form
    {
        public static string nameKey; 

        public FormAddMember()
        {
            InitializeComponent();
        }

        private void ButtonAddMember_Click(object sender, EventArgs e)
        {
            //追加ボタンをクリック
            DialogResult result = MessageBox.Show("この内容で登録してもいいですか？", "追加登録", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (result == DialogResult.Yes)//OKよりメンバーの追加
            {
                FormAutoMail.AddressList.Add(textBoxAddName.Text, textBoxAddAddress.Text);//Dictionalyへ追加
            }
            this.Close();//フォームを閉じる
        }

        private void ButtonCansel_Click(object sender, EventArgs e)
        {
            this.Close();//フォームを閉じる
        }
    }
}

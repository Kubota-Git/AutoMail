using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.IO;




namespace AutoMail
{
    public partial class FormExcel : Form
    {
        Dictionary<string, string> weekName = new Dictionary<string, string>//曜日リスト
        {
            {"Sunday","日" },
            {"Monday","月" },
            {"Tuesday","火" },
            {"Wednesday","水" },
            {"Thursday","木" },
            {"Friday","金" },
            {"Saturday","土" },
        };

        //状態格納変数
        bool[] checkBoxContent = new bool[11];
        List<string> contents = new List<string>();

        public FormExcel()
        {
            InitializeComponent();
        }

        private void FormExcel_Load(object sender, EventArgs e)
        {
            //コンボボックスへ格納
            //使用者名情報
            foreach (string memerName in FormAutoMail.UserNameList)
            {
                this.comboBoxUserName.Items.Add(memerName);
            }

            //事業所情報          
            foreach (string data in FormAutoMail.departmentList)
            {
                this.comboBoxDepartment.Items.Add(data);
            }

            //教育訓練情報     
            foreach (string data in FormAutoMail.trainingList)
            {
                this.comboBoxTraining.Items.Add(data);
            }

            //就業場所情報      
            foreach (string data in FormAutoMail.placeList)
            {
                this.comboBoxPlace.Items.Add(data);
            }


            //初期表示(読込データの1行目を表示)                       
            labelDate.Text = "作成する日付：" + FormAutoMail.day.ToLongDateString();//日付
            comboBoxUserName.Text = comboBoxUserName.Items[0].ToString();//使用者
            comboBoxMenter.Text = comboBoxMenter.Items[0].ToString();//講習者
            comboBoxDepartment.Text = comboBoxDepartment.Items[0].ToString();//事業所
            comboBoxTraining.Text = comboBoxTraining.Items[0].ToString();//教習訓練
            comboBoxPlace.Text = comboBoxPlace.Items[0].ToString();//就業場所


            //就業時間の計算
            TimeMethod();


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //値の格納
            for (int i = 0; i < 11; i++) 
            {
                if (checkBoxContent[i] == true)//チェックボックスがONのみ有効
                {
                    //if(this.Controls["checkBoxContent" + i].)
                    //コントロールを変数にて扱う
                    contents.Add(this.Controls["comboBoxContent" + (i + 1)].Text 
                        + this.Controls["textBoxContent" + (i + 1)].Text);
                }                
              
            }
          


            //アプリケーションのオブジェクト
            Microsoft.Office.Interop.Excel.Application excel;
            //ブックのオブジェクト
            Workbook workbook;
            //シートのオブジェクト
            Worksheet Sheet;

            //アプリケーションのインスタンス作成
            excel = new Microsoft.Office.Interop.Excel.Application
            {
                //アプリケーションの表示設定 Visible=true:Excel表示　false:Excel非表示(バックグラウンド処理)
                Visible = false
            };

            try
            {
                //Excelファイルの場所
                string file_path = Path.GetFullPath(FormAutoMail.reportFile);
                

                //ファイルを開く
                workbook = excel.Workbooks.Open(file_path);

                ///*********///
                //Excelファイル操作処理～～
                ///*********///

                // シートを取得する
                //workbook = excel.Workbooks.Open();
                Sheet = workbook.Sheets[1];

                //range指定して書き込む
                Sheet.Range["E6"].Value = FormAutoMail.day.Year;//年の入力
                Sheet.Range["H6"].Value = FormAutoMail.day.Month;//月の入力
                Sheet.Range["J6"].Value = FormAutoMail.day.Day;//日の入力
                Sheet.Range["L6"].Value = weekName[FormAutoMail.day.DayOfWeek.ToString()];//曜日の入力



                Sheet.Range["H2"].Value = comboBoxDepartment.Text;//事業部
                Sheet.Range["O2"].Value = comboBoxUserName.Text;//受講者
                Sheet.Range["E7"].Value = numericUpDownStartTimeH.Text + ":"+ numericUpDownStartTimeM.Text;//開始時刻
                Sheet.Range["J7"].Value = numericUpDownEndTimeH.Text + ":" + numericUpDownEndTimeM.Text;//終了時刻
                Sheet.Range["P6"].Value = labelTotalTime.Text;//Total時間
                Sheet.Range["E8"].Value = comboBoxTraining.Text;//教育訓練内容
                Sheet.Range["P8"].Value = comboBoxPlace.Text;//実施場所
                Sheet.Range["P9"].Value = comboBoxMenter.Text;//講師名

                //【教育訓練の内容について】
                int i = 0;
                foreach(string obj in contents)
                {
                     //チェックボックス判定を追記したいところ
                     Sheet.Range["A" + (12 + i)].Value = obj;//内容i行目
                    i++;
                }                

                //【受講生の考察・感想】
                Sheet.Range["A24"].Value = textBoxComment.Text;//感想
                             
                //ファイル名：教育訓練レポート_受講者名_日付
                FormAutoMail.excelFileTitle = "教育訓練レポート_" + comboBoxUserName.Text + "_" + FormAutoMail.day.ToLongDateString()+".xls";

                // 保存
                string FilePath = file_path.Replace(FormAutoMail.reportFile, FormAutoMail.excelFileTitle);//ファイル名入れ替え
                workbook.SaveAs(FilePath);//Saveで上書き,SaveAsで名前を付けて保存

                MessageBox.Show("保存できました。\n該当のフォルダをご確認ください。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //ブック閉じる
                workbook.Close();

                Marshal.ReleaseComObject(Sheet);
                Marshal.ReleaseComObject(workbook);

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();

                // アプリケーションのオブジェクトの解放
                excel.Quit();
                Marshal.ReleaseComObject(excel);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"エラー",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                //ガベージコレクションの実行
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();

                //フォームを閉じる
                this.Close();
            }

        }

        private void TextBoxContent1_TextChanged(object sender, EventArgs e)
        {
            if (checkBoxContent1.Checked == true)
            {
                checkBoxContent[0] = true;
            }
            else
            {
                checkBoxContent[0] = false;
            }
        }

        private void TextBoxContent2_TextChanged(object sender, EventArgs e)
        {
            if (checkBoxContent2.Checked == true)
            {
                checkBoxContent[1] = true;
            }
            else
            {
                checkBoxContent[1] = false;
            }
        }

        private void TextBoxContent3_TextChanged(object sender, EventArgs e)
        {
            if (checkBoxContent3.Checked == true)
            {
                checkBoxContent[2] = true;
            }
            else
            {
                checkBoxContent[2] = false;
            }
        }

        private void TextBoxContent4_TextChanged(object sender, EventArgs e)
        {
            if (checkBoxContent4.Checked == true)
            {
                checkBoxContent[3] = true;
            }
            else
            {
                checkBoxContent[3] = false;
            }
        }

        private void TextBoxContent5_TextChanged(object sender, EventArgs e)
        {
            if (checkBoxContent5.Checked == true)
            {
                checkBoxContent[4] = true;
            }
            else
            {
                checkBoxContent[4] = false;
            }
        }
        private void TextBoxContent6_TextChanged(object sender, EventArgs e)
        {
            if (checkBoxContent6.Checked == true)
            {
                checkBoxContent[5] = true;
            }
            else
            {
                checkBoxContent[5] = false;
            }
        }
        private void TextBoxContent7_TextChanged(object sender, EventArgs e)
        {
            if (checkBoxContent7.Checked == true)
            {
                checkBoxContent[6] = true;
            }
            else
            {
                checkBoxContent[6] = false;
            }
        }
        private void TextBoxContent8_TextChanged(object sender, EventArgs e)
        {
            if (checkBoxContent8.Checked == true)
            {
                checkBoxContent[7] = true;
            }
            else
            {
                checkBoxContent[7] = false;
            }
        }
        private void TextBoxContent9_TextChanged(object sender, EventArgs e)
        {
            if (checkBoxContent9.Checked == true)
            {
                checkBoxContent[8] = true;
            }
            else
            {
                checkBoxContent[8] = false;
            }
        }
        private void TextBoxContent10_TextChanged(object sender, EventArgs e)
        {
            if (checkBoxContent10.Checked == true)
            {
                checkBoxContent[9] = true;
            }
            else
            {
                checkBoxContent[9] = false;
            }
        }
        private void TextBoxContent11_TextChanged(object sender, EventArgs e)
        {
            if (checkBoxContent11.Checked == true)
            {
                checkBoxContent[10] = true;
            }
            else
            {
                checkBoxContent[10] = false;
            }
        }
        private void NumericUpDownStartTimeH_ValueChanged(object sender, EventArgs e)
        {
            //就業時間の計算
            TimeMethod();
        }

        private void NumericUpDownStartTimeM_ValueChanged(object sender, EventArgs e)
        {
            //就業時間の計算
            TimeMethod();
        }

        private void NumericUpDownEndTimeH_ValueChanged(object sender, EventArgs e)
        {
            //就業時間の計算
            TimeMethod();
        }

        private void NumericUpDownEndTimeM_ValueChanged(object sender, EventArgs e)
        {
            //就業時間の計算
            TimeMethod();
        }


        private void NumericUpDownRestTimeH_ValueChanged(object sender, EventArgs e)
        {
            //就業時間の計算
            TimeMethod();
        }

        private void NumericUpDownRestTimeM_ValueChanged(object sender, EventArgs e)
        {
            //就業時間の計算
            TimeMethod();
        }


        /*--------------------------------------------------------*/
        /*メソッド(関数メンバ)④*/
        /*--------------------------------------------------------*/
        /*--------------------------------------------------------*/
        /*メソッド名：TimeMethod*/
        /*　概　要　：就業時間の計算*/
        /*　仮引数　：なし*/
        /*　戻り値　：なし*/
        /*　特　記　：時 + (分/60)として計算*/
        /*--------------------------------------------------------*/
        public void TimeMethod()
        {
            //フォームから値を読込み
            double restTime = (double)numericUpDownRestTimeH.Value + ((double)numericUpDownRestTimeM.Value / 60);
            double startTime = (double)numericUpDownStartTimeH.Value + ((double)numericUpDownStartTimeM.Value / 60);
            double endTime = (double)numericUpDownEndTimeH.Value + ((double)numericUpDownEndTimeM.Value / 60);

            //就業時間の計算
            double totalTime = endTime - startTime - restTime;

            labelTotalTime.Text = totalTime.ToString("F2");//小数桁数2桁まで
        }

        private void textBoxComment_TextChanged(object sender, EventArgs e)
        {
            
            int num = textBoxComment.TextLength;
  
            labelStringNum.Text = "(" + num + "/ 450文字)";

            if(num > 450)
            {
                MessageBox.Show("入力文字数がExcel枠を超える可能性があります。\nご確認願います。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

    }
}

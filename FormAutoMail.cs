using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.IO;


namespace AutoMail
{
    public partial class FormAutoMail : Form
    {
        public static DateTime toDay = DateTime.Now;//日付情報の取得
        public static DateTime day = new DateTime();//日付用の変数
        private string messageBody;//日報内容
        public static Dictionary<string, string> AddressList = new Dictionary<string, string>();//アドレス格納
        public static Dictionary<string, string> MyDataList = new Dictionary<string, string>();//使用者情報格納
        public const string addressFile = "AddressList.txt";//アドレスデータ名
        public const string MessageFormFile = "MessageForm.txt";//定型文ファイル名
        public const string myDataFile = "MyData.txt";//使用者名
        public const string reportFile = "ReportForm.xls";//日報フォーム
        public static List<string> UserNameList = new List<string>();//送信者名登録用
        public static List<string> SendNameList = new List<string>();//送信先名登録用
        public bool excelFlug;//エクセル操作フラッグ
        private int counter = 0;//カウンター用変数
        public static string excelFileTitle;//Excelファイル名
        public static string excelOutputFilePath;//Excelファイルのパス

        
        public static int counterTimerH ;//送信タイマー残り時間H格納変数
        public static int counterTimerM;//送信タイマー残り時間M格納変数

        
        private DateTime lateSendTime;//送信タイマー格納変数

        public List<string> AttachFilePath = new List<string>(); //添付ファイルのパス


        public const string departmentListFile = "DepartmentList.txt";//事業所リストファイル
        public static List<string> departmentList = new List<string>();//事業所リスト登録用

        public const string trainingListFile = "TrainingList.txt";//教育訓練リストファイル
        public static List<string> trainingList = new List<string>();//教育訓練リスト登録用

        public const string placeListFile = "PlaceList.txt";//就業場所リストファイル
        public static List<string> placeList = new List<string>();//就業場所リスト登録用



        public FormAutoMail()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttonMailCreate.Enabled = false;//メール作成ボタンOFF
            labelTotay.Text = "本　日：" + toDay.ToLongDateString();
            radioButtonToday.Checked = true;//初期は本日の日程

            //使用者情報の読み込み(Dataファイル、格納ディクショナリ)            
            ReadUserDataMethod(myDataFile, out MyDataList);
            //上記データの反映
            foreach (string key in MyDataList.Keys)
            {
                textBoxUserName.Text = key;
                UserNameList.Add(key);
            }            

            //送付先情報の読み込み(アドレスファイル、格納ディクショナリ)            
            ReadUserDataMethod(addressFile, out AddressList);

            //上記データの反映
            foreach (string key in AddressList.Keys)
            {
                //コンボボックスへ格納(Keyのみを格納)
                this.comboBoxSendTo.Items.Add(key);
                this.comboBoxSendCC1.Items.Add(key);
                this.comboBoxSendCC2.Items.Add(key);
                //表示用名前の格納
                SendNameList.Add(key);
            }

            //送信者名を表示(AddressList登録順)
            this.comboBoxSendTo.Text = comboBoxSendTo.Items[0].ToString();
            this.comboBoxSendCC1.Text = comboBoxSendTo.Items[1].ToString();
            this.comboBoxSendCC2.Text = comboBoxSendTo.Items[2].ToString();


            //定型文を読み込み(定型文ファイル、格納する変数)            
            MessageFormAddMethod(MessageFormFile, out messageBody);

            //定型文を表示           
            NameAddSamaMethod(comboBoxSendTo.Text,out string nameSama);//姓を格納
            
            messageBody = messageBody.Replace("{TO}", nameSama);
            messageBody = messageBody.Replace("{FROM}", textBoxUserName.Text);
            textBoxMail.Text = messageBody;

            //事業所情報の読み込み(Dataファイル、Listファイル)            
            DataToListMethod(departmentListFile, out departmentList);
            //教育訓練情報の読み込み(Dataファイル、Listファイル)            
            DataToListMethod(trainingListFile, out trainingList);
            //就業場所情報の読み込み(Dataファイル、Listファイル)            
            DataToListMethod(placeListFile, out placeList);
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("この内容で送信しても宜しいでしょうか？","最終確認",
                MessageBoxButtons.OKCancel,MessageBoxIcon.Information) ==DialogResult.OK)
            {
                if (textBoxUserName.Text != "" &&//送信者が空白出ない場合
                excelFlug != false//Excel未操作
                )//送信タイマー機能なし
                {
                    //送信ボタン操作OFF
                    buttonMailCreate.Enabled = false;

                    //フォームの最小化
                    this.WindowState = FormWindowState.Minimized;

                    // outlookメールの立ち上げ
                    var application = new Microsoft.Office.Interop.Outlook.Application();

                    MailItem mailItem = application.CreateItem(OlItemType.olMailItem);
                    if (mailItem != null)
                    {
                        // To
                        Recipient to = mailItem.Recipients.Add(AddressList[comboBoxSendTo.Text]);
                        to.Type = (int)Outlook.OlMailRecipientType.olTo;

                        // Cc
                        if (comboBoxSendCC1.Text != "")
                        {
                            Recipient cc = mailItem.Recipients.Add(AddressList[comboBoxSendCC1.Text]);
                            cc.Type = (int)Outlook.OlMailRecipientType.olCC;
                        }
                        if (comboBoxSendCC2.Text != "")
                        {
                            Recipient cc2 = mailItem.Recipients.Add(AddressList[comboBoxSendCC2.Text]);
                            cc2.Type = (int)Outlook.OlMailRecipientType.olCC;
                        }

                        // アドレス帳の表示名で表示できる
                        mailItem.Recipients.ResolveAll();

                        // 件名
                        mailItem.Subject = $"日報{day.Year}年{day.Month}月{day.Day}日分(久保田將広) ";

                        // 本文
                        mailItem.Body = messageBody;

                        // 表示(Displayメソッド引数のtrue/falseでモーダル/モードレスウィンドウを指定して表示できる)
                        mailItem.Display(false);

                        //ファイルを添付                        
                        foreach (string path in AttachFilePath)
                        {
                            if (path != "")//空白で無ければ
                            {
                                mailItem.Attachments.Add(path);//ファイルを添付
                            }
                        }                        

                        //送信時間の設定有無
                        if (checkBoxSendTimer.Checked == true)//送信時間が設定されている場合
                        {
                            //送信時間を設定し、待機トレイに格納
                            mailItem.DeferredDeliveryTime = lateSendTime;                            

                        }

                        //メールを下書き保存
                        mailItem.Save();

                        //メールを送信
                        mailItem.Send();

                        //フォームを閉じる
                        this.Close();

                    }
                }
                //未編集部分を警告
                else if(textBoxUserName.Text == "")//送信者が空白の場合
                {
                    MessageBox.Show("送信者氏名が空白です。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (excelFlug == false)
                {
                    if(MessageBox.Show("日報が編集されておりません。\n宜しいですか？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Information)==DialogResult.Yes)
                    {
                        //Yesならそのまま送信へ進む
                        excelFlug = true;

                        ButtonCreate_Click(sender,e);//再度実行
                    }                    
                        
                }                
            }
        }

        private void RadioButtonToday_CheckedChanged(object sender, EventArgs e)
        {
            day = toDay;//本日の日付を代入
            labelSelectDate.Text = "";//日付更新
            labelTotay.ForeColor = Color.Black;

        }

        private void RadioButtonOtherDay_CheckedChanged(object sender, EventArgs e)
        {
            day = monthCalendar.SelectionStart;//選択した日付を選択
            labelSelectDate.Text = "選択日："+day.ToLongDateString();//日付更新
            labelTotay.ForeColor = Color.Gray;
        }

        private void MonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            
            day = monthCalendar.SelectionStart;//選択した日付を選択
            radioButtonOtherDay.Checked = true;//チェックボックス選択ON
            labelSelectDate.Text = "選択日："+day.ToLongDateString();//日付更新
        }

        private void ButtonSendUserAdd_Click(object sender, EventArgs e)
        {
            FormAddMember formAddMember = new FormAddMember();//追加フォームの立ち上げ
            if (formAddMember.ShowDialog() == DialogResult.OK)//モーダルダイアログで開く
            {
                //追加ボタンが押されたらコンボボックスへ登録
                this.comboBoxSendTo.Items.Add(AddressList[FormAddMember.nameKey]);
                this.comboBoxSendCC1.Items.Add(AddressList[FormAddMember.nameKey]);
                this.comboBoxSendCC2.Items.Add(AddressList[FormAddMember.nameKey]);

                //アドレスファイルにも書き込み(書き込みファイル名、追加氏名,追加アドレス)
                AddAddressMethod(addressFile, FormAddMember.nameKey, AddressList[FormAddMember.nameKey]);

            }

            formAddMember.Dispose();//フォームを閉じる


        }
        private void ComboBoxSendTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(counter > 0 )//初期表示の再はスルー
            {
                NameAddSamaMethod(comboBoxSendTo.Text, out string comboNameSama);//コンボボックス氏名+様

                foreach (string keyName in AddressList.Keys)
                {
                    NameAddSamaMethod(keyName, out string keyNameSama);//検索氏名+様
                    if (messageBody.IndexOf(keyNameSama) != -1)//メール本文を検索
                    {
                        //異なる氏名の場合はコンボボックス氏名へ変更
                        textBoxMail.Text = messageBody.Replace(keyNameSama, comboNameSama);
                    }
                }
            }
            counter++;

        }

        private void TextBoxMail_TextChanged(object sender, EventArgs e)
        {
            messageBody = textBoxMail.Text;//編集された内容を更新
            buttonMailCreate.Enabled = true;//メール作成ボタンON
        }



        private void TextBoxFromName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxUserName.Text == "")//空白の場合
            {
                MessageBox.Show("送信者氏名が空白です。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonFromUserAdd_Click(object sender, EventArgs e)
        {
            if (textBoxUserName.Text != "")//空白ではない場合
            {
                UserNameList.Add(textBoxUserName.Text);//氏名を格納

                //内容の修正
                foreach (string fromName in UserNameList)
                {
                    if (messageBody.IndexOf(fromName) != -1)//メール本文から氏名を検索
                    {
                        //該当した場合は氏名の変更
                        textBoxMail.Text = messageBody.Replace(fromName, UserNameList[UserNameList.Count - 1]);
                    }
                }
            }

        }

        private void ButtonExcel_Click(object sender, EventArgs e)
        {
            FormExcel formExcel = new FormExcel();//フォームの立ち上げ
            if (formExcel.ShowDialog() == DialogResult.OK)//モーダルダイアログで開く
            {
                if (excelFileTitle != "")//日報を添付
                {
                    AttachFilePath.Add(Path.GetFullPath(excelFileTitle));//ファイルパスをリストへ格納

                }
            }
            excelFlug = true;//エクセル操作完了
            formExcel.Dispose();//フォームを閉じる
        }



        private void CheckBoxSendTimer_CheckedChanged_1(object sender, EventArgs e)
        {           

            if(checkBoxSendTimer.Checked != false)//チェックボックスが//ONの場合
            {
                TimerMethod();               
            }          
            else//OFFの場合
            {               
                buttonMailCreate.Text = "メール配信";                
            }
        }

        private void NumericUpDownSendTimerH_ValueChanged(object sender, EventArgs e)
        {
            checkBoxSendTimer.Checked = true;//チェックボックスをON
            TimerMethod();
        }

        private void NumericUpDownSendTimerM_ValueChanged(object sender, EventArgs e)
        {
            checkBoxSendTimer.Checked = true;//チェックボックスをON
            TimerMethod();
        }      
        

        /*--------------------------------------------------------*/
        /*メソッド(関数メンバ)④*/
        /*--------------------------------------------------------*/
        /*--------------------------------------------------------*/
        /*メソッド名：MessageFormAddMethod*/
        /*　概　要　：定型文を読み込む*/
        /*　仮引数　：string textFile:読込Textファイル名*/
        /*          ：out string obj:ファイル内容を反映する変数*/
        /*　戻り値　：なし*/
        /*　特　記　：ファイルが存在しない場合はエラー文を返す*/
        /*--------------------------------------------------------*/
        public void MessageFormAddMethod(string textFile, out string obj)
        {
            obj = null;//初期化
            try
            {
                using (StreamReader reader = new StreamReader(textFile, Encoding.Default))
                {
                    obj = reader.ReadToEnd();//読み込んだファイルを書き込み
                }
            }
            catch (System.Exception ex)//読込エラー時の対応
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        /*--------------------------------------------------------*/
        /*メソッド名：AddAddressMethod*/
        /*　概　要　：送り先アドレスを読み込む*/
        /*　仮引数　：string addressFile:読込むアドレスファイル名*/
        /*          ：string addName:追加氏名*/
        /*          ：string addAddress:追加アドレス*/
        /*　戻り値　：なし*/
        /*　特　記　：ファイルが存在しない場合はエラー文を返す*/
        /*--------------------------------------------------------*/
        public void AddAddressMethod(string addressFileName,string addName,string addAddress)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter
                    (addressFileName, true, Encoding.Default))
                {
                    writer.WriteLine("\n"+addName + "," + addAddress + "\n");
                }
            }
            catch (System.Exception ex)//読込エラー時の対応
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*--------------------------------------------------------*/
        /*メソッド名：ReadDataMethod*/
        /*　概　要　：送り先アドレスを読み込む*/
        /*　仮引数　：string addressFile:読込むアドレスファイル名*/
        /*　戻り値　：なし*/
        /*　特　記　：ファイルが存在しない場合はエラー文を返す*/
        /*--------------------------------------------------------*/
        public void ReadUserDataMethod(string dataFileName, out Dictionary<string, string> dictionary)
        {
            dictionary = new Dictionary<string, string>();//メソッド用のディクショナリを準備

            //ファイルから読み込み
            try
            {
                using (StreamReader reader = new StreamReader(dataFileName, Encoding.Default))
                {
                    string data;
                    string[] spritData;

                    //段落ごとに読込む
                    while ((data = reader.ReadLine()) != null)
                    {
                        spritData = data.Split(',');//,で分割して格納
                        dictionary.Add(spritData[0], spritData[1]);//格納した値をKey,Valueにてディクショナリィへ格納
                    }
                    //読み込んだファイルを書き込み
                }
            }
            catch (System.Exception ex)//読込エラー時の対応
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /*--------------------------------------------------------*/
        /*メソッド名：NameAddSamaMethod*/
        /*　概　要　：姓に様を付ける*/
        /*　仮引数1 ：string name:氏名*/
        /*　仮引数2 ：out string namePlus:姓+様を追加*/
        /*　戻り値　：なし*/
        /*　特　記　：みよじと名前の間に半角スペースが必要*/
        /*--------------------------------------------------------*/
        public void NameAddSamaMethod(string name,out string nameSama)
        {
            string[] firstName = name.Split(' ');//姓を格納
            nameSama = firstName[0].Insert(firstName[0].Length, "様");//姓+様
        }

        /*--------------------------------------------------------*/
        /*メソッド名：DataToListMethod*/
        /*　概　要　：定型データを読み込む*/
        /*　仮引数1 ：string dataFile:読込むファイル名*/
        /*　仮引数2 ：out List<string> dataList:格納するリスト名*/
        /*　戻り値　：なし*/
        /*　特　記　：ファイルが存在しない場合はエラー文を返す*/
        /*--------------------------------------------------------*/
        public void DataToListMethod(string dataFileName, out List<string> dataList)
        {
            //引数のオブジェクト可
            dataList = new List<string>();

            //ファイルから読み込み
            try
            {
                using (StreamReader reader = new StreamReader(dataFileName, Encoding.Default))
                {
                    string data;//文字列格納変数

                    //段落ごとに読込む
                    while ((data = reader.ReadLine()) != null)
                    {
                        dataList.Add(data);//格納した値を直接格納
                    }

                }
            }
            catch (System.Exception ex)//読込エラー時の対応
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /*--------------------------------------------------------*/
        /*メソッド名：TimerMethod*/
        /*　概　要　：タイマー時間の計算*/
        /*　仮引数　：なし*/
        /*　戻り値　：なし*/
        /*　特　記　：時 + (分/60)として計算*/
        /*--------------------------------------------------------*/
        public void TimerMethod()
        {
            
            //入力値から送信時間を設定
            lateSendTime = new DateTime(
                toDay.Year,//年
                toDay.Month,//月
                toDay.Day,//日
                (int)numericUpDownSendTimerH.Value,//時
                (int)numericUpDownSendTimerM.Value,//分
                 0);//秒


            if (checkBoxSendTimer.Checked == true)
            {
            //ボタン表示の変更
            buttonMailCreate.Text = lateSendTime.Hour + ":" +
                                    lateSendTime.Minute +
                                    "にメールを配信";
            }


        }

        private void ButtonAttachFile_Click(object sender, EventArgs e)
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();

            //はじめに「ファイル名」で表示される文字列
            ofd.FileName = "default.xls";

            //指定しない（空の文字列）の時は、現在のディレクトリが表示される
            ofd.InitialDirectory = @"";

            //ファイル形式の指定(未指定時はすべてのファイルが表示)EXCELファイル(*.xls;*.xlsx)|すべてのファイル(*.*)|*.*
            ofd.Filter = "";

            //タイトルを設定する
            ofd.Title = "開くファイルを選択してください";

            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ofd.RestoreDirectory = true;

            //存在しないファイルの名前が指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ofd.CheckFileExists = true;

            //存在しないパスが指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ofd.CheckPathExists = true;

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき、選択されたファイル名を表示する

                AttachFilePath.Add(Path.GetFullPath(ofd.FileName));//ファイルパスのをリストへ格納
                

            }
        }
    }
}

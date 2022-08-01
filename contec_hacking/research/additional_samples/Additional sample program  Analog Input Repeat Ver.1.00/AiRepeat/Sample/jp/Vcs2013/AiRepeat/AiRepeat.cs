using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CaioCs;

namespace AiRepeat
{
    public partial class AiRepeat : Form
    {
        //----------------------------------------
        // クラスCaioインスタンス作成
        //----------------------------------------
        Caio aio = new Caio();

        //----------------------------------------
        // グローバル変数の宣言
        //----------------------------------------
        public short g_id;
        public ulong g_sampling_count;

        public AiRepeat()
        {
            InitializeComponent();
        }

        private void AiRepeat_Load(object sender, EventArgs e)
        {
            //----------------------------------------
            // デバイス名の初期表示を更新
            //----------------------------------------
            textBox_DeviceName.Text = "AIO000";
        }

        //================================================================================
        // デバイス初期化ボタンをクリックした際の処理になります
        // デバイスの初期化処理を行います
        //================================================================================
        private void button_Init_Click(object sender, EventArgs e)
        {
            int    ret1;            // 戻り値取得用1
            int    ret2;            // 戻り値取得用2
            String error_string;    // エラーコード文字列
            String devicename;      // デバイス名

            //----------------------------------------
            // デバイスを初期化
            //----------------------------------------
            //--------------------
            // デバイス名をテキストボックスから取得
            //--------------------
            devicename = textBox_DeviceName.Text;
            //--------------------
            // デバイス初期化
            // 変更注意関数(変更するとアプリが動作しなくなる可能性があります)
            //--------------------
            ret1 = aio.Init(devicename, out g_id);
            //----------------------------------------
            // エラー処理
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // エラー文字列取得に失敗した場合
                // エラー文字列を初期化
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "初期化処理：aio.Init = " + ret1.ToString() + "：" + error_string;
                return;
            }
            //----------------------------------------
            // デバイスをリセット
            //----------------------------------------
            ret1 = aio.ResetDevice(g_id);
            //----------------------------------------
            // エラー処理
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // エラー文字列取得に失敗した場合
                // エラー文字列を初期化
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "初期化処理：aio.ResetDevice = " + ret1.ToString() + "：" + error_string;
                return;
            }
            //----------------------------------------
            // 入力方式をシングルエンドに設定
            //----------------------------------------
            ret1 = aio.SetAiInputMethod(g_id, 0);
            //----------------------------------------
            // エラー処理
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // エラー文字列取得に失敗した場合
                // エラー文字列を初期化
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "初期化処理：aio.SetAiInputMethod = " + ret1.ToString() + "：" + error_string;
                return;
            }
            //----------------------------------------
            // チャネル数を1に設定
            //----------------------------------------
            ret1 = aio.SetAiChannels(g_id, 1);
            //----------------------------------------
            // エラー処理
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // エラー文字列取得に失敗した場合
                // エラー文字列を初期化
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "初期化処理：aio.SetAiChannels = " + ret1.ToString() + "：" + error_string;
                return;
            }
            //----------------------------------------
            // レンジを±10Vに設定
            //----------------------------------------
            ret1 = aio.SetAiRange(g_id, 0, (short)CaioConst.PM10);
            //----------------------------------------
            // エラー処理
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // エラー文字列取得に失敗した場合
                // エラー文字列を初期化
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "初期化処理：aio.SetAiRange = " + ret1.ToString() + "：" + error_string;
                return;
            }
            //----------------------------------------
            // メモリタイプをFIFOに設定
            //----------------------------------------
            ret1 = aio.SetAiMemoryType(g_id, 0);
            //----------------------------------------
            // エラー処理
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // エラー文字列取得に失敗した場合
                // エラー文字列を初期化
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "初期化処理：aio.SetAiMemoryType = " + ret1.ToString() + "：" + error_string;
                return;
            }
            //----------------------------------------
            // クロックタイプを内部クロックに設定
            //----------------------------------------
            ret1 = aio.SetAiClockType(g_id, 0);
            //----------------------------------------
            // エラー処理
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // エラー文字列取得に失敗した場合
                // エラー文字列を初期化
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "初期化処理：aio.SetAiClockType = " + ret1.ToString() + "：" + error_string;
                return;
            }
            //----------------------------------------
            // サンプリングクロックを1msecに設定
            //----------------------------------------
            ret1 = aio.SetAiSamplingClock(g_id, 1000);
            //----------------------------------------
            // エラー処理
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // エラー文字列取得に失敗した場合
                // エラー文字列を初期化
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "初期化処理：aio.SetAiSamplingClock = " + ret1.ToString() + "：" + error_string;
                return;
            }
            //----------------------------------------
            // 開始条件を外部トリガ立ち上がりに設定
            //----------------------------------------
            ret1 = aio.SetAiStartTrigger(g_id, 1);
            //----------------------------------------
            // エラー処理
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // エラー文字列取得に失敗した場合
                // エラー文字列を初期化
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "初期化処理：aio.SetAiStartTrigger = " + ret1.ToString() + "：" + error_string;
                return;
            }
            //----------------------------------------
            // 停止条件を指定回数に設定
            //----------------------------------------
            ret1 = aio.SetAiStopTrigger(g_id, 0);
            //----------------------------------------
            // エラー処理
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // エラー文字列取得に失敗した場合
                // エラー文字列を初期化
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "初期化処理：aio.SetAiStopTrigger = " + ret1.ToString() + "：" + error_string;
                return;
            }
            //----------------------------------------
            // サンプリング停止回数を1000回に設定
            //----------------------------------------
            ret1 = aio.SetAiStopTimes(g_id, 1000);
            //----------------------------------------
            // エラー処理
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // エラー文字列取得に失敗した場合
                // エラー文字列を初期化
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "初期化処理：aio.SetAiStopTimes = " + ret1.ToString() + "：" + error_string;
                return;
            }
            //----------------------------------------
            // イベントにサンプリング開始、リピート終了、動作終了を設定
            // 変更注意関数(変更するとアプリが動作しなくなる可能性があります)
            //----------------------------------------
            ret1 = aio.SetAiEvent(g_id, (uint)Handle, (int)(CaioConst.AIE_START | CaioConst.AIE_RPTEND | CaioConst.AIE_END));
            //----------------------------------------
            // エラー処理
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // エラー文字列取得に失敗した場合
                // エラー文字列を初期化
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "初期化処理：aio.SetAiEvent = " + ret1.ToString() + "：" + error_string;
                return;
            }
            //----------------------------------------
            // 初期化処理完了のメッセ―ジ表示
            //----------------------------------------
            textBox_Return.Text = "初期化処理：正常終了";
        }

        //================================================================================
        // リピート回数設定ボタンをクリックした際の処理になります
        // リピート回数の設定を行います
        //================================================================================
        private void button_Repeat_Click(object sender, EventArgs e)
        {
            int    ret1;            // 戻り値取得用1
            int    ret2;            // 戻り値取得用2
            int    repeat_times;    // リピート回数
            String error_string;    // エラーコード文字列

            //----------------------------------------
            // GUIの情報を更新
            //----------------------------------------
            this.Refresh();
            //----------------------------------------
            // リピート回数を設定
            //----------------------------------------
            try{
                repeat_times = int.Parse(textBox_RepeatTimes.Text);
            }catch{
                repeat_times = 0;
            }
            ret1 = aio.SetAiRepeatTimes(g_id, repeat_times);
            //----------------------------------------
            // エラー処理
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // エラー文字列取得に失敗した場合
                // エラー文字列を初期化
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "リピート回数設定：aio.SetAiRepeatTimes = " + ret1.ToString() + "：" + error_string;
                return;
            }
            //----------------------------------------
            // リピート回数設定完了のメッセ―ジ表示
            //----------------------------------------
            textBox_Return.Text = "リピート回数設定：正常終了";
        }

        //================================================================================
        // サンプリング開始ボタンをクリックした際の処理になります
        // メモリとステータスのクリアを行った後、サンプリング開始を行います
        //================================================================================
        private void button_Start_Click(object sender, EventArgs e)
        {
            int    ret1;                // 戻り値取得用1
            int    ret2;                // 戻り値取得用2
            String error_string;        // エラーコード文字列
            String text_string;         // テキストボックス更新用
            int    aistatus;            // アナログ入力ステータス
            int    airepeatcount;       // アナログ入力リピート回数

            //----------------------------------------
            // メモリクリア
            //----------------------------------------
            ret1 = aio.ResetAiMemory(g_id);
            //----------------------------------------
            // エラー処理
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // エラー文字列取得に失敗した場合
                // エラー文字列を初期化
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "サンプリング開始：aio.ResetAiMemory = " + ret1.ToString() + "：" + error_string;
                return;
            }
            //----------------------------------------
            // ステータスクリア
            //----------------------------------------
            ret1 = aio.ResetAiStatus(g_id);
            //----------------------------------------
            // エラー処理
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // エラー文字列取得に失敗した場合
                // エラー文字列を初期化
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "サンプリング開始：aio.ResetAiStatus = " + ret1.ToString() + "：" + error_string;
                return;
            }
            g_sampling_count = 0;
            //----------------------------------------
            // サンプリング開始
            //----------------------------------------
            ret1 = aio.StartAi(g_id);
            //----------------------------------------
            // エラー処理
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // エラー文字列取得に失敗した場合
                // エラー文字列を初期化
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "サンプリング開始：aio.StartAi = " + ret1.ToString() + "：" + error_string;
                return;
            }
            //----------------------------------------
            // ステータスを取得
            //----------------------------------------
            ret1 = aio.GetAiStatus(g_id, out aistatus);
            //----------------------------------------
            // エラー処理
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // エラー文字列取得に失敗した場合
                // エラー文字列を初期化
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "サンプリング開始：aio.GetAiStatus = " + ret1.ToString() + "：" + error_string;
                return;
            }
            //----------------------------------------
            // ステータスの表示
            //----------------------------------------
            text_string = String.Format("{0:X8}H (", aistatus);
            //--------------------
            // 動作中ステータス有効時
            //--------------------
            if ((aistatus & (int)CaioConst.AIS_BUSY) == (int)CaioConst.AIS_BUSY){
                text_string += "動作中";
            //--------------------
            // 動作中ステータス無効時
            //--------------------
            }else{
                text_string += "停止中";
            }
            //--------------------
            // 開始トリガ待ちステータス有効時
            //--------------------
            if ((aistatus & (int)CaioConst.AIS_START_TRG) == (int)CaioConst.AIS_START_TRG){
                text_string += ", 開始トリガ待ち";
            }
            //--------------------
            // 指定サンプリング回数格納ステータス有効時
            //--------------------
            if ((aistatus & (int)CaioConst.AIS_DATA_NUM) == (int)CaioConst.AIS_DATA_NUM){
                text_string += ", 指定回数格納";
            }
            //--------------------
            // オーバーフローステータス有効時
            //--------------------
            if ((aistatus & (int)CaioConst.AIS_OFERR) == (int)CaioConst.AIS_OFERR){
                text_string += ", オーバーフロー";
            }
            //--------------------
            // サンプリングクロックエラーステータス有効時
            //--------------------
            if ((aistatus & (int)CaioConst.AIS_SCERR) == (int)CaioConst.AIS_SCERR){
                text_string += ", サンプリングクロックエラー";
            }
            //--------------------
            // AD変換エラーステータス有効時
            //--------------------
            if ((aistatus & (int)CaioConst.AIS_AIERR) == (int)CaioConst.AIS_AIERR){
                text_string += ", AD変換エラー";
            }
            //--------------------
            // ドライバスペックエラーステータス有効時
            //--------------------
            if ((aistatus & (int)CaioConst.AIS_DRVERR) == (int)CaioConst.AIS_DRVERR){
                text_string += ", ドライバスペックエラー";
            }
            text_string += ")";
            textBox_Status.Text = text_string;
            //----------------------------------------
            // 総サンプリング回数を更新
            //----------------------------------------
            textBox_SamplingCount.Text = g_sampling_count.ToString();
            //----------------------------------------
            // 現在のリピート回数を取得
            //----------------------------------------
            ret1 = aio.GetAiRepeatCount(g_id, out airepeatcount);
            //----------------------------------------
            // エラー処理
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // エラー文字列取得に失敗した場合
                // エラー文字列を初期化
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "サンプリング開始：aio.GetAiRepeatCount = " + ret1.ToString() + "：" + error_string;
                return;
            }
            //----------------------------------------
            // リピート回数を更新
            //----------------------------------------
            textBox_RepeatCount.Text = airepeatcount.ToString();
            //----------------------------------------
            // サンプリング開始完了のメッセ―ジ表示
            //----------------------------------------
            textBox_Return.Text = "サンプリング開始：正常終了";
        }

        //================================================================================
        // サンプリング停止ボタンをクリックした際の処理になります
        // サンプリング停止を行います
        //================================================================================
        private void button_Stop_Click(object sender, EventArgs e)
        {
            int    ret1;           // 戻り値取得用1
            int    ret2;           // 戻り値取得用2
            String error_string;   // エラーコード文字列

            //----------------------------------------
            // サンプリング停止
            //----------------------------------------
            ret1 = aio.StopAi(g_id);
            //----------------------------------------
            // エラー処理
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // エラー文字列取得に失敗した場合
                // エラー文字列を初期化
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "サンプリング停止：aio.StopAi = " + ret1.ToString() + "：" + error_string;
                return;
            }
            //----------------------------------------
            // サンプリング停止完了のメッセ―ジ表示
            //----------------------------------------
            textBox_Return.Text = "サンプリング停止：正常終了";
        }

        //================================================================================
        // デバイス終了処理ボタンをクリックした際の処理になります
        // デバイスの終了処理を行います
        //================================================================================
        private void button_Exit_Click(object sender, EventArgs e)
        {
            int    ret1;           // 戻り値取得用1
            int    ret2;           // 戻り値取得用2
            String error_string;   // エラーコード文字列

            //----------------------------------------
            // デバイスの終了処理
            //----------------------------------------
            ret1 = aio.Exit(g_id);
            //----------------------------------------
            // エラー処理
            //----------------------------------------
            if (ret1 != 0){
                ret2 = aio.GetErrorString(ret1, out error_string);
                //--------------------
                // エラー文字列取得に失敗した場合
                // エラー文字列を初期化
                //--------------------
                if (ret2 != 0){
                    error_string = "";
                }
                textBox_Return.Text = "デバイス終了処理：aio.Exit = " + ret1.ToString() + "：" + error_string;
                return;
            }
            //----------------------------------------
            // デバイス終了処理完了のメッセ―ジ表示
            //----------------------------------------
            textBox_Return.Text = "デバイス終了処理：正常終了";
        }

        //================================================================================
        // 閉じるボタンを押した際の処理になります
        // アプリの終了処理を行います
        //================================================================================
        private void button_Close_Click(object sender, EventArgs e)
        {
            //----------------------------------------
            // ダイアログを終了する
            //----------------------------------------
            this.Close();
        }

        //================================================================================
        // イベントが発生した時の動作
        // 各イベントが発生したとき、イベント毎に処理を行う
        //================================================================================
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            int     ret1;                // 戻り値取得用1
            int     ret2;                // 戻り値取得用2
            String  error_string;        // エラーコード文字列
            String  text_string;         // テキストボックス更新用
            int     aisamplingcount;     // サンプリングカウント
            float[] aidata;              // アナログデータ
            short   aichannels;          // チャネル数
            int     aistatus;            // ステータス
            int     airepeatcount;       // リピート回数
            int     i, j;

            //----------------------------------------
            // AD変換開始条件成立イベント
            // データの取得、表示を行う
            //----------------------------------------
            if (m.Msg == (short)CaioConst.AIOM_AIE_START){
                //----------------------------------------
                // ステータスを取得
                //----------------------------------------
                ret1 = aio.GetAiStatus(g_id, out aistatus);
                //----------------------------------------
                // エラー処理
                //----------------------------------------
                if (ret1 != 0){
                    ret2 = aio.GetErrorString(ret1, out error_string);
                    //--------------------
                    // エラー文字列取得に失敗した場合
                    // エラー文字列を初期化
                    //--------------------
                    if (ret2 != 0){
                        error_string = "";
                    }
                    textBox_Return.Text = "AD変換開始条件成立処理：aio.GetAiStatus = " + ret1.ToString() + "：" + error_string;
                    return;
                }
                //----------------------------------------
                // ステータスの表示
                //----------------------------------------
                text_string = String.Format("{0:X8}H (", aistatus);
                //--------------------
                // 動作中ステータス有効時
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_BUSY) == (int)CaioConst.AIS_BUSY){
                    text_string += "動作中";
                //--------------------
                // 動作中ステータス無効時
                //--------------------
                }else{
                    text_string += "停止中";
                }
                //--------------------
                // 開始トリガ待ちステータス有効時
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_START_TRG) == (int)CaioConst.AIS_START_TRG){
                    text_string += ", 開始トリガ待ち";
                }
                //--------------------
                // 指定サンプリング回数格納ステータス有効時
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_DATA_NUM) == (int)CaioConst.AIS_DATA_NUM){
                    text_string += ", 指定回数格納";
                }
                //--------------------
                // オーバーフローステータス有効時
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_OFERR) == (int)CaioConst.AIS_OFERR){
                    text_string += ", オーバーフロー";
                }
                //--------------------
                // サンプリングクロックエラーステータス有効時
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_SCERR) == (int)CaioConst.AIS_SCERR){
                    text_string += ", サンプリングクロックエラー";
                }
                //--------------------
                // AD変換エラーステータス有効時
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_AIERR) == (int)CaioConst.AIS_AIERR){
                    text_string += ", AD変換エラー";
                }
                //--------------------
                // ドライバスペックエラーステータス有効時
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_DRVERR) == (int)CaioConst.AIS_DRVERR){
                    text_string += ", ドライバスペックエラー";
                }
                text_string += ")";
                textBox_Status.Text = text_string;
                //----------------------------------------
                // イベント処理完了のメッセ―ジ表示
                //----------------------------------------
                textBox_Return.Text = "AD変換開始条件成立処理：正常終了";
            }
            //----------------------------------------
            // リピート終了イベント
            // データの取得、表示を行う
            //----------------------------------------
            if (m.Msg == (short)CaioConst.AIOM_AIE_RPTEND){
                //----------------------------------------
                // ステータスを取得
                //----------------------------------------
                ret1 = aio.GetAiStatus(g_id, out aistatus);
                //----------------------------------------
                // エラー処理
                //----------------------------------------
                if (ret1 != 0){
                    ret2 = aio.GetErrorString(ret1, out error_string);
                    //--------------------
                    // エラー文字列取得に失敗した場合
                    // エラー文字列を初期化
                    //--------------------
                    if (ret2 != 0){
                        error_string = "";
                    }
                    textBox_Return.Text = "リピート終了イベント処理：aio.GetAiStatus = " + ret1.ToString() + "：" + error_string;
                    return;
                }
                //----------------------------------------
                // ステータスの表示
                //----------------------------------------
                text_string = String.Format("{0:X8}H (", aistatus);
                //--------------------
                // 動作中ステータス有効時
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_BUSY) == (int)CaioConst.AIS_BUSY){
                    text_string += "動作中";
                //--------------------
                // 動作中ステータス無効時
                //--------------------
                }else{
                    text_string += "停止中";
                }
                //--------------------
                // 開始トリガ待ちステータス有効時
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_START_TRG) == (int)CaioConst.AIS_START_TRG){
                    text_string += ", 開始トリガ待ち";
                }
                //--------------------
                // 指定サンプリング回数格納ステータス有効時
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_DATA_NUM) == (int)CaioConst.AIS_DATA_NUM){
                    text_string += ", 指定回数格納";
                }
                //--------------------
                // オーバーフローステータス有効時
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_OFERR) == (int)CaioConst.AIS_OFERR){
                    text_string += ", オーバーフロー";
                }
                //--------------------
                // サンプリングクロックエラーステータス有効時
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_SCERR) == (int)CaioConst.AIS_SCERR){
                    text_string += ", サンプリングクロックエラー";
                }
                //--------------------
                // AD変換エラーステータス有効時
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_AIERR) == (int)CaioConst.AIS_AIERR){
                    text_string += ", AD変換エラー";
                }
                //--------------------
                // ドライバスペックエラーステータス有効時
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_DRVERR) == (int)CaioConst.AIS_DRVERR){
                    text_string += ", ドライバスペックエラー";
                }
                text_string += ")";
                textBox_Status.Text = text_string;
                //----------------------------------------
                // 現在のサンプリング回数を取得
                //----------------------------------------
                ret1 = aio.GetAiSamplingCount(g_id, out aisamplingcount);
                //----------------------------------------
                // エラー処理
                //----------------------------------------
                if (ret1 != 0){
                    ret2 = aio.GetErrorString(ret1, out error_string);
                    //--------------------
                    // エラー文字列取得に失敗した場合
                    // エラー文字列を初期化
                    //--------------------
                    if (ret2 != 0){
                        error_string = "";
                    }
                    textBox_Return.Text = "リピート終了イベント処理：aio.GetAiSamplingCount = " + ret1.ToString() + "：" + error_string;
                    return;
                }
                //----------------------------------------
                // チャネル数取得
                //----------------------------------------
                ret1 = aio.GetAiChannels(g_id, out aichannels);
                //----------------------------------------
                // エラー処理
                //----------------------------------------
                if (ret1 != 0){
                    ret2 = aio.GetErrorString(ret1, out error_string);
                    //--------------------
                    // エラー文字列取得に失敗した場合
                    // エラー文字列を初期化
                    //--------------------
                    if (ret2 != 0){
                        error_string = "";
                    }
                    textBox_Return.Text = "リピート終了イベント処理：aio.GetAiChannels = " + ret1.ToString() + "：" + error_string;
                    return;
                }
                //----------------------------------------
                // サンプリングデータを取得
                //----------------------------------------
                //--------------------
                // データ格納用の配列を確保
                //--------------------
                aidata = new float[aisamplingcount * aichannels];
                if (aidata == null){
                    textBox_Return.Text = "リピート終了イベント処理：データ格納用の配列確保に失敗";
                    return;
                }
                ret1 = aio.GetAiSamplingDataEx(g_id, ref aisamplingcount, ref aidata);
                //----------------------------------------
                // エラー処理
                //----------------------------------------
                if (ret1 != 0){
                    ret2 = aio.GetErrorString(ret1, out error_string);
                    //--------------------
                    // エラー文字列取得に失敗した場合
                    // エラー文字列を初期化
                    //--------------------
                    if (ret2 != 0){
                        error_string = "";
                    }
                    textBox_Return.Text = "リピート終了イベント処理：aio.GetAiSamplingDataEx = " + ret1.ToString() + "：" + error_string;
                    aidata = null;
                    return;
                }
                g_sampling_count += (ulong)aisamplingcount;
                //----------------------------------------
                // 総サンプリング回数を更新
                //----------------------------------------
                textBox_SamplingCount.Text = g_sampling_count.ToString();
                //----------------------------------------
                // 現在のリピート回数を取得
                //----------------------------------------
                ret1 = aio.GetAiRepeatCount(g_id, out airepeatcount);
                //----------------------------------------
                // エラー処理
                //----------------------------------------
                if (ret1 != 0){
                    ret2 = aio.GetErrorString(ret1, out error_string);
                    //--------------------
                    // エラー文字列取得に失敗した場合
                    // エラー文字列を初期化
                    //--------------------
                    if (ret2 != 0){
                        error_string = "";
                    }
                    textBox_Return.Text = "リピート終了イベント処理：aio.GetAiRepeatCount = " + ret1.ToString() + "：" + error_string;
                    aidata = null;
                    return;
                }
                //----------------------------------------
                // リピート回数を更新
                //----------------------------------------
                textBox_RepeatCount.Text = airepeatcount.ToString();
                //----------------------------------------
                // サンプリングデータを表示するための文字列を格納
                //----------------------------------------
                text_string = "";
                for (i = 0; i < aisamplingcount; i++)
                {
                    text_string += String.Format("{0,5}:     ", i);
                    for (j = 0; j < aichannels; j++)
                    {
                        text_string += String.Format(aidata[i * aichannels + j].ToString("F5"));
                    }
                    text_string += "\r\n";
                }
                //----------------------------------------
                // サンプリングデータを表示
                //----------------------------------------
                textBox_SamplingData.Text = text_string;
                //----------------------------------------
                // イベント処理完了のメッセ―ジ表示
                //----------------------------------------
                textBox_Return.Text = "リピート終了イベント処理：正常終了";
                aidata = null;
            }
            //----------------------------------------
            // デバイス動作終了イベント
            // データの取得、表示を行う
            //----------------------------------------
            if (m.Msg == (short)CaioConst.AIOM_AIE_END){
                //----------------------------------------
                // ステータスを取得
                //----------------------------------------
                ret1 = aio.GetAiStatus(g_id, out aistatus);
                //----------------------------------------
                // エラー処理
                //----------------------------------------
                if (ret1 != 0){
                    ret2 = aio.GetErrorString(ret1, out error_string);
                    //--------------------
                    // エラー文字列取得に失敗した場合
                    // エラー文字列を初期化
                    //--------------------
                    if (ret2 != 0){
                        error_string = "";
                    }
                    textBox_Return.Text = "デバイス動作終了イベント処理：aio.GetAiStatus = " + ret1.ToString() + "：" + error_string;
                    return;
                }
                //----------------------------------------
                // ステータスの表示
                //----------------------------------------
                text_string = String.Format("{0:X8}H (", aistatus);
                //--------------------
                // 動作中ステータス有効時
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_BUSY) == (int)CaioConst.AIS_BUSY){
                    text_string += "動作中";
                //--------------------
                // 動作中ステータス無効時
                //--------------------
                }else{
                    text_string += "停止中";
                }
                //--------------------
                // 開始トリガ待ちステータス有効時
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_START_TRG) == (int)CaioConst.AIS_START_TRG){
                    text_string += ", 開始トリガ待ち";
                }
                //--------------------
                // 指定サンプリング回数格納ステータス有効時
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_DATA_NUM) == (int)CaioConst.AIS_DATA_NUM){
                    text_string += ", 指定回数格納";
                }
                //--------------------
                // オーバーフローステータス有効時
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_OFERR) == (int)CaioConst.AIS_OFERR){
                    text_string += ", オーバーフロー";
                }
                //--------------------
                // サンプリングクロックエラーステータス有効時
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_SCERR) == (int)CaioConst.AIS_SCERR){
                    text_string += ", サンプリングクロックエラー";
                }
                //--------------------
                // AD変換エラーステータス有効時
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_AIERR) == (int)CaioConst.AIS_AIERR){
                    text_string += ", AD変換エラー";
                }
                //--------------------
                // ドライバスペックエラーステータス有効時
                //--------------------
                if ((aistatus & (int)CaioConst.AIS_DRVERR) == (int)CaioConst.AIS_DRVERR){
                    text_string += ", ドライバスペックエラー";
                }
                text_string += ")";
                textBox_Status.Text = text_string;
                //----------------------------------------
                // 現在のサンプリング回数を取得
                //----------------------------------------
                ret1 = aio.GetAiSamplingCount(g_id, out aisamplingcount);
                //----------------------------------------
                // エラー処理
                //----------------------------------------
                if (ret1 != 0){
                    ret2 = aio.GetErrorString(ret1, out error_string);
                    //--------------------
                    // エラー文字列取得に失敗した場合
                    // エラー文字列を初期化
                    //--------------------
                    if (ret2 != 0){
                        error_string = "";
                    }
                    textBox_Return.Text = "デバイス動作終了イベント処理：aio.GetAiSamplingCount = " + ret1.ToString() + "：" + error_string;
                    return;
                }
                //----------------------------------------
                // チャネル数取得
                //----------------------------------------
                ret1 = aio.GetAiChannels(g_id, out aichannels);
                //----------------------------------------
                // エラー処理
                //----------------------------------------
                if (ret1 != 0){
                    ret2 = aio.GetErrorString(ret1, out error_string);
                    //--------------------
                    // エラー文字列取得に失敗した場合
                    // エラー文字列を初期化
                    //--------------------
                    if (ret2 != 0){
                        error_string = "";
                    }
                    textBox_Return.Text = "デバイス動作終了イベント処理：aio.GetAiChannels = " + ret1.ToString() + "：" + error_string;
                    return;
                }
                //----------------------------------------
                // サンプリングデータを取得
                //----------------------------------------
                //--------------------
                // データ格納用の配列を確保
                //--------------------
                aidata = new float[aisamplingcount * aichannels];
                if (aidata == null){
                    textBox_Return.Text = "デバイス動作終了イベント処理：データ格納用の配列確保に失敗";
                    return;
                }
                ret1 = aio.GetAiSamplingDataEx(g_id, ref aisamplingcount, ref aidata);
                //----------------------------------------
                // エラー処理
                //----------------------------------------
                if (ret1 != 0){
                    ret2 = aio.GetErrorString(ret1, out error_string);
                    //--------------------
                    // エラー文字列取得に失敗した場合
                    // エラー文字列を初期化
                    //--------------------
                    if (ret2 != 0){
                        error_string = "";
                    }
                    textBox_Return.Text = "デバイス動作終了イベント処理：aio.GetAiSamplingDataEx = " + ret1.ToString() + "：" + error_string;
                    aidata = null;
                    return;
                }
                g_sampling_count += (ulong)aisamplingcount;
                //----------------------------------------
                // 総サンプリング回数を更新
                //----------------------------------------
                textBox_SamplingCount.Text = g_sampling_count.ToString();
                //----------------------------------------
                // 現在のリピート回数を取得
                //----------------------------------------
                ret1 = aio.GetAiRepeatCount(g_id, out airepeatcount);
                //----------------------------------------
                // エラー処理
                //----------------------------------------
                if (ret1 != 0){
                    ret2 = aio.GetErrorString(ret1, out error_string);
                    //--------------------
                    // エラー文字列取得に失敗した場合
                    // エラー文字列を初期化
                    //--------------------
                    if (ret2 != 0){
                        error_string = "";
                    }
                    textBox_Return.Text = "デバイス動作終了イベント処理：aio.GetAiRepeatCount = " + ret1.ToString() + "：" + error_string;
                    aidata = null;
                    return;
                }
                //----------------------------------------
                // リピート回数を更新
                //----------------------------------------
                textBox_RepeatCount.Text = airepeatcount.ToString();
                //----------------------------------------
                // サンプリングデータを表示するための文字列を格納
                //----------------------------------------
                text_string = "";
                for (i = 0; i < aisamplingcount; i++)
                {
                    text_string += String.Format("{0,5}:     ", i);
                    for (j = 0; j < aichannels; j++)
                    {
                        text_string += String.Format(aidata[i * aichannels + j].ToString("F5"));
                    }
                    text_string += "\r\n";
                }
                //----------------------------------------
                // サンプリングデータを表示
                //----------------------------------------
                textBox_SamplingData.Text = text_string;
                //----------------------------------------
                // イベント処理完了のメッセ―ジ表示
                //----------------------------------------
                textBox_Return.Text = "デバイス動作終了イベント処理：正常終了";
                aidata = null;
            }
            base.WndProc(ref m);
        }
    }
}

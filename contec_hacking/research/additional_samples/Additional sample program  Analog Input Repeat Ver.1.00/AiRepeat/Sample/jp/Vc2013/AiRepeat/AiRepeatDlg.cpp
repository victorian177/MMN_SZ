
// AiRepeatDlg.cpp : 実装ファイル
//

#include "stdafx.h"
#include "AiRepeat.h"
#include "AiRepeatDlg.h"
#include "afxdialogex.h"
#include "Caio.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CAiRepeatDlg ダイアログ



CAiRepeatDlg::CAiRepeatDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(CAiRepeatDlg::IDD, pParent)
	, m_repeat_times(1)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CAiRepeatDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_EDIT_DEVICENAME, m_edt_devicename);
	DDX_Control(pDX, IDC_EDIT_SAMPLINGDATA, m_edt_samplingdata);
	DDX_Control(pDX, IDC_EDIT_STATUS, m_edt_status);
	DDX_Control(pDX, IDC_EDIT_SAMPLINGCOUNT, m_edt_samplingcount);
	DDX_Control(pDX, IDC_EDIT_REPEATCOUNT, m_edt_repeatcount);
	DDX_Control(pDX, IDC_EDIT_RETURN, m_edt_return);
	DDX_Text(pDX, IDC_EDIT_REPEATTIMES, m_repeat_times);
}

BEGIN_MESSAGE_MAP(CAiRepeatDlg, CDialogEx)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BUTTON_INIT, &CAiRepeatDlg::OnBnClickedButtonInit)
	ON_BN_CLICKED(IDC_BUTTON_REPEAT, &CAiRepeatDlg::OnBnClickedButtonRepeat)
	ON_BN_CLICKED(IDC_BUTTON_START, &CAiRepeatDlg::OnBnClickedButtonStart)
	ON_BN_CLICKED(IDC_BUTTON_STOP, &CAiRepeatDlg::OnBnClickedButtonStop)
	ON_BN_CLICKED(IDC_BUTTON_EXIT, &CAiRepeatDlg::OnBnClickedButtonExit)
	ON_BN_CLICKED(IDC_BUTTON_CLOSE, &CAiRepeatDlg::OnBnClickedButtonClose)
END_MESSAGE_MAP()

//----------------------------------------
// グローバル変数の宣言
//----------------------------------------
short			g_id;
unsigned long	g_sampling_count;

// CAiRepeatDlg メッセージ ハンドラー

BOOL CAiRepeatDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// このダイアログのアイコンを設定します。アプリケーションのメイン ウィンドウがダイアログでない場合、
	//  Framework は、この設定を自動的に行います。
	SetIcon(m_hIcon, TRUE);			// 大きいアイコンの設定
	SetIcon(m_hIcon, FALSE);		// 小さいアイコンの設定

	//----------------------------------------
	// デバイス名の初期表示を更新
	//----------------------------------------
	m_edt_devicename.SetWindowTextW(_T("AIO000"));

	return TRUE;  // フォーカスをコントロールに設定した場合を除き、TRUE を返します。
}

// ダイアログに最小化ボタンを追加する場合、アイコンを描画するための
//  下のコードが必要です。ドキュメント/ビュー モデルを使う MFC アプリケーションの場合、
//  これは、Framework によって自動的に設定されます。

void CAiRepeatDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // 描画のデバイス コンテキスト

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// クライアントの四角形領域内の中央
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// アイコンの描画
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

// ユーザーが最小化したウィンドウをドラッグしているときに表示するカーソルを取得するために、
//  システムがこの関数を呼び出します。
HCURSOR CAiRepeatDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}


//================================================================================
// デバイス初期化ボタンをクリックした際の処理になります
// デバイスの初期化処理を行います
//================================================================================
void CAiRepeatDlg::OnBnClickedButtonInit()
{
	TCHAR	text_temp[256];		// テキスト一時格納用
	long	ret1;				// 戻り値取得用1
	long	ret2;				// 戻り値取得用2
	char	error_string[256];	// エラーコード文字列
	CString	text_string;		// テキストボックス更新用
	char	devicename[256];	// デバイス名

	//----------------------------------------
	// デバイスを初期化
	//----------------------------------------
	//--------------------
	// デバイス名をテキストボックスから取得
	//--------------------
	m_edt_devicename.GetWindowTextW(text_temp, 256);
	sprintf_s(devicename, "%S", text_temp);
	//--------------------
	// デバイス初期化
	// 変更注意関数(変更するとアプリが動作しなくなる可能性があります)
	//--------------------
	ret1 = AioInit(devicename, &g_id);
	//----------------------------------------
	// エラー処理
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// エラー文字列取得に失敗した場合
		// エラー文字列を初期化
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("初期化処理：AioInit = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// デバイスをリセット
	//----------------------------------------
	ret1 = AioResetDevice(g_id);
	//----------------------------------------
	// エラー処理
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// エラー文字列取得に失敗した場合
		// エラー文字列を初期化
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("初期化処理：AioResetDevice = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// 入力方式をシングルエンドに設定
	//----------------------------------------
	ret1 = AioSetAiInputMethod(g_id, 0);
	//----------------------------------------
	// エラー処理
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// エラー文字列取得に失敗した場合
		// エラー文字列を初期化
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("初期化処理：AioSetAiInputMethod = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// チャネル数を1に設定
	//----------------------------------------
	ret1 = AioSetAiChannels(g_id, 1);
	//----------------------------------------
	// エラー処理
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// エラー文字列取得に失敗した場合
		// エラー文字列を初期化
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("初期化処理：AioSetAiChannels = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// レンジを±10Vに設定
	//----------------------------------------
	ret1 = AioSetAiRange(g_id, 0, PM10);
	//----------------------------------------
	// エラー処理
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// エラー文字列取得に失敗した場合
		// エラー文字列を初期化
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("初期化処理：AioSetAiRange = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// メモリタイプをFIFOに設定
	//----------------------------------------
	ret1 = AioSetAiMemoryType(g_id, 0);
	//----------------------------------------
	// エラー処理
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// エラー文字列取得に失敗した場合
		// エラー文字列を初期化
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("初期化処理：AioSetAiMemoryType = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// クロックタイプを内部クロックに設定
	//----------------------------------------
	ret1 = AioSetAiClockType(g_id, 0);
	//----------------------------------------
	// エラー処理
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// エラー文字列取得に失敗した場合
		// エラー文字列を初期化
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("初期化処理：AioSetAiClockType = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// サンプリングクロックを1msecに設定
	//----------------------------------------
	ret1 = AioSetAiSamplingClock(g_id, 1000);
	//----------------------------------------
	// エラー処理
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// エラー文字列取得に失敗した場合
		// エラー文字列を初期化
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("初期化処理：AioSetAiSamplingClock = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// 開始条件を外部トリガ立ち上がりに設定
	//----------------------------------------
	ret1 = AioSetAiStartTrigger(g_id, 1);
	//----------------------------------------
	// エラー処理
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// エラー文字列取得に失敗した場合
		// エラー文字列を初期化
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("初期化処理：AioSetAiStartTrigger = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// 停止条件を指定回数に設定
	//----------------------------------------
	ret1 = AioSetAiStopTrigger(g_id, 0);
	//----------------------------------------
	// エラー処理
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// エラー文字列取得に失敗した場合
		// エラー文字列を初期化
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("初期化処理：AioSetAiStopTrigger = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// サンプリング停止回数を1000回に設定
	//----------------------------------------
	ret1 = AioSetAiStopTimes(g_id, 1000);
	//----------------------------------------
	// エラー処理
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// エラー文字列取得に失敗した場合
		// エラー文字列を初期化
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("初期化処理：AioSetAiStopTimes = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// イベントにサンプリング開始、リピート終了、動作終了を設定
	// 変更注意関数(変更するとアプリが動作しなくなる可能性があります)
	//----------------------------------------
	ret1 = AioSetAiEvent(g_id, m_hWnd, (AIE_START | AIE_RPTEND | AIE_END));
	//----------------------------------------
	// エラー処理
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// エラー文字列取得に失敗した場合
		// エラー文字列を初期化
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("初期化処理：AioSetAiEvnet = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// 初期化処理完了のメッセ―ジ表示
	//----------------------------------------
	text_string.Format(_T("初期化処理：正常終了"));
	m_edt_return.SetWindowText(text_string);
}


//================================================================================
// リピート回数設定ボタンをクリックした際の処理になります
// リピート回数の設定を行います
//================================================================================
void CAiRepeatDlg::OnBnClickedButtonRepeat()
{
	TCHAR	text_temp[256];		// テキスト一時格納用
	long	ret1;				// 戻り値取得用1
	long	ret2;				// 戻り値取得用2
	char	error_string[256];	// エラーコード文字列
	CString	text_string;		// テキストボックス更新用

	//----------------------------------------
	// GUIの情報を更新
	//----------------------------------------
	UpdateData(TRUE);
	//----------------------------------------
	// リピート回数を設定
	//----------------------------------------
	ret1 = AioSetAiRepeatTimes(g_id, m_repeat_times);
	//----------------------------------------
	// エラー処理
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// エラー文字列取得に失敗した場合
		// エラー文字列を初期化
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("リピート回数設定：AioSetAiRepeatTimes = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// リピート回数設定完了のメッセ―ジ表示
	//----------------------------------------
	text_string.Format(_T("リピート回数設定：正常終了"));
	m_edt_return.SetWindowText(text_string);
}


//================================================================================
// サンプリング開始ボタンをクリックした際の処理になります
// メモリとステータスのクリアを行った後、サンプリング開始を行います
//================================================================================
void CAiRepeatDlg::OnBnClickedButtonStart()
{
	TCHAR	text_temp[256];		// テキスト一時格納用
	long	ret1;				// 戻り値取得用1
	long	ret2;				// 戻り値取得用2
	char	error_string[256];	// エラーコード文字列
	CString	text_string;		// テキストボックス更新用
	CString	text_string_temp;	// テキストボックス一時格納用
	long	aistatus;			// アナログ入力ステータス
	long	airepeatcount;		// アナログ入力リピート回数

	//----------------------------------------
	// メモリクリア
	//----------------------------------------
	ret1 = AioResetAiMemory(g_id);
	//----------------------------------------
	// エラー処理
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// エラー文字列取得に失敗した場合
		// エラー文字列を初期化
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("サンプリング開始：AioResetAiMemory = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// ステータスクリア
	//----------------------------------------
	ret1 = AioResetAiStatus(g_id);
	//----------------------------------------
	// エラー処理
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// エラー文字列取得に失敗した場合
		// エラー文字列を初期化
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("サンプリング開始：AioResetAiStatus = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	g_sampling_count	= 0;
	//----------------------------------------
	// サンプリング開始
	//----------------------------------------
	ret1 = AioStartAi(g_id);
	//----------------------------------------
	// エラー処理
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// エラー文字列取得に失敗した場合
		// エラー文字列を初期化
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("サンプリング開始：AioStartAi = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// ステータスを取得
	//----------------------------------------
	ret1 = AioGetAiStatus(g_id, &aistatus);
	//----------------------------------------
	// エラー処理
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// エラー文字列取得に失敗した場合
		// エラー文字列を初期化
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("サンプリング開始：AioGetAiStatus = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// ステータスの表示
	//----------------------------------------
	text_string.Format(_T("%08xH ("), aistatus);
	//--------------------
	// 動作中ステータス有効時
	//--------------------
	if ((aistatus & AIS_BUSY) == AIS_BUSY){
		text_string_temp.Format(_T("動作中"));
		text_string += text_string_temp;
	//--------------------
	// 動作中ステータス無効時
	//--------------------
	}else{
		text_string_temp.Format(_T("停止中"));
		text_string += text_string_temp;
	}
	//--------------------
	// 開始トリガ待ちステータス有効時
	//--------------------
	if ((aistatus & AIS_START_TRG) == AIS_START_TRG){
		text_string_temp.Format(_T(", 開始トリガ待ち"));
		text_string += text_string_temp;
	}
	//--------------------
	// 指定サンプリング回数格納ステータス有効時
	//--------------------
	if ((aistatus & AIS_DATA_NUM) == AIS_DATA_NUM){
		text_string_temp.Format(_T(", 指定回数格納"));
		text_string += text_string_temp;
	}
	//--------------------
	// オーバーフローステータス有効時
	//--------------------
	if ((aistatus & AIS_OFERR) == AIS_OFERR){
		text_string_temp.Format(_T(", オーバーフロー"));
		text_string += text_string_temp;
	}
	//--------------------
	// サンプリングクロックエラーステータス有効時
	//--------------------
	if ((aistatus & AIS_SCERR) == AIS_SCERR){
		text_string_temp.Format(_T(", サンプリングクロックエラー"));
		text_string += text_string_temp;
	}
	//--------------------
	// AD変換エラーステータス有効時
	//--------------------
	if ((aistatus & AIS_AIERR) == AIS_AIERR){
		text_string_temp.Format(_T(", AD変換エラー"));
		text_string += text_string_temp;
	}
	//--------------------
	// ドライバスペックエラーステータス有効時
	//--------------------
	if ((aistatus & AIS_DRVERR) == AIS_DRVERR){
		text_string_temp.Format(_T(", ドライバスペックエラー"));
		text_string += text_string_temp;
	}
	text_string_temp.Format(_T(")"));
	text_string += text_string_temp;
	m_edt_status.SetWindowText(text_string);
	//----------------------------------------
	// 総サンプリング回数を更新
	//----------------------------------------
	text_string.Format(_T("%d"), g_sampling_count);
	m_edt_samplingcount.SetWindowText(text_string);
	//----------------------------------------
	// 現在のリピート回数を取得
	//----------------------------------------
	ret1 = AioGetAiRepeatCount(g_id, &airepeatcount);
	//----------------------------------------
	// エラー処理
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// エラー文字列取得に失敗した場合
		// エラー文字列を初期化
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("サンプリング開始：AioGetAiRepeatCount = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// リピート回数を更新
	//----------------------------------------
	text_string.Format(_T("%d"), airepeatcount);
	m_edt_repeatcount.SetWindowText(text_string);
	//----------------------------------------
	// サンプリング開始完了のメッセ―ジ表示
	//----------------------------------------
	text_string.Format(_T("サンプリング開始：正常終了"));
	m_edt_return.SetWindowText(text_string);
}


//================================================================================
// サンプリング停止ボタンをクリックした際の処理になります
// サンプリング停止を行います
//================================================================================
void CAiRepeatDlg::OnBnClickedButtonStop()
{
	TCHAR	text_temp[256];		// テキスト一時格納用
	long	ret1;				// 戻り値取得用1
	long	ret2;				// 戻り値取得用2
	char	error_string[256];	// エラーコード文字列
	CString	text_string;		// テキストボックス更新用

	//----------------------------------------
	// サンプリング停止
	//----------------------------------------
	ret1 = AioStopAi(g_id);
	//----------------------------------------
	// エラー処理
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// エラー文字列取得に失敗した場合
		// エラー文字列を初期化
		//--------------------
		if (ret2 != 0) {
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("サンプリング停止：AioStopAi = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// サンプリング停止完了のメッセ―ジ表示
	//----------------------------------------
	text_string.Format(_T("サンプリング停止：正常終了"));
	m_edt_return.SetWindowText(text_string);
}


//================================================================================
// デバイス終了処理ボタンをクリックした際の処理になります
// デバイスの終了処理を行います
//================================================================================
void CAiRepeatDlg::OnBnClickedButtonExit()
{
	TCHAR	text_temp[256];		// テキスト一時格納用
	long	ret1;				// 戻り値取得用1
	long	ret2;				// 戻り値取得用2
	char	error_string[256];	// エラーコード文字列
	CString	text_string;		// テキストボックス更新用

	//----------------------------------------
	// デバイスの終了処理
	//----------------------------------------
	ret1 = AioExit(g_id);
	//----------------------------------------
	// エラー処理
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// エラー文字列取得に失敗した場合
		// エラー文字列を初期化
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("デバイス終了処理：AioExit = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// デバイス終了処理完了のメッセ―ジ表示
	//----------------------------------------
	text_string.Format(_T("デバイス終了処理：正常終了"));
	m_edt_return.SetWindowText(text_string);
}


//================================================================================
// 閉じるボタンを押した際の処理になります
// アプリの終了処理を行います
//================================================================================
void CAiRepeatDlg::OnBnClickedButtonClose()
{
	//----------------------------------------
	// ダイアログを終了する
	//----------------------------------------
	CDialog::OnOK();
}


//================================================================================
// イベントが発生した時の動作
// 各イベントが発生したとき、イベント毎に処理を行う
//================================================================================
LRESULT CAiRepeatDlg::DefWindowProc(UINT message, WPARAM wParam, LPARAM lParam)
{
	TCHAR	text_temp[256];			// テキスト一時格納用
	long	ret1;					// 戻り値取得用1
	long	ret2;					// 戻り値取得用2
	char	error_string[256];		// エラーコード文字列
	CString	text_string;			// テキストボックス更新用
	long	aisamplingcount;		// サンプリングカウント
	float	*aidata;				// アナログデータ
	CString	text_string_temp;		// テキストボックス一時格納用
	short	aichannels;				// チャネル数
	long	aistatus;				// ステータス
	long	airepeatcount;			// リピート回数
	int		i, j;

	//----------------------------------------
	// AD変換開始条件成立イベント
	// データの取得、表示を行う
	//----------------------------------------
	if (message == AIOM_AIE_START){
		//----------------------------------------
		// ステータスを取得
		//----------------------------------------
		ret1 = AioGetAiStatus(g_id, &aistatus);
		//----------------------------------------
		// エラー処理
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// エラー文字列取得に失敗した場合
			// エラー文字列を初期化
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("AD変換開始条件成立処理：AioGetAiStatus = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			return TRUE;
		}
		//----------------------------------------
		// ステータスの表示
		//----------------------------------------
		text_string.Format(_T("%08xH ("), aistatus);
		//--------------------
		// 動作中ステータス有効時
		//--------------------
		if ((aistatus & AIS_BUSY) == AIS_BUSY){
			text_string_temp.Format(_T("動作中"));
		//--------------------
		// 動作中ステータス無効時
		//--------------------
		}else{
			text_string_temp.Format(_T("停止中"));
		}
		text_string += text_string_temp;
		//--------------------
		// 開始トリガ待ちステータス有効時
		//--------------------
		if ((aistatus & AIS_START_TRG) == AIS_START_TRG){
			text_string_temp.Format(_T(", 開始トリガ待ち"));
			text_string += text_string_temp;
		}
		//--------------------
		// 指定サンプリング回数格納ステータス有効時
		//--------------------
		if ((aistatus & AIS_DATA_NUM) == AIS_DATA_NUM){
			text_string_temp.Format(_T(", 指定回数格納"));
			text_string += text_string_temp;
		}
		//--------------------
		// オーバーフローステータス有効時
		//--------------------
		if ((aistatus & AIS_OFERR) == AIS_OFERR){
			text_string_temp.Format(_T(", オーバーフロー"));
			text_string += text_string_temp;
		}
		//--------------------
		// サンプリングクロックエラーステータス有効時
		//--------------------
		if ((aistatus & AIS_SCERR) == AIS_SCERR){
			text_string_temp.Format(_T(", サンプリングクロックエラー"));
			text_string += text_string_temp;
		}
		//--------------------
		// AD変換エラーステータス有効時
		//--------------------
		if ((aistatus & AIS_AIERR) == AIS_AIERR){
			text_string_temp.Format(_T(", AD変換エラー"));
			text_string += text_string_temp;
		}
		//--------------------
		// ドライバスペックエラーステータス有効時
		//--------------------
		if ((aistatus & AIS_DRVERR) == AIS_DRVERR){
			text_string_temp.Format(_T(", ドライバスペックエラー"));
			text_string += text_string_temp;
		}
		text_string_temp.Format(_T(")"));
		text_string += text_string_temp;
		m_edt_status.SetWindowText(text_string);
		//----------------------------------------
		// イベント処理完了のメッセ―ジ表示
		//----------------------------------------
		text_string.Format(_T("AD変換開始条件成立処理：正常終了"));
		m_edt_return.SetWindowText(text_string);
	}
	//----------------------------------------
	// リピート終了イベント
	// データの取得、表示を行う
	//----------------------------------------
	if (message == AIOM_AIE_RPTEND){
		//----------------------------------------
		// ステータスを取得
		//----------------------------------------
		ret1 = AioGetAiStatus(g_id, &aistatus);
		//----------------------------------------
		// エラー処理
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// エラー文字列取得に失敗した場合
			// エラー文字列を初期化
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("リピート終了イベント処理：AioGetAiStatus = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			return TRUE;
		}
		//----------------------------------------
		// ステータスの表示
		//----------------------------------------
		text_string.Format(_T("%08xH ("), aistatus);
		//--------------------
		// 動作中ステータス有効時
		//--------------------
		if ((aistatus & AIS_BUSY) == AIS_BUSY){
			text_string_temp.Format(_T("動作中"));
		//--------------------
		// 動作中ステータス無効時
		//--------------------
		}else{
			text_string_temp.Format(_T("停止中"));
		}
		text_string += text_string_temp;
		//--------------------
		// 開始トリガ待ちステータス有効時
		//--------------------
		if ((aistatus & AIS_START_TRG) == AIS_START_TRG){
			text_string_temp.Format(_T(", 開始トリガ待ち"));
			text_string += text_string_temp;
		}
		//--------------------
		// 指定サンプリング回数格納ステータス有効時
		//--------------------
		if ((aistatus & AIS_DATA_NUM) == AIS_DATA_NUM){
			text_string_temp.Format(_T(", 指定回数格納"));
			text_string += text_string_temp;
		}
		//--------------------
		// オーバーフローステータス有効時
		//--------------------
		if ((aistatus & AIS_OFERR) == AIS_OFERR){
			text_string_temp.Format(_T(", オーバーフロー"));
			text_string += text_string_temp;
		}
		//--------------------
		// サンプリングクロックエラーステータス有効時
		//--------------------
		if ((aistatus & AIS_SCERR) == AIS_SCERR){
			text_string_temp.Format(_T(", サンプリングクロックエラー"));
			text_string += text_string_temp;
		}
		//--------------------
		// AD変換エラーステータス有効時
		//--------------------
		if ((aistatus & AIS_AIERR) == AIS_AIERR){
			text_string_temp.Format(_T(", AD変換エラー"));
			text_string += text_string_temp;
		}
		//--------------------
		// ドライバスペックエラーステータス有効時
		//--------------------
		if ((aistatus & AIS_DRVERR) == AIS_DRVERR){
			text_string_temp.Format(_T(", ドライバスペックエラー"));
			text_string += text_string_temp;
		}
		text_string_temp.Format(_T(")"));
		text_string += text_string_temp;
		m_edt_status.SetWindowText(text_string);
		//----------------------------------------
		// 現在のサンプリング回数を取得
		//----------------------------------------
		ret1 = AioGetAiSamplingCount(g_id, &aisamplingcount);
		//----------------------------------------
		// エラー処理
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// エラー文字列取得に失敗した場合
			// エラー文字列を初期化
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("リピート終了イベント処理：AioGetAiSamplingCount = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			return TRUE;
		}
		//----------------------------------------
		// チャネル数取得
		//----------------------------------------
		ret1 = AioGetAiChannels(g_id, &aichannels);
		//----------------------------------------
		// エラー処理
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// エラー文字列取得に失敗した場合
			// エラー文字列を初期化
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("リピート終了イベント処理：AioGetAiChannels = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			return TRUE;
		}
		//----------------------------------------
		// サンプリングデータを取得
		//----------------------------------------
		//--------------------
		// データ格納用の配列を確保
		//--------------------
		aidata = (float *)malloc(sizeof(float)* aisamplingcount * aichannels);
		if (aidata == NULL){
			text_string.Format(_T("リピート終了イベント処理：データ格納用の配列確保に失敗"));
			m_edt_return.SetWindowText(text_string);
			return TRUE;
		}
		ret1 = AioGetAiSamplingDataEx(g_id, &aisamplingcount, aidata);
		//----------------------------------------
		// エラー処理
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// エラー文字列取得に失敗した場合
			// エラー文字列を初期化
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("リピート終了イベント処理：AioGetAiSamplingDataEx = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			free(aidata);
			return TRUE;
		}
		g_sampling_count += aisamplingcount;
		//----------------------------------------
		// 総サンプリング回数を更新
		//----------------------------------------
		text_string.Format(_T("%d"), g_sampling_count);
		m_edt_samplingcount.SetWindowText(text_string);
		//----------------------------------------
		// 現在のリピート回数を取得
		//----------------------------------------
		ret1 = AioGetAiRepeatCount(g_id, &airepeatcount);
		//----------------------------------------
		// エラー処理
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// エラー文字列取得に失敗した場合
			// エラー文字列を初期化
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("リピート終了イベント処理：AioGetAiRepeatCount = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			free(aidata);
			return TRUE;
		}
		//----------------------------------------
		// リピート回数を更新
		//----------------------------------------
		text_string.Format(_T("%d"), airepeatcount);
		m_edt_repeatcount.SetWindowText(text_string);
		//----------------------------------------
		// サンプリングデータを表示するための文字列を格納
		//----------------------------------------
		text_string.Empty();
		for (i = 0; i < aisamplingcount; i++){
			text_string_temp.Format(_T("%5d:     "), i + 1);
			text_string += text_string_temp;
			for (j = 0; j < aichannels; j++){
				text_string_temp.Format(_T("%2.5f "), aidata[i * aichannels + j]);
				text_string += text_string_temp;
			}
			text_string_temp.Format(_T("\r\n"));
			text_string += text_string_temp;
		}
		//----------------------------------------
		// サンプリングデータを表示
		//----------------------------------------
		m_edt_samplingdata.SetWindowTextW(text_string);
		//----------------------------------------
		// イベント処理完了のメッセ―ジ表示
		//----------------------------------------
		text_string.Format(_T("リピート終了イベント処理：正常終了"));
		m_edt_return.SetWindowText(text_string);
		free(aidata);
	}
	//----------------------------------------
	// デバイス動作終了イベント
	// データの取得、表示を行う
	//----------------------------------------
	if (message == AIOM_AIE_END){
		//----------------------------------------
		// ステータスを取得
		//----------------------------------------
		ret1 = AioGetAiStatus(g_id, &aistatus);
		//----------------------------------------
		// エラー処理
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// エラー文字列取得に失敗した場合
			// エラー文字列を初期化
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("デバイス動作終了イベント処理：AioGetAiStatus = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			return TRUE;
		}
		//----------------------------------------
		// ステータスの表示
		//----------------------------------------
		text_string.Format(_T("%08xH ("), aistatus);
		//--------------------
		// 動作中ステータス有効時
		//--------------------
		if ((aistatus & AIS_BUSY) == AIS_BUSY){
			text_string_temp.Format(_T("動作中"));
		//--------------------
		// 動作中ステータス無効時
		//--------------------
		}else{
			text_string_temp.Format(_T("停止中"));
		}
		text_string += text_string_temp;
		//--------------------
		// 開始トリガ待ちステータス有効時
		//--------------------
		if ((aistatus & AIS_START_TRG) == AIS_START_TRG){
			text_string_temp.Format(_T(", 開始トリガ待ち"));
			text_string += text_string_temp;
		}
		//--------------------
		// 指定サンプリング回数格納ステータス有効時
		//--------------------
		if ((aistatus & AIS_DATA_NUM) == AIS_DATA_NUM){
			text_string_temp.Format(_T(", 指定回数格納"));
			text_string += text_string_temp;
		}
		//--------------------
		// オーバーフローステータス有効時
		//--------------------
		if ((aistatus & AIS_OFERR) == AIS_OFERR){
			text_string_temp.Format(_T(", オーバーフロー"));
			text_string += text_string_temp;
		}
		//--------------------
		// サンプリングクロックエラーステータス有効時
		//--------------------
		if ((aistatus & AIS_SCERR) == AIS_SCERR){
			text_string_temp.Format(_T(", サンプリングクロックエラー"));
			text_string += text_string_temp;
		}
		//--------------------
		// AD変換エラーステータス有効時
		//--------------------
		if ((aistatus & AIS_AIERR) == AIS_AIERR){
			text_string_temp.Format(_T(", AD変換エラー"));
			text_string += text_string_temp;
		}
		//--------------------
		// ドライバスペックエラーステータス有効時
		//--------------------
		if ((aistatus & AIS_DRVERR) == AIS_DRVERR){
			text_string_temp.Format(_T(", ドライバスペックエラー"));
			text_string += text_string_temp;
		}
		text_string_temp.Format(_T(")"));
		text_string += text_string_temp;
		m_edt_status.SetWindowText(text_string);
		//----------------------------------------
		// 現在のサンプリング回数を取得
		//----------------------------------------
		ret1 = AioGetAiSamplingCount(g_id, &aisamplingcount);
		//----------------------------------------
		// エラー処理
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// エラー文字列取得に失敗した場合
			// エラー文字列を初期化
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("デバイス動作終了イベント処理：AioGetAiSamplingCount = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			return TRUE;
		}
		//----------------------------------------
		// チャネル数取得
		//----------------------------------------
		ret1 = AioGetAiChannels(g_id, &aichannels);
		//----------------------------------------
		// エラー処理
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// エラー文字列取得に失敗した場合
			// エラー文字列を初期化
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("デバイス動作終了イベント処理：AioGetAiChannels = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			return TRUE;
		}
		//----------------------------------------
		// サンプリングデータを取得
		//----------------------------------------
		//--------------------
		// データ格納用の配列を確保
		//--------------------
		aidata = (float *)malloc(sizeof(float)* aisamplingcount * aichannels);
		if (aidata == NULL){
			text_string.Format(_T("デバイス動作終了イベント処理：データ格納用の配列確保に失敗"));
			m_edt_return.SetWindowText(text_string);
			return TRUE;
		}
		ret1 = AioGetAiSamplingDataEx(g_id, &aisamplingcount, aidata);
		//----------------------------------------
		// エラー処理
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// エラー文字列取得に失敗した場合
			// エラー文字列を初期化
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("デバイス動作終了イベント処理：AioGetAiSamplingDataEx = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			free(aidata);
			return TRUE;
		}
		g_sampling_count += aisamplingcount;
		//----------------------------------------
		// 総サンプリング回数を更新
		//----------------------------------------
		text_string.Format(_T("%d"), g_sampling_count);
		m_edt_samplingcount.SetWindowText(text_string);
		//----------------------------------------
		// 現在のリピート回数を取得
		//----------------------------------------
		ret1 = AioGetAiRepeatCount(g_id, &airepeatcount);
		//----------------------------------------
		// エラー処理
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// エラー文字列取得に失敗した場合
			// エラー文字列を初期化
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("デバイス動作終了イベント処理：AioGetAiRepeatCount = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			free(aidata);
			return TRUE;
		}
		//----------------------------------------
		// リピート回数を更新
		//----------------------------------------
		text_string.Format(_T("%d"), airepeatcount);
		m_edt_repeatcount.SetWindowText(text_string);
		//----------------------------------------
		// サンプリングデータを表示するための文字列を格納
		//----------------------------------------
		text_string.Empty();
		for (i = 0; i < aisamplingcount; i++){
			text_string_temp.Format(_T("%5d:     "), i + 1);
			text_string += text_string_temp;
			for (j = 0; j < aichannels; j++){
				text_string_temp.Format(_T("%2.5f "), aidata[i * aichannels + j]);
				text_string += text_string_temp;
			}
			text_string_temp.Format(_T("\r\n"));
			text_string += text_string_temp;
		}
		//----------------------------------------
		// サンプリングデータを表示
		//----------------------------------------
		m_edt_samplingdata.SetWindowTextW(text_string);
		//----------------------------------------
		// イベント処理完了のメッセ―ジ表示
		//----------------------------------------
		text_string.Format(_T("デバイス動作終了イベント処理：正常終了"));
		m_edt_return.SetWindowText(text_string);
		free(aidata);
	}

	return CDialog::DefWindowProc(message, wParam, lParam);
}
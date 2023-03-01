
// ComSampleDlg.cpp : 実装ファイル
//

#include "stdafx.h"
#include "ComSample.h"
#include "ComSampleDlg.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

// CComSampleDlg ダイアログ



CComSampleDlg::CComSampleDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(CComSampleDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CComSampleDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);

	DDX_Control(pDX, IDC_COMBO_COMPORT1, m_ComPort);
	DDX_Control(pDX, IDC_TEXT, m_Text);
	DDX_Control(pDX, IDC_OPENBUTTON, m_OpenButton);
}

BEGIN_MESSAGE_MAP(CComSampleDlg, CDialogEx)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_OPENBUTTON, &CComSampleDlg::OnBnClickedOpenbutton)
	ON_BN_CLICKED(IDC_ENDBUTTON, &CComSampleDlg::OnBnClickedEndbutton)
	ON_WM_KEYDOWN()
END_MESSAGE_MAP()

//グローバル変数
HANDLE	hComm;				// COMポートのハンドル
CWinThread* ComRecvThread;	// COM受信データスレッドハンドル

//TCHARタイプをcharタイプに変換します
void CComSampleDlg::TcharToChar(const TCHAR* tchar, char* _char) {
	int iLength;

	iLength = WideCharToMultiByte(CP_ACP, 0, tchar, -1, NULL, 0, NULL, NULL);
	WideCharToMultiByte(CP_ACP, 0, tchar, -1, _char, iLength, NULL, NULL);
}

//charタイプをTCHARタイプに変換します
void CComSampleDlg::CharToTchar(const char* _char, TCHAR* tchar) {
	int iLength;

	iLength = MultiByteToWideChar(CP_ACP, 0, _char, int(strlen(_char) + 1), NULL, 0);
	MultiByteToWideChar(CP_ACP, 0, _char, int(strlen(_char) + 1), tchar, iLength);
}

//COM受信データスレッド(16Byte毎受信)
UINT ComRecvData(LPVOID pParam)
{
	BOOL			bRet;
	DWORD			dwErrorFlags;
	COMSTAT			ComStat;
	DWORD			dwLength = 0;
	char			szReadData[17];
	TCHAR			TcharData[17];
	CString			TextStr;			
	DWORD			dwError;
	TCHAR			szText[100];
	CComSampleDlg	*ComDlg = (CComSampleDlg *)pParam;
	while(1) {
		if (hComm != NULL) {
			//バッファがキューに溜まっている？
			ClearCommError(hComm, &dwErrorFlags, &ComStat) ;
			//16Byte毎受信
			if ((ComStat.cbInQue % 16 == 0) && (ComStat.cbInQue >= 16)) {
				if (dwErrorFlags > 0){
					wsprintf(szText, _T("ClearCommError:Error(dwErrorFlags=%X Hex)\n"), dwErrorFlags);
					ComDlg->m_Text.SetWindowText(szText);
					return FALSE;
				}
				//読みこみ
				dwLength = sizeof(szReadData);
				bRet = ReadFile(hComm, szReadData, dwLength, &dwLength, NULL);
				//エラーチェック
				if (bRet == FALSE) {
					dwError = GetLastError();
					wsprintf(szText, _T("ReadFile:Error(%d)"), dwError);
					ComDlg->m_Text.SetWindowText(szText);
					return FALSE;
				}
				//受信データの表示
				szReadData[dwLength] = '\0';
				ComDlg->CharToTchar(szReadData, TcharData);
				if (dwLength != 0) {
					ComDlg->m_Text.GetWindowText(TextStr);
					TextStr += TcharData;
					ComDlg->m_Text.SetWindowText(TextStr);
				}
			}
		}
	}

	return TRUE;
}

//CComSampleDlg メッセージ ハンドラー

BOOL CComSampleDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	//このダイアログのアイコンを設定します。アプリケーションのメイン ウィンドウがダイアログでない場合、
	//Framework は、この設定を自動的に行います。
	SetIcon(m_hIcon, TRUE);			//大きいアイコンの設定
	SetIcon(m_hIcon, FALSE);		//小さいアイコンの設定

	TCHAR	szText[256];
	int		cnt;
	//ポート番号を割り振る(1から255まで)
    for (cnt = 1; cnt < 256; cnt++)
    {
		wsprintf(szText, _T("COM%d"), cnt);
		m_ComPort.AddString(szText);
    }
	//初期設定時はCOM1を選択させておく。
	m_ComPort.SelectString(-1, _T("COM1"));

	m_Text.SetWindowTextW(_T("Please select Port Number. After, push <Port Open> button."));

	ComRecvThread = AfxBeginThread(ComRecvData, this);

	return TRUE;  //フォーカスをコントロールに設定した場合を除き、TRUE を返します。
}

//ダイアログに最小化ボタンを追加する場合、アイコンを描画するための
//下のコードが必要です。ドキュメント/ビュー モデルを使う MFC アプリケーションの場合、
//これは、Framework によって自動的に設定されます。

void CComSampleDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); //描画のデバイス コンテキスト

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		//クライアントの四角形領域内の中央
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		//アイコンの描画
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

//ユーザーが最小化したウィンドウをドラッグしているときに表示するカーソルを取得するために、
//システムがこの関数を呼び出します。
HCURSOR CComSampleDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

//ポートオープン/クローズを行うボタン
void CComSampleDlg::OnBnClickedOpenbutton()
{
	TCHAR			szCommPort[100];
	TCHAR			szText[100];
	DWORD			dwError;
	BOOL			bRet;
	DCB				dcb;
	COMMTIMEOUTS	CommTimeOuts;
	//COMポート名の作成
	m_ComPort.GetWindowText(szText, sizeof(szText));
	wsprintf(szCommPort, _T("\\\\.\\%s"), szText);
	if (hComm == NULL) {
		//オープン
		hComm = CreateFile(
					szCommPort,
					GENERIC_READ | GENERIC_WRITE,
					0,
					NULL,
					OPEN_EXISTING,
					FILE_ATTRIBUTE_NORMAL,
					NULL);
		//エラーチェック
		if (hComm == INVALID_HANDLE_VALUE) {
			dwError = GetLastError();
			wsprintf(szText, _T("CreateFile:Error(%d)"), dwError);
			m_Text.SetWindowText(szText);
			return;
		}
		//次回このボタンを押すときは　ポートクローズのため
        //ボタンに対し　ポートクローズの表示を行う
		m_OpenButton.SetWindowTextW(_T("Port Close"));
        //ポートオープンが正常に行えた事をテキストに表示する。
		m_Text.SetWindowText(_T("Port Open sucess."));
		//送受信バッファクリア
		PurgeComm(hComm, PURGE_TXABORT | PURGE_RXABORT |
						 PURGE_TXCLEAR | PURGE_RXCLEAR ) ;
		//タイムアウト値セット
		CommTimeOuts.ReadIntervalTimeout = 0xFFFFFFFF;
		CommTimeOuts.ReadTotalTimeoutMultiplier = 0 ;
		CommTimeOuts.ReadTotalTimeoutConstant = 5000;
		CommTimeOuts.WriteTotalTimeoutMultiplier = 0 ;
		CommTimeOuts.WriteTotalTimeoutConstant = 5000;
		SetCommTimeouts(hComm, &CommTimeOuts ) ;
		//通信デバイスの状態取得
		dcb.DCBlength = sizeof( DCB );
		GetCommState(hComm, &dcb );
		//通信デバイスセット
		//ボーレート設定(Setting Baudrate.) 
		dcb.BaudRate = 9600;
		//データビット設定(Setting Databits.) 
		dcb.ByteSize = 8;
		//ストップビット設定(Setting Stopbits.)
		dcb.StopBits = ONESTOPBIT;
		//パリティ設定(Setting Paritybits.)
		dcb.Parity = NOPARITY;
		//RTS, DTRコントロール設定(Setting RTS/DTR Controls.)
		dcb.fRtsControl = RTS_CONTROL_ENABLE;
		dcb.fDtrControl = DTR_CONTROL_ENABLE;

		dcb.fOutxDsrFlow = FALSE;
		dcb.fBinary = TRUE;
		dcb.fParity = TRUE;

		bRet = SetCommState(hComm, &dcb);
		//エラーチェック
		if (bRet == FALSE ) {
			dwError = GetLastError();
			wsprintf(szText, _T("SetCommState:Error(%d)"), dwError);
			m_Text.SetWindowText(szText);
			return;
		}
	} else {
		//クローズ
		bRet = CloseHandle(hComm);
		hComm = NULL;
		//エラーチェック
		if (bRet == FALSE) {
			dwError = GetLastError();
			wsprintf(szText, _T("CloseHandle:Error(%d)"), dwError);
			m_Text.SetWindowText(szText);
			return;
		}

		//次回このボタンを押すときは　ポートクローズのため
        //ボタンに対し　ポートクローズの表示を行う
		m_OpenButton.SetWindowTextW(_T("Port Open"));
        //ポートオープンが正常に行えた事をテキストに表示する。
		m_Text.SetWindowText(_T("Port Close success."));
	}
}

//ポートをクローズしてサンプルを終了する
void CComSampleDlg::OnBnClickedEndbutton()
{
	BOOL	bRet;
	TCHAR	szText[100];
	DWORD	dwError;
	if (hComm != NULL) {
		//クローズ
		bRet = CloseHandle(hComm);
		//エラーチェック
		if (bRet == FALSE) {
			dwError = GetLastError();
			wsprintf(szText, _T("CloseHandle:Error(%d)"), dwError);
			m_Text.SetWindowText(szText);
			return;
		}
	}
}

//キーを押したときに起動するメンバ
BOOL CComSampleDlg::PreTranslateMessage(MSG* pMsg)
{
	char	szWriteData[2];
	TCHAR	szTcharWriteData[2];
	DWORD	nWriteLength;
	DWORD	dwBytesWritten;

	if ((pMsg->message == WM_KEYDOWN) && (m_Text.m_hWnd == pMsg->hwnd)) {
		if (hComm != NULL)//すでにポートがオープンされている場合は、処理する。
        {
			//入力したキーが0-9、A-Zですか判断
			if (((pMsg->wParam >= 'A') && (pMsg->wParam <= 'Z')) ||
				((pMsg->wParam >= '0') && (pMsg->wParam <= '9'))) {
				wsprintf(szTcharWriteData, _T("%c"), pMsg->wParam);
				nWriteLength = lstrlen(szTcharWriteData);
				TcharToChar(szTcharWriteData, szWriteData);
				WriteFile(hComm, (LPCVOID)szWriteData, nWriteLength, &dwBytesWritten, NULL);
			//入力したキーが0-9(数値キーパット)ですか判断
			} else if ((pMsg->wParam >= VK_NUMPAD0) && (pMsg->wParam <= VK_NUMPAD9)) {
				wsprintf(szTcharWriteData, _T("%c"), (pMsg->wParam - 48));
				nWriteLength = lstrlen(szTcharWriteData);
				TcharToChar(szTcharWriteData, szWriteData);
				WriteFile(hComm, (LPCVOID)szWriteData, nWriteLength, &dwBytesWritten, NULL);
			//他に何もしない
			} else {
				
			}
		}
	}

	return CDialogEx::PreTranslateMessage(pMsg);
}


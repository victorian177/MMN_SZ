
// AiRepeatDlg.h : ヘッダー ファイル
//

#pragma once
#include "afxwin.h"


// CAiRepeatDlg ダイアログ
class CAiRepeatDlg : public CDialogEx
{
// コンストラクション
public:
	CAiRepeatDlg(CWnd* pParent = NULL);	// 標準コンストラクター

// ダイアログ データ
	enum { IDD = IDD_AIREPEAT_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV サポート
	virtual LRESULT DefWindowProc(UINT message, WPARAM wParam, LPARAM lParam);


// 実装
protected:
	HICON m_hIcon;

	// 生成された、メッセージ割り当て関数
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	CEdit m_edt_devicename;
	long m_repeat_times;
	CEdit m_edt_samplingdata;
	CEdit m_edt_status;
	CEdit m_edt_samplingcount;
	CEdit m_edt_repeatcount;
	CEdit m_edt_return;
	afx_msg void OnBnClickedButtonInit();
	afx_msg void OnBnClickedButtonRepeat();
	afx_msg void OnBnClickedButtonStart();
	afx_msg void OnBnClickedButtonStop();
	afx_msg void OnBnClickedButtonExit();
	afx_msg void OnBnClickedButtonClose();
};

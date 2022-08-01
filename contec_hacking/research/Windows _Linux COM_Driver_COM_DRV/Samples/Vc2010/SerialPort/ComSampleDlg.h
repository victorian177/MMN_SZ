
// ComSampleDlg.h : ヘッダー ファイル
//

#pragma once


// CComSampleDlg ダイアログ
class CComSampleDlg : public CDialogEx
{
// コンストラクション
public:
	CComSampleDlg(CWnd* pParent = NULL);	// 標準コンストラクター

// ダイアログ データ
	enum { IDD = IDD_COMSAMPLE_DIALOG };

	CComboBox	m_ComPort;
	CEdit		m_Text;
	CButton		m_OpenButton;

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV サポート


// 実装
protected:
	HICON m_hIcon;

	// 生成された、メッセージ割り当て関数
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	void TcharToChar(const TCHAR* tchar, char* _char);
	void CharToTchar(const char* _char, TCHAR* tchar);
	afx_msg void OnBnClickedOpenbutton();
	afx_msg void OnBnClickedEndbutton();
	afx_msg BOOL PreTranslateMessage(MSG* pMsg);
};

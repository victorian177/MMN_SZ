
// AiRepeatDlg.h : header file
//

#pragma once
#include "afxwin.h"


// CAiRepeatDlg dialog
class CAiRepeatDlg : public CDialogEx
{
// Construction
public:
	CAiRepeatDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_AIREPEAT_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	virtual LRESULT DefWindowProc(UINT message, WPARAM wParam, LPARAM lParam);


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
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

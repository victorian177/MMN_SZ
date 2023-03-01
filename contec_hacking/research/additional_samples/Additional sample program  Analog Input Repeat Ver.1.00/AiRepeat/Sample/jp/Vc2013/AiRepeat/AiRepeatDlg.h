
// AiRepeatDlg.h : �w�b�_�[ �t�@�C��
//

#pragma once
#include "afxwin.h"


// CAiRepeatDlg �_�C�A���O
class CAiRepeatDlg : public CDialogEx
{
// �R���X�g���N�V����
public:
	CAiRepeatDlg(CWnd* pParent = NULL);	// �W���R���X�g���N�^�[

// �_�C�A���O �f�[�^
	enum { IDD = IDD_AIREPEAT_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV �T�|�[�g
	virtual LRESULT DefWindowProc(UINT message, WPARAM wParam, LPARAM lParam);


// ����
protected:
	HICON m_hIcon;

	// �������ꂽ�A���b�Z�[�W���蓖�Ċ֐�
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

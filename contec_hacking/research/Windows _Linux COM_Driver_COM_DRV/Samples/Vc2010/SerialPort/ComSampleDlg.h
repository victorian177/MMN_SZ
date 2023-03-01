
// ComSampleDlg.h : �w�b�_�[ �t�@�C��
//

#pragma once


// CComSampleDlg �_�C�A���O
class CComSampleDlg : public CDialogEx
{
// �R���X�g���N�V����
public:
	CComSampleDlg(CWnd* pParent = NULL);	// �W���R���X�g���N�^�[

// �_�C�A���O �f�[�^
	enum { IDD = IDD_COMSAMPLE_DIALOG };

	CComboBox	m_ComPort;
	CEdit		m_Text;
	CButton		m_OpenButton;

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV �T�|�[�g


// ����
protected:
	HICON m_hIcon;

	// �������ꂽ�A���b�Z�[�W���蓖�Ċ֐�
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

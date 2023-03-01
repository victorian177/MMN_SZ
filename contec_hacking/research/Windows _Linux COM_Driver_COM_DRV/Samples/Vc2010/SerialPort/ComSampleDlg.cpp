
// ComSampleDlg.cpp : �����t�@�C��
//

#include "stdafx.h"
#include "ComSample.h"
#include "ComSampleDlg.h"
#include "afxdialogex.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

// CComSampleDlg �_�C�A���O



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

//�O���[�o���ϐ�
HANDLE	hComm;				// COM�|�[�g�̃n���h��
CWinThread* ComRecvThread;	// COM��M�f�[�^�X���b�h�n���h��

//TCHAR�^�C�v��char�^�C�v�ɕϊ����܂�
void CComSampleDlg::TcharToChar(const TCHAR* tchar, char* _char) {
	int iLength;

	iLength = WideCharToMultiByte(CP_ACP, 0, tchar, -1, NULL, 0, NULL, NULL);
	WideCharToMultiByte(CP_ACP, 0, tchar, -1, _char, iLength, NULL, NULL);
}

//char�^�C�v��TCHAR�^�C�v�ɕϊ����܂�
void CComSampleDlg::CharToTchar(const char* _char, TCHAR* tchar) {
	int iLength;

	iLength = MultiByteToWideChar(CP_ACP, 0, _char, int(strlen(_char) + 1), NULL, 0);
	MultiByteToWideChar(CP_ACP, 0, _char, int(strlen(_char) + 1), tchar, iLength);
}

//COM��M�f�[�^�X���b�h(16Byte����M)
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
			//�o�b�t�@���L���[�ɗ��܂��Ă���H
			ClearCommError(hComm, &dwErrorFlags, &ComStat) ;
			//16Byte����M
			if ((ComStat.cbInQue % 16 == 0) && (ComStat.cbInQue >= 16)) {
				if (dwErrorFlags > 0){
					wsprintf(szText, _T("ClearCommError:Error(dwErrorFlags=%X Hex)\n"), dwErrorFlags);
					ComDlg->m_Text.SetWindowText(szText);
					return FALSE;
				}
				//�ǂ݂���
				dwLength = sizeof(szReadData);
				bRet = ReadFile(hComm, szReadData, dwLength, &dwLength, NULL);
				//�G���[�`�F�b�N
				if (bRet == FALSE) {
					dwError = GetLastError();
					wsprintf(szText, _T("ReadFile:Error(%d)"), dwError);
					ComDlg->m_Text.SetWindowText(szText);
					return FALSE;
				}
				//��M�f�[�^�̕\��
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

//CComSampleDlg ���b�Z�[�W �n���h���[

BOOL CComSampleDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	//���̃_�C�A���O�̃A�C�R����ݒ肵�܂��B�A�v���P�[�V�����̃��C�� �E�B���h�E���_�C�A���O�łȂ��ꍇ�A
	//Framework �́A���̐ݒ�������I�ɍs���܂��B
	SetIcon(m_hIcon, TRUE);			//�傫���A�C�R���̐ݒ�
	SetIcon(m_hIcon, FALSE);		//�������A�C�R���̐ݒ�

	TCHAR	szText[256];
	int		cnt;
	//�|�[�g�ԍ�������U��(1����255�܂�)
    for (cnt = 1; cnt < 256; cnt++)
    {
		wsprintf(szText, _T("COM%d"), cnt);
		m_ComPort.AddString(szText);
    }
	//�����ݒ莞��COM1��I�������Ă����B
	m_ComPort.SelectString(-1, _T("COM1"));

	m_Text.SetWindowTextW(_T("Please select Port Number. After, push <Port Open> button."));

	ComRecvThread = AfxBeginThread(ComRecvData, this);

	return TRUE;  //�t�H�[�J�X���R���g���[���ɐݒ肵���ꍇ�������ATRUE ��Ԃ��܂��B
}

//�_�C�A���O�ɍŏ����{�^����ǉ�����ꍇ�A�A�C�R����`�悷�邽�߂�
//���̃R�[�h���K�v�ł��B�h�L�������g/�r���[ ���f�����g�� MFC �A�v���P�[�V�����̏ꍇ�A
//����́AFramework �ɂ���Ď����I�ɐݒ肳��܂��B

void CComSampleDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); //�`��̃f�o�C�X �R���e�L�X�g

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		//�N���C�A���g�̎l�p�`�̈���̒���
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		//�A�C�R���̕`��
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

//���[�U�[���ŏ��������E�B���h�E���h���b�O���Ă���Ƃ��ɕ\������J�[�\�����擾���邽�߂ɁA
//�V�X�e�������̊֐����Ăяo���܂��B
HCURSOR CComSampleDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

//�|�[�g�I�[�v��/�N���[�Y���s���{�^��
void CComSampleDlg::OnBnClickedOpenbutton()
{
	TCHAR			szCommPort[100];
	TCHAR			szText[100];
	DWORD			dwError;
	BOOL			bRet;
	DCB				dcb;
	COMMTIMEOUTS	CommTimeOuts;
	//COM�|�[�g���̍쐬
	m_ComPort.GetWindowText(szText, sizeof(szText));
	wsprintf(szCommPort, _T("\\\\.\\%s"), szText);
	if (hComm == NULL) {
		//�I�[�v��
		hComm = CreateFile(
					szCommPort,
					GENERIC_READ | GENERIC_WRITE,
					0,
					NULL,
					OPEN_EXISTING,
					FILE_ATTRIBUTE_NORMAL,
					NULL);
		//�G���[�`�F�b�N
		if (hComm == INVALID_HANDLE_VALUE) {
			dwError = GetLastError();
			wsprintf(szText, _T("CreateFile:Error(%d)"), dwError);
			m_Text.SetWindowText(szText);
			return;
		}
		//���񂱂̃{�^���������Ƃ��́@�|�[�g�N���[�Y�̂���
        //�{�^���ɑ΂��@�|�[�g�N���[�Y�̕\�����s��
		m_OpenButton.SetWindowTextW(_T("Port Close"));
        //�|�[�g�I�[�v��������ɍs���������e�L�X�g�ɕ\������B
		m_Text.SetWindowText(_T("Port Open sucess."));
		//����M�o�b�t�@�N���A
		PurgeComm(hComm, PURGE_TXABORT | PURGE_RXABORT |
						 PURGE_TXCLEAR | PURGE_RXCLEAR ) ;
		//�^�C���A�E�g�l�Z�b�g
		CommTimeOuts.ReadIntervalTimeout = 0xFFFFFFFF;
		CommTimeOuts.ReadTotalTimeoutMultiplier = 0 ;
		CommTimeOuts.ReadTotalTimeoutConstant = 5000;
		CommTimeOuts.WriteTotalTimeoutMultiplier = 0 ;
		CommTimeOuts.WriteTotalTimeoutConstant = 5000;
		SetCommTimeouts(hComm, &CommTimeOuts ) ;
		//�ʐM�f�o�C�X�̏�Ԏ擾
		dcb.DCBlength = sizeof( DCB );
		GetCommState(hComm, &dcb );
		//�ʐM�f�o�C�X�Z�b�g
		//�{�[���[�g�ݒ�(Setting Baudrate.) 
		dcb.BaudRate = 9600;
		//�f�[�^�r�b�g�ݒ�(Setting Databits.) 
		dcb.ByteSize = 8;
		//�X�g�b�v�r�b�g�ݒ�(Setting Stopbits.)
		dcb.StopBits = ONESTOPBIT;
		//�p���e�B�ݒ�(Setting Paritybits.)
		dcb.Parity = NOPARITY;
		//RTS, DTR�R���g���[���ݒ�(Setting RTS/DTR Controls.)
		dcb.fRtsControl = RTS_CONTROL_ENABLE;
		dcb.fDtrControl = DTR_CONTROL_ENABLE;

		dcb.fOutxDsrFlow = FALSE;
		dcb.fBinary = TRUE;
		dcb.fParity = TRUE;

		bRet = SetCommState(hComm, &dcb);
		//�G���[�`�F�b�N
		if (bRet == FALSE ) {
			dwError = GetLastError();
			wsprintf(szText, _T("SetCommState:Error(%d)"), dwError);
			m_Text.SetWindowText(szText);
			return;
		}
	} else {
		//�N���[�Y
		bRet = CloseHandle(hComm);
		hComm = NULL;
		//�G���[�`�F�b�N
		if (bRet == FALSE) {
			dwError = GetLastError();
			wsprintf(szText, _T("CloseHandle:Error(%d)"), dwError);
			m_Text.SetWindowText(szText);
			return;
		}

		//���񂱂̃{�^���������Ƃ��́@�|�[�g�N���[�Y�̂���
        //�{�^���ɑ΂��@�|�[�g�N���[�Y�̕\�����s��
		m_OpenButton.SetWindowTextW(_T("Port Open"));
        //�|�[�g�I�[�v��������ɍs���������e�L�X�g�ɕ\������B
		m_Text.SetWindowText(_T("Port Close success."));
	}
}

//�|�[�g���N���[�Y���ăT���v�����I������
void CComSampleDlg::OnBnClickedEndbutton()
{
	BOOL	bRet;
	TCHAR	szText[100];
	DWORD	dwError;
	if (hComm != NULL) {
		//�N���[�Y
		bRet = CloseHandle(hComm);
		//�G���[�`�F�b�N
		if (bRet == FALSE) {
			dwError = GetLastError();
			wsprintf(szText, _T("CloseHandle:Error(%d)"), dwError);
			m_Text.SetWindowText(szText);
			return;
		}
	}
}

//�L�[���������Ƃ��ɋN�����郁���o
BOOL CComSampleDlg::PreTranslateMessage(MSG* pMsg)
{
	char	szWriteData[2];
	TCHAR	szTcharWriteData[2];
	DWORD	nWriteLength;
	DWORD	dwBytesWritten;

	if ((pMsg->message == WM_KEYDOWN) && (m_Text.m_hWnd == pMsg->hwnd)) {
		if (hComm != NULL)//���łɃ|�[�g���I�[�v������Ă���ꍇ�́A��������B
        {
			//���͂����L�[��0-9�AA-Z�ł������f
			if (((pMsg->wParam >= 'A') && (pMsg->wParam <= 'Z')) ||
				((pMsg->wParam >= '0') && (pMsg->wParam <= '9'))) {
				wsprintf(szTcharWriteData, _T("%c"), pMsg->wParam);
				nWriteLength = lstrlen(szTcharWriteData);
				TcharToChar(szTcharWriteData, szWriteData);
				WriteFile(hComm, (LPCVOID)szWriteData, nWriteLength, &dwBytesWritten, NULL);
			//���͂����L�[��0-9(���l�L�[�p�b�g)�ł������f
			} else if ((pMsg->wParam >= VK_NUMPAD0) && (pMsg->wParam <= VK_NUMPAD9)) {
				wsprintf(szTcharWriteData, _T("%c"), (pMsg->wParam - 48));
				nWriteLength = lstrlen(szTcharWriteData);
				TcharToChar(szTcharWriteData, szWriteData);
				WriteFile(hComm, (LPCVOID)szWriteData, nWriteLength, &dwBytesWritten, NULL);
			//���ɉ������Ȃ�
			} else {
				
			}
		}
	}

	return CDialogEx::PreTranslateMessage(pMsg);
}


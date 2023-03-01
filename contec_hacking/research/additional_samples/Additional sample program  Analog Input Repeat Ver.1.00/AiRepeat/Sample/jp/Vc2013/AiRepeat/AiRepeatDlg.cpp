
// AiRepeatDlg.cpp : �����t�@�C��
//

#include "stdafx.h"
#include "AiRepeat.h"
#include "AiRepeatDlg.h"
#include "afxdialogex.h"
#include "Caio.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CAiRepeatDlg �_�C�A���O



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
// �O���[�o���ϐ��̐錾
//----------------------------------------
short			g_id;
unsigned long	g_sampling_count;

// CAiRepeatDlg ���b�Z�[�W �n���h���[

BOOL CAiRepeatDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// ���̃_�C�A���O�̃A�C�R����ݒ肵�܂��B�A�v���P�[�V�����̃��C�� �E�B���h�E���_�C�A���O�łȂ��ꍇ�A
	//  Framework �́A���̐ݒ�������I�ɍs���܂��B
	SetIcon(m_hIcon, TRUE);			// �傫���A�C�R���̐ݒ�
	SetIcon(m_hIcon, FALSE);		// �������A�C�R���̐ݒ�

	//----------------------------------------
	// �f�o�C�X���̏����\�����X�V
	//----------------------------------------
	m_edt_devicename.SetWindowTextW(_T("AIO000"));

	return TRUE;  // �t�H�[�J�X���R���g���[���ɐݒ肵���ꍇ�������ATRUE ��Ԃ��܂��B
}

// �_�C�A���O�ɍŏ����{�^����ǉ�����ꍇ�A�A�C�R����`�悷�邽�߂�
//  ���̃R�[�h���K�v�ł��B�h�L�������g/�r���[ ���f�����g�� MFC �A�v���P�[�V�����̏ꍇ�A
//  ����́AFramework �ɂ���Ď����I�ɐݒ肳��܂��B

void CAiRepeatDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // �`��̃f�o�C�X �R���e�L�X�g

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// �N���C�A���g�̎l�p�`�̈���̒���
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// �A�C�R���̕`��
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

// ���[�U�[���ŏ��������E�B���h�E���h���b�O���Ă���Ƃ��ɕ\������J�[�\�����擾���邽�߂ɁA
//  �V�X�e�������̊֐����Ăяo���܂��B
HCURSOR CAiRepeatDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}


//================================================================================
// �f�o�C�X�������{�^�����N���b�N�����ۂ̏����ɂȂ�܂�
// �f�o�C�X�̏������������s���܂�
//================================================================================
void CAiRepeatDlg::OnBnClickedButtonInit()
{
	TCHAR	text_temp[256];		// �e�L�X�g�ꎞ�i�[�p
	long	ret1;				// �߂�l�擾�p1
	long	ret2;				// �߂�l�擾�p2
	char	error_string[256];	// �G���[�R�[�h������
	CString	text_string;		// �e�L�X�g�{�b�N�X�X�V�p
	char	devicename[256];	// �f�o�C�X��

	//----------------------------------------
	// �f�o�C�X��������
	//----------------------------------------
	//--------------------
	// �f�o�C�X�����e�L�X�g�{�b�N�X����擾
	//--------------------
	m_edt_devicename.GetWindowTextW(text_temp, 256);
	sprintf_s(devicename, "%S", text_temp);
	//--------------------
	// �f�o�C�X������
	// �ύX���ӊ֐�(�ύX����ƃA�v�������삵�Ȃ��Ȃ�\��������܂�)
	//--------------------
	ret1 = AioInit(devicename, &g_id);
	//----------------------------------------
	// �G���[����
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// �G���[������擾�Ɏ��s�����ꍇ
		// �G���[�������������
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("�����������FAioInit = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// �f�o�C�X�����Z�b�g
	//----------------------------------------
	ret1 = AioResetDevice(g_id);
	//----------------------------------------
	// �G���[����
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// �G���[������擾�Ɏ��s�����ꍇ
		// �G���[�������������
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("�����������FAioResetDevice = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// ���͕������V���O���G���h�ɐݒ�
	//----------------------------------------
	ret1 = AioSetAiInputMethod(g_id, 0);
	//----------------------------------------
	// �G���[����
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// �G���[������擾�Ɏ��s�����ꍇ
		// �G���[�������������
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("�����������FAioSetAiInputMethod = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// �`���l������1�ɐݒ�
	//----------------------------------------
	ret1 = AioSetAiChannels(g_id, 1);
	//----------------------------------------
	// �G���[����
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// �G���[������擾�Ɏ��s�����ꍇ
		// �G���[�������������
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("�����������FAioSetAiChannels = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// �����W���}10V�ɐݒ�
	//----------------------------------------
	ret1 = AioSetAiRange(g_id, 0, PM10);
	//----------------------------------------
	// �G���[����
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// �G���[������擾�Ɏ��s�����ꍇ
		// �G���[�������������
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("�����������FAioSetAiRange = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// �������^�C�v��FIFO�ɐݒ�
	//----------------------------------------
	ret1 = AioSetAiMemoryType(g_id, 0);
	//----------------------------------------
	// �G���[����
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// �G���[������擾�Ɏ��s�����ꍇ
		// �G���[�������������
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("�����������FAioSetAiMemoryType = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// �N���b�N�^�C�v������N���b�N�ɐݒ�
	//----------------------------------------
	ret1 = AioSetAiClockType(g_id, 0);
	//----------------------------------------
	// �G���[����
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// �G���[������擾�Ɏ��s�����ꍇ
		// �G���[�������������
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("�����������FAioSetAiClockType = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// �T���v�����O�N���b�N��1msec�ɐݒ�
	//----------------------------------------
	ret1 = AioSetAiSamplingClock(g_id, 1000);
	//----------------------------------------
	// �G���[����
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// �G���[������擾�Ɏ��s�����ꍇ
		// �G���[�������������
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("�����������FAioSetAiSamplingClock = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// �J�n�������O���g���K�����オ��ɐݒ�
	//----------------------------------------
	ret1 = AioSetAiStartTrigger(g_id, 1);
	//----------------------------------------
	// �G���[����
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// �G���[������擾�Ɏ��s�����ꍇ
		// �G���[�������������
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("�����������FAioSetAiStartTrigger = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// ��~�������w��񐔂ɐݒ�
	//----------------------------------------
	ret1 = AioSetAiStopTrigger(g_id, 0);
	//----------------------------------------
	// �G���[����
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// �G���[������擾�Ɏ��s�����ꍇ
		// �G���[�������������
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("�����������FAioSetAiStopTrigger = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// �T���v�����O��~�񐔂�1000��ɐݒ�
	//----------------------------------------
	ret1 = AioSetAiStopTimes(g_id, 1000);
	//----------------------------------------
	// �G���[����
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// �G���[������擾�Ɏ��s�����ꍇ
		// �G���[�������������
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("�����������FAioSetAiStopTimes = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// �C�x���g�ɃT���v�����O�J�n�A���s�[�g�I���A����I����ݒ�
	// �ύX���ӊ֐�(�ύX����ƃA�v�������삵�Ȃ��Ȃ�\��������܂�)
	//----------------------------------------
	ret1 = AioSetAiEvent(g_id, m_hWnd, (AIE_START | AIE_RPTEND | AIE_END));
	//----------------------------------------
	// �G���[����
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// �G���[������擾�Ɏ��s�����ꍇ
		// �G���[�������������
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("�����������FAioSetAiEvnet = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// ���������������̃��b�Z�\�W�\��
	//----------------------------------------
	text_string.Format(_T("�����������F����I��"));
	m_edt_return.SetWindowText(text_string);
}


//================================================================================
// ���s�[�g�񐔐ݒ�{�^�����N���b�N�����ۂ̏����ɂȂ�܂�
// ���s�[�g�񐔂̐ݒ���s���܂�
//================================================================================
void CAiRepeatDlg::OnBnClickedButtonRepeat()
{
	TCHAR	text_temp[256];		// �e�L�X�g�ꎞ�i�[�p
	long	ret1;				// �߂�l�擾�p1
	long	ret2;				// �߂�l�擾�p2
	char	error_string[256];	// �G���[�R�[�h������
	CString	text_string;		// �e�L�X�g�{�b�N�X�X�V�p

	//----------------------------------------
	// GUI�̏����X�V
	//----------------------------------------
	UpdateData(TRUE);
	//----------------------------------------
	// ���s�[�g�񐔂�ݒ�
	//----------------------------------------
	ret1 = AioSetAiRepeatTimes(g_id, m_repeat_times);
	//----------------------------------------
	// �G���[����
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// �G���[������擾�Ɏ��s�����ꍇ
		// �G���[�������������
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("���s�[�g�񐔐ݒ�FAioSetAiRepeatTimes = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// ���s�[�g�񐔐ݒ芮���̃��b�Z�\�W�\��
	//----------------------------------------
	text_string.Format(_T("���s�[�g�񐔐ݒ�F����I��"));
	m_edt_return.SetWindowText(text_string);
}


//================================================================================
// �T���v�����O�J�n�{�^�����N���b�N�����ۂ̏����ɂȂ�܂�
// �������ƃX�e�[�^�X�̃N���A���s������A�T���v�����O�J�n���s���܂�
//================================================================================
void CAiRepeatDlg::OnBnClickedButtonStart()
{
	TCHAR	text_temp[256];		// �e�L�X�g�ꎞ�i�[�p
	long	ret1;				// �߂�l�擾�p1
	long	ret2;				// �߂�l�擾�p2
	char	error_string[256];	// �G���[�R�[�h������
	CString	text_string;		// �e�L�X�g�{�b�N�X�X�V�p
	CString	text_string_temp;	// �e�L�X�g�{�b�N�X�ꎞ�i�[�p
	long	aistatus;			// �A�i���O���̓X�e�[�^�X
	long	airepeatcount;		// �A�i���O���̓��s�[�g��

	//----------------------------------------
	// �������N���A
	//----------------------------------------
	ret1 = AioResetAiMemory(g_id);
	//----------------------------------------
	// �G���[����
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// �G���[������擾�Ɏ��s�����ꍇ
		// �G���[�������������
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("�T���v�����O�J�n�FAioResetAiMemory = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// �X�e�[�^�X�N���A
	//----------------------------------------
	ret1 = AioResetAiStatus(g_id);
	//----------------------------------------
	// �G���[����
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// �G���[������擾�Ɏ��s�����ꍇ
		// �G���[�������������
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("�T���v�����O�J�n�FAioResetAiStatus = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	g_sampling_count	= 0;
	//----------------------------------------
	// �T���v�����O�J�n
	//----------------------------------------
	ret1 = AioStartAi(g_id);
	//----------------------------------------
	// �G���[����
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// �G���[������擾�Ɏ��s�����ꍇ
		// �G���[�������������
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("�T���v�����O�J�n�FAioStartAi = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// �X�e�[�^�X���擾
	//----------------------------------------
	ret1 = AioGetAiStatus(g_id, &aistatus);
	//----------------------------------------
	// �G���[����
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// �G���[������擾�Ɏ��s�����ꍇ
		// �G���[�������������
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("�T���v�����O�J�n�FAioGetAiStatus = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// �X�e�[�^�X�̕\��
	//----------------------------------------
	text_string.Format(_T("%08xH ("), aistatus);
	//--------------------
	// ���쒆�X�e�[�^�X�L����
	//--------------------
	if ((aistatus & AIS_BUSY) == AIS_BUSY){
		text_string_temp.Format(_T("���쒆"));
		text_string += text_string_temp;
	//--------------------
	// ���쒆�X�e�[�^�X������
	//--------------------
	}else{
		text_string_temp.Format(_T("��~��"));
		text_string += text_string_temp;
	}
	//--------------------
	// �J�n�g���K�҂��X�e�[�^�X�L����
	//--------------------
	if ((aistatus & AIS_START_TRG) == AIS_START_TRG){
		text_string_temp.Format(_T(", �J�n�g���K�҂�"));
		text_string += text_string_temp;
	}
	//--------------------
	// �w��T���v�����O�񐔊i�[�X�e�[�^�X�L����
	//--------------------
	if ((aistatus & AIS_DATA_NUM) == AIS_DATA_NUM){
		text_string_temp.Format(_T(", �w��񐔊i�["));
		text_string += text_string_temp;
	}
	//--------------------
	// �I�[�o�[�t���[�X�e�[�^�X�L����
	//--------------------
	if ((aistatus & AIS_OFERR) == AIS_OFERR){
		text_string_temp.Format(_T(", �I�[�o�[�t���["));
		text_string += text_string_temp;
	}
	//--------------------
	// �T���v�����O�N���b�N�G���[�X�e�[�^�X�L����
	//--------------------
	if ((aistatus & AIS_SCERR) == AIS_SCERR){
		text_string_temp.Format(_T(", �T���v�����O�N���b�N�G���["));
		text_string += text_string_temp;
	}
	//--------------------
	// AD�ϊ��G���[�X�e�[�^�X�L����
	//--------------------
	if ((aistatus & AIS_AIERR) == AIS_AIERR){
		text_string_temp.Format(_T(", AD�ϊ��G���["));
		text_string += text_string_temp;
	}
	//--------------------
	// �h���C�o�X�y�b�N�G���[�X�e�[�^�X�L����
	//--------------------
	if ((aistatus & AIS_DRVERR) == AIS_DRVERR){
		text_string_temp.Format(_T(", �h���C�o�X�y�b�N�G���["));
		text_string += text_string_temp;
	}
	text_string_temp.Format(_T(")"));
	text_string += text_string_temp;
	m_edt_status.SetWindowText(text_string);
	//----------------------------------------
	// ���T���v�����O�񐔂��X�V
	//----------------------------------------
	text_string.Format(_T("%d"), g_sampling_count);
	m_edt_samplingcount.SetWindowText(text_string);
	//----------------------------------------
	// ���݂̃��s�[�g�񐔂��擾
	//----------------------------------------
	ret1 = AioGetAiRepeatCount(g_id, &airepeatcount);
	//----------------------------------------
	// �G���[����
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// �G���[������擾�Ɏ��s�����ꍇ
		// �G���[�������������
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("�T���v�����O�J�n�FAioGetAiRepeatCount = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// ���s�[�g�񐔂��X�V
	//----------------------------------------
	text_string.Format(_T("%d"), airepeatcount);
	m_edt_repeatcount.SetWindowText(text_string);
	//----------------------------------------
	// �T���v�����O�J�n�����̃��b�Z�\�W�\��
	//----------------------------------------
	text_string.Format(_T("�T���v�����O�J�n�F����I��"));
	m_edt_return.SetWindowText(text_string);
}


//================================================================================
// �T���v�����O��~�{�^�����N���b�N�����ۂ̏����ɂȂ�܂�
// �T���v�����O��~���s���܂�
//================================================================================
void CAiRepeatDlg::OnBnClickedButtonStop()
{
	TCHAR	text_temp[256];		// �e�L�X�g�ꎞ�i�[�p
	long	ret1;				// �߂�l�擾�p1
	long	ret2;				// �߂�l�擾�p2
	char	error_string[256];	// �G���[�R�[�h������
	CString	text_string;		// �e�L�X�g�{�b�N�X�X�V�p

	//----------------------------------------
	// �T���v�����O��~
	//----------------------------------------
	ret1 = AioStopAi(g_id);
	//----------------------------------------
	// �G���[����
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// �G���[������擾�Ɏ��s�����ꍇ
		// �G���[�������������
		//--------------------
		if (ret2 != 0) {
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("�T���v�����O��~�FAioStopAi = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// �T���v�����O��~�����̃��b�Z�\�W�\��
	//----------------------------------------
	text_string.Format(_T("�T���v�����O��~�F����I��"));
	m_edt_return.SetWindowText(text_string);
}


//================================================================================
// �f�o�C�X�I�������{�^�����N���b�N�����ۂ̏����ɂȂ�܂�
// �f�o�C�X�̏I���������s���܂�
//================================================================================
void CAiRepeatDlg::OnBnClickedButtonExit()
{
	TCHAR	text_temp[256];		// �e�L�X�g�ꎞ�i�[�p
	long	ret1;				// �߂�l�擾�p1
	long	ret2;				// �߂�l�擾�p2
	char	error_string[256];	// �G���[�R�[�h������
	CString	text_string;		// �e�L�X�g�{�b�N�X�X�V�p

	//----------------------------------------
	// �f�o�C�X�̏I������
	//----------------------------------------
	ret1 = AioExit(g_id);
	//----------------------------------------
	// �G���[����
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// �G���[������擾�Ɏ��s�����ꍇ
		// �G���[�������������
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("�f�o�C�X�I�������FAioExit = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// �f�o�C�X�I�����������̃��b�Z�\�W�\��
	//----------------------------------------
	text_string.Format(_T("�f�o�C�X�I�������F����I��"));
	m_edt_return.SetWindowText(text_string);
}


//================================================================================
// ����{�^�����������ۂ̏����ɂȂ�܂�
// �A�v���̏I���������s���܂�
//================================================================================
void CAiRepeatDlg::OnBnClickedButtonClose()
{
	//----------------------------------------
	// �_�C�A���O���I������
	//----------------------------------------
	CDialog::OnOK();
}


//================================================================================
// �C�x���g�������������̓���
// �e�C�x���g�����������Ƃ��A�C�x���g���ɏ������s��
//================================================================================
LRESULT CAiRepeatDlg::DefWindowProc(UINT message, WPARAM wParam, LPARAM lParam)
{
	TCHAR	text_temp[256];			// �e�L�X�g�ꎞ�i�[�p
	long	ret1;					// �߂�l�擾�p1
	long	ret2;					// �߂�l�擾�p2
	char	error_string[256];		// �G���[�R�[�h������
	CString	text_string;			// �e�L�X�g�{�b�N�X�X�V�p
	long	aisamplingcount;		// �T���v�����O�J�E���g
	float	*aidata;				// �A�i���O�f�[�^
	CString	text_string_temp;		// �e�L�X�g�{�b�N�X�ꎞ�i�[�p
	short	aichannels;				// �`���l����
	long	aistatus;				// �X�e�[�^�X
	long	airepeatcount;			// ���s�[�g��
	int		i, j;

	//----------------------------------------
	// AD�ϊ��J�n���������C�x���g
	// �f�[�^�̎擾�A�\�����s��
	//----------------------------------------
	if (message == AIOM_AIE_START){
		//----------------------------------------
		// �X�e�[�^�X���擾
		//----------------------------------------
		ret1 = AioGetAiStatus(g_id, &aistatus);
		//----------------------------------------
		// �G���[����
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// �G���[������擾�Ɏ��s�����ꍇ
			// �G���[�������������
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("AD�ϊ��J�n�������������FAioGetAiStatus = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			return TRUE;
		}
		//----------------------------------------
		// �X�e�[�^�X�̕\��
		//----------------------------------------
		text_string.Format(_T("%08xH ("), aistatus);
		//--------------------
		// ���쒆�X�e�[�^�X�L����
		//--------------------
		if ((aistatus & AIS_BUSY) == AIS_BUSY){
			text_string_temp.Format(_T("���쒆"));
		//--------------------
		// ���쒆�X�e�[�^�X������
		//--------------------
		}else{
			text_string_temp.Format(_T("��~��"));
		}
		text_string += text_string_temp;
		//--------------------
		// �J�n�g���K�҂��X�e�[�^�X�L����
		//--------------------
		if ((aistatus & AIS_START_TRG) == AIS_START_TRG){
			text_string_temp.Format(_T(", �J�n�g���K�҂�"));
			text_string += text_string_temp;
		}
		//--------------------
		// �w��T���v�����O�񐔊i�[�X�e�[�^�X�L����
		//--------------------
		if ((aistatus & AIS_DATA_NUM) == AIS_DATA_NUM){
			text_string_temp.Format(_T(", �w��񐔊i�["));
			text_string += text_string_temp;
		}
		//--------------------
		// �I�[�o�[�t���[�X�e�[�^�X�L����
		//--------------------
		if ((aistatus & AIS_OFERR) == AIS_OFERR){
			text_string_temp.Format(_T(", �I�[�o�[�t���["));
			text_string += text_string_temp;
		}
		//--------------------
		// �T���v�����O�N���b�N�G���[�X�e�[�^�X�L����
		//--------------------
		if ((aistatus & AIS_SCERR) == AIS_SCERR){
			text_string_temp.Format(_T(", �T���v�����O�N���b�N�G���["));
			text_string += text_string_temp;
		}
		//--------------------
		// AD�ϊ��G���[�X�e�[�^�X�L����
		//--------------------
		if ((aistatus & AIS_AIERR) == AIS_AIERR){
			text_string_temp.Format(_T(", AD�ϊ��G���["));
			text_string += text_string_temp;
		}
		//--------------------
		// �h���C�o�X�y�b�N�G���[�X�e�[�^�X�L����
		//--------------------
		if ((aistatus & AIS_DRVERR) == AIS_DRVERR){
			text_string_temp.Format(_T(", �h���C�o�X�y�b�N�G���["));
			text_string += text_string_temp;
		}
		text_string_temp.Format(_T(")"));
		text_string += text_string_temp;
		m_edt_status.SetWindowText(text_string);
		//----------------------------------------
		// �C�x���g���������̃��b�Z�\�W�\��
		//----------------------------------------
		text_string.Format(_T("AD�ϊ��J�n�������������F����I��"));
		m_edt_return.SetWindowText(text_string);
	}
	//----------------------------------------
	// ���s�[�g�I���C�x���g
	// �f�[�^�̎擾�A�\�����s��
	//----------------------------------------
	if (message == AIOM_AIE_RPTEND){
		//----------------------------------------
		// �X�e�[�^�X���擾
		//----------------------------------------
		ret1 = AioGetAiStatus(g_id, &aistatus);
		//----------------------------------------
		// �G���[����
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// �G���[������擾�Ɏ��s�����ꍇ
			// �G���[�������������
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("���s�[�g�I���C�x���g�����FAioGetAiStatus = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			return TRUE;
		}
		//----------------------------------------
		// �X�e�[�^�X�̕\��
		//----------------------------------------
		text_string.Format(_T("%08xH ("), aistatus);
		//--------------------
		// ���쒆�X�e�[�^�X�L����
		//--------------------
		if ((aistatus & AIS_BUSY) == AIS_BUSY){
			text_string_temp.Format(_T("���쒆"));
		//--------------------
		// ���쒆�X�e�[�^�X������
		//--------------------
		}else{
			text_string_temp.Format(_T("��~��"));
		}
		text_string += text_string_temp;
		//--------------------
		// �J�n�g���K�҂��X�e�[�^�X�L����
		//--------------------
		if ((aistatus & AIS_START_TRG) == AIS_START_TRG){
			text_string_temp.Format(_T(", �J�n�g���K�҂�"));
			text_string += text_string_temp;
		}
		//--------------------
		// �w��T���v�����O�񐔊i�[�X�e�[�^�X�L����
		//--------------------
		if ((aistatus & AIS_DATA_NUM) == AIS_DATA_NUM){
			text_string_temp.Format(_T(", �w��񐔊i�["));
			text_string += text_string_temp;
		}
		//--------------------
		// �I�[�o�[�t���[�X�e�[�^�X�L����
		//--------------------
		if ((aistatus & AIS_OFERR) == AIS_OFERR){
			text_string_temp.Format(_T(", �I�[�o�[�t���["));
			text_string += text_string_temp;
		}
		//--------------------
		// �T���v�����O�N���b�N�G���[�X�e�[�^�X�L����
		//--------------------
		if ((aistatus & AIS_SCERR) == AIS_SCERR){
			text_string_temp.Format(_T(", �T���v�����O�N���b�N�G���["));
			text_string += text_string_temp;
		}
		//--------------------
		// AD�ϊ��G���[�X�e�[�^�X�L����
		//--------------------
		if ((aistatus & AIS_AIERR) == AIS_AIERR){
			text_string_temp.Format(_T(", AD�ϊ��G���["));
			text_string += text_string_temp;
		}
		//--------------------
		// �h���C�o�X�y�b�N�G���[�X�e�[�^�X�L����
		//--------------------
		if ((aistatus & AIS_DRVERR) == AIS_DRVERR){
			text_string_temp.Format(_T(", �h���C�o�X�y�b�N�G���["));
			text_string += text_string_temp;
		}
		text_string_temp.Format(_T(")"));
		text_string += text_string_temp;
		m_edt_status.SetWindowText(text_string);
		//----------------------------------------
		// ���݂̃T���v�����O�񐔂��擾
		//----------------------------------------
		ret1 = AioGetAiSamplingCount(g_id, &aisamplingcount);
		//----------------------------------------
		// �G���[����
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// �G���[������擾�Ɏ��s�����ꍇ
			// �G���[�������������
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("���s�[�g�I���C�x���g�����FAioGetAiSamplingCount = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			return TRUE;
		}
		//----------------------------------------
		// �`���l�����擾
		//----------------------------------------
		ret1 = AioGetAiChannels(g_id, &aichannels);
		//----------------------------------------
		// �G���[����
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// �G���[������擾�Ɏ��s�����ꍇ
			// �G���[�������������
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("���s�[�g�I���C�x���g�����FAioGetAiChannels = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			return TRUE;
		}
		//----------------------------------------
		// �T���v�����O�f�[�^���擾
		//----------------------------------------
		//--------------------
		// �f�[�^�i�[�p�̔z����m��
		//--------------------
		aidata = (float *)malloc(sizeof(float)* aisamplingcount * aichannels);
		if (aidata == NULL){
			text_string.Format(_T("���s�[�g�I���C�x���g�����F�f�[�^�i�[�p�̔z��m�ۂɎ��s"));
			m_edt_return.SetWindowText(text_string);
			return TRUE;
		}
		ret1 = AioGetAiSamplingDataEx(g_id, &aisamplingcount, aidata);
		//----------------------------------------
		// �G���[����
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// �G���[������擾�Ɏ��s�����ꍇ
			// �G���[�������������
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("���s�[�g�I���C�x���g�����FAioGetAiSamplingDataEx = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			free(aidata);
			return TRUE;
		}
		g_sampling_count += aisamplingcount;
		//----------------------------------------
		// ���T���v�����O�񐔂��X�V
		//----------------------------------------
		text_string.Format(_T("%d"), g_sampling_count);
		m_edt_samplingcount.SetWindowText(text_string);
		//----------------------------------------
		// ���݂̃��s�[�g�񐔂��擾
		//----------------------------------------
		ret1 = AioGetAiRepeatCount(g_id, &airepeatcount);
		//----------------------------------------
		// �G���[����
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// �G���[������擾�Ɏ��s�����ꍇ
			// �G���[�������������
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("���s�[�g�I���C�x���g�����FAioGetAiRepeatCount = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			free(aidata);
			return TRUE;
		}
		//----------------------------------------
		// ���s�[�g�񐔂��X�V
		//----------------------------------------
		text_string.Format(_T("%d"), airepeatcount);
		m_edt_repeatcount.SetWindowText(text_string);
		//----------------------------------------
		// �T���v�����O�f�[�^��\�����邽�߂̕�������i�[
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
		// �T���v�����O�f�[�^��\��
		//----------------------------------------
		m_edt_samplingdata.SetWindowTextW(text_string);
		//----------------------------------------
		// �C�x���g���������̃��b�Z�\�W�\��
		//----------------------------------------
		text_string.Format(_T("���s�[�g�I���C�x���g�����F����I��"));
		m_edt_return.SetWindowText(text_string);
		free(aidata);
	}
	//----------------------------------------
	// �f�o�C�X����I���C�x���g
	// �f�[�^�̎擾�A�\�����s��
	//----------------------------------------
	if (message == AIOM_AIE_END){
		//----------------------------------------
		// �X�e�[�^�X���擾
		//----------------------------------------
		ret1 = AioGetAiStatus(g_id, &aistatus);
		//----------------------------------------
		// �G���[����
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// �G���[������擾�Ɏ��s�����ꍇ
			// �G���[�������������
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("�f�o�C�X����I���C�x���g�����FAioGetAiStatus = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			return TRUE;
		}
		//----------------------------------------
		// �X�e�[�^�X�̕\��
		//----------------------------------------
		text_string.Format(_T("%08xH ("), aistatus);
		//--------------------
		// ���쒆�X�e�[�^�X�L����
		//--------------------
		if ((aistatus & AIS_BUSY) == AIS_BUSY){
			text_string_temp.Format(_T("���쒆"));
		//--------------------
		// ���쒆�X�e�[�^�X������
		//--------------------
		}else{
			text_string_temp.Format(_T("��~��"));
		}
		text_string += text_string_temp;
		//--------------------
		// �J�n�g���K�҂��X�e�[�^�X�L����
		//--------------------
		if ((aistatus & AIS_START_TRG) == AIS_START_TRG){
			text_string_temp.Format(_T(", �J�n�g���K�҂�"));
			text_string += text_string_temp;
		}
		//--------------------
		// �w��T���v�����O�񐔊i�[�X�e�[�^�X�L����
		//--------------------
		if ((aistatus & AIS_DATA_NUM) == AIS_DATA_NUM){
			text_string_temp.Format(_T(", �w��񐔊i�["));
			text_string += text_string_temp;
		}
		//--------------------
		// �I�[�o�[�t���[�X�e�[�^�X�L����
		//--------------------
		if ((aistatus & AIS_OFERR) == AIS_OFERR){
			text_string_temp.Format(_T(", �I�[�o�[�t���["));
			text_string += text_string_temp;
		}
		//--------------------
		// �T���v�����O�N���b�N�G���[�X�e�[�^�X�L����
		//--------------------
		if ((aistatus & AIS_SCERR) == AIS_SCERR){
			text_string_temp.Format(_T(", �T���v�����O�N���b�N�G���["));
			text_string += text_string_temp;
		}
		//--------------------
		// AD�ϊ��G���[�X�e�[�^�X�L����
		//--------------------
		if ((aistatus & AIS_AIERR) == AIS_AIERR){
			text_string_temp.Format(_T(", AD�ϊ��G���["));
			text_string += text_string_temp;
		}
		//--------------------
		// �h���C�o�X�y�b�N�G���[�X�e�[�^�X�L����
		//--------------------
		if ((aistatus & AIS_DRVERR) == AIS_DRVERR){
			text_string_temp.Format(_T(", �h���C�o�X�y�b�N�G���["));
			text_string += text_string_temp;
		}
		text_string_temp.Format(_T(")"));
		text_string += text_string_temp;
		m_edt_status.SetWindowText(text_string);
		//----------------------------------------
		// ���݂̃T���v�����O�񐔂��擾
		//----------------------------------------
		ret1 = AioGetAiSamplingCount(g_id, &aisamplingcount);
		//----------------------------------------
		// �G���[����
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// �G���[������擾�Ɏ��s�����ꍇ
			// �G���[�������������
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("�f�o�C�X����I���C�x���g�����FAioGetAiSamplingCount = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			return TRUE;
		}
		//----------------------------------------
		// �`���l�����擾
		//----------------------------------------
		ret1 = AioGetAiChannels(g_id, &aichannels);
		//----------------------------------------
		// �G���[����
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// �G���[������擾�Ɏ��s�����ꍇ
			// �G���[�������������
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("�f�o�C�X����I���C�x���g�����FAioGetAiChannels = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			return TRUE;
		}
		//----------------------------------------
		// �T���v�����O�f�[�^���擾
		//----------------------------------------
		//--------------------
		// �f�[�^�i�[�p�̔z����m��
		//--------------------
		aidata = (float *)malloc(sizeof(float)* aisamplingcount * aichannels);
		if (aidata == NULL){
			text_string.Format(_T("�f�o�C�X����I���C�x���g�����F�f�[�^�i�[�p�̔z��m�ۂɎ��s"));
			m_edt_return.SetWindowText(text_string);
			return TRUE;
		}
		ret1 = AioGetAiSamplingDataEx(g_id, &aisamplingcount, aidata);
		//----------------------------------------
		// �G���[����
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// �G���[������擾�Ɏ��s�����ꍇ
			// �G���[�������������
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("�f�o�C�X����I���C�x���g�����FAioGetAiSamplingDataEx = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			free(aidata);
			return TRUE;
		}
		g_sampling_count += aisamplingcount;
		//----------------------------------------
		// ���T���v�����O�񐔂��X�V
		//----------------------------------------
		text_string.Format(_T("%d"), g_sampling_count);
		m_edt_samplingcount.SetWindowText(text_string);
		//----------------------------------------
		// ���݂̃��s�[�g�񐔂��擾
		//----------------------------------------
		ret1 = AioGetAiRepeatCount(g_id, &airepeatcount);
		//----------------------------------------
		// �G���[����
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// �G���[������擾�Ɏ��s�����ꍇ
			// �G���[�������������
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("�f�o�C�X����I���C�x���g�����FAioGetAiRepeatCount = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			free(aidata);
			return TRUE;
		}
		//----------------------------------------
		// ���s�[�g�񐔂��X�V
		//----------------------------------------
		text_string.Format(_T("%d"), airepeatcount);
		m_edt_repeatcount.SetWindowText(text_string);
		//----------------------------------------
		// �T���v�����O�f�[�^��\�����邽�߂̕�������i�[
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
		// �T���v�����O�f�[�^��\��
		//----------------------------------------
		m_edt_samplingdata.SetWindowTextW(text_string);
		//----------------------------------------
		// �C�x���g���������̃��b�Z�\�W�\��
		//----------------------------------------
		text_string.Format(_T("�f�o�C�X����I���C�x���g�����F����I��"));
		m_edt_return.SetWindowText(text_string);
		free(aidata);
	}

	return CDialog::DefWindowProc(message, wParam, lParam);
}

// AiRepeatDlg.cpp : implementation file
//

#include "stdafx.h"
#include "AiRepeat.h"
#include "AiRepeatDlg.h"
#include "afxdialogex.h"
#include "Caio.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CAiRepeatDlg dialog



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
// Declaration of global variables
//----------------------------------------
short			g_id;
unsigned long	g_sampling_count;

// CAiRepeatDlg message handlers

BOOL CAiRepeatDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	//----------------------------------------
	// Update the initial display of Device Name
	//----------------------------------------
	m_edt_devicename.SetWindowTextW(_T("AIO000"));

	return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CAiRepeatDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CAiRepeatDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}


//================================================================================
// It is the process when the Device Init button is clicked
// Initialize the device
//================================================================================
void CAiRepeatDlg::OnBnClickedButtonInit()
{
	TCHAR	text_temp[256];		// For temporary storage of text
	long	ret1;				// For return value 1
	long	ret2;				// For return value 2
	char	error_string[256];	// Error code string
	CString	text_string;		// For updating the textbox
	char	devicename[256];	// Device name

	//----------------------------------------
	// Initialize the device
	//----------------------------------------
	//--------------------
	// Get device name from the textbox
	//--------------------
	m_edt_devicename.GetWindowTextW(text_temp, 256);
	sprintf_s(devicename, "%S", text_temp);
	//--------------------
	// Device initialization
	// Caution for modify this function (if modified, the application may not work)
	//--------------------
	ret1 = AioInit(devicename, &g_id);
	//----------------------------------------
	// Error process
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// When failed to get the error string,
		// initialize the error string
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("Initialization Process : AioInit = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// Reset device
	//----------------------------------------
	ret1 = AioResetDevice(g_id);
	//----------------------------------------
	// Error process
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// When failed to get the error string,
		// initialize the error string
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("Initialization Process : AioResetDevice = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// Set the input method to Single-end
	//----------------------------------------
	ret1 = AioSetAiInputMethod(g_id, 0);
	//----------------------------------------
	// Error process
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// When failed to get the error string,
		// initialize the error string
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("Initialization Process : AioSetAiInputMethod = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// Set the number of channels to 1 channel
	//----------------------------------------
	ret1 = AioSetAiChannels(g_id, 1);
	//----------------------------------------
	// Error process
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// When failed to get the error string,
		// initialize the error string
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("Initialization Process : AioSetAiChannels = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// Set the input range to +/- 10V
	//----------------------------------------
	ret1 = AioSetAiRange(g_id, 0, PM10);
	//----------------------------------------
	// Error process
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// When failed to get the error string,
		// initialize the error string
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("Initialization Process : AioSetAiRange = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// Set the memory type to FIFO
	//----------------------------------------
	ret1 = AioSetAiMemoryType(g_id, 0);
	//----------------------------------------
	// Error process
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// When failed to get the error string,
		// initialize the error string
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("Initialization Process : AioSetAiMemoryType = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// Set the clock type to Internal Clock
	//----------------------------------------
	ret1 = AioSetAiClockType(g_id, 0);
	//----------------------------------------
	// Error process
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// When failed to get the error string,
		// initialize the error string
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("Initialization Process : AioSetAiClockType = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// Set the sampling clock to 1 msec
	//----------------------------------------
	ret1 = AioSetAiSamplingClock(g_id, 1000);
	//----------------------------------------
	// Error process
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// When failed to get the error string,
		// initialize the error string
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("Initialization Process : AioSetAiSamplingClock = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// Set the start condition to External Trigger Rising Edge
	//----------------------------------------
	ret1 = AioSetAiStartTrigger(g_id, 1);
	//----------------------------------------
	// Error process
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// When failed to get the error string,
		// initialize the error string
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("Initialization Process : AioSetAiStartTrigger = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// Set the stop condition to Stop Conversion by The Specified Times
	//----------------------------------------
	ret1 = AioSetAiStopTrigger(g_id, 0);
	//----------------------------------------
	// Error process
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// When failed to get the error string,
		// initialize the error string
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("Initialization Process : AioSetAiStopTrigger = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// Set the sampling stop times to 1000
	//----------------------------------------
	ret1 = AioSetAiStopTimes(g_id, 1000);
	//----------------------------------------
	// Error process
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// When failed to get the error string,
		// initialize the error string
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("Initialization Process : AioSetAiStopTimes = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// Set the event factor to 'Event that AD conversion start ', 'Event that repeat end' and 'Event that device operation end'
	// Caution for modify this function (if modified, the application may not work)
	//----------------------------------------
	ret1 = AioSetAiEvent(g_id, m_hWnd, (AIE_START | AIE_RPTEND | AIE_END));
	//----------------------------------------
	// Error process
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// When failed to get the error string,
		// initialize the error string
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("Initialization Process : AioSetAiEvnet = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// Display the message that initialization process is completed
	//----------------------------------------
	text_string.Format(_T("Initialization Process : Successful completion"));
	m_edt_return.SetWindowText(text_string);
}


//================================================================================
// It is the process when the Repeat Times Setting button is clicked
// Set the repeat times
//================================================================================
void CAiRepeatDlg::OnBnClickedButtonRepeat()
{
	TCHAR	text_temp[256];		// For temporary storage of text
	long	ret1;				// For return value 1
	long	ret2;				// For return value 2
	char	error_string[256];	// Error code string
	CString	text_string;		// For updating the textbox

	//----------------------------------------
	// Update GUI information
	//----------------------------------------
	UpdateData(TRUE);
	//----------------------------------------
	// Set the repeat times
	//----------------------------------------
	ret1 = AioSetAiRepeatTimes(g_id, m_repeat_times);
	//----------------------------------------
	// Error process
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// When failed to get the error string,
		// initialize the error string
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("Repeat Times Setting Process : AioSetAiRepeatTimes = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// Display the message that the repeat times setting process is completed
	//----------------------------------------
	text_string.Format(_T("Repeat Times Setting Process : Successful completion"));
	m_edt_return.SetWindowText(text_string);
}


//================================================================================
// It is the process when the Sampling Start button is clicked
// After clearing the memory and status, start sampling
//================================================================================
void CAiRepeatDlg::OnBnClickedButtonStart()
{
	TCHAR	text_temp[256];		// For temporary storage of text
	long	ret1;				// For return value 1
	long	ret2;				// For return value 2
	char	error_string[256];	// Error code string
	CString	text_string;		// For updating the textbox
	CString	text_string_temp;	// For temporary storage of textbox
	long	aistatus;			// Analog input status
	long	airepeatcount;		// Analog input repeat times

	//----------------------------------------
	// Clear memory
	//----------------------------------------
	ret1 = AioResetAiMemory(g_id);
	//----------------------------------------
	// Error process
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// When failed to get the error string,
		// initialize the error string
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("Sampling Start : AioResetAiMemory = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// Clear status
	//----------------------------------------
	ret1 = AioResetAiStatus(g_id);
	//----------------------------------------
	// Error process
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// When failed to get the error string,
		// initialize the error string
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("Sampling Start : AioResetAiStatus = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	g_sampling_count	= 0;
	//----------------------------------------
	// Start sampling
	//----------------------------------------
	ret1 = AioStartAi(g_id);
	//----------------------------------------
	// Error process
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// When failed to get the error string,
		// initialize the error string
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("Sampling Start : AioStartAi = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// Get status
	//----------------------------------------
	ret1 = AioGetAiStatus(g_id, &aistatus);
	//----------------------------------------
	// Error process
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// When failed to get the error string,
		// initialize the error string
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("Sampling Start : AioGetAiStatus = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// Display status
	//----------------------------------------
	text_string.Format(_T("%08xH ("), aistatus);
	//--------------------
	// When status 'Device is running' is ON
	//--------------------
	if ((aistatus & AIS_BUSY) == AIS_BUSY){
		text_string_temp.Format(_T("Operating"));
		text_string += text_string_temp;
	//--------------------
	// When status 'Device is running' is OFF
	//--------------------
	}else{
		text_string_temp.Format(_T("Stop"));
		text_string += text_string_temp;
	}
	//--------------------
	// When status 'Wait the start trigger' is ON
	//--------------------
	if ((aistatus & AIS_START_TRG) == AIS_START_TRG){
		text_string_temp.Format(_T(", Wait the start trigger"));
		text_string += text_string_temp;
	}
	//--------------------
	// When status 'The specified number of data are stored' is ON
	//--------------------
	if ((aistatus & AIS_DATA_NUM) == AIS_DATA_NUM){
		text_string_temp.Format(_T(", The specified number of data are stored"));
		text_string += text_string_temp;
	}
	//--------------------
	// When status 'Overflow' is ON
	//--------------------
	if ((aistatus & AIS_OFERR) == AIS_OFERR){
		text_string_temp.Format(_T(", Overflow"));
		text_string += text_string_temp;
	}
	//--------------------
	// When status 'Sampling clock error' is ON
	//--------------------
	if ((aistatus & AIS_SCERR) == AIS_SCERR){
		text_string_temp.Format(_T(", Sampling clock error"));
		text_string += text_string_temp;
	}
	//--------------------
	// When status 'AD conversion error' is ON
	//--------------------
	if ((aistatus & AIS_AIERR) == AIS_AIERR){
		text_string_temp.Format(_T(", AD conversion error"));
		text_string += text_string_temp;
	}
	//--------------------
	// When status 'Driver spec error' is ON
	//--------------------
	if ((aistatus & AIS_DRVERR) == AIS_DRVERR){
		text_string_temp.Format(_T(", Driver spec error"));
		text_string += text_string_temp;
	}
	text_string_temp.Format(_T(")"));
	text_string += text_string_temp;
	m_edt_status.SetWindowText(text_string);
	//----------------------------------------
	// Update the total sampling times
	//----------------------------------------
	text_string.Format(_T("%d"), g_sampling_count);
	m_edt_samplingcount.SetWindowText(text_string);
	//----------------------------------------
	// Get the current repeat times
	//----------------------------------------
	ret1 = AioGetAiRepeatCount(g_id, &airepeatcount);
	//----------------------------------------
	// Error process
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// When failed to get the error string,
		// initialize the error string
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("Sampling Start : AioGetAiRepeatCount = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// Update the repeat times
	//----------------------------------------
	text_string.Format(_T("%d"), airepeatcount);
	m_edt_repeatcount.SetWindowText(text_string);
	//----------------------------------------
	// Display the message that sampling start is completed
	//----------------------------------------
	text_string.Format(_T("Sampling Start : Successful completion"));
	m_edt_return.SetWindowText(text_string);
}


//================================================================================
// It is the process when the Sampling Stop button is clicked
// Stop sampling
//================================================================================
void CAiRepeatDlg::OnBnClickedButtonStop()
{
	TCHAR	text_temp[256];		// For temporary storage of text
	long	ret1;				// For return value 1
	long	ret2;				// For return value 2
	char	error_string[256];	// Error code string
	CString	text_string;		// For updating the textbox

	//----------------------------------------
	// Stop sampling
	//----------------------------------------
	ret1 = AioStopAi(g_id);
	//----------------------------------------
	// Error process
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// When failed to get the error string,
		// initialize the error string
		//--------------------
		if (ret2 != 0) {
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("Sampling Stop : AioStopAi = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// Display the message that sampling stop is completed
	//----------------------------------------
	text_string.Format(_T("Sampling Stop : Successful completion"));
	m_edt_return.SetWindowText(text_string);
}


//================================================================================
// It is the process when the Device Exit button is clicked
// Perform the exit process of device
//================================================================================
void CAiRepeatDlg::OnBnClickedButtonExit()
{
	TCHAR	text_temp[256];		// For temporary storage of text
	long	ret1;				// For return value 1
	long	ret2;				// For return value 2
	char	error_string[256];	// Error code string
	CString	text_string;		// For updating the textbox

	//----------------------------------------
	// Exit process of device
	//----------------------------------------
	ret1 = AioExit(g_id);
	//----------------------------------------
	// Error process
	//----------------------------------------
	if (ret1 != 0){
		ret2 = AioGetErrorString(ret1, error_string);
		//--------------------
		// When failed to get the error string,
		// initialize the error string
		//--------------------
		if (ret2 != 0){
			strcpy_s(error_string, "");
		}
		wsprintf(text_temp, _T("%S"), error_string);
		text_string.Format(_T("Device Exit Process : AioExit = %d : %s"), ret1, text_temp);
		m_edt_return.SetWindowText(text_string);
		return;
	}
	//----------------------------------------
	// Display the message that device exit process is completed
	//----------------------------------------
	text_string.Format(_T("Device Exit Process : Successful completion"));
	m_edt_return.SetWindowText(text_string);
}


//================================================================================
// It is the process when the Close button is clicked
// Perform the exit process of the application
//================================================================================
void CAiRepeatDlg::OnBnClickedButtonClose()
{
	//----------------------------------------
	// Close dialog
	//----------------------------------------
	CDialog::OnOK();
}


//================================================================================
// Operation when an event occurs
// Process for each event occurred
//================================================================================
LRESULT CAiRepeatDlg::DefWindowProc(UINT message, WPARAM wParam, LPARAM lParam)
{
	TCHAR	text_temp[256];			// For temporary storage of text
	long	ret1;					// For return value 1
	long	ret2;					// For return value 2
	char	error_string[256];		// Error code string
	CString	text_string;			// For updating the textbox
	long	aisamplingcount;		// Sampling count
	float	*aidata;				// Analog data
	CString	text_string_temp;		// For temporary storage of textbox
	short	aichannels;				// Number of channels
	long	aistatus;				// Status
	long	airepeatcount;			// Repeat times
	int		i, j;

	//----------------------------------------
	// Event that AD conversion start
	// Acquire and display data
	//----------------------------------------
	if (message == AIOM_AIE_START){
		//----------------------------------------
		// Get status
		//----------------------------------------
		ret1 = AioGetAiStatus(g_id, &aistatus);
		//----------------------------------------
		// Error process
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// When failed to get the error string,
			// initialize the error string
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("AD Conversion Start Process : AioGetAiStatus = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			return TRUE;
		}
		//----------------------------------------
		// Display status
		//----------------------------------------
		text_string.Format(_T("%08xH ("), aistatus);
		//--------------------
		// When status 'Device is running' is ON
		//--------------------
		if ((aistatus & AIS_BUSY) == AIS_BUSY){
			text_string_temp.Format(_T("Operating"));
		//--------------------
		// When status 'Device is running' is OFF
		//--------------------
		}else{
			text_string_temp.Format(_T("Stop"));
		}
		text_string += text_string_temp;
		//--------------------
		// When status 'Wait the start trigger' is ON
		//--------------------
		if ((aistatus & AIS_START_TRG) == AIS_START_TRG){
			text_string_temp.Format(_T(", Wait the start trigger"));
			text_string += text_string_temp;
		}
		//--------------------
		// When status 'The specified number of data are stored' is ON
		//--------------------
		if ((aistatus & AIS_DATA_NUM) == AIS_DATA_NUM){
			text_string_temp.Format(_T(", The specified number of data are stored"));
			text_string += text_string_temp;
		}
		//--------------------
		// When status 'Overflow' is ON
		//--------------------
		if ((aistatus & AIS_OFERR) == AIS_OFERR){
			text_string_temp.Format(_T(", Overflow"));
			text_string += text_string_temp;
		}
		//--------------------
		// When status 'Sampling clock error' is ON
		//--------------------
		if ((aistatus & AIS_SCERR) == AIS_SCERR){
			text_string_temp.Format(_T(", Sampling clock error"));
			text_string += text_string_temp;
		}
		//--------------------
		// When status 'AD conversion error' is ON
		//--------------------
		if ((aistatus & AIS_AIERR) == AIS_AIERR){
			text_string_temp.Format(_T(", AD conversion error"));
			text_string += text_string_temp;
		}
		//--------------------
		// When status 'Driver spec error' is ON
		//--------------------
		if ((aistatus & AIS_DRVERR) == AIS_DRVERR){
			text_string_temp.Format(_T(", Driver spec error"));
			text_string += text_string_temp;
		}
		text_string_temp.Format(_T(")"));
		text_string += text_string_temp;
		m_edt_status.SetWindowText(text_string);
		//----------------------------------------
		// Display the message that event process is completed
		//----------------------------------------
		text_string.Format(_T("AD Conversion Start Process : Successful completion"));
		m_edt_return.SetWindowText(text_string);
	}
	//----------------------------------------
	// Event that repeat end
	// Acquire and display data
	//----------------------------------------
	if (message == AIOM_AIE_RPTEND){
		//----------------------------------------
		// Get status
		//----------------------------------------
		ret1 = AioGetAiStatus(g_id, &aistatus);
		//----------------------------------------
		// Error process
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// When failed to get the error string,
			// initialize the error string
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("Repeat End Event Process : AioGetAiStatus = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			return TRUE;
		}
		//----------------------------------------
		// Display status
		//----------------------------------------
		text_string.Format(_T("%08xH ("), aistatus);
		//--------------------
		// When status 'Device is running' is ON
		//--------------------
		if ((aistatus & AIS_BUSY) == AIS_BUSY){
			text_string_temp.Format(_T("Operating"));
		//--------------------
		// When status 'Device is running' is OFF
		//--------------------
		}else{
			text_string_temp.Format(_T("Stop"));
		}
		text_string += text_string_temp;
		//--------------------
		// When status 'Wait the start trigger' is ON
		//--------------------
		if ((aistatus & AIS_START_TRG) == AIS_START_TRG){
			text_string_temp.Format(_T(", Wait the start trigger"));
			text_string += text_string_temp;
		}
		//--------------------
		// When status 'The specified number of data are stored' is ON
		//--------------------
		if ((aistatus & AIS_DATA_NUM) == AIS_DATA_NUM){
			text_string_temp.Format(_T(", The specified number of data are stored"));
			text_string += text_string_temp;
		}
		//--------------------
		// When status 'Overflow' is ON
		//--------------------
		if ((aistatus & AIS_OFERR) == AIS_OFERR){
			text_string_temp.Format(_T(", Overflow"));
			text_string += text_string_temp;
		}
		//--------------------
		// When status 'Sampling clock error' is ON
		//--------------------
		if ((aistatus & AIS_SCERR) == AIS_SCERR){
			text_string_temp.Format(_T(", Sampling clock error"));
			text_string += text_string_temp;
		}
		//--------------------
		// When status 'AD conversion error' is ON
		//--------------------
		if ((aistatus & AIS_AIERR) == AIS_AIERR){
			text_string_temp.Format(_T(", AD conversion error"));
			text_string += text_string_temp;
		}
		//--------------------
		// When status 'Driver spec error' is ON
		//--------------------
		if ((aistatus & AIS_DRVERR) == AIS_DRVERR){
			text_string_temp.Format(_T(", Driver spec error"));
			text_string += text_string_temp;
		}
		text_string_temp.Format(_T(")"));
		text_string += text_string_temp;
		m_edt_status.SetWindowText(text_string);
		//----------------------------------------
		// Get the current sampling times
		//----------------------------------------
		ret1 = AioGetAiSamplingCount(g_id, &aisamplingcount);
		//----------------------------------------
		// Error process
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// When failed to get the error string,
			// initialize the error string
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("Repeat End Event Process : AioGetAiSamplingCount = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			return TRUE;
		}
		//----------------------------------------
		// Get the number of channels
		//----------------------------------------
		ret1 = AioGetAiChannels(g_id, &aichannels);
		//----------------------------------------
		// Error process
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// When failed to get the error string,
			// initialize the error string
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("Repeat End Event Process : AioGetAiChannels = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			return TRUE;
		}
		//----------------------------------------
		// Get sampling data
		//----------------------------------------
		//--------------------
		// Allocate an array for storing data
		//--------------------
		aidata = (float *)malloc(sizeof(float)* aisamplingcount * aichannels);
		if (aidata == NULL){
			text_string.Format(_T("Repeat End Event Process : Failed to allocate an array for storing data"));
			m_edt_return.SetWindowText(text_string);
			return TRUE;
		}
		ret1 = AioGetAiSamplingDataEx(g_id, &aisamplingcount, aidata);
		//----------------------------------------
		// Error process
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// When failed to get the error string,
			// initialize the error string
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("Repeat End Event Process : AioGetAiSamplingDataEx = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			free(aidata);
			return TRUE;
		}
		g_sampling_count += aisamplingcount;
		//----------------------------------------
		// Update the total sampling times
		//----------------------------------------
		text_string.Format(_T("%d"), g_sampling_count);
		m_edt_samplingcount.SetWindowText(text_string);
		//----------------------------------------
		// Get the current repeat times
		//----------------------------------------
		ret1 = AioGetAiRepeatCount(g_id, &airepeatcount);
		//----------------------------------------
		// Error process
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// When failed to get the error string,
			// initialize the error string
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("Repeat End Event Process : AioGetAiRepeatCount = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			free(aidata);
			return TRUE;
		}
		//----------------------------------------
		// Update the repeat times
		//----------------------------------------
		text_string.Format(_T("%d"), airepeatcount);
		m_edt_repeatcount.SetWindowText(text_string);
		//----------------------------------------
		// Store a string for displaying the sampling data
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
		// Display the sampling data
		//----------------------------------------
		m_edt_samplingdata.SetWindowTextW(text_string);
		//----------------------------------------
		// Display the message that event process is completed
		//----------------------------------------
		text_string.Format(_T("Repeat End Event Process : Successful completion"));
		m_edt_return.SetWindowText(text_string);
		free(aidata);
	}
	//----------------------------------------
	// Event that device operation end
	// Acquire and display data
	//----------------------------------------
	if (message == AIOM_AIE_END){
		//----------------------------------------
		// Get status
		//----------------------------------------
		ret1 = AioGetAiStatus(g_id, &aistatus);
		//----------------------------------------
		// Error process
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// When failed to get the error string,
			// initialize the error string
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("Device Operation End Event Process : AioGetAiStatus = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			return TRUE;
		}
		//----------------------------------------
		// Display status
		//----------------------------------------
		text_string.Format(_T("%08xH ("), aistatus);
		//--------------------
		// When status 'Device is running' is ON
		//--------------------
		if ((aistatus & AIS_BUSY) == AIS_BUSY){
			text_string_temp.Format(_T("Operating"));
		//--------------------
		// When status 'Device is running' is OFF
		//--------------------
		}else{
			text_string_temp.Format(_T("Stop"));
		}
		text_string += text_string_temp;
		//--------------------
		// When status 'Wait the start trigger' is ON
		//--------------------
		if ((aistatus & AIS_START_TRG) == AIS_START_TRG){
			text_string_temp.Format(_T(", Wait the start trigger"));
			text_string += text_string_temp;
		}
		//--------------------
		// When status 'The specified number of data are stored' is ON
		//--------------------
		if ((aistatus & AIS_DATA_NUM) == AIS_DATA_NUM){
			text_string_temp.Format(_T(", The specified number of data are stored"));
			text_string += text_string_temp;
		}
		//--------------------
		// When status 'Overflow' is ON
		//--------------------
		if ((aistatus & AIS_OFERR) == AIS_OFERR){
			text_string_temp.Format(_T(", Overflow"));
			text_string += text_string_temp;
		}
		//--------------------
		// When status 'Sampling clock error' is ON
		//--------------------
		if ((aistatus & AIS_SCERR) == AIS_SCERR){
			text_string_temp.Format(_T(", Sampling clock error"));
			text_string += text_string_temp;
		}
		//--------------------
		// When status 'AD conversion error' is ON
		//--------------------
		if ((aistatus & AIS_AIERR) == AIS_AIERR){
			text_string_temp.Format(_T(", AD conversion error"));
			text_string += text_string_temp;
		}
		//--------------------
		// When status 'Driver spec error' is ON
		//--------------------
		if ((aistatus & AIS_DRVERR) == AIS_DRVERR){
			text_string_temp.Format(_T(", Driver spec error"));
			text_string += text_string_temp;
		}
		text_string_temp.Format(_T(")"));
		text_string += text_string_temp;
		m_edt_status.SetWindowText(text_string);
		//----------------------------------------
		// Get the current sampling times
		//----------------------------------------
		ret1 = AioGetAiSamplingCount(g_id, &aisamplingcount);
		//----------------------------------------
		// Error process
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// When failed to get the error string,
			// initialize the error string
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("Device Operation End Event Process : AioGetAiSamplingCount = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			return TRUE;
		}
		//----------------------------------------
		// Get the number of channels
		//----------------------------------------
		ret1 = AioGetAiChannels(g_id, &aichannels);
		//----------------------------------------
		// Error process
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// When failed to get the error string,
			// initialize the error string
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("Device Operation End Event Process : AioGetAiChannels = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			return TRUE;
		}
		//----------------------------------------
		// Get sampling data
		//----------------------------------------
		//--------------------
		// Allocate an array for storing data
		//--------------------
		aidata = (float *)malloc(sizeof(float)* aisamplingcount * aichannels);
		if (aidata == NULL){
			text_string.Format(_T("Device Operation End Event Process : Failed to allocate an array for storing data"));
			m_edt_return.SetWindowText(text_string);
			return TRUE;
		}
		ret1 = AioGetAiSamplingDataEx(g_id, &aisamplingcount, aidata);
		//----------------------------------------
		// Error process
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// When failed to get the error string,
			// initialize the error string
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("Device Operation End Event Process : AioGetAiSamplingDataEx = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			free(aidata);
			return TRUE;
		}
		g_sampling_count += aisamplingcount;
		//----------------------------------------
		// Update the total sampling times
		//----------------------------------------
		text_string.Format(_T("%d"), g_sampling_count);
		m_edt_samplingcount.SetWindowText(text_string);
		//----------------------------------------
		// Get the current repeat times
		//----------------------------------------
		ret1 = AioGetAiRepeatCount(g_id, &airepeatcount);
		//----------------------------------------
		// Error process
		//----------------------------------------
		if (ret1 != 0){
			ret2 = AioGetErrorString(ret1, error_string);
			//--------------------
			// When failed to get the error string,
			// initialize the error string
			//--------------------
			if (ret2 != 0){
				strcpy_s(error_string, "");
			}
			wsprintf(text_temp, _T("%S"), error_string);
			text_string.Format(_T("Device Operation End Event Process : AioGetAiRepeatCount = %d : %s"), ret1, text_temp);
			m_edt_return.SetWindowText(text_string);
			free(aidata);
			return TRUE;
		}
		//----------------------------------------
		// Update the repeat times
		//----------------------------------------
		text_string.Format(_T("%d"), airepeatcount);
		m_edt_repeatcount.SetWindowText(text_string);
		//----------------------------------------
		// Store a string for displaying the sampling data
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
		// Display the sampling data
		//----------------------------------------
		m_edt_samplingdata.SetWindowTextW(text_string);
		//----------------------------------------
		// Display the message that event process is completed
		//----------------------------------------
		text_string.Format(_T("Device Operation End Event Process : Successful completion"));
		m_edt_return.SetWindowText(text_string);
		free(aidata);
	}

	return CDialog::DefWindowProc(message, wParam, lParam);
}
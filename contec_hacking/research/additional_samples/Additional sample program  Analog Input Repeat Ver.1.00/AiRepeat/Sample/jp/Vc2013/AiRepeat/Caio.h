//==============================================================================================
//	API-AIO(WDM)�p��`�t�@�C��																	
//==============================================================================================

//----------------------------------------------------------------------------------------------
//	�O������M��																				
//----------------------------------------------------------------------------------------------
#define	AIO_AIF_CLOCK				0	//�A�i���O���͊O���N���b�N
#define	AIO_AIF_START				1	//�A�i���O���͊O���J�n�g���K
#define	AIO_AIF_STOP				2	//�A�i���O���͊O����~�g���K
#define	AIO_AOF_CLOCK				3	//�A�i���O�o�͊O���N���b�N
#define	AIO_AOF_START				4	//�A�i���O�o�͊O���J�n�g���K
#define	AIO_AOF_STOP				5	//�A�i���O�o�͊O����~�g���K

//----------------------------------------------------------------------------------------------
//	���o�̓����W																				
//----------------------------------------------------------------------------------------------
#define	PM10						0	//�}10V
#define	PM5							1	//�}5V
#define	PM25						2	//�}2.5V
#define	PM125						3	//�}1.25V
#define	PM1							4	//�}1V
#define	PM0625						5	//�}0.625V
#define	PM05						6	//�}0.5V
#define	PM03125						7	//�}0.3125V
#define	PM025						8	//�}0.25V
#define	PM0125						9	//�}0.125V
#define	PM01						10	//�}0.1V
#define	PM005						11	//�}0.05V
#define	PM0025						12	//�}0.025V
#define	PM00125						13	//�}0.0125V
#define	PM001						14	//�}0.01V
#define	P10							50	//0�`10V
#define	P5							51	//0�`5V
#define	P4095						52	//0�`4.095V
#define	P25							53	//0�`2.5V
#define	P125						54	//0�`1.25V
#define	P1							55	//0�`1V
#define	P05							56	//0�`0.5V
#define	P025						57	//0�`0.25V
#define	P01							58	//0�`0.1V
#define	P005						59	//0�`0.05V
#define	P0025						60	//0�`0.025V
#define	P00125						61	//0�`0.0125V
#define	P001						62	//0�`0.01V
#define	P20MA						100	//0�`20mA
#define	P4TO20MA					101	//4�`20mA
#define	P1TO5						150	//1�`5V

//----------------------------------------------------------------------------------------------
//	�A�i���O���̓C�x���g																		
//----------------------------------------------------------------------------------------------
#define	AIE_START			0x00000002	//AD�ϊ��J�n���������C�x���g
#define	AIE_RPTEND			0x00000010	//���s�[�g�I���C�x���g
#define	AIE_END				0x00000020	//�f�o�C�X����I���C�x���g
#define	AIE_DATA_NUM		0x00000080	//�w��T���v�����O�񐔊i�[�C�x���g
#define	AIE_DATA_TSF		0x00000100	//�w��]�������C�x���g
#define	AIE_OFERR			0x00010000	//�I�[�o�[�t���[�C�x���g
#define	AIE_SCERR			0x00020000	//�T���v�����O�N���b�N�G���[�C�x���g
#define	AIE_ADERR			0x00040000	//AD�ϊ��G���[�C�x���g

//----------------------------------------------------------------------------------------------
//	�A�i���O�o�̓C�x���g																		
//----------------------------------------------------------------------------------------------
#define	AOE_START			0x00000002	//DA�ϊ��J�n���������C�x���g
#define	AOE_RPTEND			0x00000010	//���s�[�g�I���C�x���g
#define	AOE_END				0x00000020	//�f�o�C�X����I���C�x���g
#define	AOE_DATA_NUM		0x00000080	//�w��T���v�����O�񐔏o�̓C�x���g
#define	AOE_DATA_TSF		0x00000100	//�w��]�������C�x���g
#define	AOE_SCERR			0x00020000	//�T���v�����O�N���b�N�G���[�C�x���g
#define	AOE_DAERR			0x00040000	//DA�ϊ��G���[�C�x���g

//----------------------------------------------------------------------------------------------
//	�J�E���^�C�x���g																			
//----------------------------------------------------------------------------------------------
#define	CNTE_DATA_NUM		0x00000010	//��r�J�E���g��v�C�x���g
#define	CNTE_ORERR			0x00010000	//�J�E���g�I�[�o�[�����C�x���g
#define	CNTE_ERR			0x00020000	//�J�E���^����G���[

//----------------------------------------------------------------------------------------------
//	�^�C�}�C�x���g																				
//----------------------------------------------------------------------------------------------
#define	TME_INT				0x00000001	//�C���^�[�o�������C�x���g

//----------------------------------------------------------------------------------------------
//	�A�i���O���̓X�e�[�^�X																		
//----------------------------------------------------------------------------------------------
#define	AIS_BUSY			0x00000001	//�f�o�C�X���쒆
#define	AIS_START_TRG		0x00000002	//�J�n�g���K�҂�
#define	AIS_DATA_NUM		0x00000010	//�w��T���v�����O�񐔊i�[
#define	AIS_OFERR			0x00010000	//�I�[�o�[�t���[
#define	AIS_SCERR			0x00020000	//�T���v�����O�N���b�N�G���[
#define	AIS_AIERR			0x00040000	//AD�ϊ��G���[
#define	AIS_DRVERR			0x00080000	//�h���C�o�X�y�b�N�G���[

//----------------------------------------------------------------------------------------------
//	�A�i���O�o�̓X�e�[�^�X																		
//----------------------------------------------------------------------------------------------
#define	AOS_BUSY			0x00000001	//�f�o�C�X���쒆
#define	AOS_START_TRG		0x00000002	//�J�n�g���K�҂�
#define	AOS_DATA_NUM		0x00000010	//�w��T���v�����O�񐔏o��
#define	AOS_SCERR			0x00020000	//�T���v�����O�N���b�N�G���[
#define	AOS_AOERR			0x00040000	//DA�ϊ��G���[
#define	AOS_DRVERR			0x00080000	//�h���C�o�X�y�b�N�G���[

//----------------------------------------------------------------------------------------------
//	�J�E���^�X�e�[�^�X																			
//----------------------------------------------------------------------------------------------
#define	CNTS_BUSY			0x00000001	//�J�E���^���쒆
#define	CNTS_DATA_NUM		0x00000010	//��r�J�E���g��v
#define	CNTS_ORERR			0x00010000	//�I�[�o�[����
#define	CNTS_ERR			0x00020000	//�J�E���^����G���[

//----------------------------------------------------------------------------------------------
//	�A�i���O���̓��b�Z�[�W																		
//----------------------------------------------------------------------------------------------
#define AIOM_AIE_START			0x1000	//AD�ϊ��J�n���������C�x���g
#define AIOM_AIE_RPTEND			0x1001	//���s�[�g�I���C�x���g
#define AIOM_AIE_END			0x1002	//�f�o�C�X����I���C�x���g
#define AIOM_AIE_DATA_NUM		0x1003	//�w��T���v�����O�񐔊i�[�C�x���g
#define AIOM_AIE_DATA_TSF		0x1007	//�w��]�������C�x���g
#define AIOM_AIE_OFERR			0x1004	//�I�[�o�[�t���[�C�x���g
#define AIOM_AIE_SCERR			0x1005	//�T���v�����O�N���b�N�G���[�C�x���g
#define AIOM_AIE_ADERR			0x1006	//AD�ϊ��G���[�C�x���g

//----------------------------------------------------------------------------------------------
//	�A�i���O�o�̓��b�Z�[�W																		
//----------------------------------------------------------------------------------------------
#define AIOM_AOE_START			0x1020	//DA�ϊ��J�n���������C�x���g
#define AIOM_AOE_RPTEND			0x1021	//���s�[�g�I���C�x���g
#define AIOM_AOE_END			0x1022	//�f�o�C�X����I���C�x���g
#define AIOM_AOE_DATA_NUM		0x1023	//�w��T���v�����O�񐔏o�̓C�x���g
#define AIOM_AOE_DATA_TSF		0x1027	//�w��]�������C�x���g
#define AIOM_AOE_SCERR			0x1025	//�T���v�����O�N���b�N�G���[�C�x���g
#define AIOM_AOE_DAERR			0x1026	//DA�ϊ��G���[�C�x���g

//----------------------------------------------------------------------------------------------
//	�J�E���^���b�Z�[�W																			
//----------------------------------------------------------------------------------------------
#define AIOM_CNTE_DATA_NUM		0x1042	//��r�J�E���g��v�C�x���g
#define AIOM_CNTE_ORERR			0x1043	//�J�E���g�I�[�o�[�����C�x���g
#define AIOM_CNTE_ERR			0x1044	//�J�E���g����G���[�C�x���g

//----------------------------------------------------------------------------------------------
//	�^�C�}���b�Z�[�W																			
//----------------------------------------------------------------------------------------------
#define AIOM_TME_INT			0x1060	//�C���^�[�o�������C�x���g

//----------------------------------------------------------------------------------------------
//	�A�i���O���͓Y�t�f�[�^																		
//----------------------------------------------------------------------------------------------
#define	AIAT_AI				0x00000001	//�A�i���O���͕t�����
#define	AIAT_AO0			0x00000100	//�A�i���O�o�̓f�[�^
#define	AIAT_DIO0			0x00010000	//�f�W�^�����o�̓f�[�^
#define	AIAT_CNT0			0x01000000	//�J�E���^�`���l���O�f�[�^
#define	AIAT_CNT1			0x02000000	//�J�E���^�`���l���P�f�[�^

//----------------------------------------------------------------------------------------------
//	�J�E���^���샂�[�h																			
//----------------------------------------------------------------------------------------------
#define	CNT_LOADPRESET		0x0000001	//�v���Z�b�g�J�E���g�l�̃��[�h
#define	CNT_LOADCOMP		0x0000002	//��r�J�E���g�l�̃��[�h

//----------------------------------------------------------------------------------------------
//	�C�x���g�R���g���[���ڑ���M��																
//----------------------------------------------------------------------------------------------
#define	AIOECU_DEST_AI_CLK			4	//�A�i���O���̓T���v�����O�N���b�N
#define	AIOECU_DEST_AI_START		0	//�A�i���O���͕ϊ��J�n�M��
#define	AIOECU_DEST_AI_STOP			2	//�A�i���O���͕ϊ���~�M��
#define	AIOECU_DEST_AO_CLK			36	//�A�i���O�o�̓T���v�����O�N���b�N
#define	AIOECU_DEST_AO_START		32	//�A�i���O�o�͕ϊ��J�n�M��
#define	AIOECU_DEST_AO_STOP			34	//�A�i���O�o�͕ϊ���~�M��
#define	AIOECU_DEST_CNT0_UPCLK		134	//�J�E���^�O�A�b�v�N���b�N�M��
#define	AIOECU_DEST_CNT1_UPCLK		135	//�J�E���^�P�A�b�v�N���b�N�M��
#define	AIOECU_DEST_CNT0_START		128	//�J�E���^�O�A�^�C�}�O����J�n�M��
#define	AIOECU_DEST_CNT1_START		129	//�J�E���^�P�A�^�C�}�P����J�n�M��
#define	AIOECU_DEST_CNT0_STOP		130	//�J�E���^�O�A�^�C�}�O�����~�M��
#define	AIOECU_DEST_CNT1_STOP		131	//�J�E���^�P�A�^�C�}�P�����~�M��
#define	AIOECU_DEST_MASTER1			104	//�����o�X�}�X�^�M���P
#define	AIOECU_DEST_MASTER2			105	//�����o�X�}�X�^�M���Q
#define	AIOECU_DEST_MASTER3			106	//�����o�X�}�X�^�M���R

//----------------------------------------------------------------------------------------------
//	�C�x���g�R���g���[���ڑ����M��																
//----------------------------------------------------------------------------------------------
#define	AIOECU_SRC_OPEN				-1	//���ڑ�
#define	AIOECU_SRC_AI_CLK			4	//�A�i���O���͓����N���b�N�M��
#define	AIOECU_SRC_AI_EXTCLK		146	//�A�i���O���͊O���N���b�N�M��
#define	AIOECU_SRC_AI_TRGSTART		144	//�A�i���O���͊O���g���K�J�n�M��
#define	AIOECU_SRC_AI_LVSTART		28	//�A�i���O���̓��x���g���K�J�n�M��
#define	AIOECU_SRC_AI_STOP			17	//�A�i���O���͕ϊ��񐔏I���M���i�x���Ȃ��j
#define	AIOECU_SRC_AI_STOP_DELAY	18	//�A�i���O���͕ϊ��񐔏I���M���i�x������j
#define	AIOECU_SRC_AI_LVSTOP		29	//�A�i���O���̓��x���g���K��~�M��
#define	AIOECU_SRC_AI_TRGSTOP		145	//�A�i���O���͊O���g���K��~�M��
#define	AIOECU_SRC_AO_CLK			66	//�A�i���O�o�͓����N���b�N�M��
#define	AIOECU_SRC_AO_EXTCLK		149	//�A�i���O�o�͊O���N���b�N�M��
#define	AIOECU_SRC_AO_TRGSTART		147	//�A�i���O�o�͊O���g���K�J�n�M��
#define	AIOECU_SRC_AO_STOP_FIFO		352	//�A�i���O�o�͎w��񐔏o�͏I���M���iFIFO�g�p�j
#define	AIOECU_SRC_AO_STOP_RING		80	//�A�i���O�o�͎w��񐔏o�͏I���M���iRING�g�p�j
#define	AIOECU_SRC_AO_TRGSTOP		148	//�A�i���O�o�͊O���g���K��~�M��
#define	AIOECU_SRC_CNT0_UPCLK		150	//�J�E���^�O�A�b�v�N���b�N�M��
#define	AIOECU_SRC_CNT1_UPCLK		152	//�J�E���^�P�A�b�v�N���b�N�M��
#define	AIOECU_SRC_CNT0_CMP			288	//�J�E���^�O��r�J�E���g��v
#define	AIOECU_SRC_CNT1_CMP			289	//�J�E���^�P��r�J�E���g��v
#define	AIOECU_SRC_SLAVE1			136	//�����o�X�X���[�u�M���P
#define	AIOECU_SRC_SLAVE2			137	//�����o�X�X���[�u�M���Q
#define	AIOECU_SRC_SLAVE3			138	//�����o�X�X���[�u�M���R
#define	AIOECU_SRC_START			384	//Ai, Ao, Cnt, Tm�\�t�g�E�F�A�J�n�M��
#define	AIOECU_SRC_STOP				385	//Ai, Ao, Cnt, Tm�\�t�g�E�F�A��~�M��

//----------------------------------------------------------------------------------------------
// M�f�o�C�X�p�J�E���^���b�Z�[�W
//----------------------------------------------------------------------------------------------
#define	AIOM_CNTM_COUNTUP_CH0		0x1070	// �J�E���g�A�b�v�A�`���l���ԍ�0
#define	AIOM_CNTM_COUNTUP_CH1		0x1071	//         "                   1
#define	AIOM_CNTM_TIME_UP			0x1090	//�^�C���A�b�v
#define	AIOM_CNTM_COUNTER_ERROR		0x1091	//�J�E���^�G���[
#define	AIOM_CNTM_CARRY_BORROW		0x1092	//�L�����[�^�{���[

//----------------------------------------------------------------------------------------------
//	�֐��v���g�^�C�v																			
//----------------------------------------------------------------------------------------------
#ifdef __cplusplus
extern "C"{
#endif
//���ʊ֐�
long WINAPI AioInit(char * DeviceName, short * Id);
long WINAPI AioExit(short Id);
long WINAPI AioResetDevice(short Id);
long WINAPI AioGetErrorString(long ErrorCode, char * ErrorString);
long WINAPI AioQueryDeviceName(short Index, char * DeviceName, char * Device);
long WINAPI AioGetDeviceType(char * Device, short * DeviceType);
long WINAPI AioSetControlFilter(short Id, short Signal, float Value);
long WINAPI AioGetControlFilter(short Id, short Signal, float *Value);
long WINAPI AioResetProcess(short Id);

//�A�i���O���͊֐�
long WINAPI AioSingleAi(short Id, short AiChannel, long * AiData);
long WINAPI AioSingleAiEx(short Id, short AiChannel, float * AiData);
long WINAPI AioMultiAi(short Id, short AiChannels, long * AiData);
long WINAPI AioMultiAiEx(short Id, short AiChannels, float * AiData);
long WINAPI AioSingleAiSR(short Id, short AiChannel, long * AiData, unsigned short * Timestamp, BYTE Mode);
long WINAPI AioSingleAiExSR(short Id, short AiChannel, float * AiData, unsigned short * Timestamp, BYTE Mode);
long WINAPI AioMultiAiSR(short Id, short AiChannels, long * AiData, unsigned short * Timestamp, BYTE Mode);
long WINAPI AioMultiAiExSR(short Id, short AiChannels, float * AiData, unsigned short * Timestamp, BYTE Mode);
long WINAPI AioGetAiResolution(short Id, short * AiResolution);
long WINAPI AioSetAiInputMethod(short Id, short AiInputMethod);
long WINAPI AioGetAiInputMethod(short Id, short * AiInputMethod);
long WINAPI AioGetAiMaxChannels(short Id, short * AiMaxChannels);
long WINAPI AioSetAiChannel(short Id, short AiChannel, short Enabled);
long WINAPI AioGetAiChannel(short Id, short AiChannel, short *Enabled);
long WINAPI AioSetAiChannels(short Id, short AiChannels);
long WINAPI AioGetAiChannels(short Id, short * AiChannels);
long WINAPI AioSetAiChannelSequence(short Id, short AiSequence, short AiChannel);
long WINAPI AioGetAiChannelSequence(short Id, short AiSequence, short * AiChannel);
long WINAPI AioSetAiRange(short Id, short AiChannel, short AiRange);
long WINAPI AioSetAiRangeAll(short Id, short AiRange);
long WINAPI AioGetAiRange(short Id, short AiChannel, short * AiRange);
long WINAPI AioSetAiTransferMode(short Id, short AiTransferMode);
long WINAPI AioGetAiTransferMode(short Id, short *AiTransferMode);
long WINAPI AioSetAiDeviceBufferMode(short Id, short AiDeviceBufferMode);
long WINAPI AioGetAiDeviceBufferMode(short Id, short *AiDeviceBufferMode);
long WINAPI AioSetAiMemorySize(short Id, long AiMemorySize);
long WINAPI AioGetAiMemorySize(short Id, long *AiMemorySize);
long WINAPI AioSetAiTransferData(short Id, long DataNumber, long *Buffer);
long WINAPI AioSetAiAttachedData(short Id, long AttachedData);
long WINAPI AioGetAiSamplingDataSize(short Id, short *DataSize);
long WINAPI AioSetAiMemoryType(short Id, short AiMemoryType);
long WINAPI AioGetAiMemoryType(short Id, short * AiMemoryType);
long WINAPI AioSetAiRepeatTimes(short Id, long AiRepeatTimes);
long WINAPI AioGetAiRepeatTimes(short Id, long * AiRepeatTimes);
long WINAPI AioSetAiClockType(short Id, short AiClockType);
long WINAPI AioGetAiClockType(short Id, short * AiClockType);
long WINAPI AioSetAiSamplingClock(short Id, float AiSamplingClock);
long WINAPI AioGetAiSamplingClock(short Id, float * AiSamplingClock);
long WINAPI AioSetAiScanClock(short Id, float AiScanClock);
long WINAPI AioGetAiScanClock(short Id, float * AiScanClock);
long WINAPI AioSetAiClockEdge(short Id, short AoClockEdge);
long WINAPI AioGetAiClockEdge(short Id, short * AoClockEdge);
long WINAPI AioSetAiStartTrigger(short Id, short AiStartTrigger);
long WINAPI AioGetAiStartTrigger(short Id, short * AiStartTrigger);
long WINAPI AioSetAiStartLevel(short Id, short AiChannel, long AiStartLevel, short AiDirection);
long WINAPI AioSetAiStartLevelEx(short Id, short AiChannel, float AiStartLevel, short AiDirection);
long WINAPI AioGetAiStartLevel(short Id, short AiChannel, long * AiStartLevel, short * AiDirection);
long WINAPI AioGetAiStartLevelEx(short Id, short AiChannel, float * AiStartLevel, short * AiDirection);
long WINAPI AioSetAiStartInRange(short Id, short AiChannel, long Level1, long Level2, long StateTimes);
long WINAPI AioSetAiStartInRangeEx(short Id, short AiChannel, float Level1, float Level2, long StateTimes);
long WINAPI AioGetAiStartInRange(short Id, short AiChannel, long *Level1, long *Level2, long *StateTimes);
long WINAPI AioGetAiStartInRangeEx(short Id, short AiChannel, float *Level1, float *Level2, long *StateTimes);
long WINAPI AioSetAiStartOutRange(short Id, short AiChannel, long Level1, long Level2, long StateTimes);
long WINAPI AioSetAiStartOutRangeEx(short Id, short AiChannel, float Level1, float Level2, long StateTimes);
long WINAPI AioGetAiStartOutRange(short Id, short AiChannel, long *Level1, long *Level2, long *StateTimes);
long WINAPI AioGetAiStartOutRangeEx(short Id, short AiChannel, float *Level1, float *Level2, long *StateTimes);
long WINAPI AioSetAiStopTrigger(short Id, short AiStopTrigger);
long WINAPI AioGetAiStopTrigger(short Id, short * AiStopTrigger);
long WINAPI AioSetAiStopTimes(short Id, long AiStopTimes);
long WINAPI AioGetAiStopTimes(short Id, long * AiStopTimes);
long WINAPI AioSetAiStopLevel(short Id, short AiChannel, long AiStopLevel, short AiDirection);
long WINAPI AioSetAiStopLevelEx(short Id, short AiChannel, float AiStopLevel, short AiDirection);
long WINAPI AioGetAiStopLevel(short Id, short AiChannel, long * AiStopLevel, short * AiDirection);
long WINAPI AioGetAiStopLevelEx(short Id, short AiChannel, float * AiStopLevel, short * AiDirection);
long WINAPI AioSetAiStopInRange(short Id, short AiChannel, long Level1, long Level2, long StateTimes);
long WINAPI AioSetAiStopInRangeEx(short Id, short AiChannel, float Level1, float Level2, long StateTimes);
long WINAPI AioGetAiStopInRange(short Id, short AiChannel, long *Level1, long *Level2, long *StateTimes);
long WINAPI AioGetAiStopInRangeEx(short Id, short AiChannel, float *Level1, float *Level2, long *StateTimes);
long WINAPI AioSetAiStopOutRange(short Id, short AiChannel, long Level1, long Level2, long StateTimes);
long WINAPI AioSetAiStopOutRangeEx(short Id, short AiChannel, float Level1, float Level2, long StateTimes);
long WINAPI AioGetAiStopOutRange(short Id, short AiChannel, long *Level1, long *Level2, long *StateTimes);
long WINAPI AioGetAiStopOutRangeEx(short Id, short AiChannel, float *Level1, float *Level2, long *StateTimes);
long WINAPI AioSetAiStopDelayTimes(short Id, long AiStopDelayTimes);
long WINAPI AioGetAiStopDelayTimes(short Id, long * AiStopDelayTimes);
long WINAPI AioSetAiEvent(short Id, HWND hWnd, long AiEvent);
long WINAPI AioGetAiEvent(short Id, HWND * hWnd, long * AiEvent);
long WINAPI AioSetAiCallBackProc(short Id,
	long (_stdcall *pProc)(short Id, short AiEvent, WPARAM wParam, LPARAM lParam, void *Param), long AiEvent, void *Param);
long WINAPI AioSetAiEventSamplingTimes(short Id, long AiSamplingTimes);
long WINAPI AioGetAiEventSamplingTimes(short Id, long * AiSamplingTimes);
long WINAPI AioSetAiEventTransferTimes(short Id, long AiTransferTimes);
long WINAPI AioGetAiEventTransferTimes(short Id, long *AiTransferTimes);
long WINAPI AioStartAi(short Id);
long WINAPI AioStartAiSync(short Id, long TimeOut);
long WINAPI AioStopAi(short Id);
long WINAPI AioGetAiStatus(short Id, long * AiStatus);
long WINAPI AioGetAiSamplingCount(short Id, long * AiSamplingCount);
long WINAPI AioGetAiStopTriggerCount(short Id, long * AiStopTriggerCount);
long WINAPI AioGetAiTransferCount(short Id, long *AiTransferCount);
long WINAPI AioGetAiTransferLap(short Id, long *Lap);
long WINAPI AioGetAiStopTriggerTransferCount(short Id, long *Count);
long WINAPI AioGetAiRepeatCount(short Id, long * AiRepeatCount);
long WINAPI AioGetAiSamplingData(short Id, long * AiSamplingTimes, long * AiData);
long WINAPI AioGetAiSamplingDataEx(short Id, long * AiSamplingTimes, float * AiData);
long WINAPI AioResetAiStatus(short Id);
long WINAPI AioResetAiMemory(short Id);
long WINAPI AioSetAiDigitalFilter(short Id, short AiChannel, short FilterType, short FilterValue);
long WINAPI AioGetAiDigitalFilter(short Id, short AiChannel, short *FilterType, short *FilterValue);

//�A�i���O�o�͊֐�
long WINAPI AioSingleAo(short Id, short AoChannel, long AoData);
long WINAPI AioSingleAoEx(short Id, short AoChannel, float AoData);
long WINAPI AioMultiAo(short Id, short AoChannels, long * AoData);
long WINAPI AioMultiAoEx(short Id, short AoChannels, float * AoData);
long WINAPI AioGetAoResolution(short Id, short * AoResolution);
long WINAPI AioSetAoChannels(short Id, short AoChannels);
long WINAPI AioGetAoChannels(short Id, short * AoChannels);
long WINAPI AioGetAoMaxChannels(short Id, short * AoMaxChannels);
long WINAPI AioSetAoRange(short Id, short AoChannel, short AoRange);
long WINAPI AioSetAoRangeAll(short Id, short AoRange);
long WINAPI AioGetAoRange(short Id, short AoChannel, short * AoRange);
long WINAPI AioSetAoTransferMode(short Id, short AoTransferMode);
long WINAPI AioGetAoTransferMode(short Id, short *AoTransferMode);
long WINAPI AioSetAoDeviceBufferMode(short Id, short AoDeviceBufferMode);
long WINAPI AioGetAoDeviceBufferMode(short Id, short *AoDeviceBufferMode);
long WINAPI AioSetAoMemorySize(short Id, long AoMemorySize);
long WINAPI AioGetAoMemorySize(short Id, long *AoMemorySize);
long WINAPI AioSetAoTransferData(short Id, long DataNumber, long *Buffer);
long WINAPI AioGetAoSamplingDataSize(short Id, short *DataSize);
long WINAPI AioSetAoMemoryType(short Id, short AoMemoryType);
long WINAPI AioGetAoMemoryType(short Id, short * AoMemoryType);
long WINAPI AioSetAoRepeatTimes(short Id, long AoRepeatTimes);
long WINAPI AioGetAoRepeatTimes(short Id, long * AoRepeatTimes);
long WINAPI AioSetAoClockType(short Id, short AoClockType);
long WINAPI AioGetAoClockType(short Id, short * AoClockType);
long WINAPI AioSetAoSamplingClock(short Id, float AoSamplingClock);
long WINAPI AioGetAoSamplingClock(short Id, float * AoSamplingClock);
long WINAPI AioSetAoClockEdge(short Id, short AoClockEdge);
long WINAPI AioGetAoClockEdge(short Id, short * AoClockEdge);
long WINAPI AioSetAoSamplingData(short Id, long AoSamplingTimes, long * AoData);
long WINAPI AioSetAoSamplingDataEx(short Id, long AoSamplingTimes, float * AoData);
long WINAPI AioGetAoSamplingTimes(short Id, long * AoSamplingTimes);
long WINAPI AioSetAoStartTrigger(short Id, short AoStartTrigger);
long WINAPI AioGetAoStartTrigger(short Id, short * AoStartTrigger);
long WINAPI AioSetAoStopTrigger(short Id, short AoStopTrigger);
long WINAPI AioGetAoStopTrigger(short Id, short * AoStopTrigger);
long WINAPI AioSetAoEvent(short Id, HWND hWnd, long AoEvent);
long WINAPI AioGetAoEvent(short Id, HWND * hWnd, long * AoEvent);
long WINAPI AioSetAoCallBackProc(short Id,
	long (_stdcall *pProc)(short Id, short AiEvent, WPARAM wParam, LPARAM lParam, void *Param), long AoEvent, void *Param);
long WINAPI AioSetAoEventSamplingTimes(short Id, long AoSamplingTimes);
long WINAPI AioGetAoEventSamplingTimes(short Id, long * AoSamplingTimes);
long WINAPI AioSetAoEventTransferTimes(short Id, long AoTransferTimes);
long WINAPI AioGetAoEventTransferTimes(short Id, long *AoTransferTimes);
long WINAPI AioStartAo(short Id);
long WINAPI AioStopAo(short Id);
long WINAPI AioEnableAo(short Id, short AoChannel);
long WINAPI AioDisableAo(short Id, short AoChannel);
long WINAPI AioGetAoStatus(short Id, long * AoStatus);
long WINAPI AioGetAoSamplingCount(short Id, long * AoSamplingCount);
long WINAPI AioGetAoTransferCount(short Id, long *AoTransferCount);
long WINAPI AioGetAoTransferLap(short Id, long *Lap);
long WINAPI AioGetAoRepeatCount(short Id, long * AoRepeatCount);
long WINAPI AioResetAoStatus(short Id);
long WINAPI AioResetAoMemory(short Id);

//�f�W�^�����o�͊֐�
long WINAPI AioSetDiFilter(short Id, short Bit, float Value);
long WINAPI AioGetDiFilter(short Id, short Bit, float *Value);
long WINAPI AioInputDiBit(short Id, short DiBit, short * DiData);
long WINAPI AioOutputDoBit(short Id, short DoBit, short DoData);
long WINAPI AioInputDiByte(short Id, short DiPort, short * DiData);
long WINAPI AioOutputDoByte(short Id, short DoPort, short DoData);
long WINAPI AioSetDioDirection(short Id, long Dir);
long WINAPI AioGetDioDirection (short Id, long * Dir);

//�J�E���^�֐�
long WINAPI AioGetCntMaxChannels(short Id, short * CntMaxChannels);
long WINAPI AioSetCntComparisonMode(short Id, short CntChannel, short CntMode);
long WINAPI AioGetCntComparisonMode(short Id, short CntChannel, short *CntMode);
long WINAPI AioSetCntPresetReg(short Id, short CntChannel, long PresetNumber, long *PresetData, short Flag);
long WINAPI AioSetCntComparisonReg(short Id, short CntChannel, long ComparisonNumber, long *ComparisonData, short Flag);
long WINAPI AioSetCntInputSignal(short Id, short CntChannel, short CntInputSignal);
long WINAPI AioGetCntInputSignal(short Id, short CntChannel, short *CntInputSignal);
long WINAPI AioSetCntEvent(short Id, short CntChannel, HWND hWnd, long CntEvent);
long WINAPI AioGetCntEvent(short Id, short CntChannel, HWND *hWnd, long *CntEvent);
long WINAPI AioSetCntCallBackProc(short Id, short CntChannel,
	long (_stdcall *pProc)(short Id, short CntEvent, WPARAM wParam, LPARAM lParam, void *Param), long CntEvent, void *Param);
long WINAPI AioSetCntFilter(short Id, short CntChannel, short Signal, float Value);
long WINAPI AioGetCntFilter(short Id, short CntChannel, short Signal, float *Value);
long WINAPI AioStartCnt(short Id, short CntChannel);
long WINAPI AioStopCnt(short Id, short CntChannel);
long WINAPI AioPresetCnt(short Id, short CntChannel, long PresetData);
long WINAPI AioGetCntStatus(short Id, short CntChannel, long *CntStatus);
long WINAPI AioGetCntCount(short Id, short CntChannel, long *Count);
long WINAPI AioResetCntStatus(short Id, short CntChannel, long CntStatus);

//�^�C�}�֐�
long WINAPI AioSetTmEvent(short Id, short TimerId, HWND hWnd, long TmEvent);
long WINAPI AioGetTmEvent(short Id, short TimerId, HWND * hWnd, long * TmEvent);
long WINAPI AioSetTmCallBackProc(short Id, short TimerId,
	long (_stdcall *pProc)(short Id, short TmEvent, WPARAM wParam, LPARAM lParam, void *Param), long TmEvent, void *Param);
long WINAPI AioStartTmTimer(short Id, short TimerId, float Interval);
long WINAPI AioStopTmTimer(short Id, short TimerId);
long WINAPI AioStartTmCount(short Id, short TimerId);
long WINAPI AioStopTmCount(short Id, short TimerId);
long WINAPI AioLapTmCount(short Id, short TimerId, long *Lap);
long WINAPI AioResetTmCount(short Id, short TimerId);
long WINAPI AioTmWait(short Id, short TimerId, long Wait);

//�C�x���g�R���g���[��
long WINAPI AioSetEcuSignal(short Id, short Destination, short Source);
long WINAPI AioGetEcuSignal(short Id, short Destination, short *Source);

// Setting function (set)
long WINAPI AioGetCntmMaxChannels(short Id, short *CntmMaxChannels);
long WINAPI AioSetCntmZMode(short Id, short ChNo, short Mode);
long WINAPI AioSetCntmZLogic(short Id, short ChNo, short ZLogic);
long WINAPI AioSelectCntmChannelSignal(short Id, short ChNo, short SigType);
long WINAPI AioSetCntmCountDirection(short Id, short ChNo, short Dir);
long WINAPI AioSetCntmOperationMode(short Id, short ChNo, short Phase, short Mul, short SyncClr);
long WINAPI AioSetCntmDigitalFilter(short Id, short ChNo, short FilterValue);
long WINAPI AioSetCntmPulseWidth(short Id, short ChNo, short PlsWidth);
long WINAPI AioSetCntmDIType(short Id, short ChNo, short InputType);
long WINAPI AioSetCntmOutputHardwareEvent(short Id, short ChNo, short OutputLogic, unsigned long EventType, short PulseWidth);
long WINAPI AioSetCntmInputHardwareEvent(short Id, short ChNo, unsigned long EventType, short RF0, short RF1, short Reserved);
long WINAPI AioSetCntmCountMatchHardwareEvent(short Id, short ChNo, short RegisterNo, unsigned long EventType, short Reserved);
long WINAPI AioSetCntmPresetRegister(short Id, short ChNo, unsigned long PresetData, short Reserved);
long WINAPI AioSetCntmTestPulse(short Id, short CntmInternal, short CntmOut, short CntmReserved);
// Setting function (get)
long WINAPI AioGetCntmZMode(short Id, short ChNo, short *Mode);
long WINAPI AioGetCntmZLogic(short Id, short ChNo, short *ZLogic);
long WINAPI AioGetCntmChannelSignal(short Id, short CntmChNo, short *CntmSigType);
long WINAPI AioGetCntmCountDirection(short Id, short ChNo, short *Dir);
long WINAPI AioGetCntmOperationMode(short Id, short ChNo, short *Phase, short *Mul, short *SyncClr);
long WINAPI AioGetCntmDigitalFilter(short Id, short ChNo, short *FilterValue);
long WINAPI AioGetCntmPulseWidth(short Id, short ChNo, short *PlsWidth);
// Counter function
long WINAPI AioCntmStartCount(short Id, short *ChNo, short ChNum);
long WINAPI AioCntmStopCount(short Id, short *ChNo, short ChNum);
long WINAPI AioCntmPreset(short Id, short *ChNo, short ChNum, unsigned long *PresetData);
long WINAPI AioCntmZeroClearCount(short Id, short *ChNo, short ChNum);
long WINAPI AioCntmReadCount(short Id, short *ChNo, short ChNum, unsigned long *CntDat);
long WINAPI AioCntmReadStatus(short Id, short ChNo, short *Sts);
long WINAPI AioCntmReadStatusEx(short Id, short ChNo, unsigned long *Sts);
// Notify function
long WINAPI AioCntmNotifyCountUp(short Id, short ChNo, short RegNo, unsigned long Count, HANDLE hWnd);
long WINAPI AioCntmStopNotifyCountUp(short Id, short ChNo, short RegNo);
long WINAPI AioCntmCountUpCallbackProc(short Id , void *CallBackProc , void *Param);
long WINAPI AioCntmNotifyCounterError(short Id, HANDLE hWnd);
long WINAPI AioCntmStopNotifyCounterError(short Id);
long WINAPI AioCntmCounterErrorCallbackProc(short Id , void *CallBackProc , void *Param);
long WINAPI AioCntmNotifyCarryBorrow(short Id, HANDLE hWnd);
long WINAPI AioCntmStopNotifyCarryBorrow(short Id);
long WINAPI AioCntmCarryBorrowCallbackProc(short Id, void *CallBackProc, void *Param);
long WINAPI AioCntmNotifyTimer(short Id, unsigned long TimeValue, HANDLE hWnd);
long WINAPI AioCntmStopNotifyTimer(short Id);
long WINAPI AioCntmTimerCallbackProc(short Id , void *CallBackProc , void *Param);
// General purpose input function
long WINAPI AioCntmInputDIByte(short Id, short Reserved, BYTE *bData);
long WINAPI AioCntmOutputDOBit(short Id, short AiomChNo, short Reserved, BYTE OutData);

#ifdef __cplusplus
};
#endif

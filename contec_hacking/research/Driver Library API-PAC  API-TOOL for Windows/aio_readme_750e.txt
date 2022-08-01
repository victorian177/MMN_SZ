=====================================================================
=            Windows Driver for Analog I/O Driver                   =
=                                            API-AIO(WDM) Ver.7.50  =
=                                                 CONTEC Co., Ltd.  =
=====================================================================

- Contents
==========
  Introduction
  Notes
  Installation
  The history of version-up


- Introduction
==============
  Thank you for purchasing this product.

  The following description is a supplementary explanation for API-AIO(WDM).
  Please refer to Online Help(APITOOL.CHM) for how to use API-AIO(WDM).


- Notes
=======
  In the following cases, the maximum size of the buffer for bus master is limited.

  <a PC has the memory more than 4G Byte>
  In Windows 64 bit OS and Windows 32 bit OS, PAE (Physical Address Extension) is enabled.

  <a PC has the memory less than 4G Byte>
  In Windows 64 bit OS or Windows 32 bit OS, PAE (Physical Address Extension) is enabled, 
  and [Memory Reclaiming] functionality is enabled by BIOS setting of the PC (matherboard) 
  in which a board is plugged.

  * According to PC (motherboard), there is the case that [Memory Reclaiming] functionality 
  cannot be changed to Enabled/Disabled by BIOS setting, therefore, please confirm in advance.

  * Up to 2 Mbyte for Windows 10 Version 1703 and later, up to 1 Mbyte for earlier OS. 

  The target device
  AIO-163202F-PE, ADA16-32/2(PCI)F, AI-1204Z-PCI


- Installation
==============
  For the installation procedure of the device driver and the development environment (sample programs, etc.),
  refer to the following help file after extracting the download file.
      Help\ENG\APITOOL.chm


- The history of version-up
===========================

  * Series device list
    F-Series:               ADA16-32/2(PCI)F, AIO-163202F-PE
    L-Series:               ADA16-8/2(LPCI)L,
                            AD16-64(LPCI)LA, AD16-16(LPCI)L,
                            DA16-16(LPCI)L, DA16-8(LPCI)L, DA16-4(LPCI)L
                            ADAI16-8/2(LPCI)L, ADI16-16(LPCI)L, DAI16-4(LPCI)L
                            AIO-160802L-LPE, AI-1616L-LPE, AO-1604L-LPE
                            AIO-121602AH-PCI, AIO-121602AL-PCI
                            AI-1216AH-PCI, AI-1216AL-PCI
                            AIO-160802LI-PE, AI-1616LI-PE
                            AO-1604LI-PE, AI-1664LA-LPE
                            AO-1608L-LPE, AO-1616L-LPE
    E-Series:               AD12-16(PCI)E, AD12-16U(PCI)E, AD12-16U(PCI)EH
                            AD16-16(PCI)E, AD16-16U(PCI)EH, ADI12-16(PCI), AI-1216I2-PCI
                            AD12-16(PCI)EV, AD12-16U(PCI)EV,
                            AD16-16(PCI)EV, AD16-16U(PCI)EV
                            AIO-121601E3-PE, AIO-121601UE3-PE
                            AIO-161601E3-PE, AIO-161601UE3-PE
                            AD12-16(PCI), AD12-64(PCI)
                            AI-1604CI2-PCI, AO-1604CI3-PCI, AO-1604CI2-PCI
                            DA12-4(PCI), DA12-8(PCI), DA12-16(PCI)
    B-Series:               AI-1216B-RB1-PCI, AI-1216B-RU1-PCI
    Z-Series:               AI-1204Z-PCI, AI-1204Z-PE
    USB-Series:             ADI12-8(USB), ADI16-4(USB), DAI12-4(USB), DAI16-4(USB)
    N-Series:               AIO-121602LN-USB, AIO-120802LN-USB, AI-1608VIN-USB, AI-1608AIN-USB,
                            AO-1604VIN-USB, AO-1604AIN-USB
    X-Series:               AIO-163202FX-USB, AO-1604LX-USB, AI-1664LAX-USB
    Y-Series:               AI-1608AY-USB, AI-1608GY-USB, AIO-160802AY-USB, AIO-160802GY-USB
    Wireless I/O-Series:    AI-1004LY-WQ, AI-1004LY-WQ-EU, AI-1004LY-WQ-US, AI-1004LY-WQ-CN
    CONPROSYS nano-Series:  CPSN-AI-1208LI, CPSN-AI-2408LI, CPSN-AO-1602LC
    CONPROSYS-Series:       CPS-AI-1608LI, CPS-AI-1608ALI, CPS-AO-1604LI, CPS-AO-1604VLI

  Ver.7.41 -> 7.50 (Web Release 2022.03)
  ----------------------------------------
  - Support C-Logger Ver.1.50.

  Ver.7.40 -> 7.41 (Web Release 2022.02)
  ----------------------------------------
  - Fixed a bug that the return value may be undefined when executing function AioGetAiSamplingDataEx from a 32 bit application on 64-bit OS.
    Target device: AI-1204Z-PE
  - Fixed a bug that the setting was not reflected normally in the function AioSetDiFilter.
    Target device: AI-1608VIN-USB
                   AI-1608AIN-USB
                   AO-1604VIN-USB
                   AO-1604AIN-USB

  Ver.7.30 -> 7.40 (Web Release 2022.01)
  ----------------------------------------
  - Add support development language
    Support language: Python 3.10
  - Checked the operation on Windows 10 21H2
  - Add support OS
    Support OS:       Microsoft Windows 10 IoT Enterprise LTSC 2021
  - Fixed a bug that blue screen will occur when executing function AioGetAiSamplingDataEx from a 32 bit application on 64 bit OS.
    Target device: AI-1204Z-PE

  Ver.7.21 -> 7.30 (Web Release 2021.12)
  ----------------------------------------
  - Add support OS
    Support OS:    Microsoft Windows 11  (64bit)

  Ver.7.20 -> 7.21 (Web Release 2021.09)
  ----------------------------------------
  - Added a configurable combination of synchronous bus slave signals in the AioSetEcuSignal function.
    Target device: AI-1204Z-PE
                   AI-1204Z-PCI

  Ver.7.12 -> 7.20 (Web Release 2021.06)
  ----------------------------------------
  - Checked the operation on the following OS
    Target OS:     Microsoft Windows 10 21H1
                   Microsoft Windows 10 IoT Enterprise 2019 LTSC
                   Microsoft Windows 10 IoT Enterprise LTSB 2016
  - Fixed a bug that function processing may not be completed when the following products are operated in multithread.
    Target device: GW1-ETH-WQ
                   GW1-ETH-WQ-EU
                   GW1-ETH-WQ-US
                   GW1-ETH-WQ-CN
                   CPSN-MCB271-S1-041
                   CPSN-MCB271-1-041

  Ver.7.11 -> 7.12 (Web Release 2021.05)
  ----------------------------------------
  - Fixed a bug that the process may not be completed when AioStartAo is executed after executing AioStopAo.

  Ver.7.10 -> 7.11 (Web Release 2021.05)
  ----------------------------------------
  - Fixed a bug that the output value becomes abnormal when simple input is performed during continuous output with AIO-163202FX-USB.

  Ver.7.01 -> 7.10 (Web Release 2021.04)
  ----------------------------------------
  - Add support development language
    Support language: Python 3.9
  - Fixed the following bugs that occurred in AI-1204Z-PE
    . In the user buffer mode and [Not overwrite the memory] setting, some sampling data is overwritten when an overflow occurs.
    . In the device buffer mode and FIFO mode setting, sampling with a specific memory size does not stop even if an overflow occurs.
    . Internal parameters return to the default, when AioInit function is executed in another process during multi-process.
    . Sampling stops when AioExit function is executed in another process during multi-process.

  Ver.7.00 -> 7.01 (Web Release 2021.03)
  ----------------------------------------
  - Fixed a bug that the calibration program could not calibrate correctly
    Analog input function target device:  AIO-121602LN-USB
                                          AIO-120802LN-USB
                                          AIO-121602AH-PCI
                                          AI-1216AH-PCI
                                          AIO-121602AL-PCI
                                          AIO-1216AH-PCI
                                          AIO-1204Z-PCI
    Analog output function target device: All devices
  - Fixed a bug that the calibration program could not be started
    Target device: AI-1616LI-PE
                   AO-1604LI-PE
  - Fixed a bug that settings other than CH0 could not be confirmed in the calibration program.
    Target device: AI-1204Z-PE

  Ver.6.80 -> 7.00 (Web Release 2021.02)
  ----------------------------------------
  - Add support controller
    Support controller: CC-USB271-CPSN4
  - Revise the support OS
    Support OS:         Microsoft Windows 10  (32bit/64bit)
  - End of support for the following devices
    ADA16-32/2(CB)F, ADA16-8/2(CB)L

  Ver.6.70 -> 6.80 (Web Release 2020.12)
  ----------------------------------------
  - Checked the operation on Windows 10 20H2.
  - Supported Windows 10 security policy (memory integrity).
  - Fixed a bug that data could not be acquired normally when AioSingleAiEx was executed with CPSN-AI-1208LI + CPSN-MCB271-xxx.
  - Fixed the following bugs that occurred in AI-1204Z-PE
    . "20001" error occurs when executing AioSetAiRangeAll.
    . It may take some time to stop conversion after the conversion stop condition is satisfied.
    . Device information revision is not displayed properly in diagnosis report.
    . When sampling is performed with the device buffer mode and memory format set to FIFO, sampling stops when the total sampling times exceeds the set buffer size.

  Ver.6.60 -> 6.70 (Web Release 2020.11)
  ----------------------------------------
  - Add support device
    CPSN-AO-1602LC

  Ver.6.50 -> 6.60 (Web Release 2020.09)
  ----------------------------------------
  - Add support development language
    Support language: Python 3.8
  - Fixed a bug that the maximum number of samplings could not be set with AioSetAiStopTimes on AI-1204Z-PE.

  Ver.6.41 -> 6.50 (Web Release 2020.07)
  ----------------------------------------
  - Checked the operation on Windows 10 2004.

  Ver.6.40 -> 6.41 (Web Release 2020.07)
  ----------------------------------------
  - Fixed a bug that a blue screen may produce when try sampling more than buffer size set in AI-1204Z-PE.

  Ver.6.30 -> 6.40 (Web Release 2020.06)
  ----------------------------------------
  - Supports new devices
    AI-1204Z-PE

  Ver.6.20 -> 6.30 (Web Release 2020.04)
  ----------------------------------------
  - Integrate the USB driver
  - Revise the support OS
    Support OS:       Microsoft Windows 10  (32bit/64bit)
                      Microsoft Windows 8.1 (32bit/64bit)
                      Microsoft Windows 7   (32bit/64bit)
  - Revise the support development language
    Support language: Microsoft Visual Basic .NET (2010,2012,2013,2015,2017,2019)
                      Microsoft Visual C#         (2010,2012,2013,2015,2017,2019)
                      Microsoft Visual C++ (MFC)  (2010,2012,2013,2015,2017,2019)
  - End of support for the following devices
    CPU-CA10(USB), AIO-121601M-PCI

  Ver.6.13 -> 6.20 (Web Release 2020.03)
  ----------------------------------------
  - Supports new devices
    CPSN-AI-2408LI

  Ver.6.12 -> 6.13 (Web Release 2020.02)
  ----------------------------------------
  - Fixed an issue that sampling may not be performed properly even if AioStartAi is executed.
    Target function: AI-1608VIN-USB
                     AI-1608AIN-USB
 
  Ver.6.11 -> 6.12 (Web Release 2020.01)
  ----------------------------------------
  - Fixed an issue that a blue screen may occur when performing continuous output by changing the number of channels used.
    Target function: AO-1608L-PE
                     AO-1616L-LPE
                     DA16-08(LPCI)L
                     DA16-16(LPCI)L

  Ver.6.10 -> 6.11 (Web Release 2020.01)
  ----------------------------------------
  - Fixed an issue that data may not be measured with AIO-163202FX-USB.
    Target function: AioMultiAi
                     AioMultiAiEx

  Ver.6.03 -> 6.10 (Web Release 2019.12)
  ----------------------------------------
  - Checked the operation on Windows 10 19H2.

  Ver.6.02 -> 6.03
  ----------------------------------------
  - Fixed an issue that the application may not terminate normally.

  Ver.6.01 -> 6.02
  ----------------------------------------
  - Fixed the following issues that occur when RING memory is set with AI-1608VIN-USB and AI-1608AIN-USB
    . When sampling by looping the driver memory, some data may not be obtained
    . Memory is reset when AioStartAi is executed

  Ver.6.00 -> 6.01
  ----------------------------------------
  - Fixed the following issues with AO-1604VIN-USB and AO-1604AIN-USB
    . Output may become abnormal when using the repeat function
    . When the start condition or stop condition is set to external trigger, a value other than 1 can be set into AioSetAoRepeatTimes.

  Ver.5.90 -> 6.00 (Web Release 2019.09)
  ----------------------------------------
  - Add support development language
    Support language: Microsoft Visual Basic 2019
                      Microsoft Visual C# 2019
                      Microsoft Visual C++ 2019

  Ver.5.80 -> 5.90 (Web Release 2019.08)
  ----------------------------------------
  - Add support device
    Support device:   AI-1216I2-PCI

  Ver.5.70 -> 5.80 (Web Release 2019.07)
  ----------------------------------------
  - Add support controller
    Support controller: CPSN-MCB271-1-041

  Ver.5.62 -> 5.70 (Web Release 2019.07)
  ----------------------------------------
  - Checked the operation on Windows 10 19H1.

  Ver.5.61 -> 5.62 (Web Release 2019.07)
  ----------------------------------------
  - Fixed an issue that other than Stop conversion by the specified times" can not be set as stop condition of analog output in L series and F series after Ver 5.30 or later.

  Ver.5.56 -> 5.61 (Web Release 2019.05)
  ----------------------------------------
  - Add support device
    Support device:   AI-1004LY-WQ-CN

  Ver.5.55 -> 5.56 (Web Release 2019.04)
  ----------------------------------------
  - Fixed an issue  that the sampling count may become abnormal with AI-1608VIN-USB or AI-1608AIN-USB.

  Ver.5.54 -> 5.55 (Web Release 2019.04)
  ----------------------------------------
  - Fixed an issue that AO-1604VIN-USB or AO-1604AIN-USB can not be initialized in Ver.5.54.

  Ver.5.52 -> 5.54 (Web Release 2019.04)
  ----------------------------------------
  - Fixed an issue that AioGetAiSamplingDataEx can not get data properly while sampling with AI-1608VIN-USB or AI-1608AIN-USB.

  Ver.5.51 -> 5.52 (Web Release 2019.03)
  ----------------------------------------
  - Fixed an issue that can not be sampling if another application is run while sampling.

  Ver.5.50 -> 5.51 (Web Release 2019.03)
  ----------------------------------------
  - Fixed an issue that an exception error may occur when the application is terminated.

  Ver.5.40 -> 5.50 (Web Release 2019.03)
  ----------------------------------------
  - Add support device
    Support device:   AO-1604VIN-USB
                      AO-1604AIN-USB

  Ver.5.33 -> 5.40 (Web Release 2019.02)
  ----------------------------------------
  - Add support device
    Support device:   AI-1608VIN-USB
                      AI-1608AIN-USB

  Ver.5.32 -> 5.33 (Web Release 2019.01)
  ----------------------------------------
  - Fixed an issue that the repeat does not operate correctly when the start condition ECU and the stop condition specified times with the AIO-163202FX-USB analog output.

  Ver.5.31 -> 5.32 (Web Release 2018.12)
  ----------------------------------------
  - Fixed an issue that memory leak occurred when AioMultiAi(Ex) was executed on Wireless I/O-Series or CONPROSYS nano-Series.

  Ver.5.30 -> 5.31 (Web Release 2018.12)
  ----------------------------------------
  - Fixed an issue that timing of Event that the specified number of data are stored shifted when using two or more USB products.

  Ver.5.23 -> 5.30 (Web Release 2018.11)
  ----------------------------------------
  - Add support device
    Support device:   CPS-AI-1608LI
                      CPS-AI-1608ALI
                      CPS-AO-1604LI
                      CPS-AO-1604VLI
  - Fixed an issue where samples could not be compiled in a specific development language.

  Ver.5.22 -> 5.23
  ----------------------------------------
  - Fixed an issue that callback event setting is initialized when Stop function is executed after callback event setting.

  Ver.5.21 -> 5.22 (Web Release 2018.11)
  ----------------------------------------
  - Fixed an issue that the last output data becomes abnormal when repeat output with L-Series.

  Ver.5.20 -> 5.21 (Web Release 2018.10)
  ----------------------------------------
  - Fixed an issue that 10002 error occurred when AioGetCntMaxChannels was executed on board products.

  Ver.5.12 -> 5.20 (Web Release 2018.07)
  ----------------------------------------
  - Add support device
    Support device:   AI-1004LY-WQ-EU
                      AI-1004LY-WQ-US
  - Changed to be able to get the list of existing devices normally with AioQueryDeviceName 
    even if information about devices that no longer exist remains.

  Ver.5.11 -> 5.12 (Web Release 2018.05)
  ----------------------------------------
  - Fixed an issue that Event that AD conversion start does not occur 
    when Start Trigger is set to Level comparison in N-Series and Y-Series.

  Ver.5.10 -> 5.11 (Web Release 2018.04)
  ----------------------------------------
  - Fixed a problem that data can not be normally acquired
    with AioGetSamplingData (AioGetAiSamplingDataEx) in the F-Series.
  - Fixed a problem that sampling data could not be acquired correctly
    when user buffer of F-Series or Z-Series was used with Windows 10 RS 2 or later.

  Ver.5.01 -> 5.10 (Web Release)
  ----------------------------------------
  - Add support device
    Support device:   AI-1004LY-WQ
                      CPSN-AI-1208LI

  Ver.5.00 -> 5.01 (Web Release)
  ----------------------------------------
  - Fixed a problem that may cause blue screen at shutdown.
  - Fixed a problem that AioStartSync sometimes terminates normally
    without data acquisition at the second execution.

  Ver.4.96 -> 5.00 (Ver.Aug.2017)
  ----------------------------------------
  - Add support development language
    Support language: Microsoft Visual Basic 2017
                      Microsoft Visual C# 2017
                      Microsoft Visual C++ 2017
  - In the definition file (Caio.vb, Caio.bas, Caio.pas), 
    fixed a problem that AIOM_AOE_DAERR definition was incorrect.

    [API-USBP(WDM) Ver.5.00]
  - Add support development language
    Support language: Microsoft Visual Basic 2017
                      Microsoft Visual C# 2017
                      Microsoft Visual C++ 2017
  - In the definition file (Caio.vb, Caio.bas, Caio.pas), 
    fixed a problem that AIOM_AOE_DAERR definition was incorrect.

  Ver.4.95 -> 4.96 (Web Release)
  ----------------------------------------
  - Fixed a problem that AioStartAi can not be done even if AioResetAiMemory is executed after overflow occurs.

  Ver.4.94 -> 4.95
  ----------------------------------------
  - Fixed a problem that may take about 1 second when AioStartAi or AioStartAo is executed.

  Ver.4.93 -> 4.94
  ----------------------------------------
  - Fixed a problem that analog output might not be possible when AioStartAo was executed more than once on the USB device.
  - Fixed a problem where parameters in the driver could not be reset when running AioInit.
  - Fixed a problem that the number of sampling times becomes 1 when overflow occurs.
  - Fixed a problem that increasing number of repeat times with external trigger after operation stopped setting external trigger in RING memory.
  - Fixed a problem that "21469" error does not occur when AioStartAi is executed after overflow.
  - Fixed a problem where parameters that can be acquired at the time of occurrence of the event are set incorrectly when AD repeat end is set in the event.
  - Fixed a problem that analog output was not generated even if analog output data was set.

  Ver.4.92 -> 4.93 (Web Release)
  ----------------------------------------
  - Fixed a probrem that an error code 18200 occurrence when AioCntmNotifyTimer argument "hWnd" was set to 0..

  Ver.4.91 -> 4.92
  ----------------------------------------
  - Fixed a probrem that which AioStopAi can not stop operation when callback processing is in progress.

  Ver.4.90 -> 4.91
  ----------------------------------------
  - Fixed a problem that " A driver inner error occurred " occurred in AioStopAi when AioStartAi and AioStopAi were executed repeatedly.

  Ver.4.80 -> 4.90 (Web Release)
  ----------------------------------------
  - Support "Driver Signing policy changes in Windows 10".
  - The support on the following OS was terminated
    Microsoft Windows 98 and Second Edition
    Microsoft Windows Me
  - Fixed a problem of freezing when AioStartAi or AioStartAo was executed during operation.
  - Fixed a problem of freezing when AioStopAi was executed with AI-1204Z-PCI.
  - Fixed a problem that errorcode 10002 occurred when AioGetCntMaxChannels or AioSetCntCallBackProc was executed.
  - Fixed a problem that errorcode does not occur when setting the tried to acquire data beyond the converted number 
    with AioGetAiSamplingDataEx.
  - Fixed a problem that " Event that the specified number of data are stored " does not occur
  - Fixed a problem where " Event that repeat end " does not occur if sampling clock is fast
  - Fixed a problem " AoSamplingTimes " to become abnormal when analog output started.
  - Fixed a problem where API-TIMER(WDM) TimInit could not be executed before executing AioInit.
  - Fixed a problem that calibration program (caiocal.exe/caiocalf.exe) does not operate properly on AIO-12xx02LN-USB.
  - Fixed a problem errocode 20037 occur on AO-1604LX-USB.

  Ver.4.73 -> 4.80 (Web Release)
  ----------------------------------------
  - Add support development language
    Support language: Microsoft Visual Basic 2015
                      Microsoft Visual Basic 2015 Express Edition
                      Microsoft Visual C# 2015
                      Microsoft Visual C# 2015 Express Edition
                      Microsoft Visual C++ 2015

  Ver.4.72 -> 4.73 (Web Release)
  ----------------------------------------
  - Add support device
    Support device:   AI-1608GY-USB

  Ver.4.71 -> 4.72 (Web Release)
  ----------------------------------------
  - Fixed a bug where the sampling clock error will not occur in a particular sampling clock in USB device.
  - Fixed a bug where AioResetAoMemory can perform during the execution of the analog output in USBdevice.
  - Update the version of the calibration program(caiocal.exe).

  Ver.4.70 -> 4.71 (Web Release)
  ----------------------------------------
  - Fixed a bug that can not be set the external clock to the rising in the AO-1604LX-USB.
  - Fixed a bug the error code 10003 occurs in AioInit function when you run a 32bit application in WOW64 to use the USB device.

  Ver.4.603 -> 4.70 (Web Release)
  ----------------------------------------
  - Add support OS
    Support OS:       Microsoft Windows 10
                      Microsoft Windows 10 x64 Edition
  - For F-Series and L-Series, fault correction that count match pulse isn't output.
  - For AIO-121601M-PCI, fault correction that the general-purpose input status cannot be retrieved by 
    function AioCntmReadStatusEx, and the general-purpose input data can not be read by function AioCntmInputDIByte.
  - For L-Series and AIO-121601M-PCI, fault correction that the edge setting isn't reflected by AioSetAoClockEdge.
  - For AIO-121602LN-USB, AIO-120802LN-USB, AIO-163202FX-USB, AI-1664LAX-USB, AO-1604LX-USB, 
    fault correction that operation becomes unstable when using comparison count match function.
  - For Y-Series, fault correction that the edge setting isn't reflected 
    if you run functions in the order of AioSetAiClockType->AioSetAiClockEdge.

  Ver.4.60 -> 4.603 (API-USBP(WDM) Ver.4.70)
  ----------------------------------------
  - Add support device
    Support device:   AIO-160802GY-USB
  - The defect which can't normally acquire a sampling count is corrected in the AioGetAiStopTriggerCount function 
    in AIO-163202FX-USB.

  Ver.4.53 -> 4.60 (Ver.Dec.2014)
  ----------------------------------------
  - Add support OS
    Support OS:       Microsoft Windows 8.1
                      Microsoft Windows 8.1 x64 Edition
  - Add support development language
    Support language: Microsoft Visual Basic 2013
                      Microsoft Visual Basic 2013 Express Edition
                      Microsoft Visual C# 2013
                      Microsoft Visual C# 2013 Express Edition
                      Microsoft Visual C++ 2013
  - If not in Japanese language environment, the fault which the defined error string of error code 28000 - 28032 
    cannot be retrieved by funtion AioGetErrorString is corrected. 
  - For AIO-163202FX-USB, fault correction that processing is not completed by performing AioStopAo function 
    when AO device buffer is RING mode. 
  - For USB device, fault correction that event of AO device operation end is notified for two times 
    when conditions are satisfied. 
    (Except DAI12-4(USB)GY, DAI16-4(USB))

  Ver.4.50 -> 4.53 (Web Release 2014.04)
  ----------------------------------------
  - In F-Series, if it samples to the maximum of a buffer at the time of FIFO mode use, 
    the fault where the number of times of a sampling is set to 0 and which cannot do data acquisition will be corrected. 
  - In L-Series and AIO-121601M-PCI, when not setting up the end event of device operation by the sampling of AD,
    the fault which processing does not complete by the 2nd AioStartAi function execution is corrected. 
  - The problem which a proofreading program freezes is corrected in L-Series and AIO-121601M-PCI. 

  Ver.4.45 -> 4.50 (Web Release 2014.02)
  ----------------------------------------
  - Add support OS
    Support OS:       Microsoft Windows 8
                      Microsoft Windows 8 x64 Edition
  - Add support development language
    Support language: Microsoft Visual Basic 2012
                      Microsoft Visual Basic 2012 Express Edition
                      Microsoft Visual C# 2012
                      Microsoft Visual C# 2012 Express Edition
                      Microsoft Visual C++ 2012
  - For AI-1204Z-PCI, fault correction that [AioStartAi: A user buffer isn't set up] error occurs 
    by measuring the executive time of function AioGetAiSamplingData, when the program for 
    measuring the executive speed of function is running in an OS which recognizes memory more than 4G Byte.
  - For F-Series and AIO-121601M-PCI, if the conversion start condition is specified 
    to [Event controller output], [Wait the start trigger] status will not be notified.
  - Fault correction that the sampling operation can't be started normally.
  - Fault correction that error 20002 occurs by function AioSetTmEvent and AioStartTmCount.
  - For L-Series and AIO-121601M-PCI, fault correction that AI repeat function doesn't work normally.
  - For AI-1204Z-PCI, fault correction that exception error occurs by performing function AioExit.
  - For L-Series and AIO-121601M-PCI, fault correction that data doesn't output normally 
    by function AioMultiAo and AioMultiAoEx, after calling AO continuous functions.
  - The fault is corrected, which an error indicating that [Contec USB Service] has failed to start is recorded 
    in the event log, if a USB device was removed without uninstalling the driver.

  Ver.4.36 -> 4.45 (Web Release 2013.11)
  ----------------------------------------
  - For USB device with counter function, fault correction that it can't count, 
    if count start and count stop are performed repeatedly.
  - For AIO-163202FX-USB, fault correction that sampling clock error (20000H) occurs, 
    if AO repeat is terminated by the conversion stop conditions other than times stop.
  - For F-Series and L-Series, fault correction that the repeat count doesn't increase, 
    if AO repeat and software start are set.
  - For AIO-163202FX-USB, fault correction that repeat runs over the specified times, 
    when using AO repeat function.
  - Mistake correction of the strings can be retrieved by function AioGetErrorString 
    corresponding to the return values 12381 and 12382.
  - For AI-1204Z-PCI, fault correction that [Event that the specified number of data are stored] 
    occurs after [Event that device operation end].
  - For Y-Series, fault correction that it can't output to DO03.
  - Fault correction that blue screen occurs, when simple I/O functions are performed.(Except USB device)

  Ver.4.30 -> 4.35 (Ver.July.2013)
  ----------------------------------------
  - In F-Series and L-Series, AO repeat function corrects the fault which does not operate normally.
  - In L-Series, if 2 is set to the argument of AioSetAoStopTrigger, 
    the fault to which 23260 errors return will be corrected. 
  - The fault which cannot perform the sampling start by a level trigger normally 
    by AI-1664LAX-USB is corrected. 
  - If AioStartAo, AioGetAoStatus, and AioStopAo are repeated in order 
    in DA12-16(PCI), DA12-8(PCI), DA12-4(PCI), and DAI16-4C(PCI), 
    it will correct that a sampling clock error may occur. 

  Ver.4.27 -> 4.30
  ----------------------------------------
  - It will correct that BSoD may occur, if AioSetAiStopTimes or AioSetAiRangeAll is performed in DEMO DEVICE. 
  - If AioGetCntMaxChannels is performed by the USB device which does not have a counter function, 
    although a counter function does not exist, the fault to which CntMaxChannels=1 returns will be corrected. 
  - If AioResetProcess is performed in the USB device which has a counter function, 
    the unfixed value which is not defined will correct the fault which returns as an error. 
  - In L-Series with the function of AI and AO both, if a sampling is started in order of AI and AO, 
    the fault stopped in the middle of the sampling of AI while status has been busy will be corrected. 
  - In AI-1204Z-PCI, if samples, such as SingleAi, are performed by a debug mode, 
    and a debugger is forced to terminate after performing AioInit, it will correct that BSoD may occur.

  Ver.4.25 -> 4.27
  ----------------------------------------
  - In PC which recognizes the memory of 4 GByte or more, execution of AioResetDevice will correct that 
    an error code 21985 may occur. 
  - It corrects that a pulse-like waveform may be outputted to instruction execution time 
    in AioInit or AioResetDevice by AIO-163202FX-USB.

  Ver.4.22-> 4.25
  ----------------------------------------
  - Fault correction that 11460 error code is generated, at the start of the second sampling in Windows 98.
  - Fault correction that FIFO is empty (data retrieved 0) does not return an error code 21584, 
    even at run-time state of AioGetAiSamplingData.

  Ver.4.21-> 4.22 (Web Release)
  ----------------------------------------
  - Fault correction that there is a possibility that BSoD occurs, 
    when execute a function after execution AioResetProcess, in multiple processes.

  Ver.4.20-> 4.21 (Web Release)
  ----------------------------------------
  - Z-Series and F-Series, on Windows 64bit OS, and has the memory more than 4G Byte,
    If you set more than 1MByte the buffer, so that the error returned by 21985 Fix 
    and AioSetAiMemorySize AioSetAiTransferData.
    PC in this condition, if you want to use the C-LOGGER Ver.1.27, you must use this version of the driver.

  Ver.4.11-> 4.20
  ----------------------------------------
  - Support WOW64 (Since Windows 7)
  - Fault correction that AioStartAi does not complete, 
    when it is executed in the order of AioMultiAi->AioStartAi with AI-1204Z-PCI.
  - Fault correction that function AioGetAiSamplingData can not acquire the data, 
    which's number is set by function AioSetAiStopTimes.
  - Fault correction that the sampling data can not be acquired successfully 
    by User buffer mode (bus master) in 64bit OS.
  - Fault correction that the application is exited without performed AioExit when sampling.
  - Fault correction that the sampling clock error is returned as a buffer overflow error,
    when a USB device is used with external clock.
  - Fault correction that memory leak occurs when AioStartAi is performed continuously 
    with a USB device.
  - When a count match event occurs with L-Series, the value passed to the parameter (lParam) of the event routine 
    is modified from current count value to the count value (comparison value) when event has occurred. 
  - Fault correction when the parameter PresetNumber of function AioSetCntPresetReg is changed and 
    funtion AioStartCnt is executed, even if a count match event doesn't occur, the count value is 
    changed to be the value set by parameter PresetNumber.
  - Fault correction that the data is interchanged between channels which is acquired by AioGetAiSamplingData etc., 
    when using AI-1604CI2-PCI (ADI16-4C(PCI)).
  - Fault correction that the internel clock of AIO-163202FX-USB can not be output to external.
  - Fault correction that AioGetCntMaxChannels can not be used with AIO-163202FX-USB.
  - Fault correction that the scan clock can not be set successfully and the sampling is to be unusually fast, 
    if the parameter AiScanClock of function AioSetAiScanClock is set a decimal point when using E-Series board.

  Ver.4.10 -> 4.11 (Web Release)
  ----------------------------------------
  - Fault correction when two or more USB devices including the other categories are used in the same process,
    the USB devices doesn't work normally.
  - Fault correction that the return value is 20001, when function 
    AioSetAiMemorySize/AioGetAiMemorySize is called for the devices which can 
    support the functions.
  - Fault in mixed use of a simple function and a sampling function is corrected at the time of AIO-163202FX-USB use. 

  Ver.4.01 -> 4.10 (API-USBP(WDM) Ver.4.60)
  ----------------------------------------
  - Add support development language
    Support language: Microsoft Visual Basic 2010
                      Microsoft Visual Basic 2010 Express Edition
                      Microsoft Visual C# 2010
                      Microsoft Visual C# 2010 Express Edition
                      Microsoft Visual C++ 2010
  - Add support device
    Support device:   AIO-121602LN-USB
                      AIO-120802LN-USB

  Ver.4.00 -> 4.01
  ----------------------------------------
  - Solves the problem that the function returns 20003 errors at multiprocessing. 
  - Under specific conditions "AoSpec.exe" to be used to hang fixes.

  Ver.3.90 -> 4.00 (API-USBP(WDM) Ver.4.40)
  ----------------------------------------
  - Add support OS (USB device)
    Support OS:       Microsoft Windows 7 64bit Edition
                      Microsoft Windows Server 2008 64bit Edition
                      Microsoft Windows Vista x64 Edition
                      Microsoft Windows Server 2003 x64 Edition
                      Microsoft Windows XP Professional x64 Edition
  - Add support device
    Support device:   AI-1664LAX-USB
  - Fault correction with the function declaration file of Visual Basic.NET
  - Fault correction that the return value is 0 (Normality completion), when function 
    AioSetAiMemorySize/AioGetAiMemorySize is called for the devices which can not 
    support the functions.
  - Fault correction that the acquisition value is always 0, when function AioGetAiStopTriggerCount 
    is called for DEMO board.
  - Fault correction that the clock is shorter than the specified value of function AioSetAiSamplingClock,
    when clock is set to be 1.4usec, 1.3usec, 0.9usec, 0.7usec.

  Ver.3.80 -> 3.90 (API-USBP(WDM) Ver.4.20)
  ----------------------------------------
  - Add support device
    Support device:   AO-1604LX-USB
  - Solve the problem that AioSetControlFilter function 
    doesn't work correctly.(AIO-163202FX-USB)
  - Solve the problem that the last data may collapse 
    when AD conversion is repeated.(AIO-163202FX-USB)
  - Solve the problem that the value of AioGetAiStopTriggerCount function becomes 0 
    after executing AioStopAi function.(L-Series)
  - Solve the problem that 23260 error occures when
    value 2 is set to AioSetAoStopTrigger function.(L-Series)

  Ver.3.70 -> 3.80 (Web Release 2010.04)
  ----------------------------------------
  - Solve the problem that the application locks up when 
    AioStartAi and AioStopAi functions are executed repeatedly.(AI-1204Z-PCI)
  - Solve the problem that 23341 error occurs when executing 
    AioSetAoStartTrigger function.

  Ver.3.62 -> 3.70 (API-USBP(WDM) Ver.4.10, Web Release 2009.11)
  ----------------------------------------
  - Add support OS
    Support OS:       Microsoft Windows 7
                      Microsoft Windows 7 64bit Edition (Except for USB device)
  - Solve the problem that the application locks up when 
    initialization->initiation->termination process is repeated twice.(AI-1204Z-PCI)
  - Solve the problem that 20003 error occurs when executing 
    AioInit after the application crashed.(AI-1204Z-PCI)
  - Solve the problem that overflow event doesn't ocuur.(AI-1204Z-PCI)
  - Solve the problem that sampling clock error status doesn't ocuur 
    when transfer process is not on time.(AI-1204Z-PCI)
  - Solve the problem that the last bainary data is set to 0 when acquireing data 
    under single-channel and odd number of sampling.(AI-1204Z-PCI)
  - Solve the problem that time interval of timer and 
    stopwatch is not correct.(AI-1204Z-PCI)
  - Solve some problems about RING memory mode.(AI-1204Z-PCI)

  Ver.3.61 -> 3.62 (API-USBP(WDM) Ver.4.00)
  ----------------------------------------
  - Solve the problem that hang-up may occurs when using
    AioGetAiSamplingData funcrion with RING memory.(E-Series)
  - Solve the problem that hang-up may occurs when executing
    AioInit, AioStartAo and AioExit funcrion repeatedly.(AO devices)
  - Solve the problem that 21960 error occurs when
    specifies device-buffer-mode by AioSetAiTransferMode function.(Z-Series)
  - Solve the problem that error occurs while hardware-installation
    on Windows 2000.

  Ver.3.52 -> 3.61 (Web Release 2009.05)
  ----------------------------------------
  - Solve the problem that 20001 error occures when setting 
    the function AioSetAiTransferMode, AioSetAoTransferMode, everytime.
  - Solve the problem that, under the state of "Wait the start trigger",
    the hang-up occurs when AioExit is performed (E-Series)
  - Solve the problem that overflow error was occured.(AI-1204Z-PCI).
  - Solve the problem that repeating operation software start - 
    stop conversion by the specified times, rock the devices(AI-1204Z-PCI).
  - Solve the problem that repeating operation AioStartAi - AioStopAi, 
    or AioStartAi - AioResetDevice, rock the devices(AI-1204Z-PCI).

  Ver.3.52 -> 3.60 (API-USBP(WDM) Ver.3.90)
  ----------------------------------------
  - Add support device
    Support device:   AIO-163202FX-USB

  Ver.3.51 -> 3.52 (Ver.Mar.2009)
  ----------------------------------------
  - Solve the problem in counter function of AIO-121601M-PCI.

  Ver.3.50 -> 3.51 (Web Release 2009.02)
  ----------------------------------------
  - Add support OS
    Support OS:       Microsoft Windows Server 2008
                      Microsoft Windows Server 2008 64bit Edition (Except for USB device)

  Ver.3.47 -> 3.50 (Ver.Jan.2009)
  ----------------------------------------
  - Add support development language
    Support language: Microsoft Visual C++.NET C++/CLI
  - Add support device
    Support device:   AIO-121601M-PCI
  - Add new functions
    AioGetCntmMaxChannels
    AioSetCntmZMode, AioSetCntmZLogic 
    AioSelectCntmChannelSignal, AioSetCntmCountDirection
    AioSetCntmOperationMode, AioSetCntmDigitalFilter
    AioSetCntmOutputHardwareEvent, AioSetCntmInputHardwareEvent 
    AioSetCntmCountMatchHardwareEvent, AioSetCntmPresetRegister
    AioGetCntmZMode, AioGetCntmZLogic
    AioGetCntmChannelSignal, AioGetCntmCountDirection
    AioGetCntmOperationMode, AioGetCntmDigitalFilter
    AioCntmStartCount, AioCntmStopCount
    AioCntmPreset, AioCntmZeroClearCount
    AioCntmReadCount
    AioCntmNotifyCountUp, AioCntmStopNotifyCountUp
    AioCntmCountUpCallbackProc, AioCntmNotifyCounterError
    AioCntmStopNotifyCounterError, AioCntmCounterErrorCallbackProc
    AioCntmNotifyCarryBorrow, AioCntmStopNotifyCarryBorrow
    AioCntmCarryBorrowCallbackProc, AioCntmNotifyTimer
    AioCntmStopNotifyTimer, AioCntmTimerCallbackProc
    AioSetCntmTestPulse, AioCntmReadStatusEx
    AioCntmInputDIByte, AioCntmOutputDOBit

  Ver.3.46 -> 3.47 (Web Release 2008.10)
  ----------------------------------------
  - Solve the problem that when set External clock, and set internal clock.
    Next, start sampling by external clock, sampling clock error was occured.(AI-1204Z-PCI).

  Ver.3.45 -> 3.46 (Ver.Oct.2008)
  ----------------------------------------
  - Solve the problem that when continuous sampling like sample AiLong, 
    sampling is stopped (DEMO device and devices other than F-Series, L-Series, E-Series)
  - Add the function that when operating sampling used ring memory, 
    it is able to get a sampling data(E-series).
  - Solve the problem that repeating operation AioStartAi - AioStopAi, 
    or AioStartAi - AioResetDevice, rock the devices(AI-1204Z-PCI).
  - Solve the problem that using Busmaster, sampling data is odd data
    (Busmaster device).
  - Solve the problem that events are not occured by setteing condition.
  - Support API-TIMER(WDM).

  Ver.3.44 -> 3.45 (Web Release 2008.07)
  ----------------------------------------
  - Add support development language
    Support language: Microsoft Visual Basic 2008
                      Microsoft Visual Basic 2008 Express Edition
                      Microsoft Visual C# 2008
                      Microsoft Visual C# 2008 Express Edition
                      Microsoft Visual C++ 2008
  - Solve the problem that the output does not wait for the next repeat operation 
    and the output progresses if the conditions for multiple repeat and external trigger start are set 
    (devices other than F-Series, L-Series, E-Series).

  Ver.3.43 -> 3.44 (Web Release 2008.05)
  ----------------------------------------
  - Solve the problem that if using the function AioSetAiRange, and AioSetAiRangeAll,
    it is not able to get correct sampling data from devices(F-Series, L-Series).

  Ver.3.42 -> 3.43 (Web Release 2008.05)
  ----------------------------------------
  - Solve the problem that Diagnosis Program can't be operated normally,
    when using CPU-CA10+FIT device with AI-1608AY-USB or AIO-160802AY-USB.
  - Solve the problem that API Functions for AI-1608AY-USB or AIO-160802AY-USB
    can't be operated normally, when using CPU-CA10+FIT device 
    with AI-1608AY-USB or AIO-160802AY-USB.

  Ver.3.41 -> 3.42 (Web Release 2008.04)
  ----------------------------------------
  - Solve the problem that a calibration program can't be ,
    and returns 22204 error (ADA16-32/2(CB)F).
  - Solve problems that it changes to unlimited Repeat, 
    and the callback setting, and call AioStopAi on sampling,
    application hangs irregularly.
  - Solve the problem when sampling Memory full, it is not able to 
    get sampling data from devices.

  Ver.3.40 -> 3.41 (Ver.Apr.2008)
  ----------------------------------------
  - Solve the problem that the level trigger setting is not reflected
    when using USB-devices.
  - Solve the problem that the event could not be raised and the operation stops
    due to overflow when performing continuous sampling input 
    by using repeat and after a certain number of times.
    (DEMO device and devices other than F-Series, L-Series, E-Series)
  - Solve the problem that does not work properly when repeat setting is performed (L-Series).
  - The mistake device name were corrected
    (AI-1664LA-LPE, AO-1608L-LPE, AO-1616L-LPE). 
  - AI-1204Z-PCI supports the following functions
    AioSetAiStartInRangeEx, AioGetAiStartInRangeEx
    AioSetAiStartOutRangeEx, AioGetAiStartOutRangeEx
    AioSetAiStopInRangeEx, AioGetAiStopInRangeEx
    AioSetAiStopOutRangeEx, AioGetAiStopOutRangeEx
  - Solve the problem that 21440 error occures when
    using the function AiSamplingClock set 10usec everytime
    (ADA16-8/2(CP)L, AD16-64(LPCI)LA, AI-1664LA-LPE).

  Ver.3.31 -> 3.40 (Ver.Jan.2008 for AIO)
  ----------------------------------------
  - Add support device
    Support device:   AI-1204Z-PCI
                      AIO-160802LI-PE
                      AI-1616LI-PE
                      AO-1604LI-PE
                      AI-1664LA-LPE
                      AO-1608L-LPE
                      AO-1616L-LPE

  Ver.3.30 -> 3.31 (Web Release 2008.01)
  ----------------------------------------
  - Solve the problem that the dialog of "DeviceType Unknown Error" is displayed
    when using AD12-8(PM) using on the property  page on the device manager. 
  - Solve the problem that OS hangs when using DEMO Device

  Ver.3.21 -> 3.30 (Ver.Jan.2008)
  ----------------------------------------
  - Solve the problem that the number of handle on the task manager 
    increases every time the application is operated. 
  - Solve the problem that a calibration program can't be adjusted,
    and returns 22204 error(L-Series).
  - Solve the problem that 20001 error occures when setting 
    the function AioSetDiFilter, AioGetDiFilter, everytime.
  - Solve the problem that correct Range can't be set 
    by the function AioSetAiRange, AioSetAiRangeAll.

  Ver.3.20 -> 3.21 (Web Release 2007.10)
  ----------------------------------------
  - Solve the problem that occures while using ACX-PAC(W32)

  Ver.3.10 -> 3.20 (Ver.Oct.2007)
  ----------------------------------------
  - Add support development language
    Support language: Microsoft Visual Basic 2005 Express Edition
                      Microsoft Visual C# 2005 Express Edition
  - Add support device
    Support device:   AIO-121601E3-PE
                      AIO-121601UE3-PE
                      AIO-161601E3-PE
                      AIO-161601UE3-PE
  - Solve the problem that 21061 error occures when
    setting the function AioSetAiRangeAll everytime (E-Series).
  - Solve the problem that the dialog of "DeviceType Unknown Error" is displayed
    when using DemoDevice using on the property  page on the device manager. 
  - Solve problems that it changes to Ring memory form, a limited sampling, 
    and the callback setting using USB-devices, and AiStart is repeated,
    sampling operation stoped.

  Ver.3.00 -> 3.10 (Ver.Jun.2007)
  ----------------------------------------
  - Add support OS (Except for USB device)
    Support OS:       Microsoft Windows Vista x64 Edition
                      Microsoft Windows Server 2003 x64 Edition
                      Microsoft Windows XP Professional x64 Edition
  - Add support device
    Support device:   AI-1216B-RB1-PCI
                      AI-1216B-RU1-PCI

  Ver.2.30 -> 3.00 (Ver.Feb.2007)
  ----------------------------------------
  - Add support OS
    Support OS:       Microsoft Windows Vista
  - Add support device
    Support device:   AIO-121602AH-PCI
                      AIO-121602AL-PCI
                      AI-1216AH-PCI
                      AI-1216AL-PCI
  - Add digital-signing to device driver
  - Add device driver auto-installation function (W2000 series only)
  - Add version check of DLL and SYS function
  - Support standby mode
  - Add new functions
    AioResetProcess, AioStartAiSync
    AioSetAiStartInRangeEx, AioGetAiStartInRangeEx
    AioSetAiStartOutRangeEx, AioGetAiStartOutRangeEx
    AioSetAiStopInRangeEx, AioGetAiStopInRangeEx
    AioSetAiStopOutRangeEx, AioGetAiStopOutRangeEx
  - Add utility for Visual Studio.NET
  - Solve the problem that OS hangs when using DEMO Device
  - Solve the problem that sometimes  AD or DA conversion error 
    occures when using simple functions (other than F-Series and L-Series)
  - Solve the problem that OS hangs by clicking AioGetAiSamplingData
    when using CAIOSPEC.EXE (E-Series)
  - Solve the problem that motion doesn't complete unless one more
    sampling clock number which is specified (other than E-Series, F-Series and L-Series)
  - Solve the problem that data misalignment occures among channels
    under conditions of using multi channels, external trigger start,
    stop conversion by the specified times and multiple repeat times (L-Series)

  Ver.2.20 -> 2.30 (Web Release 2006.12)
  ----------------------------------------
  - Solve the problem that AioGetAiSamplingCount function may
    return invalid value on multi-core CPU (E-Series)
  - Shorten the execution time and reduce the time variation of
    AioStartAi, AioStartAo, AioStartTmTimer and AioStartCnt function
  - Solve the problem that the event that specified number of data are stored
    may not occur depend on the process conditions

  Ver.2.10 -> 2.20 (Web Release 2006.09)
  ----------------------------------------
  - Solve the problem that occures while using ML-DAQ

  Ver.1.90 -> 2.10 (Ver.Aug.2006)
  ----------------------------------------
  - Add support device
    Support device:   AIO-160802L-LPE
                      AI-1616L-LPE
                      AO-1604L-LPE

  Ver.1.80 -> 1.90 (Ver.Apr.2006)
  ----------------------------------------
  - Add support development language
    Support language: Microsoft Visual Basic 2005
                      Microsoft Visual C# 2005
                      Microsoft Visual C++ 2005
  - Add support device
    Support device:   AIO-163202F-PE
                      DA16-8(LPCI)L
                      DA16-4(LPCI)L

  Ver.1.70 -> 1.80 (Ver.Feb.2006)
  ----------------------------------------
  - Support C-LOGGER Ver.1.0

  Ver.1.60 -> 1.70 (Ver.Nov.2005)
  ----------------------------------------
  - Add support device
    Support device:   AD12-16(PCI)EV
                      AD12-16U(PCI)EV
                      AD16-16(PCI)EV
                      AD16-16U(PCI)EV
                      AD16-64(LPCI)LA

  Ver.1.50 -> 1.60 (Ver.Aug.2005)
  ----------------------------------------
  - Add support OS
    Support OS:       Microsoft Windows Server 2003
  - Add support device
    Support device:   ADAI16-8/2(LPCI)L
                      ADI16-16(LPCI)L
                      DAI16-4(LPCI)L
  - Add new functions
    AioSetAiClockEdge, AioGetAiClockEdge
    AioSetAoClockEdge, AioGetAoClockEdge

  Ver.1.42 -> 1.50 (Ver.Apr.2005)
  ----------------------------------------
  - Support MATLAB Data Acqiosition Toolbox

  Ver.1.41 -> 1.42 (Web Release 2005.01)
  ----------------------------------------
  - Solve the problem that an automation error occurs
    while using ACX-AIO.

  Ver.1.40 -> 1.41 (Ver.Jan.2005)
  ----------------------------------------
  - Support Hyper-Threading PC
  - Solve the problem that diagnosis program occurs error code 4
    occasionally with PCI boards
  - Solve the problem that acquired data become misaligned
    between each channels when using multi channels (L-Series)

  Ver.1.31 -> 1.40 (Ver.Oct.2004)
  ----------------------------------------
  - Add support device
    Support device:   ADA16-8/2(CB)L
  - Solve the problem that gain adjustment cannot do 
    a calibration program manually.
    (F-Series, ADA12-8/2(LPCI), AD16-16(LPCI)L)

  Ver.1.30 -> 1.31 (Ver.Jun.2004)
  ----------------------------------------
  - Add support development language
    Support language: Microsoft Visual C#.NET 2002
                      Microsoft Visual C#.NET 2003
  - Support scan clock setting (E-Series, F-Series)
  - Support acquiring substrate temperature (ADI16-4L(PCI))
  - Solve the problem that AI motion does not stop normally
    if stop condition is changed by AioSetEcuSignal function
    (F-Series)
  - Solve the problem that AO motion does not stop normally
    if stop condition is changed by AioSetEcuSignal function
    (F-Series)
  - Solve the problem that the falling edge can't be specified
    when using external trigger start or stop mode
    (AD12-64(PCI), AD12-16(PCI))
  - Solve the problem that Lap value of AioGetAiTransferLap
    becomes unusual when transfering more than 64Mb data in
    bus master mode (F-Series)
  - Solve the problem that AioSetAiChannelSequence is invalid
    to AioMultiAi function (E-Series)

  Ver.1.21 -> 1.30 (Ver.Nov.2003)
  ----------------------------------------
  - Add support device
    Support device:   ADA16-8/2(LPCI)L
                      AD16-16(LPCI)L
                      DA16-4(LPCI)L

  Ver.1.20 -> 1.21 (Web Release 2003.06)
  ----------------------------------------
  - The following functions are added to uninstaller
    Delete setup information files that reproduced by the system
    Delete the device registered into the device manager
  - Solve the problem that a diagnostic program forces to terminate
    when a range is made a uni-Poral setup (E-Series)
  - Solve the problem which will be forced to terminate
    if x button is pushed during operation by AiSpec and AoSpec
  - Solve the problem which may be unable to set up a value normally
    with AiSetAiSamplingClock and AiSetAoSamplingClock function
    is corrected (all devices)
  - Solve the problem that DI data is not appended 
    (F-Series)
  - Solve the problem that will hang-up if AioExit function is performed
    inputting an external trigger continuously by Ai and Ao function
    (F-Series)
  - Solve the problem that cannot set up any ranges other than
    -10V - +10V or 0V - +10V and 4mA - 20mA with AioSetAiRangeAll function
    (ADI12-16(PCI))
  - Solve the problem that an omission generates to output data
    when a repeat output function is used by the RING memory
    (DA12-16(PCI), DA12-8(PCI), DA12-4(PCI))
  - Solve the form error of AioSetAiChannelSequence and AioGetAiChannelSequence
    (CAIO.BAS, CAIO.VB, CAIO.PAS)

  Ver.1.10 -> 1.20 (Web Release 2003.03)
  ----------------------------------------
  - Support English OS, Language, Tools
  - CAIO.DLL is sharable between API-AIO(WDM) and API-USBP(WDM)
  - Solve the problem that the converted data isn't right (AD16-4L(PCI))
  - Solve the problem in sample AiEx 
    that the converted data in saved file is broken
  - Solve the problem that error occurs in
    AioSetAiStartInRange, AioSetAiStartOutRange,
    AioSetAiStopInRange and AioSetAiStopOutRange functions
  
  Ver.1.04 -> 1.10 (Ver.Dec.2002)
  ----------------------------------------
  - Add support development language
    Support language: Microsoft Visual C++.NET
                      Microsoft Visual Basic.NET
  - Add support device
    Support device:   ADA16-32/2(PCI)F
                      ADA16-32/2(CB)F
  - Add new functions
  - Add new samples
  - Solve the problem that the application is locked if other functions
    are used when the AioInit function failed (all devices)
  - Solve the problem that AioInit function succeeds even if the board JP
    is in the state that the interrupt is disabled (E-Series)
  - Solve the problem that the system exceptionally hangs up when the sampling clock error
    occurs because of the high-speed operation of analog I/O (all devices)
  - Add NULL check and error code to functions AioQueryDeviceName and
    AioGetDeviceType(all devices)
  - Solve the problem that error occurs when channel 0 is specified for
    AioEnableAo and AioDisableAo (DAI16-4C(PCI))
  - Solve the problem that multi-channel output is abnormal (DAI16-4C(PCI))
  - Solve the problem that "Normality completion" is returned even if
    10820 error occurs(E-Series)
  - Correct the driver in order to return error when function AioStartAi
    is executed without resetting the memory after buffer overflow error
    occurs(all devices)
  - Solve the problem that AD conversion error exceptionally occurs
    in function AioSingleAi (AD16-16U(PCI)EH)
  - Solve the problem that the ranges other than +/-10V, 0 to 10V and
    4mA to 20mA can not be set (ADI12-16(PCI))
  - Solve the problem that D/A conversion error exceptionally occurs in
    both function AioSingleAo and function AioMultiAo(DA12-16(PCI),
    DA12-8(PCI), DA12-4(PCI))
  - Solve the problem that the used handle is not opened when
    AioStartAi is performed (E-Series)
  - Solve the problem that graph drawing of both utility AiSpec and
    utility AoSpec does not support multi-channels(AD12-16U(PCI)EH, AD16-16U(PCI)EH)
  - Solve the problem that the old data is acquired in function AioSingleAi
    (ADI16-4C(PCI))
  - Solve the problem that +/-2.5V can not be set in function AioSetAiRange
    (AD12-16U(PCI)EH)

  Ver.1.03 -> 1.04 (Ver.Aug.2002)
  ----------------------------------------
  - Make modifications in order that the failure in retrieving
    the sampling count is more difficult to come off (E-Series)
  - Solve the problem that the sampling clock error occurs
    at the 65535th time of event if you perform the operation
    in sample AiLong(E-Series)
  - Solve the problem that the converted data cannot be acquired
    normally from expansion channels when channels have been expanded
    (E-Series)
  - Solve the problem that W9x cannot start up as the card is plugged
    when you use cards on a note PC(AD12-8(PM))
  - Solve the problem that the raising of sampling clock causes
    the memory violation(AD12-8(PM))
  - Solve the problem that the incorrect converted data are acquired
    when the sampling clock is speeded to 10usec or so(AD12-8(PM))
  - Solve the problem that the sampling clock cannot be changed
    when external start trigger is used(DA12-16(PCI), DA12-8(PCI), DA12-4(PCI))

  Ver.1.02 -> 1.03 (Web Release 2002.02)
  ----------------------------------------
  - Add driver update method to help
  - Add tutorial for simple digital I/O to help
  - The JP setting and pin assignment is illustrated in
    Driver Specifications-Specifications based on devices of help(Japanese only)
  - Solve the problem that, if the sample AiLong is used on W9x,
    the event doesn't occur when "Event that the specified number
    of data are stored" occurs and the window is moved
  - Solve the problem that the system hangs in sample MultiAo(AD12-8(PM))
  - Solve the problem that the data is incorrect in sample MultiAi
    (AD12-8(PM))
  - Solve the problem that the practical conversion speed is abnormal
    and data is incorrect in sample AiEx(AD12-8(PM))
  - Solve the problem that the status "Device is running" doesn't
    become OFF if the sampling times is set to 1
  - Correct the sample programs
  - Take out the description mistakes in help

  Ver.1.01 -> 1.02
  ----------------------------------------
  - Solve the problem that the driver cannot be used on W2000
    if you login as a user
  - Solve the problem that 0 is returned instead of 21441
  - Solve the problem that "Store up to the specified number
    of data" status doesn't become OFF even if retrieving data
    is performed (E-Series)
  - Solve the problem that, under the state of "Wait the start trigger",
    the error 21480 occurs when AioStopAi is performed (E-Series)
  - Correct the sample programs
  - Take out the description mistakes in help

  Ver.1.00 -> 1.01
  ----------------------------------------
  - Solve the problem that the repeat operation cannot be performed normally
    (E-Series)
  - Make modifications in order that "Event that repeat end" is not fired
    when the repeat operation completely finished (E-Series)
  - Make modifications in order that the clock error set by driver is
    reset by AioResetAiStatus or AioStartAi (E-Series)
  - Solve the problem that not only clock error occurs, but also conversion
    termination event occurs when the conversion speed is too fast, the driver
    cannot process them in time (E-Series)

  Ver.1.00 (Ver.Jan.2002)
  ----------------------------------------
  - First release


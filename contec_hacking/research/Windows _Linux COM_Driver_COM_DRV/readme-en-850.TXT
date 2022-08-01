
=========================================================
            Serial Communication Driver
                        COM-DRV(W32) Ver.8.50
                               CONTEC Co., Ltd.
=========================================================


- Contents
===========
 Introduction
 Specification
 Restrictive Matter
 Hardware Setup
 
 Install
 Cautions
 Career at version up


- Introduction
===============
 Thank you for purchasing this product.

  COM-DRV (W32) is software that enables you to use our serial communication boards
  such as PCI bus board and PCI Express bus board on Windows in the same way as the COM port of the personal computer.
  This makes it possible to perform various serial communications on Windows.


- Specification
===============
 Applicable OS:

 COM-DRV(W32)
             Microsoft Windows 10

 COM-DRV(W64)
             Microsoft Windows 11
             Microsoft Windows 10
             Microsoft Windows 10 IoT Enterprise LTSC 2021
             Microsoft Windows 10 IoT Enterprise 2019 LTSC
             Microsoft Windows 10 IoT Enterprise LTSB 2016
             Microsoft Windows Server 2022
             Microsoft Windows Server 2019
             Microsoft Windows Server 2016

 MAX ports:  256 ports

 Supported architecture: x86
                         x64

 Applicable boards:
             PCI Bus Board
                COM-1(LPCI)H, COM-2(LPCI)H, COM-4(LPCI)H, 
                COM-1PD(LPCI)H, COM-2PD(LPCI)H, 
                COM-2P(PCI)H, COM-4P(PCI)H, 
                COM-2(PCI)H, COM-4(PCI)H, COM-8PD(PCI)H, 
                COM-2PD(PCI)H, COM-4PD(PCI)H,
                COM-2(PCI), COM-4(PCI), COM-8(PCI), COM-2PD(PCI),
                COM-2CL-PCI, COM-4CL-PCI
             PCI Express Bus Board
                COM-1C-LPE, COM-2C-LPE, COM-4C-LPE,
                COM-2C-PE, COM-4C-PE, COM-8C-PE,
                COM-2PC-PE, COM-4PC-PE,
                COM-2PD-PE, COM-4PD-PE,
                COM-2PD-LPE, COM-1PDH-LPE
             CONPROSYS
                CPS-COM-1PC, CPS-COM-2PC, CPS-COM-1PD, CPS-COM-2PD
             BX-M210 GPIOmodel
                COM-1C, COM-1D

 Applicable controller:
             Box Computer
                CPS-BXC200


- Restrictive Matter
=====================
 - When using API-SIO (98/PC) NT, do not install the board from the attached media.
   If you install the board from the attached media, you cannot use API-SIO (98/PC) NT.


- Hardware Setup
================
  For details such as the position of the switches and jumpers, please refer to the Board of Reference.

  (1)COM-2(PCI), COM-4(PCI), COM-8(PCI), 
     COM-2(PCI)H, COM-4(PCI)H, COM-8(PCI)H,
     COM-1(LPCI)H, COM-2(LPCI)H, COM-4(LPCI)H, 
     COM-2P(PCI)H, COM-4P(PCI)H,
     COM-1C-LPE, COM-2C-LPE, COM-4C-LPE,
     COM-2CL-PCI, COM-4CL-PCI,
     COM-2C-PE, COM-4C-PE, COM-8C-PE,
     COM-2PC-PE, COM-4PC-PE
     - BOARD ID setting
         The BOARD ID can be set within the following range: 0 to F
         (Only COM-4(PCI): 0 to 7)
  (2)COM-2PD(PCI), COM-2PD(PCI)H, COM-4PD(PCI)H,
     COM-1PD(LPCI)H, COM-2PD(LPCI)H, 
     COM-2DL-PCI, COM-4DL-PCI,
     COM-2PD-PE, COM-4PD-PE,
     COM-2PD-LPE, COM-1PDH-LPE
     - BOARD ID setting
         The BOARD ID can be set within the following range: 0 to F
     - Transfer mode and terminator setting
         The following settings are available:
              > Full duplex (RTS and CTS connected)
              > Full duplex (RTS and CTS not used)
              > Half duplex
              > Terminator inserted
              > Terminator not inserted


- Cautions
==========
 - Setting COM ports
    You can set up the COM ports(data bits, parity, ...), using 
    "Ports in Control Panel" or "Mode command in Command Prompt".
    However COM application useally sets up these parameters.

 - About RAS and UPS
    You can use of "Remote Access Service(RAS)" and "Uninterruptible 
    Power Supply(UPS)".
    See the "On Line Help" in the Windows XX or "Windows XX set up 
    guide" for details such as RAS and UPS setting.
 - Programing
    You can use of Win32 COMM API and Communication Control.
    It supports the SerialPort class of .Net Framework 4.0 or later.
    However you can not use SerialPort in half-duplex.
    It supports pySerial 3.4.
    See the language references (Visual C++, Win32SDK, Visual C#.NET, Visual Basic.NET, 
    ...) for details such as API specification.

 - Range of the baud rate(bps)
   >COM-2(PCI)H, COM-4(PCI)H, COM-8(PCI)H, 
    COM-1(LPCI)H, COM-2(LPCI)H, COM-4(LPCI)H, 
    COM-1PD(LPCI)H, COM-2PD(LPCI)H, 
    COM-2PD(PCI)H, COM-4PD(PCI)H,
    COM-2PD(PCI), COM-2PD(PC)H,
    COM-1C-LPE, COM-2C-LPE, COM-4C-LPE
    COM-2C-PE, COM-4C-PE, COM-8C-PE,
    COM-2PC-PE, COM-4PC-PE,
    COM-2PD-PE, COM-4PD-PE,
    COM-2PD-LPE, COM-1PDH-LPE, 
    CPS-COM-1PC, CPS-COM-2PC, CPS-COM-1PD, CPS-COM-2PD
     15-921600 (bps)
      Ex.)
      50, 75, 150, 300, 600, 1200, 1800, 2400, 3600, 4800, 7200, 9600,
      14400, 19200, 28800, 38400, 57600, 115200, 230400, 460800, 
      921600
   >COM-2(PCI),COM-4(PCI),COM-8(PCI)
     4-921600 (bps)
      Ex.)
      50, 75, 150, 300, 600, 1200, 1800, 2400, 3600, 4800, 7200, 9600,
      14400, 19200, 28800, 38400, 57600, 115200, 230400
   >COM-2CL-PCI, COM-4CL-PCI
     15-230400 (bps)
      Ex.)
      50, 75, 150, 300, 600, 1200, 1800, 2400, 3600, 4800, 7200, 9600,
      14400, 19200, 28800, 38400, 57600, 115200, 230400
   >COM-1C, COM-1D
     50-115200 (bps)
      Ex.)
      50, 75, 150, 300, 600, 1200, 1800, 2400, 3600, 4800, 7200, 9600,
      14400, 19200, 28800, 38400, 57600, 115200
   
   - Upper limit of the baud rate
     The upper limit of the baud rate which can be set is dependent 
     on the processing capacity(operating rate) and load(simultaneous
     execution with another program, etc.) of the PC in use. 
     Communications at a rate higher that the upper limit will cause 
     communications errors(overrun, parity, framing).  Check the baud
     rate which can be set by actually conducting communications 
     using one of the "Hiper Terminal" utility with operating system.

    - Setting Half-duplex  
     Use Win32 API to set [RTS_CONTROL_TOGGLE] in the fRtsControl member of
     the DCB stucture.
     But, fRtsControl cannot set for Develop language. 
     Then, we wrote how to set half-duplex communication forcedly.

      1: [DeviceManeger]->[Ports(LPT&COM)]->[CONTEC Communication Port].
      2: [Setting Port]->[Advanced]->[Half duplex] check on.
      3: Reboot Operation System.
      
     This Setting Port Communicates half-duplex.

- Install
=========
 - This product install the files in the System directory and 
   "CONTEC" directory. 
   And, if another API-TOOL drivers have already been installed, the 
   files will be installed in that directory.


- Career at version up
=======================
 Ver.8.50  2022/03 
 ----------------------------------------
 - Add support OS
   Support OS:       Microsoft Windows Server 2022  (64bit)

 Ver.8.40  2022/01 
 ----------------------------------------
 - Add support device
   Support device: COM-1C
                   COM-1D

 Ver.8.30  2022/01 
 ----------------------------------------
 - Add support development language
   Support language: Python 3.10(pySerial 3.5)
 - Checked the operation on Windows 10 21H2.
 - Add support OS
   Support OS:       Microsoft Windows 10 IoT Enterprise LTSC 2021

 Ver.8.20  2021/12 
 ----------------------------------------
 - Add support OS
   Support OS:       Microsoft Windows 11  (64bit)

 Ver.8.11  2021/11 
 ----------------------------------------
 - Fixed a bug that half-duplex communication may not be performed normally.
   Target device: CPS-COM-1PC
                  CPS-COM-2PC
                  CPS-COM-1PD
                  CPS-COM-2PD

 Ver.8.10  2021/06 
 ----------------------------------------
 - Checked the operation on Windows 10 21H1.
 - Fixed a bug that BSoD may occur when the COM port is deleted and re-registered.

 Ver.8.00  2021/04 
 ----------------------------------------
 - Add support development language
   Support language: Python 3.9(pySerial 3.5)
 - Revise the support OS
   Support OS:       Microsoft Windows Server 2019   (64bit)
                     Microsoft Windows Server 2016   (64bit)
                     Microsoft Windows 10            (32bit/64bit)

 Ver.7.20  2020/12 
 ----------------------------------------
 - Checked the operation on Windows 10 20H2.
 - Supported Windows 10 security policy (memory integrity).
 - Revise the support OS
   Support OS:       Microsoft Windows 10            (32bit/64bit)
                     Microsoft Windows 8.1           (32bit/64bit)
                     Microsoft Windows 7             (32bit/64bit)
                     Microsoft Windows Server 2019   (64bit)
                     Microsoft Windows Server 2016   (64bit)
                     Microsoft Windows Server 2012R2 (64bit)

 Ver.7.10  2020/09 
 ----------------------------------------
 - Add support development language
   Support language: Python 3.8(pySerial 3.4)

 Ver.7.00  2020/07 
 ----------------------------------------
 - Checked the operation on Windows 10 2004.

 Ver.6.90  2019/12 
 ----------------------------------------
 - Checked the operation on Windows 10 19H2.

 Ver.6.80  2019/12
 ----------------------------------------
 - Begin support OS for Windows Server 2019.

 Ver.6.71  2019/10
 ----------------------------------------
 - Fixed a bug that may not close normally.

 Ver.6.70  2019/06/24 
 ----------------------------------------
 - Checked the operation on Windows 10 19H1.

 Ver.6.62  2018/11/21 
 ----------------------------------------
 - Add support Board.
   CPS-COM-1PC, CPS-COM-2PC, CPS-COM-1PD, CPS-COM-2PD [ Support OS: Windows 10 IoT Enterprise LTSB2016 64bit ]

 Ver.6.61  2017/10/20 
 ----------------------------------------
- Begin support OS for Windows Server 2016.

 Ver.6.60  2017/08/04 
 ----------------------------------------
 - Add support Board.
   COM-2PD-LPE, COM-1PDH-LPE [ Support OS: Windows 7 later / Windows Server 2008 later ]

 Ver.6.50  2017/03/13 
 ----------------------------------------
- Supports "Driver Signing policy changes in Windows 10".
- Corresponds to the baud rate setting below the decimal point.

 Ver.6.42  2015/12/09 
 ----------------------------------------
- Begin support SHA-2 signature.
- Begin support VB.NET/VCS sample for VB2015/VCS2015.

 Ver.6.41  2015/11/10 
 ----------------------------------------
- Begin support OS for Windows 10.

  Ver.6.40  2014/08/31
 ----------------------------------------
  - Add support Board.
   COM-8C-LPE, COM-8C-LPCI [ Support OS: Windows Vista later / Windows Server 2008 later ]

 Ver.6.35  2014/08/06
 ----------------------------------------
- After you set "Use Serial Mice", the driver can not transfer the data from PC to SerialMice.
  It was corrected.  

 Ver.6.34  2014/01/30 
 ----------------------------------------
- Begin support OS for Windows 8.1.
- Begin support OS for Windows Server 2012 R2.
- Driver (comdrv2k.sys) is not changed from Ver.6.33.

 Ver.6.33  2013/02/04 
 ----------------------------------------
- Begin support OS for Windows 8.
- Begin support OS for Windows Server 2012.

 Ver.6.32  2012/10/19 
 ----------------------------------------
- Begin support OS for Windows Server 2008 R2.
- [Use Serial Mice] from Driver's Property cannot change success.
  It was corrected.

 Ver.6.31  2010/11/19 [COM Setup Disk 2.10]
 ----------------------------------------
- Correct the error in the install document of Windows 7.
- At specific PC which was installed with Windows 7, [This operation 
  requires an interactive window station] is shown, and board can't be installed.
  It was corrected.
- In the case of half duplex communication, communication is abnormal.
  It was corrected.
    [COM-2CL-PCI,COM-4CL-PCI only.]
- When OS is starting up, if data is received, communication is abnormal.
  It was corrected.
    [COM-4(PCI)H only.]
    [This phenomenon will not occur at the driver of Ver.6.22 and earlier.]
- At specific PC, after board is opened, after a while, close it, then OS will be blue screen.
  It was corrected.
    [This phenomenon will not occur at the driver of Ver.6.22 and earlier.]
- At specific PC, when doing serial communication, when the state was changed to be suspend state,
  the screen is balck and can't return.
  It was corrected.
    [This phenomenon will not occur at the driver of Ver.6.22 and earlier.]

 Ver.6.30  2009/12/28
 ----------------------------------------
- Begin support OS for Windows 7.
- Begin support OS for Windows 64bit Operating System.

 Ver.6.24  2009/04/30
 ----------------------------------------
- Begin support OS for Windows Server 2008.
- Add [Use Serial Mice] from Driver's Property.

 Ver.6.23  2008/10/11
 ----------------------------------------
 - When Starting OS , PC shutdown after install device driver.
   It was corrected.
    [COM-2CL-PCI,COM-4CL-PCI.COM-2DL-PCI,COM-4DL-PCI only.]
    [Windows Vista or later.]

 Ver.6.22  2007/12/28 [COM SETUP DISK 1.90]
 ----------------------------------------
 - The data with parity bit sends and this data with different parity was received.
   At this time received data is vanished. It was corrected. [Windows 2000/XP/Server 2003/Vista]

 Ver.6.21  2007/09/05
 ----------------------------------------
 - When COM-4(PCI)H with BX700-PC send or receive larger than 128 byte,cannot send/receive a data.
   It was corrected. [Windows 2000/XP/Server 2003/Vista]
 
 Ver.6.20  2007/08/24  [COM SETUP DISK 1.80]
 ----------------------------------------
 - Add support Board.
   COM-2C-PE, COM-4C-PE, COM-8C-PE, COM-2PC-PE, COM-4PC-PE,
   COM-2PD-PE, COM-4PD-PE
 - When Device Driver reinstall,"Contec Communication Port" device cannot install.
   It was corrected.[Vista only]
  
 Ver.6.12  2007/06/26
 ----------------------------------------
 - When Starting OS, PC shutdown after install device driver.
   It was corrected.
    [Used COM-2CL-PCI,COM-4CL-PCI.COM-2DL-PCI,COM-4DL-PCI user]

  Ver.6.11  2007/06/11
 ----------------------------------------
 - When Starting OS, PC hanged up after install device driver.
   It was corrected.
    [Used COM-2CL-PCI,COM-4CL-PCI.COM-2DL-PCI,COM-4DL-PCI user]
 
  Ver.6.10  2007/05/02
 ----------------------------------------
 - Add support Board.
   COM-2DL-PCI, COM-4DL-PCI
   COM-1PD(FIT)GY (Only device driver is changed) [Only 95,98,Me]
   
  Ver.6.00  2007/03/01
 ----------------------------------------
 - Begin support OS for Windows Vista.
 - Add support Board.
   COM-2CL-PCI, COM-4CL-PCI

  Ver.5.21  2006/10/24 
 ----------------------------------------
 - When you used GetCommproperties in RS422A/485 products, value of dwProvSubType becomes PST232C.
   It was corrected.
 
 Ver.5.20  2006/10/01 
 ----------------------------------------
 - OS hang up, when Interrupt signals send at high frequency and OS is started.
   It was corrected.[Only XP,2000,Server 2003]
 - It recognizes as "serial mouse",when equipment send signals and OS is started.
   It was corrected.[Only XP,2000,Server 2003]
 - CommChk.exe is corrected.
 
 Ver.5.10  2005/11/02 [COM SETUP DISK Ver1.50]
 ----------------------------------------
 - Begin support OS.
      Windows Server 2003
   Therefore, we upgraded the uninstaller and CTstCom.exe.
 - Add support boards.
   COM-1C-LPE, COM-2C-LPE, COM-4C-LPE
 - We added to the property page the check box of the half duplex setting.
 - It was corrected that DOS sample programs cannot support COM-1PD(LPCI)H 
   and COM-2PD(LPCI)H.
 - VB sample program is changed.
 - CommChk.exe is corrected.
 - It was corrected that "RTS flow control" can not operate.
   [Only XP,2000,Server 2003] 
   
 Ver.5.00  2005/05/12 [COM SETUP DISK Ver1.40]
 ----------------------------------------
 - Add support boards.
   COM-1PD(LPCI)H, COM-2PD(LPCI)H.
 - The processing corrected in Ver.4.42 adds processing by 16550 types 
   because it is effective only excluding 16550 types. [Only 2000,XP]
 - CTstCom.exe is corrected. 

 Ver.4.40  2004/11/22 [COM SETUP DISK Ver1.30]
 ----------------------------------------
 - Add support boards.
     COM-2(FIT) (Only device driver is changed)[Only 95,98,Me]

 Ver.4.42  2004/11/16 [Only 2000,XP]
 ----------------------------------------
 - Set to a setup of a device manager's COM port, and it is transmitting 
   FIFO size. Between the transmitting data set up when it was set as 
   17 bytes or more (byte unit) It corrects that a blank may arise.


 Ver.4.41  2004/09/06 [Only 2000,XP]
 ----------------------------------------
 - At the time of installation of hardware, a "code 10" error may occur 
   in a device manager, modified.
  
 Ver.4.40  2004/06/22 [COM SETUP DISK Ver1.20]
 ----------------------------------------
 - When the baud rate besides communication tolerance level is specified, 
   a driver is corrected so that an error may be returned.
 - Add hardware information acquisition program.
 
 Ver.4.31  2003/11/14 [Only 2000,XP]
 ----------------------------------------
 - A MAX baudrate corresponds the device of 921.6kbps(es) to a low-speed 
   baudrate (less than 15bps). However, change of a registry is required.

 Ver.4.30  2002/06/03 [Only 2000,XP]
 ----------------------------------------
 - Add Uninstaller for COM-DRV.
 - The property page for ports dealing with the FIFO size of 128 bytes
   is added.
 - Driver change accompanying property page change.

 Ver.4.10->Ver.4.20 2002/07/25
 ----------------------------------------
 - Fault generates NOTE-PAC(PCI) at the time of use, modified.
 - Driver Version not change (Ver.4.10).

 Ver.4.00->Ver.4.10 2002/06/25
 ----------------------------------------
 - Add support boards.
    COM-2P(PCI)H, COM-4P(PCI)H, COM-1(LPCI)H, COM-2(LPCI)H,
    COM-4(LPCI)H

 Ver.3.50->Ver.4.00 2001/12/01
 ----------------------------------------
 - Start supprt Windows XP.
 - It is modified so that it can access it even when resource of the 
   PCI board is outside the standard range. [support OS:NT]

 Ver.3.41->Ver.3.50 2001/05/17
 ----------------------------------------
 - Add support boards.
            COM-2(PCI)H
            COM-4(PCI)H
            COM-8(PCI)H
            COM-2PD(PCI)H
            COM-4PD(PCI)H
 - Add support change fifo value.

 Ver.3.40->Ver.3.41 2000/10/02
 ----------------------------------------
 - Com2k_pi (for PCI), Com2k_is (for ISA) are modified not to 
   recognize an INF file for the version of OS when to be 4.00.950a, 
   4.00.950 when hardware is installed with Windows95.
 - Driver Version (Ver.3.20 for Windows Me/98/95, Ver.3.30 for 
   Windows NT, Ver.1.00 for Windows 2000) not change.
 - An application error in the transmitting time-out is corrected 
   with CTSTCOM.EXE. Ver.1.01->Ver.1.02
 - When CTSTCOM.EXE is used with Win2000, it isn't made to indicate 
   board choice diarog. (Because CONFIG.EXE isn't used.) 

 Ver.3.31->Ver.3.40 2000/08/21
 ----------------------------------------
 - COMDRV2K.SYS, COMFLDRV.SYS are added caused by Windows 2000 WDM 
   support start, and APCFGW.SYS is removed. 
 - And, common INF files Com2k_pi(for PCI),Com2k_is(for ISA) for 
   Windows 2000/Me/98/95 are changed. PortPci2.Inf,PortIsa2.Inf are 
   added.
 - Application DELREG.EXE for registry elimination in the ISA bus 
   board installation is added. 

 Ver.3.31->Ver.3.40 2000/08/21
 ----------------------------------------
 - COMDRV2K.SYS, COMFLDRV.SYS are added caused by Windows 2000 WDM 
   support start, and APCFGW.SYS is removed. 
 - And, common INF files Com2k_pi(for PCI),Com2k_is(for ISA) for 
   Windows 2000/Me/98/95 are changed. PortPci2.Inf,PortIsa2.Inf are 
   added.
 - Application DELREG.EXE for registry elimination in the ISA bus 
   board installation is added. 

 Ver.3.30->Ver.3.31 2000/07/03
 ----------------------------------------
 - Each INF file for Windows 2000 and an INF file for Windows 98/95 
   are made a summary file name Com2k_pi (Comdrv for PCI), ComW2k_is 
   (Comdrv for ISA) in one.

 Ver.3.21->Ver.3.30 2000/3/01
 ----------------------------------------
 - COMDRV.SYS is changed caused by Windows 2000 support start, and 
   APCFGW.SYS is added. 
 - Add INF file for Windows2000.
 - Driver Version for Win95 not change (Ver.3.20).
 - Signature of the INF file COM95_PI.INF for Windows95 was changed 
   from $CHICAGO$ to $Windows95$. 
 - It is changed from the floppy disk of the PCI board attachment as 
   well so that it can use COM-DRV with Enhanced mode of the ISA bus 
   board. 
 - Using BUF(PCI), Additional for the PCI Board Resource acquisition.
   It copes with it to 256 class, modified. [support OS:NT]


 Ver.3.20->Ver.3.21 1999/8/06
 ----------------------------------------
 - Driver Version not change (Ver.3.20).
 - Diagnosis program (CTSTCOM.EXE) BugFix. The thing which the 
   pattern which freeze when a connection is canceled was is 
   modified.  (Ver.1.00->Ver.1.01)[support OS:NT/98/95]
 - Becouse add DIAGNOSIS.TXT for CTSTCOM.EXE , change COMNT_PI.INF 
   and COM95_PI.INF. [support OS:Win NT/98/95]

 Ver.3.10->Ver.3.20 1999/6/30
 ----------------------------------------
 - Add Diagnosis program (CTSTCOM.EXE).    
 - Becouse add CTSTCOM.EXE and change install pass of APCFG.DLL, 
   change COM95_IS.INF and COM95_PI.INF. [support OS:98/95]

 Ver.2.01->Ver.3.10 1999/5/11
 ----------------------------------------
 - Version up for Version No.unity.[support OS:NT/98/95]
 - supprted ISA Bus board.(COM-2(PC)F, COM-4M(PC), COM-2PD(PC)H, 
   COM-2(PC)V, COM-2PD(PC))[support OS:98/95]

 Ver.2.00->Ver.2.01 1999/3/31
 ----------------------------------------
 - Bug fix
   If used COM-2(PCI),COM-2PD(PCI),COM-8(PCI), occur BI(Break 
   Interrupt), hung up PC,  modified. [support OS:98/95]

 Ver.2.00->Ver.2.01 1999/3/31
 ----------------------------------------
 - Bug fix
   If used COM-4M(PC), could not COM1 COM2 on PC,  modified 
   [support OS:NT]

 Ver.2.00 1999/3/31
 ----------------------------------------
 - Start supprt Windows 98/95.

 Ver.1.00->Ver.1.10 1998/11/27
 ----------------------------------------
 - Add support boards
            COM-2(PCI)
            COM-8(PCI)
            COM-2PD(PCI)
 - It was supported 256 ports at the maximum.

 Ver.1.00
 ----------------------------------------
  - Start supprt for Windows NT (supprted board:COM-2(PC)F, COM-4M(PC)
   , COM-2PD(PC)H, COM-2(PC)V, COM-2PD(PC), COM-4(PCI)).


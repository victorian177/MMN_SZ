
=========================================================
             標準COMドライバについて
                         COM-DRV(W32) Ver.8.50
                                     CONTEC Co., Ltd.
=========================================================

◆ 目次
=======
  はじめに
  仕様
  制限事項
  ハードウェア設定
  注意事項
  インストール
  バージョンアップ履歴


◆ はじめに
===========
  日頃から格別のお引き立てを賜りまして厚く御礼申し上げます。
  
  COM-DRV(W32)はWindows上でPCIバスボード、PCI Expressバスボードなど、
  当社製シリアル通信ボードをパソコン本体のCOMポートと同様に使用できるようにするためのソフトウェアです。
  これによりWindows 上で各種シリアル通信を行うことが可能です。


◆ 仕様
=======
< COM-DRV(W32) >
  適応OS
                Microsoft Windows 10

< COM-DRV(W64) >
  適応OS
                Microsoft Windows 11
                Microsoft Windows 10
                Microsoft Windows 10 IoT Enterprise LTSC 2021
                Microsoft Windows 10 IoT Enterprise 2019 LTSC
                Microsoft Windows 10 IoT Enterprise LTSB 2016
                Microsoft Windows Server 2022
                Microsoft Windows Server 2019
                Microsoft Windows Server 2016
 
  最大ポート数  256ポート

  対応アーキテクチャ  x86
                      x64

  対象ボード    PCIバスボード
                   COM-1(LPCI)H, COM-2(LPCI)H, COM-4(LPCI)H,
                   COM-8C-LPCI,
                   COM-1PD(LPCI)H, COM-2PD(LPCI)H, 
                   COM-2P(PCI)H, COM-4P(PCI)H, 
                   COM-2(PCI)H, COM-4(PCI)H, COM-8(PCI)H, 
                   COM-2PD(PCI)H, COM-4PD(PCI)H,
                   COM-2(PCI), COM-4(PCI), COM-8(PCI), COM-2PD(PCI)

                PCIバスボード (メモリタイプ)
                   COM-2CL-PCI, COM-4CL-PCI, COM-2DL-PCI, COM-4DL-PCI 
                   
                PCI Expressバスボード
                   COM-1C-LPE, COM-2C-LPE, COM-4C-LPE,
                   COM-8C-LPE,
                   COM-2C-PE, COM-4C-PE, COM-8C-PE
                   COM-2PC-PE, COM-4PC-PE, COM-2PD-PE, COM-4PD-PE,
                   COM-2PD-LPE, COM-1PDH-LPE
                   
                CONPROSYS
                   CPS-COM-1PC, CPS-COM-2PC, CPS-COM-1PD, CPS-COM-2PD

                BX-M210 GPIOモデル
                   COM-1C, COM-1D

  対象コントローラ    ボックスコンピュータ
                         CPS-BXC200


◆ 制限事項
===========
  ・API-SIO(98/PC)NTをご使用になる場合、添付メディアからボードのインストールを行わないでください。
    添付メディアからボードのインストールを行った場合、API-SIO(98/PC)NTを使用することが出来ません。


◆ ハードウェア設定
===================
  スイッチやジャンパの位置などの詳細は、ボードの解説書を参照してください。

  (1)COM-2(PCI), COM-4(PCI), COM-8(PCI),
     COM-2(PCI)H, COM-4(PCI)H, COM-8(PCI)H,
     COM-1(LPCI)H, COM-2(LPCI)H, COM-4(LPCI)H, COM-8C-LPCI, 
     COM-2P(PCI)H, COM-4P(PCI)H,
     COM-1C-LPE, COM-2C-LPE, COM-4C-LPE, COM-8C-LPE,
     COM-2CL-PCI, COM-4CL-PCI,
     COM-2C-PE, COM-4C-PE, COM-8C-PE,
     COM-2PC-PE, COM-4PC-PE
     ・BOARD IDの設定
             設定可能な範囲: 0〜F (COM-4(PCI)のみ 0〜7)

  (2)COM-2PD(PCI), COM-2PD(PCI)H, COM-4PD(PCI)H
     COM-1PD(LPCI)H, COM-2PD(LPCI)H,
     COM-2DL-PCI, COM-4DL-PCI,
     COM-2PD-PE, COM-4PD-PE,
     COM-2PD-LPE, COM-1PDH-LPE
     ・BOARD IDの設定
             設定可能な範囲: 0〜F
     ・伝送モードとターミネータの設定
             設定可能な範囲: 全二重(RTS,CTSを相手装置と接続), 
                             全二重(RTS,CTSを使用しない), 半二重
                             ターミネータ挿入する, しない


◆ 注意事項
==========
  ・通信ポートの設定
    各通信ポートはコントロールパネル内のシリアルポートの設定や、コマンドプロンプトのMODEコマンドを実行することにより、
    ボーレート、データ長、ストップビット長、パリティなどが設定できます。
    ただし、これらのパラメータは通常シリアル通信のアプリケーションが設定しているので、ここでの設定は必要ありません。

  ・RAS,UPSについて
    パソコン本体のCOMポートと同様に使用できるので、リモートアクセスサービス(RAS)や無停電電源(UPS)に対応しています。
    これらの設定に関する詳細は、各OS添付の「セットアップガイド」やOSに標準で搭載されているヘルプファイルをご覧ください。

  ・プログラミング
    OS標準のWin32 API コミュニケーション関数に対応しています。
    .Net Framework 4.0以降のSerialPortクラスに対応しています。
    但し, SerialPortクラスを使用する際、下記事項にご注意ください。
    -------------------------------------------------------------------
     ・RS-422/485の半二重通信は、SerialPortでは設定できません。
    -------------------------------------------------------------------
    pySerial 3.4に対応しています。
    
    これら関数の詳細やプログラミングについては、お手持ちの開発言語のリファレンスを参照してください。
      Ex.Visual C++, Win32SDK, Visual C#.NET Visual Basic.NET など

  ・ボーレートの設定範囲
    使用するボードによって設定できるボーレートの範囲が異なります。
    >COM-2(PCI)H, COM-4(PCI)H, COM-8(PCI)H,
     COM-1(LPCI)H, COM-2(LPCI)H, COM-4(LPCI)H, COM-8C-LPCI,
     COM-1PD(LPCI)H, COM-2PD(LPCI)H, 
     COM-2PD(PCI)H, COM-4PD(PCI)H,
     COM-2PD(PCI), COM-2PD(PC)H, 
     COM-1C-LPE, COM-2C-LPE, COM-4C-LPE, COM-8C-LPE,
     COM-2C-PE, COM-4C-PE,COM-8C-PE,
     COM-2PC-PE,COM-4PC-PE,COM-2PD-PE,COM-4PD-PE
     COM-2PD-LPE, COM-1PDH-LPE, 
     CPS-COM-1PC, CPS-COM-2PC, CPS-COM-1PD, CPS-COM-2PD
     -15〜921600 (単位:bps)
       50, 75, 150, 300, 600, 1200, 1800, 2400, 3600, 4800, 7200, 
       9600, 14400, 19200, 28800, 38400, 57600, 115200, 230400, 
       460800, 921600 など
    >COM-2(PCI), COM-4(PCI), COM-8(PCI)
     -4〜230400 (単位:bps)
       50, 75, 150, 300, 600, 1200, 1800, 2400, 3600, 4800, 7200, 
       9600, 14400, 19200, 28800, 38400, 57600, 115200, 230400 など
    >COM-2CL-PCI, COM-4CL-PCI, COM-2DL-PCI, COM-4DL-PCI
     -15〜230400 (単位:bps)
       50, 75, 150, 300, 600, 1200, 1800, 2400, 3600, 4800, 7200, 
       9600, 14400, 19200, 28800, 38400, 57600, 115200, 230400 など
    >COM-1C, COM-1D
     -50〜115200 (単位:bps)
       50, 75, 150, 300, 600, 1200, 1800, 2400, 3600, 4800, 7200, 
       9600, 14400, 19200, 28800, 38400, 57600, 115200 など
       
  ・ボーレートの設定上限
    設定可能ボーレートの上限は、ご使用になるパソコンの処理能力(動作スピード)および,
    負荷 (他のプログラムとの同時実行など)によって左右されます。
    この上限を超えたスピードで通信を行うと、通信エラー(オーバーラン、パリティ、フレーミング)の原因となります。
    OS添付のハイパーターミナルなどで実際に通信を行い、設定可能なボーレートを確認してください。

  ・半二重設定について
    Win32APIコミュニケーション関数のSetCommState()で、
    DCB構造体のfRtsControlメンバを[RTS_CONTROL_TOGGLE(0x03)]に設定することで半二重通信に対応しております。
    しかしながら、開発言語の中には、fRtsControlが設定できない言語もございます。
    その場合、以下の設定を行うことで半二重に設定することができます。

    デバイスマネージャ＞ポート＞CONTEC Communicationsのプロパティを開き、
    ポートの設定＞詳細設定から「半二重設定」のチェックボックスをオンにしてください。

    その後OSを再起動すると、そのポートの通信は 強制的に半二重通信の設定となります。

  ・シリアルマウスについて
    弊社デバイスドライバを使用される際には、シリアルマウスとして検出されないように設定を行っております。
    よって、お客様がシリアルマウスを使用される際には、
    デバイスマネージャ＞ポート＞CONTEC Communicationsのプロパティを開き、
    ポートの設定＞詳細設定から「シリアルマウスを使用する」のチェックボックスをオンにしてください。

    シリアルマウスの詳細情報につきましては、弊社FAQの[アンサーID:145]やMicrosoft様のサイトをご参照ください。
    
    http://support.microsoft.com/default.aspx?scid=kb;ja;889045


◆ インストール
===============
  ・本製品は、システムディレクトリあるいは、システムディレクトリが存在するディレクトリのCONTECフォルダにインストールします。
    既に、他のAPI-TOOLドライバがインストールされていてCONTECフォルダが存在する場合は、そのディレクトリへ上書きインストールします。
    必ず以前のファイルをバックアップしてから、インストールして下さい｡


◆ バージョンアップ履歴
=======================
  Ver.8.50  2022/03
  ----------------------------------------
   ・対応OSを追加
     対応OS：      Microsoft Windows Server 2022  (64bit)

  Ver.8.40  2022/01
  ----------------------------------------
  ・対応デバイスを追加
    対応デバイス: COM-1C
                  COM-1D

  Ver.8.30  2022/01
  ----------------------------------------
   ・対応開発言語を追加
     対応開発言語: Python 3.10(pySerial 3.5)
   ・Windows 10 21H2での動作を確認
   ・対応OSを追加
     対応OS：      Microsoft Windows 10 IoT Enterprise LTSC 2021

  Ver.8.20  2021/12
  ----------------------------------------
   ・対応OSを追加
     対応OS：      Microsoft Windows 11  (64bit)

  Ver.8.11  2021/11
  ----------------------------------------
   ・半二重通信が正常にできない場合がある不具合を修正
     対象デバイス：CPS-COM-1PC
                   CPS-COM-2PC
                   CPS-COM-1PD
                   CPS-COM-2PD

  Ver.8.10  2021/06
  ----------------------------------------
   ・Windows 10 21H1での動作を確認
   ・COMポートを削除し再登録した際、ブルースクリーンが発生する場合がある不具合を修正

  Ver.8.00  2021/04
  ----------------------------------------
   ・対応開発言語を追加
     対応開発言語: Python 3.9(pySerial 3.5)
   ・対応OSを改定
     対応OS:       Microsoft Windows Server 2019   (64bit)
                   Microsoft Windows Server 2016   (64bit)
                   Microsoft Windows 10            (32bit/64bit)

  Ver.7.20  2020/12
  ----------------------------------------
   ・Windows 10 20H2での動作を確認
   ・Windows 10 のセキュリティポリシー(メモリの整合性)に対応
   ・対応OSを改定
     対応OS:       Microsoft Windows 10            (32bit/64bit)
                   Microsoft Windows 8.1           (32bit/64bit)
                   Microsoft Windows 7             (32bit/64bit)
                   Microsoft Windows Server 2019   (64bit)
                   Microsoft Windows Server 2016   (64bit)
                   Microsoft Windows Server 2012R2 (64bit)

  Ver.7.10  2020/09
  ----------------------------------------
   ・対応開発言語を追加
     対応開発言語: Python 3.8(pySerial 3.4)

  Ver.7.00  2020/07
  ----------------------------------------
   ・Windows 10 2004での動作を確認

  Ver.6.90  2019/12
  ----------------------------------------
   ・Windows 10 19H2での動作を確認

  Ver.6.80  2019/12
  ----------------------------------------
   ・Windows Server 2019 サポート開始。

  Ver.6.71  2019/10
  ----------------------------------------
   ・正常にCloseができない場合がある不具合を修正

  Ver.6.70  2019/06/24
  ----------------------------------------
   ・Windows 10 19H1での動作を確認

  Ver.6.62  2018/11/21
  ----------------------------------------
   ・CPS-COM-1PC, CPS-COM-2PC, CPS-COM-1PD, CPS-COM-2PD追加 [サポートOS:Windows 10 IoT Enterprise LTSB2016 64bit]

  Ver.6.61  2017/10/20
  ----------------------------------------
   ・Windows Server 2016 サポート開始。

  Ver.6.60  2017/08/04
  ----------------------------------------
   ・COM-2PD-LPE, COM-1PDH-LPE追加 [ サポートOS:Windows 7以降/ Windows Server 2008以降 ]

  Ver.6.50  2017/03/13
  ----------------------------------------
   ・Windows 10 ドライバ署名ポリシー変更に対応
   ・小数点以下のボーレート設定に対応

  Ver.6.42  2015/12/09
  ----------------------------------------
   ・SHA-2署名対応開始。
   ・VB.NET/VCSサンプルがVB2015/VCS2015サポート開始。

  Ver.6.41  2015/11/10
  ----------------------------------------
   ・Windows 10 サポート開始。

  Ver.6.40  2014/08/31
  ----------------------------------------
   ・COM-8C-LPE, COM-8C-LPCI追加 [ サポートOS:Windows Vista以降/ Windows Server 2008以降 ]

  Ver.6.35  2014/08/06
  ----------------------------------------
   ・シリアルマウスを有効にするに設定した後、PCからシリアルマウスに対して
   データ送信が正常に行われず、最後のデータのみが送信される問題を修正。

  Ver.6.34  2014/01/30
  ----------------------------------------
   ・Windows 8.1 サポート開始。
   ・Windows Server 2012 R2 サポート開始。
   ・ドライバ(comdrv2k.sys)はVer.6.33から変更無し。

  Ver.6.33  2013/02/04 
  ----------------------------------------
   ・Windows 8 サポート開始。
   ・Windows Server 2012 サポート開始。

  Ver.6.32  2012/09/22 
  ----------------------------------------
   ・Windows Server 2008 R2サポート開始。
   ・「シリアルマウスを使用する」が有効にならない現象を修正。

  Ver.6.31  2010/11/29 [COM Setup Disk 2.10]
  ----------------------------------------
   ・Windows 7 のインストールドキュメントの誤記を修正。
   ・Windows 7 がインストールされた特定のPCで、「この操作には
     対話型ウィンドウステーションが必要です」となりインストールできない
     問題を修正。
   ・半二重で通信した場合に、通信が正常に行われない不具合を修正。
     [COM-2CL-PCI,COM-4CL-PCIのみ]
   ・OSを起動中にシリアルデータを受信すると、通信が正常に行われない
     不具合を修正[COM-4(PCI)Hのみ]
     この現象は Ver.6.22以前のバージョンでは発生しない。
   ・特定のPCにてポートをオープンしたあと、しばらくするとクローズすると
     ブルースクリーンになる問題を修正。
     この現象は Ver.6.22以前のバージョンでは発生しない。
   ・特定のPCにてシリアル通信中にサスペンド状態になったときに、
     画面が黒くなったまま復帰しなくなる問題を修正。
     この現象は Ver.6.30のみで発生する。

  Ver.6.30  2009/12/28 [COM Setup Disk 2.00]
  ----------------------------------------
   ・Windows 7 サポート開始。
   ・64bit OS対応ドライバ COM-DRV(W64)サポート開始。
   
  Ver.6.24  2009/04/30
  ----------------------------------------
   ・Windows Server 2008 サポート開始。
   ・イベントログ表示機能を追加(日本語)。
   ・プロパティページにて、ボーレートなどの情報を変更した後に、
     詳細ボタンを押すとその変更が保存されない現象を修正。
   ・ドライバの詳細に「シリアルマウスで使用する」項目を追加。

  Ver.6.23  2008/10/11
  ----------------------------------------
   ・COM-2CL-PCI, COM-4CL-PCI, COM-2DL-PCI, COM-4DL-PCIを使用時、
     特定のPCにインストールした後、起動中に再起動がかかってしまう不具合を修正。[Vista のみ]

  Ver.6.22  2007/12/28 [COM Setup Disk 1.90]
  ----------------------------------------
  ・送信データのパリティが受信データのパリティと一致しない場合、
    文字データが欠けてしまう不具合を修正。
    [Windows 2000/XP/Server 2003/Vista]

  ・マルチコアPCにおいて、ポートのオープンとクローズを頻繁に実行した場合、
    クローズ処理中にポートがロックする現象を解消。

  Ver.6.21  2007/09/05
  ----------------------------------------
  ・BX700-PCに内蔵されているCOM-4(PCI)Hにて 128byte以上の送信/受信を行った時、
  正常動作しない現象を解消。[Windows 2000/XP/Server 2003/Vista]
  
  Ver.6.20  2007/08/24 [COM Setup Disk 1.80]
  ----------------------------------------
  ・COM-2C-PE, COM-4C-PE, COM-8C-PE, COM-2PC-PE, COM-4PC-PE,
    COM-2PD-PE, COM-4PD-PE サポート対応。
  ・特定のPCにて ドライバの再インストールを行う際に
    [Contec Communication Port]のインストール中、
    「必要なファイルが足りません」が画面表示され、インストールできなくなる
    現象を解消。[ Vistaのみ ]
 
  Ver.6.12  2007/06/25
  ----------------------------------------
  ・COM-2CL-PCI, COM-4CL-PCI, COM-2DL-PCI, COM-4DL-PCIを使用時、
    特定のPCでインストール後、起動中に再起動がかかってしまう不具合を修正。

  Ver.6.11  2007/06/08
  ----------------------------------------
  ・COM-2CL-PCI, COM-4CL-PCI, COM-2DL-PCI, COM-4DL-PCIを使用時、
    特定のPCでインストール後、起動中に画面がロックする不具合を修正。
  
  Ver.6.10  2007/05/02 [COM SETUP DISK Ver1.70]
  ----------------------------------------
  ・COM-2DL-PCI, COM-4DL-PCI サポート対応。
  ・COM-1PD(FIT)GYサポート対応。（ドライバ本体のみ）[95,98,Meのみ]
  
  Ver.6.00  2007/03/01 [COM SETUP DISK Ver1.60]
  ----------------------------------------
  ・COM-2CL-PCI, COM-4CL-PCI サポート対応。
  ・Windows Vista サポート開始。
  
  Ver.5.21  2006/10/24
  ----------------------------------------
  ・RS422/485タイプの製品でGetCommProperties関数を使ってCOMPROP構造体を
    取得する時、dwProvSubTypeがPST_RS232として出力する現象を修正。
  
  Ver.5.20  2006/10/01
  ----------------------------------------
  ・起動時, 通信割り込みが頻発すると途中でフリーズするためドライバを修正
  ・起動時, OSが機器から送信された信号をシリアルマウスと認識するため、
    起動時シリアルマウスとして認識しないようにINFファイルを修正
  ・CommCHK.exe修正。

  Ver.5.10  2005/11/02 [COM SETUP DISK Ver1.50]
  ----------------------------------------
  ・Windows Server 2003 サポート開始。
    これに伴い、アンインストーラ、CTstCom.exeをバージョンアップ。
  ・COM-1C-LPE, COM-2C-LPE, COM-4C-LPE サポート対応。
  ・プロパティページに半二重設定用チェックボックスを追加。
  ・DOSサンプルプログラムが、COM-1PD(LPCI)H, COM-2PD(LPCI)Hに対応して
    いなかったのを修正。
  ・VBサンプルを変更。
  ・CommChk.exeを修正。
  ・RTSフロー制御が正常に動作していなかったのを修正。
     [XP,2000,Server 2003のみ]

  Ver.5.00  2005/05/12 [COM SETUP DISK Ver1.40]
  ----------------------------------------
  ・COM-1PD(LPCI)H, COM-2PD(LPCI)H サポート対応。
  ・Ver.4.42において修正した処理は16550タイプ以外でのみ有効なので、
    16550タイプでの処理を追加。[2000,XPのみ]
  ・CTstCom.exeを修正。受信バッファオーバーフローの可能性があるので
    受信バッファサイズを拡大。

  Ver.4.50  2004/11/22 [COM SETUP DISK Ver1.30]
  ----------------------------------------
  ・COM-2(FIT) サポート対応。(ドライバ本体のみ)[95,98,Meのみ]

  Ver.4.42  2004/11/16 [2000,XPのみ]
  ----------------------------------------
  ・デバイスマネージャのCOMポートの設定において、送信FIFOサイズを
    17バイト以上に設定した場合、設定した送信データ間(バイト単位)に
    ブランクが生じる場合があるのを修正。

  Ver.4.41  2004/09/06 [2000,XPのみ]
  ----------------------------------------
  ・ハードウェアのインストール時に、デバイスマネージャに｢コード１０｣
    エラーが発生する場合があるのを修正。

  Ver.4.40  2004/06/22 [COM SETUP DISK Ver1.20]
  ----------------------------------------
  ・通信許容範囲（文字化けしない限界）外のボーレートを指定した場合に、
    エラーを返すようにドライバを修正[2000,XPのみ]
  ・GetDev.exe(ハードウェア情報取得プログラム)追加[2000,XPのみ]

  Ver.4.31  2003/11/14 [2000,XPのみ]
  ----------------------------------------
  ・MAXボーレートが921.6kbpsのデバイスを、低速ボーレート(15bps未満)で
    使用できるようにドライバ変更。ただしレジストリの変更が必要。

  Ver.4.20->Ver.4.30  2002/06/03 [2000,XPのみ]
  ----------------------------------------
  ・COM-DRVアンインストーラを追加。
  ・FIFOサイズ128バイト対応のポート用プロパティページを追加。
  ・プロパティページのFIFOサイズ128バイト対応に伴うドライバ変更。

  Ver.4.10->Ver.4.20 2002/08/08
  ----------------------------------------
  ・NOTE-PAC(PCI)使用時の不具合修正応。
  ・ドライバ本体はVer.410で変更無し。

  Ver.4.00->Ver.4.10 2002/06/25
  ----------------------------------------
  ・COM-2P(PCI)H, COM-4P(PCI)H, COM-1(LPCI)H, COM-2(LPCI)H, 
    COM-4(LPCI)H サポート対応。

  Ver.3.50->Ver.4.00 2001/12/01
  ----------------------------------------
  ・Windows XP Professional、Windows XP Home Editionに対応。
  ・WindowsNT環境下でPCIボードリソースが規格範囲外にある場合でもアク
    セスできるように修正。

  Ver.3.41->Ver.3.50 2001/05/17
  ----------------------------------------
  ・COM-2(PCI)H,COM-4(PCI)H,COM-8(PCI)H,COM-2PD(PCI)H,COM-4PD(PCI)H
    サポート追加。
  ・FIFO設定値変更サポート。

  Ver.3.40->Ver.3.41 2000/10/02
  ----------------------------------------
  ・Windows95 でハードウェアのインストール時に、OS のバージョンが
    4.00.950a、4.00.950だとINFファイルを認識しないため 
    Com2k_pi(PCI用)、Com2k_is(ISA用)を修正。ただし、Ver.3.31までは認
    識する。
  ・Driver Version(Windows Me/98/95用Ver.3.20、Windows NT用Ver.3.30、
    Windows 2000用Ver.1.00)は変更無し。
  ・CTSTCOM.EXEで送信タイムアウト時のアプリケーションエラーを修正。 
    Ver.1.01->Ver.1.02
  ・CTSTCOM.EXEをWin2000で使用時にボード選択ダイアログを表示させない
    (CONFIG.EXEを使用しないため）。

  Ver.3.31->Ver.3.40 2000/08/21
  ----------------------------------------
  ・Windows 2000 WDMサポートに伴いCOMDRV2K.SYS、COMFLDRV.SYSを追加し
    APCFGW.SYSを削除。
  ・上記内容に伴い、Windows 2000/Me/98/95用共通INFファイルCom2k_pi
    (PCI用)、Com2k_is(ISA用)を変更、PortPci2.Inf、PortIsa2.Infを追加
    。
  ・ISAバスボードインストール時のレジストリキー削除用アプリケーション
    DELREG.EXEを追加。

  Ver.3.30->Ver.3.31 2000/07/03
  ----------------------------------------
  ・Windows 98/95でPCIボードをインストールしようとするとWindews 2000 
    INFファイルを認識してしまいインストールが正常に完了できない。PCI
    、ISAそれぞれのWindows 2000用INFファイルとWindows 98/95用INFファ
   イルをひとつにまとめファイル名Com2k_pi(PCI用Comdrv)、Com2k_is
   (ISA用Comdrv)とする。

  Ver.3.21->Ver.3.30 2000/03/01
  ----------------------------------------
  ・Windows 2000のサポート開始に伴いCOMDRV.SYSを変更しAPCFGW.SYSを追
    加。
  ・Windows 2000用INFファイルを追加。
  ・Windows 95用Driver VersionはVer.3.20のまま変更無し。
  ・Windows 95用INFファイルCOM95_PI.INFのsignatureを$CHICAGO$から
    $Windows95$に変更。
  ・PCIボード添付のフロッピーディスクからも、ISAバスボードのエンハン
    ストモードでのCOM-DRVの使用可能に変更。
  ・Windows NTでBUF(PCI)使用時 PCI Board Resource取得 対応追加。
    256階層まで対応に修正。[対応OS:NT]

  Ver.3.20->Ver.3.21 1999/8/06
  ----------------------------------------
  ・Driver VersionはVer.3.20のまま変更無し。
  ・診断プログラム(CTSTCOM.EXE)のBugFix。接続解除時にフリーズする
    パターンがあったのを修正。Ver.1.00->Ver.1.01[対応OS:NT/98/95]
  ・Diagnosis.txtの追加とそれに伴いCOM95_PI.INF、COMNT_PI.INFを変更。
    [対応OS:NT/98/95]
  ・PC-98XXシリーズ用INFファイル名をPC98_W95.infからPc9800.infに変更。

  Ver.3.10->Ver.3.20 1999/6/30
  ----------------------------------------
  ・診断プログラム(CTSTCOM.EXE)を追加。[対応OS:NT/98/95]    
  ・CTSTCOM.EXE追加とAPCFG.DLLのインストールパスの変更に伴い
    COM95_IS.INF及びCOM95_PI.INFを変更。 [対応OS:98/95]

  Ver.2.01->Ver.3.10 1999/5/11
  ----------------------------------------
  ・Windows 98/95版、NT版 バージョンNo．統一のためのバージョンアッ
    プ。
  ・ISAバスボード対応。(COM-2(PC)F, COM-4M(PC), COM-2PD(PC)H, 
    COM-2(PC)V,COM-2PD(PC))[対応OS:98/95] (ただし、API-PACにのみ添付)

  Ver.2.00->Ver.2.01 1999/3/31
  ----------------------------------------
  ・COM-4M(PC)使用時にパソコン本体のCOM1,COM2が通信できなかった不具合
    を修正。 [対応OS:NT]

  Ver.2.00->Ver.2.01 1999/3/31
  ----------------------------------------
  ・COM-2(PCI),COM-2PD(PCI),COM-8(PCI)使用時にBreak Interruptが発生
    するとOSがハングアップしてしまう不具合を修正。[対応OS:98/95]

  Ver.1.10->Ver.2.00 1999/3/31
  ----------------------------------------
  ・Windows 98/95 サポート開始。(対応ボード：COM-2(PCI),COM-2PD(PCI),
    COM-8(PCI),COM-4(PCI)) [対応OS:98/95]

  Ver.1.00->Ver.1.10  1998/11/27
  ----------------------------------------
  ・COM-2(PCI)、COM-8(PCI)、COM-2PD(PCI)サポート対応。[対応OS:NT]
  ・最大ポート数を256までサポート。[対応OS:NT]
  Ver.1.00
  ・Windows NTのみ対応でサポート開始。(対応ボード：COM-2(PC)F, 
    COM-4M(PC), COM-2PD(PC)H, COM-2(PC)V, COM-2PD(PC), COM-4(PCI))

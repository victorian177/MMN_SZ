=====================================================================
=                 API-AIO(WDM) Additional Sample Programs           =
=                        Analog Input Repeat                        =
=                                                         Ver.1.00  =
=                                                 CONTEC Co., Ltd.  =
=====================================================================

- Introduction
=======================
  This package is the additional sample programs to show usage examples
  that are not presented in the sample programs of the development 
  environment for API-AIO(WDM).
  
  Please use it as a reference when using the API-AIO(WDM) development environment.


- Specification
=======================
  [Supported driver]
  API-AIO(WDM)

  [Supported development languages]
  Microsoft Visual C++ (MFC)  (2013,2015,2017,2019)
  Microsoft Visual C#         (2013,2015,2017,2019)
  Microsoft Visual Basic .NET (2013,2015,2017,2019)

  [Supported devices]
  Devices that support the AioSetAiRepeatTimes function


- About this sample
=======================
  This is a sample program that sets repeat times and performs sampling.
  In this sample program, repeat times can be specified in any value.

  ====================================================================================
   Sampling conditions |Setting sampling conditions                   |How to change *
  ====================================================================================
   Input method        |Single-end input                              |Source code
   Input range         |+/- 10[V]                                     |Source code
   Memory type         |FIFO                                          |Source code
   Clock type          |Internal clock                                |Source code
   Sampling clock      |1000[usec]                                    |Source code
   Start condition     |External trigger rising edge                  |Source code
   Stop condition      |Stop conversion by the specified times (1000) |Source code
   Number of channels  |1                                             |Source code
   Repeat times        |Any value                                     |Window
   Event factor        |Event that AD conversion start                |Source code (Change notice)
                       |Event that repeat end                         |Source code (Change notice)
                       |Event that device operation end               |Source code (Change notice)
  ====================================================================================
  *  How to change
     Source code                 : Conditions can be changed in the source code. 
     Source code (Change notice) : Conditions can be changed in the source code, but please note that it may not work.
     Window                      : Any value can be set from the window.


- Glossary
=======================
  [Repeat]
    Repeat is the repetition from the satisfaction of the sampling start condition to the satisfaction of the sampling stop condition including delay sampling.
    If the repeat times remains, after the sampling stop condition is satisfied, it automatically shifts to waiting for the sampling start condition.
    It is also possible to repeat for infinite repeat times. When repeating infinitely, stop the operation with the forced stop command by software.
    Infinite repeat times can be set by setting the repeat times to [0].


- Usage
=======================
  1. Initialization
   - Enter the device name set in the Device Manager into the [Device Name] textbox, and click the [Device Init] button.
   - Input method, input range, clock type, sampling clock, start condition, stop condition and number of channels are set in the [Device Init] button.
     If you want to change each setting, change the value of the setting you want to change.

  2. Repeat Times Setting
   - Enter the repeat times you want to set in the [Repeat Times] textbox, and click the [Repeat Times Setting] button to set the repeat times.

  4. Sampling Start
   - Click the [Sampling Start] button to start sampling.

  5. Sampling Complete
   - When the stop condition is satisfied, sampling ends.
   - After the sampling is completed, the sampling data will be displayed.
   - If the repeat times remains, it will wait for the sampling start condition.
   - Click the [Sampling Stop] button to stop sampling regardless of the stop conditions and repeat times.

  6. Exit handling of device
   - Click the [Device Exit] button to perform the exit handling of device.


- Version History
=======================
  Ver.1.00 (Web Release 2022.04)
  ----------------------------------------
  - First release

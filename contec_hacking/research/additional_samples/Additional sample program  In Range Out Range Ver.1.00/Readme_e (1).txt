=====================================================================
=                 API-AIO(WDM) Additional Sample Programs           =
=                           In Range Out Range                      =
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
  Devices equipped with In Range and Out Range function


- About this sample
=======================
  This is a sample program that sets start condition and stop condition to In Range or Out Range and performs sampling.
  In this sample program, start condition and stop condition can be specified in any value.

  ===================================================================================================================
   Sampling conditions                |Setting sampling conditions                       |How to change *
  ===================================================================================================================
   Input method                       |Single-end input                                  |Source code
   Input range                        |+/- 10[V]                                         |Source code
   Memory type                        |FIFO                                              |Source code (Change notice)
   Clock type                         |Internal clock                                    |Source code
   Sampling clock                     |1000[usec]                                        |Source code
   Start condition                    |Any value                                         |Window
   Start condition comparison channel |0                                                 |Source code (Change notice)
   Start condition upper limit        |Any value                                         |Window
   Start condition lower limit        |Any value                                         |Window
   Start condition state-holding times|Any value                                         |Window
   Stop condition                     |Any value                                         |Window
   Stop condition comparison channel  |0                                                 |Source code (Change notice)
   Stop condition upper limit         |Any value                                         |Window
   Stop condition lower limit         |Any value                                         |Window
   Stop condition state-holding times |Any value                                         |Window
   Number of channels                 |1                                                 |Source code
   Event factor                       |Event that AD conversion start                    |Source code (Change notice)
                                      |Event that device operation end                   |Source code (Change notice)
                                      |Event that the specified number of data are stored|Source code (Change notice)
  ===================================================================================================================
  *  How to change
     Source code                 : Conditions can be changed in the source code. 
     Source code (Change notice) : Conditions can be changed in the source code, but please note that it may not work.
     Window                      : Any value can be set from the window.


- Glossary
=======================
  [In Range]
    It is a condition to be set as the sampling start condition or sampling stop condition.
    The condition is satisfied when the input value of the specified channel is within the range of the upper limit value and the lower limit value, 
    and sampling has been performed for the number of state-holding times.

  [Out Range]
    It is a condition to be set as the sampling start condition or sampling stop condition.
    The condition is satisfied when the input value of the specified channel is outside the range of the upper limit value and the lower limit value, 
    and sampling has been performed for the number of state-holding times.


- Usage
=======================
  1. Initialization
   - Enter the device name set in the Device Manager into the [Device Name] textbox, and click the [Device Init] button.
   - Sampling conditions are set in the [Device Init] button.
     If you want to change the sampling conditions, change the value of the setting you want to change.

  2. Start Condition Setting
   - Enter the start conditions, and click the [Start Condition Setting] button to reflect the start conditions.

  3. Stop Condition Setting
   - Enter the stop conditions, and click the [Stop Condition Setting] button to reflect the stop conditions.

  4. Sampling Start
   - Click the [Sampling Start] button to start sampling.

  5. Sampling Complete
   - When the stop condition is satisfied, sampling ends.
   - After the sampling is completed, the start sampling data and stop sampling data will be displayed.
   - Click the [Sampling Stop] button to stop sampling regardless of the stop conditions.

  6. Exit handling of device
   - Click the [Device Exit] button to perform the exit handling of device.

  7. Exit the application
   - Click the [Close] button to exit the application.


- Version History
=======================
  Ver.1.00 (Web Release 2022.01)
  ----------------------------------------
  ÅEFirst release

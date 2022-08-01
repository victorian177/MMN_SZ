# =======================================
# =======================================
# COM-DRV(W32)
# ComWriteRead
#                      CONTEC Co., Ltd.
# =======================================
# =======================================
import serial
import serial.rs485


# =======================================
# main function
# =======================================
def main():
    # ---------------------------------------
    # input port name
    # ---------------------------------------
    port_name = input("Input Port Name:")
    # --------------------------------------
    # port open
    # timeout = 1 sec
    # --------------------------------------
    try:
        port = serial.Serial(port_name, timeout=1)
    except Exception as error_string:
        print(f"{error_string}")
        return
    # --------------------------------------
    # select action
    # --------------------------------------
    while True:
        print("----------------------------------------")
        print("Select Action")
        print("----------------------------------------")
        print("0:Set Parameter")
        print("1:Write")
        print("2:Read")
        print("3:Exit")
        print("----------------------------------------")
        action_number = input("Input Number:")
        print("")
        # ------------------
        # set parameter
        # ------------------
        if action_number == "0":
            set_parameter(port)
        # ------------------
        # write data
        # ------------------
        elif action_number == "1":
            send_data = input("Input Write Data:")
            port.write(send_data.encode('UTF-8'))
            print("Send OK")
        # ------------------
        # read data
        # ------------------
        elif action_number == "2":
            read_data = port.read(50)
            print(f"Read Data: {read_data} ")
        # ------------------
        # exit
        # ------------------
        elif action_number == "3":
            break
        # ------------------
        # input number error
        # ------------------
        else:
            print("Input Number Error")
        print("")
    # --------------------------------------
    # port close
    # --------------------------------------
    try:
        port.close()
    except Exception as error_string:
        print(f"{error_string}")


# ======================================
# set_parameter function
# ======================================
def set_parameter(port):
    # --------------------------------------
    # parameter back up
    # --------------------------------------
    backup_baudrate = port.baudrate
    backup_bytesize = port.bytesize
    backup_stopbits = port.stopbits
    backup_parity = port.parity
    backup_duplex = port.rs485_mode
    backup_rtscts = port.rtscts
    backup_dsrdtr = port.dsrdtr
    # --------------------------------------
    # select baud rate
    # --------------------------------------
    while True:
        print("----------------------------------------")
        print("Select Baud Rate")
        print("----------------------------------------")
        print(" 0:300")
        print(" 1:600")
        print(" 2:1200")
        print(" 3:2400")
        print(" 4:4800")
        print(" 5:9600")
        print(" 6:19200")
        print(" 7:38400")
        print(" 8:57600")
        print(" 9:115200")
        print("10:230400")
        print("11:460800")
        print("12:921600")
        baudrate_number = input("Input Number:")
        # ------------------
        # baud rate "300"
        # ------------------
        if baudrate_number == "0":
            baudrate_value = 300
            break
        # ------------------
        # baud rate "600"
        # ------------------
        elif baudrate_number == "1":
            baudrate_value = 600
            break
        # ------------------
        # baud rate "1200"
        # ------------------
        elif baudrate_number == "2":
            baudrate_value = 1200
            break
        # ------------------
        # baud rate "2400"
        # ------------------
        elif baudrate_number == "3":
            baudrate_value = 2400
            break
        # ------------------
        # baud rate "4800"
        # ------------------
        elif baudrate_number == "4":
            baudrate_value = 4800
            break
        # ------------------
        # baud rate "9600"
        # ------------------
        elif baudrate_number == "5":
            baudrate_value = 9600
            break
        # ------------------
        # baud rate "19200"
        # ------------------
        elif baudrate_number == "6":
            baudrate_value = 19200
            break
        # ------------------
        # baud rate "38400"
        # ------------------
        elif baudrate_number == "7":
            baudrate_value = 38400
            break
        # ------------------
        # baud rate "57600"
        # ------------------
        elif baudrate_number == "8":
            baudrate_value = 57600
            break
        # ------------------
        # baud rate "115200"
        # ------------------
        elif baudrate_number == "9":
            baudrate_value = 115200
            break
        # ------------------
        # baud rate "230400"
        # ------------------
        elif baudrate_number == "10":
            baudrate_value = 230400
            break
        # ------------------
        # baud rate "460800"
        # ------------------
        elif baudrate_number == "11":
            baudrate_value = 460800
            break
        # ------------------
        # baud rate "921600"
        # ------------------
        elif baudrate_number == "12":
            baudrate_value = 921600
            break
        # ------------------
        # input number error
        # ------------------
        else:
            print("Input Number Error\n")
    # --------------------------------------
    # set baud rate paramter
    # --------------------------------------
    try:
        port.baudrate = baudrate_value
    except Exception as error_string:
        print(f"{error_string}")
        port.baudrate = backup_baudrate
        port.bytesize = backup_bytesize
        port.stopbits = backup_stopbits
        port.parity = backup_parity
        port.rs485_mode = backup_duplex
        port.rtscts = backup_rtscts
        port.dsrdtr = backup_dsrdtr
        return
    print("")
    # --------------------------------------
    # select byte size
    # --------------------------------------
    while True:
        print("----------------------------------------")
        print("Select Byte Size")
        print("----------------------------------------")
        print(" 0:5")
        print(" 1:6")
        print(" 2:7")
        print(" 3:8")
        bytesize_number = input("Input Number:")
        # ------------------
        # byte size "5"
        # ------------------
        if bytesize_number == "0":
            bytesize_value = serial.FIVEBITS
            break
        # ------------------
        # byte size "6"
        # ------------------
        elif bytesize_number == "1":
            bytesize_value = serial.SIXBITS
            break
        # ------------------
        # byte size "7"
        # ------------------
        elif bytesize_number == "2":
            bytesize_value = serial.SEVENBITS
            break
        # ------------------
        # byte size "8"
        # ------------------
        elif bytesize_number == "3":
            bytesize_value = serial.EIGHTBITS
            break
        else:
            print("Input Number Error\n")
    # --------------------------------------
    # set byte size paramter
    # --------------------------------------
    try:
        port.bytesize = bytesize_value
    except Exception as error_string:
        print(f"{error_string}")
        port.bytesize = backup_bytesize
        port.baudrate = backup_baudrate
        port.stopbits = backup_stopbits
        port.parity = backup_parity
        port.rs485_mode = backup_duplex
        port.rtscts = backup_rtscts
        port.dsrdtr = backup_dsrdtr
        return
    print("")
    # --------------------------------------
    # select stop bits
    # --------------------------------------
    while True:
        print("----------------------------------------")
        print("Select Stop Bits")
        print("----------------------------------------")
        print(" 0:1")
        print(" 1:1.5")
        print(" 2:2")
        stopbits_number = input("Input Number:")
        # ------------------
        # stop bits "1"
        # ------------------
        if stopbits_number == "0":
            stopbits_value = serial.STOPBITS_ONE
            break
        # ------------------
        # stop bits "1.5"
        # ------------------
        elif stopbits_number == "1":
            stopbits_value = serial.STOPBITS_ONE_POINT_FIVE
            break
        # ------------------
        # stop bits "2"
        # ------------------
        elif stopbits_number == "2":
            stopbits_value = serial.STOPBITS_TWO
            break
        # ------------------
        # input number error
        # ------------------
        else:
            print("Input Number Error\n")
    # --------------------------------------
    # set stop bits paramter
    # --------------------------------------
    try:
        port.stopbits = stopbits_value
    except Exception as error_string:
        print(f"{error_string}")
        port.stopbits = backup_stopbits
        port.baudrate = backup_baudrate
        port.bytesize = backup_bytesize
        port.parity = backup_parity
        port.rs485_mode = backup_duplex
        port.rtscts = backup_rtscts
        port.dsrdtr = backup_dsrdtr
        return
    print("")
    # --------------------------------------
    # select parity
    # --------------------------------------
    while True:
        print("----------------------------------------")
        print("Select Parity")
        print("----------------------------------------")
        print(" 0:None")
        print(" 1:Odd")
        print(" 2:Even")
        parity_number = input("Input Number:")
        # ------------------
        # parity "None"
        # ------------------
        if parity_number == "0":
            parity_value = serial.PARITY_NONE
            break
        # ------------------
        # parity "Odd"
        # ------------------
        elif parity_number == "1":
            parity_value = serial.PARITY_ODD
            break
        # ------------------
        # parity "Evne"
        # ------------------
        elif parity_number == "2":
            parity_value = serial.PARITY_EVEN
            break
        # ------------------
        # input number error
        # ------------------
        else:
            print("Input Number Error\n")
    # --------------------------------------
    # set parity paramter
    # --------------------------------------
    try:
        port.parity = parity_value
    except Exception as error_string:
        print(f"{error_string}")
        port.parity = backup_parity
        port.baudrate = backup_baudrate
        port.bytesize = backup_bytesize
        port.stopbits = backup_stopbits
        port.rs485_mode = backup_duplex
        port.rtscts = backup_rtscts
        port.dsrdtr = backup_dsrdtr
        return
    print("")
    # --------------------------------------
    # select duplex
    # --------------------------------------
    while True:
        print("----------------------------------------")
        print("Select Duplex")
        print("----------------------------------------")
        print(" 0:Full Duplex")
        print(" 1:Half Duplex")
        duplex_number = input("Input Number:")
        # ------------------
        # duplex "Full Duplex"
        # ------------------
        if duplex_number == "0":
            duplex_value = None
            break
        # ------------------
        # duplex "Half Duplex"
        # ------------------
        elif duplex_number == "1":
            duplex_value = serial.rs485.RS485Settings()
            break
        # ------------------
        # input number error
        # ------------------
        else:
            print("Input Number Error\n")
    # --------------------------------------
    # set duplex paramter
    # --------------------------------------
    try:
        port.rs485_mode = duplex_value
    except Exception as error_string:
        print(f"{error_string}")
        port.rs485_mode = backup_duplex
        port.baudrate = backup_baudrate
        port.bytesize = backup_bytesize
        port.stopbits = backup_stopbits
        port.parity = backup_parity
        port.rtscts = backup_rtscts
        port.dsrdtr = backup_dsrdtr
        return
    print("")
    # --------------------------------------
    # set full duplex
    # --------------------------------------
    if duplex_number == "0":
        # --------------------------------------
        # select flow control
        # --------------------------------------
        while True:
            print("----------------------------------------")
            print("Select Flow Control")
            print("----------------------------------------")
            print(" 0:None")
            print(" 1:RTS/CTS")
            print(" 2:DSR/DTR")
            flowctl_number = input("Input Number:")
            # ------------------
            # flow control "NONE"
            # ------------------
            if flowctl_number == "0":
                rtscts_value = False
                dsrdtr_value = False
                break
            # ------------------
            # flow control "RTS/CTS"
            # ------------------
            elif flowctl_number == "1":
                rtscts_value = True
                dsrdtr_value = False
                break
            # ------------------
            # flow control "DSR/DTR"
            # ------------------
            elif flowctl_number == "2":
                rtscts_value = False
                dsrdtr_value = True
                break
            # ------------------
            # input number error
            # ------------------
            else:
                print("Input Number Error\n")
    # --------------------------------------
    # set half duplex
    # --------------------------------------
    else:
        # --------------------------------------
        # flow control none
        # --------------------------------------
        rtscts_value = False
        dsrdtr_value = False
    # --------------------------------------
    # set flow control paramter
    # --------------------------------------
    try:
        port.rtscts = rtscts_value
    except Exception as error_string:
        print(f"{error_string}")
        port.rtscts = backup_rtscts
        port.baudrate = backup_baudrate
        port.bytesize = backup_bytesize
        port.stopbits = backup_stopbits
        port.parity = backup_parity
        port.rs485_mode = backup_duplex
        port.dsrdtr = backup_dsrdtr
        return
    try:
        port.dsrdtr = dsrdtr_value
    except Exception as error_string:
        print(f"{error_string}")
        port.dsrdtr = backup_dsrdtr
        port.baudrate = backup_baudrate
        port.bytesize = backup_bytesize
        port.stopbits = backup_stopbits
        port.parity = backup_parity
        port.rs485_mode = backup_duplex
        port.rtscts = backup_rtscts
        return
    print("")
    # --------------------------------------
    # view parameter
    # --------------------------------------
    print("----------------------------------------")
    print("Set Parameter OK")
    print("----------------------------------------")
    # ------------------
    # baud rate
    # ------------------
    print(f"BaudRate   :{port.baudrate}")
    # ------------------
    # byte size
    # ------------------
    print(f"ByteSize   :{port.bytesize}")
    # ------------------
    # stop bits
    # ------------------
    print(f"StopBits   :{port.stopbits}")
    # ------------------
    # parity
    # ------------------
    if port.parity == serial.PARITY_ODD:
        print("Parity     :ODD")
    elif port.parity == serial.PARITY_EVEN:
        print("Parity     :EVEN")
    else:
        print("Parity     :NONE")
    # ------------------
    # duplex
    # ------------------
    if duplex_number == "1":
        print("Duplex     :HALF DUPLEX")
    else:
        print("Duplex     :FULL DUPLEX")
    # ------------------
    # flow control
    # ------------------
    if port.rtscts:
        print("FlowControl:RTS/CTS")
    elif port.dsrdtr:
        print("FlowControl:DSR/DTS")
    else:
        print("FlowControl:NONE")


# ======================================
# call main function
# ======================================
if __name__ == '__main__':
    main()

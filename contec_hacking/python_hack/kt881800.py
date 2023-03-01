"""
Created on Dec 02, 2021

@author: Aleksandar Miladinovic email: alex.miladinovich@gmail.com

Python script used to decode serial data stream of Contec KT88-1800/1600 EEG amplifier and stream it to the local network via LSL

"""
import time
import serial
from pylsl import StreamInfo, StreamOutlet
import sys
import serial.tools.list_ports

ser=serial.Serial()
if len(sys.argv) > 1:
    COM_PORT=sys.argv[1:]
else:
    # port not given, using default
    if sys.platform == 'win32':
        COM_PORT='COM3'
    else:
        COM_PORT='/dev/cu.usbserial-1420'

ser = serial.Serial(port=COM_PORT,
                    baudrate=921600, parity=serial.PARITY_NONE,
                    stopbits=serial.STOPBITS_ONE,
                    bytesize=serial.EIGHTBITS,xonxoff=False,rtscts=False,dsrdtr=False)




def start_acquisition():
    packet = bytearray()
    packet.append(0x83)
    packet.append(0x88)
    return ser.write(packet)


def stop_acquisition():
    packet = bytearray()
    packet.append(0xFF)
    return ser.write(packet)


def send_default_configuration_to_EEG():
    # stop acquisition
    packet = bytearray()
    packet.append(0x90)
    packet.append(0x02)
    ser.write(packet)
    time.sleep(0.3)

    packet = bytearray()
    packet.append(0x80)
    packet.append(0x00)
    ser.write(packet)
    time.sleep(0.3)

    packet = bytearray()
    packet.append(0x81)
    packet.append(0x00)
    ser.write(packet)
    time.sleep(0.3)

    # set BN as REF (91 + 01 - AA, 02 - A1, 03 - A2, 04 - AVG, 05 - Cz, 06 - BN)
    packet = bytearray()
    packet.append(0x91)
    packet.append(0x01)
    ser.write(packet)
    time.sleep(0.3)

    # Enable HW filter 0.03Hz to 40Hz see https://patents.google.com/patent/CN103505200A/en
    packet = bytearray()
    packet.append(0x90)
    packet.append(0x03) #04 to disable it
    ser.write(packet)
    time.sleep(0.3)

    # Disable impedance measurement
    packet = bytearray()
    packet.append(0x90)
    packet.append(0x06)
    ser.write(packet)
    time.sleep(0.3)

    ser.flushInput()
    ser.flushOutput()

    return 1


def main():
    print("Send default")
    send_default_configuration_to_EEG();

    print("Start acquisition")
    start_acquisition()

    print("Setup LSL")
    stream_info_KT88 = StreamInfo('KT88', 'EEG', 18, 100, 'float32', 'kt_88_1800_EEG')
    print('Done')

    # add channel labels
    channels = stream_info_KT88.desc().append_child("channels")
    ch_labels = ['Fp1', 'Fp2', 'F3', 'F4', 'C3', 'C4', 'P3', 'P4', 'O1', 'O2', 'F7', 'F8', 'T3', 'T4', 'T5', 'T6','ECG1','ECG2']

    for c in ch_labels:
        ch=channels.append_child("channel")
        ch.append_child_value("label", c)

    # next make an outlet
    kt88_outlet = StreamOutlet(stream_info_KT88)


    ser.flushInput()
    ser.flushOutput()

    # init channels
    channel = []
    for ch in range(0, 18):
        channel.append(0)

    while 1:
        # find marker
        ser.read_until(b"\xFF")
        ser.read(1)

        for bt in range(18):
           x = ser.read(2)
           channel[bt] = ((x[0]<<8)+x[1]) & ((0x0F<<8) + 0xFF)

        for ch in range(0, 18):
            channel[ch] = float(channel[ch]-2048)/10
        # if kt88_outlet.have_consumers():
        #     print(channel[ch])
        #     kt88_outlet.push_sample(channel)
        print(channel)

if __name__ == '__main__':
    main()

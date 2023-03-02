# code to read from the arduino connected to the loadcells and print the weight and force values.

import serial
import csv

ser  = serial.Serial('com3',9600,timeout=1)
#data_file =open("3_load.csv",'a')
# remember to create file before starting
data_file = open('D:/python/final-project/final_test_22_06.csv','a')
logger = csv.writer(data_file)

def Serial_read():

    raw_data_x = ser.readline()
    string_x = raw_data_x.decode()


    raw_data_y = ser.readline()
    string_y = raw_data_y.decode()


    raw_data_z = ser.readline()
    string_z = raw_data_z.decode()



    return string_x,string_y,string_z

for i in range(700):

    x,y,z= Serial_read()
    data_per_read = [x,y,z]
    logger.writerow(data_per_read)
    print(i+1,x,y,z)
data_file.close()
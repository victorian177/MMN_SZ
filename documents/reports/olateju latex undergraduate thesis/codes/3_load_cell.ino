/*
  Code to theoreitcally read and print the data from 3 load cells simultaneously.
*/
#include "HX711.h"
HX711 scalex;
HX711 scaley;
HX711 scalez;

#define calibration_z 220000 /*10kg*/
#define calibration_y 361640 /*5kg*/
#define calibration_x 361340   /*5kg*/


//scalen.begin(out,clk)

void setup() {
  Serial.begin(9600);
  //Serial.println("3 loadcell test");


  scalez.begin(7, 6); 
  scaley.begin(9, 8); 
  scalex.begin(11, 10); 

  scalex.set_scale(calibration_x);
  scaley.set_scale(calibration_y);
  scalez.set_scale(calibration_z);

  scalex.tare();
  scaley.tare();
  scalez.tare();

}
void loop() {
  Serial.println(scalex.get_units(),2);
  Serial.println(scaley.get_units()),2;
  Serial.println(scalez.get_units(),2);
    
  delay(500);
}

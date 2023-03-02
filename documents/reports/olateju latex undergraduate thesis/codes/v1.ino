int data=0;

long selfDrivenMotorAngle=0;
long circuitDrivenMotorAngle=0;
long oldSelfEncoderCount=0;
long newSelfEncoderCount=0;
long oldCircuitEncoderCount=0;
long newCircuitEncoderCount=0;

//MOTOR CONTROL FUNCTIONS
void MotorClockwise(){digitalWrite(8,HIGH);}
void MotorCounterClockwise(){digitalWrite(8,LOW);}
void MotorOn(){digitalWrite(9,HIGH);}
void MotorOff(){digitalWrite(9,LOW);}

void setup() {
  // put your setup code here, to run once:

  Serial.begin (2000000);
  
  pinMode(2, INPUT_PULLUP); //ROTARY circuitEncoder PIN WHITE
  pinMode(3, INPUT_PULLUP); //ROTARY selfEncoder PIN WHITE
  pinMode(4, INPUT_PULLUP); //ROTARY circuitEncoder PIN GREEN
  pinMode(5, INPUT_PULLUP); //ROTARY selfEncoder PIN GREEN
  //TAKE NOTE THAT YOU ARE MAKING USE OF THE DOWN MOTOR DRIVER IN PULSR2 CONTROL BOX
  pinMode(8, OUTPUT);                                       //FR
  pinMode(9, OUTPUT);                                       //EN
  //self driven motor encoder intterupt
  attachInterrupt(0, circuitEncoderInterruptFunction, RISING);
  //circuit driven motor encoder interrupt
  attachInterrupt(1, selfEncoderInterruptFunction, RISING);
}

void loop() {
  // put your main code here, to run repeatedly:
  if(Serial.available()>0){
    data=Serial.read();
    sendEncodersReading2GUI();
  }
  if(data==0)MotorOff();
  else{
    MotorOn();
    if((oldSelfEncoderCount==600) and (newSelfEncoderCount==0))MotorClockwise();
    else if((oldSelfEncoderCount==0) and (newSelfEncoderCount==600))MotorCounterClockwise();
    else if(oldSelfEncoderCount<newSelfEncoderCount)MotorClockwise();
    else if(oldSelfEncoderCount>newSelfEncoderCount)MotorCounterClockwise();
    else if((oldSelfEncoderCount==0) and (newSelfEncoderCount==0)){
      MotorCounterClockwise();
      delay(800);
      MotorOff();
      delay(1000);
    }
  }
}

void selfEncoderInterruptFunction(){
  oldSelfEncoderCount=newSelfEncoderCount;
  if(digitalRead(5)==LOW){
//    if(newSelfEncoderCount==600)newSelfEncoderCount=0;
//    else
    newSelfEncoderCount++;
  }
  else{
//    if(newSelfEncoderCount==0)newSelfEncoderCount=600;
//    else 
    newSelfEncoderCount--;
  }
}

void circuitEncoderInterruptFunction(){
  oldCircuitEncoderCount=newCircuitEncoderCount;
  if(digitalRead(4)==LOW){
//    if(newCircuitEncoderCount==600)newCircuitEncoderCount=0;
//    else 
    newCircuitEncoderCount++;
  }
  else{
//    if(newCircuitEncoderCount==0)newCircuitEncoderCount=600;
//    else 
    newCircuitEncoderCount--;
  }
}

void sendEncodersReading2GUI(){
    Serial.print('u');
    Serial.print(newSelfEncoderCount);
    Serial.print('d');
    Serial.print(newCircuitEncoderCount);
    Serial.print('e');
    Serial.print('\n');
    Serial.flush();
}

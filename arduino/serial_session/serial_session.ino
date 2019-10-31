#include <IRremote.h>

// ir config
unsigned int irSignalON[] =  {9100 , 4750 , 500 , 750 , 500 , 1750 , 450 , 750 , 500 , 1750 , 500 , 1800 , 500 , 700 , 500 , 1750 , 500 , 800 , 450 , 1750 , 500 , 750 , 500 , 1750 , 500 , 700 , 500 , 750 , 500 , 1750 , 500 , 750 , 450 , 1850 , 450 , 1750 , 500 , 750 , 500 , 1750 , 450 , 750 , 500 , 750 , 500 , 1750 , 500 , 750 , 450 , 1850 , 450 , 700 , 500 , 1750 , 500 , 750 , 500 , 1750 , 500 , 1750 , 500 , 750 , 500 , 1750 , 500 , 750 , 500 };
unsigned int irSignalOFF[] = {9100 , 4750 , 500 , 700 , 550 , 1700 , 450 , 800 , 450 , 1800 , 500 , 1750 , 450 , 750 , 500 , 1750 , 500 , 800 , 400 , 1800 , 450 , 750 , 500 , 1800 , 500 , 750 , 500 , 700 , 500 , 1750 , 500 , 750 , 500 , 1800 , 450 , 700 , 450 , 800 , 450 , 1800 , 500 , 750 , 500 , 1750 , 500 , 1700 , 550 , 700 , 500 , 1800 , 400 , 1800 , 450 , 1850 , 500 , 700 , 500 , 1750 , 500 , 750 , 450 , 750 , 450 , 1800 , 550 , 750 , 450 };
IRsend irsend;

int touch_sensor = 8;
int move_sensor = 9;
int temperature_sensor = 0;

void setup() {
  // put your setup code here, to run once:
  pinMode(touch_sensor, INPUT);
  pinMode(move_sensor, INPUT);
  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
  bool is_touching = digitalRead(touch_sensor);  
  bool is_moving = digitalRead(move_sensor) != 1;
  int temperature = analogRead(temperature_sensor) * (500.0/1023.0);

  if (Serial.available()) {
    String device = Serial.readStringUntil('\n');
  
    if (device == "touch") {
      Serial.println(is_touching);
    }
    else if(device == "move") {
      Serial.println(is_moving);
    }
    else if (device == "temperature"){
      Serial.println(temperature);
    }
    else if (device == "ledon") {
      irsend.sendRaw(irSignalON, sizeof(irSignalON) / sizeof(irSignalON[0]), khz); //Note the approach used to automatically calculate the size of the array.
      Serial.println("led is on");
    }
    else if (device == "ledoff") {
      irsend.sendRaw(irSignalOFF, sizeof(irSignalOFF) / sizeof(irSignalOFF[0]), khz); //Note the approach used to automatically calculate the size of the array.
      Serial.println("led is off");
    }
    else {
      Serial.println(device);
      Serial.println("This device is Unknown.");
    }
  }
}

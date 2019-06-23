int touch_sensor = 8;

void setup() {
  // put your setup code here, to run once:
  pinMode(touch_sensor, INPUT);
  Serial.begin(19200);
}

void loop() {
  // put your main code here, to run repeatedly:
  int is_touching = digitalRead(touch_sensor);  

  if (Serial.available()) {
    String device = Serial.readStringUntil('\n');
  
    if (device == "touch_sensor") {
      Serial.println(is_touching);
    }
    else {
      Serial.println(device);
      Serial.println("This device is Unknown.");
    }
  }
}

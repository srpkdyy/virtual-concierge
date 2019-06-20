int touch_sns = 8;

void setup() {
  // put your setup code here, to run once:
  pinMode(touch_sns, INPUT);
  Serial.begin(19200);
}

void loop() {
  // put your main code here, to run repeatedly:
  int is_touching = digitalRead(touch_sns);  

  if (Serial.available()) {
    String device = Serial.readStringUntil('\n');
  
    if (device == "touch_sns") {
      Serial.println(is_touching);
    }
    else {
      Serial.println(device);
      Serial.println("This device is Unknown.");
    }
  }
}

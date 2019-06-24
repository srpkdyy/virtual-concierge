int touch_sensor = 8;
int temperature_sensor = 0;

void setup() {
  // put your setup code here, to run once:
  pinMode(touch_sensor, INPUT);
  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
  int is_touching = digitalRead(touch_sensor);  
  int temperature = analogRead(temperature_sensor) * (500.0/1023.0);

  if (Serial.available()) {
    String device = Serial.readStringUntil('\n');
  
    if (device == "touch") {
      Serial.println(is_touching);
    }
    else if (device == "temperature"){
      Serial.println(temperature);
    }
    else {
      Serial.println(device);
      Serial.println("This device is Unknown.");
    }
  }
}

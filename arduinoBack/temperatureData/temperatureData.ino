const int temperaturePin = 0;

void setup()
{
  Serial.begin(9600);
}

void loop()
{  
  float voltage, degreesC, degreesF;

  voltage = analogRead(temperaturePin) * 0.004882814;
  degreesC = (voltage - 0.5) * 100.0;
  degreesF = degreesC * (9.0/5.0) + 32.0;
 
  Serial.println("v: " + String(voltage) + ",c: " + String(degreesC) + ",f: " + String(degreesF));   
  delay(1000);
}

#include <Bridge.h>
#include <HttpClient.h>

const int temperaturePin = 0;

void setup()
{
  Serial.begin(9600);
}

void loop()
{
  HttpClient http;
  String url="https://192.168.86.250:5001/api/update/temperature";
  String jsondata=("{\"name\":\"value\"}");
  
  http.begin(url); 
  http.addHeader("Content-Type", "Content-Type: application/json"); 

  int httpResponseCode = http.POST(jsondata); //Send the actual POST request

  if(httpResponseCode>0){
    String response = http.getString();  //Get the response to the request
    Serial.println(httpResponseCode);   //Print return code
    Serial.println(response);           //Print request answer
  } else {
    Serial.print("Error on sending POST: ");
    Serial.println(httpResponseCode);

    http.end();

  delay(10000);
  
  float voltage, degreesC, degreesF;

  voltage = analogRead(temperaturePin) * 0.004882814;
  degreesC = (voltage - 0.5) * 100.0;
  degreesF = degreesC * (9.0/5.0) + 32.0;
 

  Serial.print("voltage: ");
  Serial.print(voltage);
  Serial.print("  deg C: ");
  Serial.print(degreesC);
  Serial.print("  deg F: ");
  Serial.println(degreesF);

  // These statements will print lines of data like this:
  // "voltage: 0.73 deg C: 22.75 deg F: 72.96"
   
  delay(1000); // repeat once per second (change as you wish!)
}

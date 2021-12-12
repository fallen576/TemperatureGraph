#include<WiFiNINA.h>
const int temperaturePin = 0;

/*
Shoutout to www.elithecomputerguy.com
*/

String url="https://192.168.86.250:5001/api/update/temperature";
String jsondata=("{\"Voltage\":1,\"Celcius\":2,\"Farhenheit\":3}");

//wifi user and pass.. tdb cause my arduino doesnt have wifi :)
char ssid[] = "";
char pass[] = "";

int status = WL_IDLE_STATUS;

char server[] = "192.168.86.250";

String postData;
String postVariable = "";

WiFiClient client;

void setup()
{
  
  Serial.begin(9600);

  while (status != WL_CONNECTED) {
    Serial.print("Attempting to connect to Network named: ");
    Serial.println(ssid);
    status = WiFi.begin(ssid, pass);
    delay(10000);
  }

  Serial.print("SSID: ");
  Serial.println(WiFi.SSID());
  IPAddress ip = WiFi.localIP();
  IPAddress gateway = WiFi.gatewayIP();
  Serial.print("IP Address: ");
  Serial.println(ip);
}

void loop()
{
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

  if (client.connect(server, 5001)) {
    client.println("POST /api/update/temperature HTTP/1.1");
    client.println("Host: iphere");
    client.println("Content-Type: application/json");
    client.print("Content-Length: ");
    client.println(postData.length());
    client.println();
    client.print(postData);
  }

  if (client.connected()) {
    client.stop();
  }
}

void post() {
}

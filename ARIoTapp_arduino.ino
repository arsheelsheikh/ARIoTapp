#define BLYNK_TEMPLATE_ID "TMPL3eLuYCnqD"
#define BLYNK_TEMPLATE_NAME "ARIoTapp"
#define BLYNK_AUTH_TOKEN "K6AeOBC-KhCtK4AMndy5MV2vM7DWzbrG"
#define BLYNK_PRINT Serial

#include <ESP8266WiFi.h>
#include <BlynkSimpleEsp8266.h>

char auth[] = BLYNK_AUTH_TOKEN;
char ssid[] = "why?";  // ENTER YOUR WIFI SSID
char pass[] = "arsheel1";  // ENTER YOUR WIFI PASSWORD

BLYNK_WRITE(V0)
{
  int value = param.asInt();
  Serial.println(value);
  if(value == 0)
  {
    digitalWrite(D4,HIGH);
  }
  if(value == 1)
  {
    digitalWrite(D4,LOW);
  } 
}


void setup()
{  
  pinMode(D4,OUTPUT);
  Serial.begin(115200);
  Blynk.begin(auth, ssid, pass);  
}

void loop()
{
  Blynk.run();
}
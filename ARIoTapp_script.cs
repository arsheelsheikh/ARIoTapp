using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Networking;

public class ARIoTapp_script : MonoBehaviour
{
    public VirtualButtonBehaviour VB_ON;
    public VirtualButtonBehaviour VB_OFF;
    public string URL_ON;
    public string URL_OFF;

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

        }
    }

    void Start()
    {
        VB_ON.RegisterOnButtonPressed(OnButtonPressed_on);

        VB_OFF.RegisterOnButtonPressed(OnButtonPressed_off);
       
    }


    public void OnButtonPressed_on(VirtualButtonBehaviour VB_ON)
    {
        StartCoroutine(GetRequest(URL_ON));
        Debug.Log("LED IS ON");
    }

    public void OnButtonPressed_off(VirtualButtonBehaviour VB_OFF)
    {
        StartCoroutine(GetRequest(URL_OFF));
        Debug.Log("LED IS OFF");
    }

}


#define BLYNK_TEMPLATE_ID "TMPL3eLuYCnqD"
#define BLYNK_TEMPLATE_NAME "ARIoTapp"
#define BLYNK_AUTH_TOKEN "K6AeOBC-KhCtK4AMndy5MV2vM7DWzbrG"

#define BLYNK_PRINT Serial
#include <ESP8266WiFi.h>
#include <BlynkSimpleEsp8266.h>

char auth[] = BLYNK_AUTH_TOKEN;
char ssid[] = "SHEIKH RESIDENCE";  // ENTER YOUR WIFI SSID
char pass[] = "12345678@";  // ENTER YOUR WIFI PASSWORD

BLYNK_WRITE(V0)
{
  int value = param.asInt();
  Serial.println(value);
  if(value == 0)
  {
    digitalWrite(LED_BUILTIN,HIGH);
  }
  if(value == 1)
  {
    digitalWrite(LED_BUILTIN,LOW);
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

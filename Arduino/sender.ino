#include <LoRa.h>
#include <SPI.h>
#include <MFRC522.h>
 
// LoRa module definitions
#define LORA_SCK 18   // LoRa SCK Pin
#define LORA_MISO 19  // LoRa MISO Pin
#define LORA_MOSI 23  // LoRa MOSI Pin
#define LORA_SS 5     // LoRa NSS Pin
#define LORA_RST 14   // LoRa NRESET Pin
#define LORA_DIO0 26  // LoRa DIO0 Pin
 
// RFID module definitions
#define SS_PIN 25   // RFID SS pin
#define RST_PIN 27  // RFID RST pin
MFRC522 mfrc522(SS_PIN, RST_PIN);
 
const int redPin = 15;
const int greenPin = 2;
const int bluePin = 0;
 
// Device ID for this sender
#define DEVICE_ID 2
 
void setup() {
  Serial.begin(115200);
  SPI.begin();         // Init SPI bus
  mfrc522.PCD_Init();  // Init RFID module
 
  LoRa.setPins(LORA_SS, LORA_RST, LORA_DIO0);
  if (!LoRa.begin(433E6)) {  // Init LoRa module
    Serial.println("LoRa initialization failed");
    while (1)
      ;
  }
  Serial.println("LoRa initialization successful");
 
  pinMode(redPin, OUTPUT);
  pinMode(greenPin, OUTPUT);
  pinMode(bluePin, OUTPUT);
}
 
 
void loop() {
  yield();
  // Check for new RFID cards
  if (mfrc522.PICC_IsNewCardPresent() && mfrc522.PICC_ReadCardSerial()) {
    String rfidData = "";
    for (byte i = 0; i < mfrc522.uid.size; i++) {
      rfidData += String(mfrc522.uid.uidByte[i] < 0x10 ? "0" : "");
      rfidData += String(mfrc522.uid.uidByte[i], HEX);
    }
    rfidData.toUpperCase();
 
    // Send RFID data via LoRa
    LoRa.beginPacket();
    LoRa.print(String(DEVICE_ID) + "," + rfidData);
    LoRa.endPacket();
    Serial.println("RFID Data sent via LoRa: " + rfidData);
 
    setColor(0, 255, 0);
    delay(1000);  // Delay to avoid sending duplicate data
  }
  setColor(255, 0, 0);
}
 
 
void setColor(int red, int green, int blue) {
  // Set RGB values using PWM
 
  analogWrite(redPin, red);
  analogWrite(greenPin, green);
  analogWrite(bluePin, blue);
}
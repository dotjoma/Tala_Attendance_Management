// #include <LiquidCrystal_I2C.h>
#include <Wire.h>
#include <SPI.h>
#include <MFRC522.h>
// #include <LoRa.h>

// RFID module definitions
#define SS_PIN 10
#define RST_PIN 9
// LiquidCrystal_I2C lcd(0x3F,16,2);
MFRC522 mfrc522(SS_PIN, RST_PIN);  // Create MFRC522 instance

// // LoRa module definitions
// #define LORA_SCK 13   // LoRa SCK Pin
// #define LORA_MISO 12  // LoRa MISO Pin
// #define LORA_MOSI 11  // LoRa MOSI Pin
// #define LORA_SS 5     // LoRa NSS Pin
// #define LORA_RST 6    // LoRa NRESET Pin
// #define LORA_DIO0 8   // LoRa DIO0 Pin
// #define DEVICE_ID

int code[] = { 32, 154, 149, 117 };  //This is the stored UID (Unlock Card)

int codeRead = 0;

String uidString;



void setup() {
  Serial.begin(9600);  //change to 115200 if lora is used
  SPI.begin();         // Init SPI bus
  mfrc522.PCD_Init();  // Init RFID module

  // lcd.init();
  // lcd.backlight();

  // lcd.setCursor(0,0);

  // lcd.print("Show your card:)");

  // LoRa.setPins(LORA_SS, LORA_RST, LORA_DIO0);
  // if (!LoRa.begin(433E6)) {  // Init LoRa module
  //   Serial.println("Sender LoRa initialization failed");
  //   while (1);
  // }
  // Serial.println("Sender LoRa initialization successful");
  // Serial.println("RFID Initialized");
}

void loop() {
  if (mfrc522.PICC_IsNewCardPresent() && mfrc522.PICC_ReadCardSerial()) {
    String tag_id = "";
    for (byte i = 0; i < mfrc522.uid.size; i++) {
      tag_id += String(mfrc522.uid.uidByte[i] < 0x10 ? "0" : "");
      tag_id += String(mfrc522.uid.uidByte[i], HEX);

      //   lcd.print(mfrc522.uid.uidByte[i] < 0x10 ? " 0" : " ");
      //   lcd.print(mfrc522.uid.uidByte[i], HEX);
    }
    tag_id.toUpperCase();
    Serial.println(tag_id);
    
    // Halt the card and wait to prevent duplicate reads
    mfrc522.PICC_HaltA();
    mfrc522.PCD_StopCrypto1();
    delay(1000);  // Wait 1 second before allowing another read
  }
  // LoRa.beginPacket();
  // Serial.println("Lora Begin Packet: " + String(LoRa.beginPacket()));
  // String message = String(DEVICE_ID) + "," + tag_id;
  // Serial.println("Sending message: " + message);
  // LoRa.print(message);
  // LoRa.endPacket();
  // Serial.println("Message sent");
}
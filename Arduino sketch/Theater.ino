#define outputA 6
#define outputB 7

#define ButtonRed 4
#define ButtonYellow 3
#define ButtonBlue 2

int counter = 0;
int aState;
int aLastState;

const int soundSensorPin = A0; 

const int trigPin = 13;  // Connect the trigger pin of the ultrasonic sensor to digital pin 2
const int echoPin = 12;




void setup() {
  // put your setup code here, to run once:
  pinMode (outputA, INPUT);
  pinMode (outputB, INPUT);

  pinMode(trigPin, OUTPUT);
  pinMode(echoPin, INPUT);

  //pinMode(ButtonRed, INPUT);
  //pinMode(ButtonYellow, INPUT);
  //pinMode(ButtonBlue, INPUT);

  Serial.begin (9600);
  aLastState = digitalRead(outputA);


}

void loop() {
  // put your main code here, to run repeatedly:
  aState = digitalRead(outputA);
  if (aState != aLastState){
    if (digitalRead(outputB) != aState) {
      counter ++;
    } else {
      counter --;

    }
    Serial.print("Position: ");
    Serial.println(counter);

  }

  aLastState = aState;


  // You can add additional code or logic as needed for your project



  checkSound();
  checkDistance();  // Call the checkDistance function

  checkButton();

  delay(100);
}


void checkButton(){
  int ButtonRedState = digitalRead(ButtonRed);
  int ButtonYellowState = digitalRead(ButtonYellow);
  int ButtonBlueState = digitalRead(ButtonBlue);

   if (ButtonRedState == LOW) {
    Serial.println("R");
    delay(100); // Add a small delay to avoid rapid multiple prints
  }

   if (ButtonYellowState == LOW) {
    Serial.println("Y");
    delay(100); // Add a small delay to avoid rapid multiple prints
  }

   if (ButtonBlueState == LOW) {
    Serial.println("B");
    delay(100); // Add a small delay to avoid rapid multiple prints
  }
}



void checkSound(){
  int soundValue = analogRead(soundSensorPin);  // Read the analog value from the sound sensor

  // Adjust this threshold value according to your sensor and environment
  int threshold = 150;
 if (soundValue > threshold) {
    Serial.println("S");  // Print "S" when a sound is detected
    delay(100);  // Add a delay to prevent continuous printing for a single sound event
  }
}

void checkDistance() {
  // Trigger the ultrasonic sensor
  digitalWrite(trigPin, LOW);
  delayMicroseconds(2);
  digitalWrite(trigPin, HIGH);
  delayMicroseconds(10);
  digitalWrite(trigPin, LOW);

  // Read the duration of the echo pulse
  long duration = pulseIn(echoPin, HIGH);

  // Calculate the distance in centimeters
  int distance = duration * 0.034 / 2;

  // Adjust this threshold value according to your requirements
  int threshold = 20;
  


  if (distance < threshold) {
    //Serial.println("U");  // Print "U" when the distance is lower than 20cm
    Serial.print("Distance: ");
    Serial.println(distance);
   
    delay(500);  // Add a delay to prevent continuous printing for a single event
  }

  // You can add additional code or logic as needed for your project
}
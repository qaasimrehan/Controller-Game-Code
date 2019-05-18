#define pressed LOW

int leftPin = 4;
int startPin = 3;
int rightPin = 2;

int leftState = 0;
int startState = 0;
int rightState = 0;
int d = 0;

void setup() {
  Serial.begin(9600);
  pinMode(leftPin, INPUT);
  pinMode(startPin, INPUT);
  pinMode(rightPin, INPUT);
  //Serial.println("");
}

void loop() {
  // put your main code here, to run repeatedly:
  leftState = digitalRead(leftPin);
  startState = digitalRead(startPin);
  rightState = digitalRead(rightPin);
  delay(150);
  
  if (leftState == pressed) {
    Serial.print("L");
    d = 1;

  }
  else if (rightState == pressed) {
    Serial.print("R");
    d = 2;
  } else if (startState == pressed) {
    Serial.print ("S");
    }else {
    Serial.print("N");
  }


}

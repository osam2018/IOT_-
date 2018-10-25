#include <LiquidCrystal.h>
LiquidCrystal lcd(12,11,5,4,3,2);

int step = 0;
int flag = 0;
char message[200] = {0};
int message_len = 0;
int start_value = 0;
char cheer_up[100] = {0};
int cheer_up_len = 0;
char alternative[100] = {0};
int alternative_len = 0;

void setup() {
  // put your setup code here, to run once:
  lcd.begin(16,2);
  step = 1;

  pinMode(6,INPUT);
  pinMode(7,INPUT);
  pinMode(8,INPUT);
  pinMode(9,INPUT);

  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
   if(step == 1)
   {
      if(flag == 0)
      {
        lcd.clear();
        lcd.print("If you sad,");
        lcd.setCursor(0,1);
        lcd.print("Push the Button!");
        flag = 1;
      }
      if(Serial.available())
      {
        message_len = Serial.readBytes(message, 200);
        message[message_len] = 0;

        int index = 0, _check = 0;
        for (int i = 0; message[i]; i++)
        {
          if(_check == 0)
          {
            if(message[i] == '_')
            {
              cheer_up[index++] = 0;
              cheer_up_len = index;
              index = 0;
              _check = 1;
            }
            else
            {
              cheer_up[index++] = message[i];
            }
          }
          else
          {
            alternative[index++] = message[i];
          }
        }
        alternative[index] = 0;
        alternative_len = index;
       // Serial.println(String(cheer_up_len));
       // Serial.println(String(alternative_len));

        step = 2;
        flag = 0;
      }
   }

   else if(step == 2)
   {
      if(flag == 0)
      {
        lcd.clear();
        lcd.print("Parent's Message");
        start_value = 0;
        flag = 1;
      }
      
      lcd.setCursor(0,1);
      for (int i = 0; i < 16; i++)
      {
        if(start_value + i > cheer_up_len - 2)
        {
          lcd.print(' ');
        }
        else
        {
          lcd.print(cheer_up[start_value + i]);
        }
      }
      if(start_value == 0)
      {
        delay(2000);
      }
      else
      {
        delay(500);
      }
      
      if(++start_value == cheer_up_len)
      {
        delay(500);
        
        step = 3;
        flag = 0;
      }
   }
   
   else if(step == 3)
   {
      if(flag == 0)
      {
        lcd.clear();
        lcd.print("Alternative");
        start_value = 0;
        flag = 1;
      }
      
      lcd.setCursor(0,1);
      for (int i = 0; i < 16; i++)
      {
        if(start_value + i > alternative_len - 2)
        {
          lcd.print(' ');
        }
        else
        {
          lcd.print(alternative[start_value + i]);
        }
      }
      if(start_value == 0)
      {
        delay(2000);
      }
      else
      {
        delay(500);
      }
      
      if(++start_value == alternative_len)
      {
        delay(500);
        
        step = 1;
        flag = 0;
      }
   }

   if(digitalRead(6) == HIGH)
   {
      while(digitalRead(6));
      Serial.print(String(1));
   }
   if(digitalRead(7) == HIGH)
   {
      while(digitalRead(7));
      Serial.print(String(2));
   }
   if(digitalRead(8) == HIGH)
   {
      while(digitalRead(8));
      Serial.print(String(3));
   }
   if(digitalRead(9) == HIGH)
   {
      while(digitalRead(9));
      Serial.print(String(4));
   }
}

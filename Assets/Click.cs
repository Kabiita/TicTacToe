using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;/*gives us diff  text data types*/
using UnityEngine.UI;

public class Click : MonoBehaviour
{
   
   
   bool isPlayerOneTurn= true;
   [SerializeField] private TextMeshProUGUI[] textElement =new TextMeshProUGUI[9];
   [SerializeField] private Button[] buttonCollection =new Button[9];
   [SerializeField] private TextMeshProUGUI statusHolder=null;
   [SerializeField] private TextMeshProUGUI turnHolder=null;
    
    private int buttonNo;
    private bool everyTextIsfilled=false;

    public void Start()
    {
        turnHolder.text="Turn of Player 1";
    }
    

    public void Afterclick(int buttonNumber)
    {
       buttonCollection[buttonNumber -1].interactable = false;
       buttonNo=buttonNumber;
      DetectPlayer();
     
    }
   
   void DetectPlayer()
   {
     if(isPlayerOneTurn == true)
     {

        textElement[buttonNo -1].text = "X";
        isPlayerOneTurn = false;
        turnHolder.text="Turn of Player 2";
        
     }
     else
     {
       textElement[buttonNo -1].text = "O";
        isPlayerOneTurn = true;
         turnHolder.text="Turn of Player 1";
        
     }
     DetectIfWin();
   }
   void DetectIfWin()
   {
      if(textElement[0].text != "" && textElement[0].text==textElement[1].text && textElement[1].text==textElement[2].text)
  {
    winCondition(textElement[0].text);
  }
  else if(textElement[3].text != "" && textElement[3].text==textElement[4].text && textElement[4].text==textElement[5].text)
  {
    winCondition(textElement[3].text);
  }
  else if(textElement[6].text != "" && textElement[6].text==textElement[7].text && textElement[7].text==textElement[8].text)
  {
    winCondition(textElement[6].text);
  }
  else if(textElement[0].text != "" && textElement[0].text==textElement[3].text && textElement[3].text==textElement[6].text)
  {
     winCondition(textElement[0].text);
  }
  else if(textElement[1].text != "" && textElement[1].text==textElement[4].text && textElement[4].text==textElement[7].text)
  {
    winCondition(textElement[1].text);
  }
  else if(textElement[2].text != "" && textElement[2].text==textElement[5].text && textElement[5].text==textElement[8].text)
  {
     winCondition(textElement[2].text);
  }
  else if(textElement[0].text != "" && textElement[0].text==textElement[4].text && textElement[4].text==textElement[8].text)
  {
    winCondition(textElement[0].text);
  }
  else if(textElement[2].text != "" && textElement[2].text==textElement[4].text && textElement[4].text==textElement[6].text)
  {
    winCondition(textElement[2].text);
  }
  
  else
     {
        CheckIfAllButtonsAreFilled();
        if(everyTextIsfilled == true)
        {
      statusHolder.text= "Draw";
           
        }
     }
  }
  void TurnOffInteractable()
  {
     for(int i = 0; i <= 8; i++)
     {
        buttonCollection[i].interactable=false;
     }
  }
   void TurnOnInteractable()
  {
     for(int i = 0; i <= 8; i++)
     {
        buttonCollection[i].interactable=true;
     }
  }
  void CheckIfAllButtonsAreFilled()
  {
     int count=0;
     for(int i=0; i<=8;i++)
     {
        if(textElement[i].text!="")
        {
           count++;
        }
     }
  
   if(count == 9)
  {
    everyTextIsfilled = true;
     turnHolder.text="";
  }
  else
  {
    everyTextIsfilled = false;
  }
 }
 void whichPlayerWon(string textElement)
 {
   if(textElement == "X")
     {
      statusHolder.text= " Won by Player 1";
       turnHolder.text="";
     }
   else
     {
      statusHolder.text= "Won by Player 2";
       turnHolder.text="";
        
     }
 }
 void winCondition(string textElement)
 {
    TurnOffInteractable();
    whichPlayerWon(textElement);
 }
 public void CloseThisGame()
 {
    Application.Quit();
 }
 
 public void restart()
 {
for(int i=0; i<=8; i++)
{
  if(textElement[i].text != "")
  {
    textElement[i].text = "";
    statusHolder.text="";
    turnHolder.text="Turn of Player 1";

  }
  TurnOnInteractable();
}
 }
}



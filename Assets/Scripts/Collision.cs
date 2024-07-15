using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class Collision : MonoBehaviour
{

    




    public TMP_Text worldText;

    public int difficulty;

    private System.Random rand = new System.Random();

    //Difficulty can be between 1 and 4, 1 easiest, 4 harest 
    private int[] sigFigs = {1, 10, 100, 1000, 10000};

    public int answer;    
    // Start is called before the first frame update    







    //private System.Random rand = new System.Random();

    public GameObject textContainer;
    public List<TMP_Text> answers = new List<TMP_Text>();



    
    
    
    private void OnTriggerEnter2D(Collider2D other){
        

        
        
        //Could we do negative numbers too?
        //var firstNumber = rand.Next(1, 100);
        var secondNumber = rand.Next(1, 10);
        var operation = rand.Next(0, 4);
        
        switch (operation)
        {
            case 0:
                addition(difficulty);
                break;
            case 1:
                subtraction(difficulty);
                break;
            
            case 2:
                multiplication(difficulty);
                break;
            
            case 3:
                division(difficulty);
                break;
            
        }






        var firstParam = -1;
        var secondParam = -1;
        //var answer = textContainer.GetComponent<textBehaviour>().answer;
        if(answer >= 0 && answer < 10){
            firstParam = 0;
            secondParam = 10;
        }
        else if(answer >= 10 && answer < 100){
            firstParam = 10;
            secondParam = 100;
        }
        else if(answer >= 100 && answer < 1000){
            firstParam = 100;
            secondParam = 1000;
        }
        else if(answer >= 1000 && answer < 10000){
            firstParam = 1000;
            secondParam = 10000;
        }
        else{
            firstParam = 10000;
            secondParam = 100000;
        }

        int[] allAnswers = new int[3];
        var correctAnswerPosition = rand.Next(0, 3);
        answers[correctAnswerPosition].text = /*textContainer.GetComponent<textBehaviour>().*/answer + "";
        allAnswers[0] = /*textContainer.GetComponent<textBehaviour>().*/answer;
        var count = 0;
        var allAnswerCount = 1;
        if(count == correctAnswerPosition){
            count ++;
        }
        while(count < 3){
            if(count == correctAnswerPosition){
                count ++;
            }
            else{
                var notCopied = false;
                var falseAnswers = -1;
                while (notCopied == false){
                    falseAnswers = rand.Next(firstParam, secondParam);
                    if(Array.IndexOf(allAnswers, falseAnswers) == -1){
                        answers[count].text = falseAnswers + "";
                        allAnswers[allAnswerCount] = falseAnswers;
                        allAnswerCount++;
                        notCopied = true;
                    }
                }
                count++;
            }

        }




        
        
        
        
        //Debug.Log("Yep");
    }




    int addition(int difficulty){
        var firstNumber = rand.Next(sigFigs[difficulty - 1], sigFigs[difficulty]);
        var secondNumber = rand.Next(sigFigs[difficulty - 1], sigFigs[difficulty]);
        worldText.text = firstNumber + " + " + secondNumber;
        answer = firstNumber + secondNumber;
        return answer;
    }

    int subtraction(int difficulty){
        var firstNumber = rand.Next(sigFigs[difficulty - 1], sigFigs[difficulty]);
        var secondNumber = -1;
        if(difficulty > 1){
            secondNumber = rand.Next(sigFigs[difficulty - 1], firstNumber);
        }
        else{
            if(firstNumber != 0){
                secondNumber = rand.Next(sigFigs[0], firstNumber);
            }
            else{
                secondNumber = 0;
            }
        }
        worldText.text = firstNumber + " - " + secondNumber;
        answer = firstNumber - secondNumber;
        return answer;
    }


    int multiplication(int difficulty){
        if(difficulty >= 3){
            difficulty = 3;
        }
        var secondDifficulty = 1;
        var firstNumber = rand.Next(sigFigs[difficulty - 1], sigFigs[difficulty]);
        var secondNumber = rand.Next(sigFigs[secondDifficulty - 1], sigFigs[secondDifficulty]);
        worldText.text = firstNumber + " * " + secondNumber;
        answer = firstNumber * secondNumber;
        return answer;
    }


    int division(int difficulty){
        if(difficulty >= 3){
            difficulty = 3;
        }
        var secondDifficulty = 1;
        var firstNumber = rand.Next(sigFigs[0], sigFigs[difficulty]);
        var noRemainder = false;
        while(!noRemainder){
            var secondNumber = rand.Next(sigFigs[secondDifficulty - 1], sigFigs[secondDifficulty]);
            if(firstNumber % secondNumber == 0){
                noRemainder = true;
                worldText.text = firstNumber + " / " + secondNumber;
                answer = firstNumber / secondNumber;
            } 
        }
        return answer;
    }

    /*
    private void OnTriggerStay2D(Collider2D other){
        Debug.Log("Yep");
    }
/*
    private void OnTriggerExit2D(Collider2D other){
        Debug.Log("Yep");
    }
*/

}

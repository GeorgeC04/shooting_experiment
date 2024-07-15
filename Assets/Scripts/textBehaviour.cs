using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;

public class textBehaviour : MonoBehaviour
{

    public TMP_Text worldText;

    public int difficulty;

    private System.Random rand = new System.Random();

    //Difficulty can be between 1 and 4, 1 easiest, 4 harest 
    private int[] sigFigs = {1, 10, 100, 1000, 10000};

    public int answer;    
    // Start is called before the first frame update
    void Start()
    {
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


    // Update is called once per frame
    void Update()
    {
        
    }
}

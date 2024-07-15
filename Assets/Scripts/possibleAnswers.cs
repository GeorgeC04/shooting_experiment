using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class possibleAnswers : MonoBehaviour
{
    
    private System.Random rand = new System.Random();

    public GameObject textContainer;
    public List<TMP_Text> answers = new List<TMP_Text>();
    // Start is called before the first frame update
    void Start()
    {
        var firstParam = -1;
        var secondParam = -1;
        var answer = textContainer.GetComponent<textBehaviour>().answer;
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
        answers[correctAnswerPosition].text = textContainer.GetComponent<textBehaviour>().answer + "";
        allAnswers[0] = textContainer.GetComponent<textBehaviour>().answer;
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
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

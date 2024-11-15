using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [Serializable]
    public class QuestionData
    {
        public string question;
        public string answerA;
        public string answerB;
        public string answerC;
        public string answerD;
        public string correctAnswer;
    }
    
    [SerializeField] private TextMeshProUGUI txtQuestion;
    [SerializeField] private TextMeshProUGUI txtAnswerA;
    [SerializeField] private TextMeshProUGUI txtAnswerB;
    [SerializeField] private TextMeshProUGUI txtAnswerC;
    [SerializeField] private TextMeshProUGUI txtAnswerD;

    [SerializeField] private QuestionData questionData;
    // Start is called before the first frame update
    void Start()
    {
        txtQuestion.text = questionData.question;
        txtAnswerA.text = "A: " + questionData.answerA;
        txtAnswerB.text = "B: " + questionData.answerB;
        txtAnswerC.text = "C: " + questionData.answerC;
        txtAnswerD.text = "D: " + questionData.answerD;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BtnAnswer_Pressed(string pressedAnswer)
    {
        
        if (questionData.correctAnswer == pressedAnswer)
        {
            Debug.Log("chinh xac!");
            

        }
        else
        {
            Debug.Log("sai!");
            
        }
    }

    
}

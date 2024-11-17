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
    
    public enum GameState
    {
        Home,
        Gameplay,
        Gameover
    }

    [SerializeField] private TextMeshProUGUI txtQuestion;
    [SerializeField] private TextMeshProUGUI txtAnswerA;
    [SerializeField] private TextMeshProUGUI txtAnswerB;
    [SerializeField] private TextMeshProUGUI txtAnswerC;
    [SerializeField] private TextMeshProUGUI txtAnswerD;
    [SerializeField] private Image imgAnswerA;
    [SerializeField] private Image imgAnswerB;
    [SerializeField] private Image imgAnswerC;
    [SerializeField] private Image imgAnswerD;

    [SerializeField] private GameObject HomePanel, GameplayPanel, GameoverPanel;

    //[SerializeField] private QuestionData[] questionData;
    [SerializeField] private QuestionScriptableData[] questionData;

    private int questionIndex;
    private GameState gameState;
    private int live = 3;

    // Start is called before the first frame update
    void Start()
    {
        SetGameState(GameState.Home);
        questionIndex = 0;
        InitQuestion(0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BtnAnswer_Pressed(string pressedAnswer)
    {
        bool traLoiDung = false;
        
        if (questionData[questionIndex].correctAnswer == pressedAnswer)
        {
            traLoiDung = true;
            Debug.Log("chinh xac!");           
        }
        else
        {
            live--;
            if (live == 0)
            {
                SetGameState(GameState.Gameover);
            }
            traLoiDung = false;
            Debug.Log("sai!");
        }

        switch(pressedAnswer)
        {
            case "a":
                imgAnswerA.color = traLoiDung ? Color.green : Color.red;
                break;
            case "b":
                imgAnswerB.color = traLoiDung ? Color.green : Color.red;
                break;
            case "c":
                imgAnswerC.color = traLoiDung ? Color.green : Color.red;
                break;
            case "d":
                imgAnswerD.color = traLoiDung ? Color.green : Color.red;
                break;
        }

        if (traLoiDung)
        {
            if (questionIndex >= questionData.Length)
            {
                Debug.Log("Ban da chien thang");
                return;
            }
            questionIndex++;
            InitQuestion(questionIndex);
        }
    }

    private void InitQuestion(int index)
    {
        if (index < 0 || index >= questionData.Length)
        {
            return;
        }

        imgAnswerA.color = Color.white;
        imgAnswerB.color = Color.white;
        imgAnswerC.color = Color.white;
        imgAnswerD.color = Color.white;
        txtQuestion.text = questionData[index].question;
        txtAnswerA.text = "A: " + questionData[index].answerA;
        txtAnswerB.text = "B: " + questionData[index].answerB;
        txtAnswerC.text = "C: " + questionData[index].answerC;
        txtAnswerD.text = "D: " + questionData[index].answerD;
    }

    public void SetGameState(GameState state)
    {
        gameState = state;
        live = 3;
        HomePanel.SetActive(gameState == GameState.Home);
        GameplayPanel.SetActive(gameState == GameState.Gameplay);
        GameoverPanel.SetActive(gameState == GameState.Gameover);
    }

    public void BtnPlay_Pressed()
    {
        SetGameState(GameState.Gameplay);
    }

    public void BtnHome_Pressed()
    {
        SetGameState(GameState.Gameover);
    }
}

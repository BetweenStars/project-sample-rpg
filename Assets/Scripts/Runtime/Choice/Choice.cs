using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq.Expressions;

public enum ChoiceType
{
    Plue,Minus,Multiply,Divide
}

public class Choice : MonoBehaviour
{
    private bool isChosen=false;
    [SerializeField] private Text choiceText;
    public ChoiceType choiceType;
    public int choiceValue;

    private void Start()
    {
        InitChoice();
    }
    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has made a choice!");
            isChosen=true;
            // Implement choice logic here
        }
    }

    public void InitChoice()
    {
        choiceType = (ChoiceType)UnityEngine.Random.Range(0,4);
        if(choiceType==ChoiceType.Plue || choiceType==ChoiceType.Minus)
        {
            choiceValue = UnityEngine.Random.Range(1, 100);
        }
        else
        {
            choiceValue = UnityEngine.Random.Range(2, 10);
        }

        switch(choiceType)
        {
            case ChoiceType.Plue:
                choiceText.text = "+" + choiceValue.ToString();
                break;
            case ChoiceType.Minus:
                choiceText.text = "-" + choiceValue.ToString();
                break;
            case ChoiceType.Multiply:
                choiceText.text = "x" + choiceValue.ToString();
                break;
            case ChoiceType.Divide:
                choiceText.text = "÷" + choiceValue.ToString();
                break;
        }
    }

    public bool CheckChosen()
    {
        return isChosen;
    }
}

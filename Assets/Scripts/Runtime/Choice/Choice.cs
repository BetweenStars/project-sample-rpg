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
    private Ground ground;

    private bool isChosen=false;
    [SerializeField] private Text choiceText;
    public ChoiceType choiceType;
    public int choiceValue;

    private void Start()
    {
        ground = GetComponentInParent<Ground>();
        
        InitChoice();
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if(ground.canChoose==false)return;

        if (other.gameObject.CompareTag("Player"))
        {
            ground.choosedChoice=this;
            ground.canChoose=false;
            isChosen=true;

            if (other.gameObject.GetComponentInParent<ArrowAttack>() == null)
            {
                Debug.Log("Can't find ArrowAttack component in parent of the player.");
            }
            else
            {
                Debug.Log("Player has chosen: " + choiceType.ToString() + " " + choiceValue);
                int currentValue = other.gameObject.GetComponentInParent<ArrowAttack>().GetArrowStack();
                int newValue = ApplyChoice(currentValue);
                other.gameObject.GetComponentInParent<ArrowAttack>().SetArrowStack(newValue);
                Debug.Log("Player's new arrow count: " + newValue);
            }

            gameObject.SetActive(false);
        }
    }

    public void InitChoice()
    {
        isChosen=false;

        choiceType = (ChoiceType)UnityEngine.Random.Range(0,4);
        if(choiceType==ChoiceType.Plue || choiceType==ChoiceType.Minus)
        {
            choiceValue = UnityEngine.Random.Range(1, 11);
        }
        else
        {
            choiceValue = UnityEngine.Random.Range(2, 4);
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

    public int ApplyChoice(int currentValue)
    {
        int appliedValue = currentValue;
        switch(choiceType)
        {
            case ChoiceType.Plue:
                appliedValue+=choiceValue;break;
            case ChoiceType.Minus:
                appliedValue-=choiceValue;break;
            case ChoiceType.Multiply:
                appliedValue*=choiceValue;break;
            case ChoiceType.Divide:
                appliedValue/=choiceValue;break;
            default:break;
        }

        if(appliedValue<1)
        {
            appliedValue=1;
        }
        return appliedValue;
    }
}

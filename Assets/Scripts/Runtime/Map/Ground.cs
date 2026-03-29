using UnityEngine;

public class Ground : MonoBehaviour
{
    public Choice choice1;
    public Choice choice2;

    public bool canChoose = true;
    public Choice choosedChoice;

    private void Update()
    {

    }

    public void InitChoices()
    {
        choice1.gameObject.SetActive(true);
        choice2.gameObject.SetActive(true);
        choice1.InitChoice();
        choice2.InitChoice();
        canChoose = true;
        choosedChoice = null;
    }
}

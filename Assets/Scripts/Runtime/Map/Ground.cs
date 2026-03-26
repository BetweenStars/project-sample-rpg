using UnityEngine;

public class Ground : MonoBehaviour
{
    public Choice choice1;
    public Choice choice2;

    private bool canChoose = true;

    private void Update()
    {
        if(!canChoose)return;

        if (choice1.CheckChosen() || choice2.CheckChosen())
        {
            canChoose = false;
            Debug.Log("Both choices have been made!");
            // Implement logic for when both choices are made
        }
    }

    public void InitChoices()
    {
        choice1.InitChoice();
        choice2.InitChoice();
        canChoose = true;
    }
}

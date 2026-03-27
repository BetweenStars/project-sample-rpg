using UnityEngine;
using UnityEngine.UI;

public class ArrowCountText : MonoBehaviour
{
    private Text countText;
    private ArrowAttack player;

    void Start()
    {
        countText = GetComponent<Text>();

    }

    void Update()
    {
        if (player == null)
        {
            if(GameObject.FindGameObjectWithTag("Player") != null)
            {
                player = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<ArrowAttack>();
            }
        }

        if (player != null)
        {
            countText.text = "Arrow Count: " + player.GetArrowStack().ToString();
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class ArrowCountText : MonoBehaviour
{
    [SerializeField]private Text countText;
    private ArrowAttack player;

    void Update()
    {
        if (player == null)
        {
            if(GameObject.FindAnyObjectByType<ArrowAttack>()!=null)
            {
                player = GameObject.FindAnyObjectByType<ArrowAttack>();
            }
        }

        if (player != null)
        {
            countText.text = "Arrow Count: " + player.GetCount().ToString();
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class CharacterHP : MonoBehaviour
{
    [SerializeField]
    private float maxHP;
    public float currentHP { get; private set; }

    [SerializeField]
    private Text hpText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHP = maxHP;

        SetText(currentHP.ToString());
    }

    public void TakeDamage(float damageAmount)
    {
        currentHP -= damageAmount;

        if (currentHP <= 0)
        {
            Die();
        }

        SetText(currentHP.ToString());
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void SetText(string text)
    {
        if (hpText == null)
            return;

        hpText.text = text;
    }
}

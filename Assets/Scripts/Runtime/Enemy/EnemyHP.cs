using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] 
    private float maxHp = 10f;
    public float currentHp { get; private set; }

    private void Start()
    {
        currentHp = maxHp;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHp -= damageAmount;

        if(currentHp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}

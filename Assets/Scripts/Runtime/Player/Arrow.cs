using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Arrow : MonoBehaviour
{
    // 투사체 속도
    [SerializeField]
    private float speed = 5.0f;
    // 투사체 유지 시간
    [SerializeField] private float remainTime = 5.0f;

    // 데미지
    private float damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //유지 시간 종료 시 파괴
        Destroy(gameObject, remainTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void Setup(float attackDamage)
    {
        damage = attackDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            EnemyHP enemy = other.GetComponent<EnemyHP>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}

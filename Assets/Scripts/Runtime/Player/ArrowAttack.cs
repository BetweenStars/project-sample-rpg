using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ArrowAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    // 공격 쿨타임
    [SerializeField] 
    private float attackInterval = 2.0f;
    // 데미지
    [SerializeField] 
    private float attackDamage = 1.0f;
    // 투사체 모델
    [SerializeField]
    private GameObject arrowPrefab;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Attack());
    }

    public IEnumerator Attack()
    {
        while(true)
        {
            GameObject arrowObj = Instantiate(arrowPrefab, transform.position, transform.rotation);
            Arrow arrowScript = arrowObj.GetComponent<Arrow>();
            if (arrowScript != null)
            {
                arrowScript.Setup(attackDamage);
            }

            yield return new WaitForSeconds(attackInterval);
        }
    }
}

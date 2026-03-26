using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ArrowAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    // ���� ��Ÿ��
    [SerializeField]
    private float attackInterval = 2.0f;
    // ������
    [SerializeField]
    private float attackDamage = 1.0f;
    // ����ü ��
    [SerializeField]
    private GameObject arrowPrefab;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Attack());
    }

    public IEnumerator Attack()
    {
        while (true)
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

    public int GetCount() { return 0; }
    public void SetCount(int count)
    {

    }
}

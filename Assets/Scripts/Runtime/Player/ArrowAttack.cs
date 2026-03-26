using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ArrowAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    [SerializeField]
    private float attackInterval = 2.0f;
    [SerializeField]
    private float attackDamage = 1.0f;
    [SerializeField]
    private GameObject arrowPrefab;

    private int arrowCount;
    [SerializeField]
    private int MaxArrowCount = 10;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Attack());
    }

    public IEnumerator Attack()
    {
        while (true)
        {
            CreateArrows();

            yield return new WaitForSeconds(attackInterval);
        }
    }

    private void CreateArrows()
    {
        //List<GameObject> arrows = new List<GameObject>();

        //for(int i = 0; i < arrowCount; i++)
        //{
        //    arrows.Add(Instantiate(arrowPrefab, transform.position, transform.rotation));
        //}

        //GameObject arrowObj = 
        //Arrow arrowScript = arrowObj.GetComponent<Arrow>();
        //if (arrowScript != null)
        //{
        //    arrowScript.Setup(attackDamage);
        //}
    }

    public int GetCount() { return arrowCount; }
    public void SetCount(int count)
    {
        arrowCount += count;

        if(arrowCount >= MaxArrowCount)
        {
            arrowCount /= MaxArrowCount;
        }
    }
}

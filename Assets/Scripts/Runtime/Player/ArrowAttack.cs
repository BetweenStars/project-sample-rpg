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


    public int arrowCount = 4;

    [SerializeField]
    private int MaxArrowCount = 10;

    private Dictionary<int, Vector3[]> formationData = new Dictionary<int, Vector3[]>()
    {
        { 1, new Vector3[] { new Vector3(0, 0, 1) } },
        { 2, new Vector3[] { 
            new Vector3(-0.3f, 0, 1),       new Vector3(0.3f, 0, 1) } },
        { 3, new Vector3[] { 
            new Vector3(-0.5f, 0, 1),       new Vector3(0, 0, 1),       new Vector3(0.5f, 0, 1) } },
        { 4, new Vector3[] {
            new Vector3(-0.3f, 0, 2.3f),    new Vector3(0.3f, 0, 2.3f), // 앞줄
            new Vector3(-0.3f, 0, 1f),      new Vector3(0.3f, 0, 1f) // 뒷줄
        } },
        { 5, new Vector3[] {
            new Vector3(-0.3f, 0, 2.3f),    new Vector3(0.3f, 0, 2.3f), // 앞줄
            new Vector3(-0.5f, 0, 1f),      new Vector3(0, 0, 1),       new Vector3(0.5f, 0, 1) // 뒷줄
        } },
        { 6, new Vector3[] {
            new Vector3(-0.5f, 0, 2.3f),    new Vector3(0, 0, 2.3f),    new Vector3(0.5f, 0, 2.3f), // 앞줄
            new Vector3(-0.5f, 0, 1f),      new Vector3(0, 0, 1f),      new Vector3(0.5f, 0, 1f) // 뒷줄
        } },
        { 7, new Vector3[] {
                                            new Vector3(0, 0, 3.6f),
            new Vector3(-0.5f, 0, 2.3f),    new Vector3(0, 0, 2.3f),    new Vector3(0.5f, 0, 2.3f), // 앞줄
            new Vector3(-0.5f, 0, 1),       new Vector3(0, 0, 1),       new Vector3(0.5f, 0, 1) // 뒷줄
        } },
        { 8, new Vector3[] {
            new Vector3(-0.3f, 0, 3.6f),                                new Vector3(0.3f, 0, 3.6f), // 앞줄
            new Vector3(-0.5f, 0, 2.3f),    new Vector3(0, 0, 2.3f),    new Vector3(0.5f, 0, 2.3f),
            new Vector3(-0.5f, 0, 1f),      new Vector3(0, 0, 1f),      new Vector3(0.5f, 0, 1f) // 뒷줄
        } },
        { 9, new Vector3[] {
            new Vector3(-0.5f, 0, 3.6f),    new Vector3(0, 0, 3.6f),    new Vector3(0.5f, 0, 3.6f), // 앞줄
            new Vector3(-0.5f, 0, 2.3f),    new Vector3(0, 0, 2.3f),    new Vector3(0.5f, 0, 2.3f),
            new Vector3(-0.5f, 0, 1f),      new Vector3(0, 0, 1f),      new Vector3(0.5f, 0, 1f) // 뒷줄
        } },
    };


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
        List<GameObject> arrows = new List<GameObject>();

        for (int i = 0; i < arrowCount % MaxArrowCount; i++)
        {
            GameObject arrowObj = Instantiate(arrowPrefab, transform.position + formationData[arrowCount][i], transform.rotation);
            Arrow arrowScript = arrowObj.GetComponent<Arrow>();
            if (arrowScript != null)
            {
                arrowScript.Setup(attackDamage);
            }

            arrows.Add(arrowObj);
        }
    }

    public int GetCount() { return arrowCount; }
    public void SetCount(int count)
    {
        arrowCount = count;

        /*
        if(arrowCount >= MaxArrowCount)
        { 
            attackDamage = arrowCount/MaxArrowCount;
        }
        */
    }
}

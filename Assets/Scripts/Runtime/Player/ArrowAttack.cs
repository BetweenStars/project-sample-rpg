using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ArrowAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    [SerializeField]
    private float attackInterval = 2.0f;
    [SerializeField]
    private GameObject arrowPrefab;

    private int MaxArrowCount = 9;
    private int MaxArrowStack = 99;

    // 전체 Arrow의 점수
    private int arrowStack = 0;
    // 발사하는 화살 개수
    private int arrowCount = 1;
    // 화살 데미지
    private int arrowDamage = 1;
    

    private List<Vector3[]> formationData = new List<Vector3[]>()
    {
        // 0 (Dummy)
        new Vector3[] { },
        // 1
        new Vector3[] { new Vector3(0, 0, 1)
        },
        // 2
        new Vector3[] { 
            new Vector3(-0.3f, 0, 1),       new Vector3(0.3f, 0, 1) 
        },
        // 3
        new Vector3[] { 
            new Vector3(-0.5f, 0, 1),       new Vector3(0, 0, 1),       new Vector3(0.5f, 0, 1) 
        },
        // 4
        new Vector3[] {
            new Vector3(-0.3f, 0, 2.3f),    new Vector3(0.3f, 0, 2.3f),
            new Vector3(-0.3f, 0, 1f),      new Vector3(0.3f, 0, 1f) 
        },
        // 5
        new Vector3[] {
            new Vector3(-0.3f, 0, 2.3f),    new Vector3(0.3f, 0, 2.3f), 
            new Vector3(-0.5f, 0, 1f),      new Vector3(0, 0, 1),       new Vector3(0.5f, 0, 1) 
        },
        // 6
        new Vector3[] {
            new Vector3(-0.5f, 0, 2.3f),    new Vector3(0, 0, 2.3f),    new Vector3(0.5f, 0, 2.3f), 
            new Vector3(-0.5f, 0, 1f),      new Vector3(0, 0, 1f),      new Vector3(0.5f, 0, 1f) 
        },
        // 7
        new Vector3[] {
                                            new Vector3(0, 0, 3.6f),
            new Vector3(-0.5f, 0, 2.3f),    new Vector3(0, 0, 2.3f),    new Vector3(0.5f, 0, 2.3f), 
            new Vector3(-0.5f, 0, 1),       new Vector3(0, 0, 1),       new Vector3(0.5f, 0, 1) 
        },
        // 8
        new Vector3[] {
            new Vector3(-0.3f, 0, 3.6f),                                new Vector3(0.3f, 0, 3.6f), 
            new Vector3(-0.5f, 0, 2.3f),    new Vector3(0, 0, 2.3f),    new Vector3(0.5f, 0, 2.3f),
            new Vector3(-0.5f, 0, 1f),      new Vector3(0, 0, 1f),      new Vector3(0.5f, 0, 1f) 
        },
        // 9 
        new Vector3[] {
            new Vector3(-0.5f, 0, 3.6f),    new Vector3(0, 0, 3.6f),    new Vector3(0.5f, 0, 3.6f), 
            new Vector3(-0.5f, 0, 2.3f),    new Vector3(0, 0, 2.3f),    new Vector3(0.5f, 0, 2.3f),
            new Vector3(-0.5f, 0, 1f),      new Vector3(0, 0, 1f),      new Vector3(0.5f, 0, 1f) 
        },
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

        for (int i = 0; i < arrowCount; i++)
        {
            GameObject arrowObj = Instantiate(arrowPrefab, transform.position + formationData[arrowCount][i], transform.rotation);
            Arrow arrowScript = arrowObj.GetComponent<Arrow>();
            if (arrowScript != null)
            {
                arrowScript.Setup(arrowDamage);
            }

            arrows.Add(arrowObj);
        }
    }

    public int GetArrowStack() { return arrowStack; }
    public void SetArrowStack(int stack)
    {
        
        arrowStack = Mathf.Clamp(stack, 0, MaxArrowStack);

        arrowCount = (arrowStack % MaxArrowCount) + 1;
        arrowDamage = arrowStack / MaxArrowCount + 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyTarg : MonoBehaviour
{
    private Enemy EnemyT; // ворог
    void Start()
    {
        EnemyT = GetComponent<Enemy>(); //зміннф ворог
    }

    public void ReackToHit()
    {
        //попав і вбив
        if (EnemyT != null)
        {
            EnemyT.Live(false);
            Destroy(this.transform.gameObject);
        }
    }
    void Update()
    {
        
    }
}

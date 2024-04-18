using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] imps;
    [SerializeField] private int impsLength;

    bool check = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (check)
        {
            if (collision.tag == "Player")
            {
                for (int i = 0; i < impsLength; i++)
                {
                    imps[i].GetComponent<EnemyController>().enabled = true;
                }
            }
            check = false;
        }
    }
}

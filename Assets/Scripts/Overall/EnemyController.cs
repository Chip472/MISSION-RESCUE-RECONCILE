using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform target;

    [SerializeField] private int clickDie;

    int gunClick;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().flipX = false;
        gameObject.GetComponent<Animator>().SetBool("run", true);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
        {
            gunClick++;
        }

        if (gunClick == clickDie)
        {
            Destroy(gameObject);
        }
    }
}

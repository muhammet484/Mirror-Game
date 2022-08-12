using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    checker Checker;
    public float Health = 100f;
    // Start is called before the first frame update
    void Start()
    {
        Checker = GameObject.Find("checker").GetComponent<checker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0f)
        {
            Checker.enemies--;
            Destroy(gameObject);
        }
    }
}

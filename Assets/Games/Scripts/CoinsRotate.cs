using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsRotate : MonoBehaviour
{
    public GameObject[] coins;

    void Update()
    {
        foreach (var item in coins)
        {
            item.transform.Rotate(new Vector3(0, Time.deltaTime * 150, 0));
        }
    }
}

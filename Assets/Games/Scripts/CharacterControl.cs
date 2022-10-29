using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{

    public SpawnManager spawnManager;

    void Start()
    {

    }

   
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(WaitTime());
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(3f);
        spawnManager.SpawnTriggerEntered();

    }
}

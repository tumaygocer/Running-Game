using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;


public class CoinsControl : MonoBehaviour
{
    public TextMeshProUGUI _text;    
    private int scor;
    bool secons; 

    private void Start()
    {
        scor = 0;
        secons = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            GameObject _coin = other.gameObject;
            scor += 1;
            _text.text = "Scor:  " + scor;
            _coin.transform.DOMove(new Vector3(-0.7f, 4.5f, transform.position.z), 0.3f);
            Destroy(_coin, 0.5f);
            

        }
    }
   
}

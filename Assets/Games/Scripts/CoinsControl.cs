using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsControl : MonoBehaviour
{
    public TextMeshProUGUI _text;
    private int scor;

    private void Start()
    {
        scor = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            scor += 1;
            _text.text = "Scor:  " + scor;
            Destroy(other.gameObject);
        }
    }
}

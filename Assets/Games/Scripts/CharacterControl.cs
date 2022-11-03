using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;
using TMPro;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] private float offSet = 0.4f;
    private List<GameObject> collection = new List<GameObject>();
    public GameObject stack;
    public GameObject House;
    public Transform location;
    public Transform fallingObjects;
    public Animator anim;
    public TextMeshProUGUI _object;
    private int _objectcount;

    private void Start()
    {
        _objectcount = 0;
        anim = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        if (collection != null && collection.Count > 0)
        {
            collection = collection.OrderBy(r => r.transform.position.y).ToList();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collection"))
        {
            _objectcount += 1;          
            GameObject _g = other.gameObject;           
            _g.transform.parent = location;
            //_g.transform.DOScale(new Vector3(2, 2, 2), 0.5f);
            _g.gameObject.transform.localPosition = Vector3.zero;           
            float newy = offSet * collection.Count;
            collection.Add(_g);
            collection[collection.Count -1].transform.localPosition = new Vector3(0, newy, 0);
            
        }

        if (other.gameObject.CompareTag("Stone"))
        {
           _objectcount -= 1;
            GameObject _removecollection = collection[collection.Count - 1];
            _removecollection.GetComponent<Rigidbody>().useGravity = true;
            _removecollection.GetComponent<BoxCollider>().isTrigger = false;           
            collection.Remove(_removecollection);
            _removecollection.transform.parent = fallingObjects;                                                        
            anim.SetTrigger("Tak�lma");           
        }

        _object.text = "Object: " + _objectcount;

        if (other.gameObject.CompareTag("Finish"))
        {          
            anim.SetTrigger("Dance");
            if (collection.Count >= 1)
            {
                House.GetComponentInChildren<MeshRenderer>().enabled = true;
            }
        }
    }   

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            anim.SetTrigger("Death");
            foreach (var item in collection)
            {
                item.GetComponent<Rigidbody>().useGravity = true;
                item.GetComponent<BoxCollider>().isTrigger = false;
                //item.transform.parent = fallingObjects;
                //collection.Remove(item);
            }
        }
    }
}

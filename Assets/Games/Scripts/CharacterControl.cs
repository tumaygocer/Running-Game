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
    public Transform houseBuild;
    public Animator anim;
    public TextMeshProUGUI _object;
    private int _objectcount;
    public GameObject _character;

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
            anim.SetTrigger("Takýlma");           
        }

        _object.text = "Object: " + _objectcount;

        if (other.gameObject.CompareTag("Finish"))
        {          
            anim.SetTrigger("Dance");
            foreach (var item in collection)
            {
                item.GetComponent<MeshRenderer>().enabled = false;
            }
            if (collection.Count >= 3)
            {
                houseBuild.transform.localPosition = Vector3.zero;
                Instantiate(House, houseBuild);
                _character.transform.DORotate(new Vector3(transform.rotation.x, 180, transform.rotation.z), 1f);               
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

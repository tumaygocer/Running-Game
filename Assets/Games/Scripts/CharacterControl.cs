using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] private float offSet = 0.4f;
    private List<GameObject> collection = new List<GameObject>();
    public GameObject stack;
    public Transform location;
    public Transform fallingObjects;

    public Animator anim;
    private void Start()
    {
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
            GameObject _g = other.gameObject;
            _g.transform.parent = location;
            _g.gameObject.transform.localPosition = Vector3.zero;           
            float newy = offSet * collection.Count;
            collection.Add(_g);
            collection[collection.Count -1].transform.localPosition = new Vector3(0, newy, 0);
            
        }

        if (other.gameObject.CompareTag("Stone"))
        {
            GameObject _removecollection = collection[collection.Count - 1];
            _removecollection.GetComponent<Rigidbody>().useGravity = true;
            _removecollection.GetComponent<BoxCollider>().isTrigger = false;
            collection.Remove(_removecollection);
            _removecollection.transform.parent = fallingObjects;                                                        
            anim.SetTrigger("Tak�lma");           
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            anim.SetTrigger("Death");
        }
    }

}

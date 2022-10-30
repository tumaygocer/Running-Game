using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] private float offSet = 0.2f;
    private List<GameObject> collection = new List<GameObject>();
    public GameObject stack;
    public Transform location;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collection"))
        {
            Debug.Log("kskks");
            //Destroy(other.gameObject);
            other.transform.parent = location.parent;
            other.gameObject.transform.position = location.transform.position;
            collection.Add(other.gameObject);
            float newy = collection[0].transform.position.y + offSet;
            other.gameObject.transform.position = new Vector3(location.transform.position.x, newy, location.transform.position.z);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField] private float offset = 25.6f;

    public List<GameObject> roads = new List<GameObject>();
    
    void Start()
    {
        if (roads != null && roads.Count > 0)
        {
            roads = roads.OrderBy(r => r.transform.position.z).ToList();
        }
        
    }

    public void MoveRoad()
    {
        GameObject moveRoad = roads[0];
        roads.Remove(moveRoad);
        float newz = roads[roads.Count - 1].transform.position.z + offset;
        moveRoad.transform.position = new Vector3(0, 0, newz);
        roads.Add(moveRoad);
    }
   
}

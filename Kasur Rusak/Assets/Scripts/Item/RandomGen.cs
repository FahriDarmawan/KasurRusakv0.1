using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGen : MonoBehaviour
{
    public List<GameObject> item;
    public Transform position;

    // Start is called before the first frame update
    void Start()
    {
        //random
        int objSpawn = Random.Range(0, item.Count);

        //spawn object
        Instantiate(item[objSpawn], transform.position, Quaternion.identity);
    }
}

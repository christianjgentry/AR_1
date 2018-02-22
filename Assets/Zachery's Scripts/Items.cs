using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {

    public GameObject[] items;
    public Transform spawn;
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnItem(int index)
    {
        GameObject go = items[index];
        Instantiate(go, spawn.position, Quaternion.identity);
    }

    void SpawnItem(string name)
    {
        GameObject go = items[0];
        foreach(GameObject g in items)
        {
            if(g.name == name)
            {
                go = g;
            }
        }

        Instantiate(go, spawn.position, Quaternion.identity);


    }
}

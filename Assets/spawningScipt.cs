using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawningScipt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Passed");
            GameManager.instance.spawnATile();
            GameManager.instance.skippedTiles++;
            if (GameManager.instance.skippedTiles >= 3)
            {
                Destroy(GameManager.instance.roadParent.transform.GetChild(0).gameObject);
            }
        }
    }
}

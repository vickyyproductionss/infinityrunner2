using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateShowObjects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotateGO();
    }
    void rotateGO()
    {
        this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y + 10 * Time.deltaTime, this.transform.eulerAngles.z + 5*Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            Camera.main.transform.position = new Vector3(0f, 2.6f, -4.2f);
            Camera.main.transform.rotation = Quaternion.Euler(177.163f, 180f, 180f);
        }

        if (Input.GetKeyDown("2"))
        {
            Camera.main.transform.position = new Vector3(0f, 1.9f, 5.2f);
            Camera.main.transform.rotation = Quaternion.Euler(15f, 180f, 0f);
        }

        if (Input.GetKeyDown("3"))
        {
            Camera.main.transform.position = new Vector3(7.39f, 8.77f, -4.3f);
            Camera.main.transform.rotation = Quaternion.Euler(177.163f, -90f, 180f);
        }
    }
}

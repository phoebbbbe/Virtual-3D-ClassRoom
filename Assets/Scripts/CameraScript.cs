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

        if (Input.GetKeyDown("4"))
        {
            Camera.main.transform.position = new Vector3(-5.36f, 8.65f, -10.69f);
            Camera.main.transform.rotation = Quaternion.Euler(177.163f, 0f, 180f);
        }

        if (Input.GetKeyDown("5"))
        {
            Camera.main.transform.position = new Vector3(9.65f, 8.21f, 14.68f);
            Camera.main.transform.rotation = Quaternion.Euler(182.608f, 23.20399f, 180f);
        }

        if (Input.GetKeyDown("6"))
        {
            Camera.main.transform.position = new Vector3(-6.631f, 8.502f, 9.382f);
            Camera.main.transform.rotation = Quaternion.Euler(182.428f, -31.17102f, 180f);
        }

        if (Input.GetKeyDown("7"))
        {
            Camera.main.transform.position = new Vector3(-8.26f, 9.19f, -7.02f);
            Camera.main.transform.rotation = Quaternion.Euler(177.94f, -148.043f, 180f);
        }

        if (Input.GetKeyDown("8"))
        {
            Camera.main.transform.position = new Vector3(5.56f, 9.21f, -7.4f);
            Camera.main.transform.rotation = Quaternion.Euler(177.917f, -210.922f, 180f);
        }

        if (Input.GetKeyDown("9"))
        {
            Camera.main.transform.position = new Vector3(-8.219f, 8.986f, -1.29f);
            Camera.main.transform.rotation = Quaternion.Euler(179.856f, -90f, 180f);
        }
    }
}

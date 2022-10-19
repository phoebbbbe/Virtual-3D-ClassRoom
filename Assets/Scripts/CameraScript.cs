using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    private readonly PhotonView _pv;
    /*
     * 學生鏡頭位置
     */
    private readonly Vector3[] _spawnPos = new Vector3[] {
            new Vector3(-0.01f,2.0f, 1.6f),
            new Vector3(-2.9f, 2.0f, -5.42f),
            new Vector3(-2.9f, 2.0f,-3.68f),
            new Vector3(-2.9f, 2.0f, -2.31f),
            new Vector3(-2.9f, 2.0f, -0.95f),
            new Vector3(-2.9f, 2.0f, 0.41f),
            new Vector3(-1.033f, 2.0f, -5.42f),
            new Vector3(-1.033f, 2.0f, -3.68f),
            new Vector3(-1.033f, 2.0f, -2.31f),
            new Vector3(-1.033f, 2.0f, -0.95f),
            new Vector3(-1.033f, 2.0f, 0.41f),
            new Vector3(0.82f, 2.0f, -5.42f),
            new Vector3(0.82f, 2.0f, -3.68f),
            new Vector3(0.82f, 2.0f, -2.31f),
            new Vector3(0.82f, 2.0f, -0.95f),
            new Vector3(0.82f, 2.0f, 0.41f),
            new Vector3(2.7f, 2.0f, -5.42f),
            new Vector3(2.7f, 2.0f, -3.68f),
            new Vector3(2.7f, 2.0f, -2.31f),
            new Vector3(2.7f, 2.0f, -0.95f),
            new Vector3(2.7f, 2.0f, 0.41f)
    };

    void Start()
    {
        /* 初始為學生後面視角 */
        if (RoleScript.seatNo != 0)
        {
            Camera.main.transform.SetPositionAndRotation(_spawnPos[RoleScript.seatNo], Quaternion.Euler(4.7f, 0, 0f));
        }
        else
        {
            Camera.main.transform.SetPositionAndRotation(_spawnPos[RoleScript.seatNo], Quaternion.Euler(4.7f, 180, 0f));
        }
    }

    public void OnClickHeadCamera()
    {
        /* 教室前面視角 */
        Camera.main.transform.SetPositionAndRotation(new Vector3(0f, 2.3f, 4.96f), Quaternion.Euler(17.342f, 180f, 0f));
    }

    public void OnClickBackCamera()
    {
        /* 教室後面視角 */
        Camera.main.transform.SetPositionAndRotation(new Vector3(0f, 3.14f, -5.34f), Quaternion.Euler(30.68f, 0f, 0f));
    }

    public void OnClickPersonCamera()
    {
        /* 學生/老師後面視角 */
        if (RoleScript.seatNo != 0)
        {
            Camera.main.transform.SetPositionAndRotation(_spawnPos[RoleScript.seatNo], Quaternion.Euler(4.7f, 0, 0f));
        }
        else
        {
            Camera.main.transform.SetPositionAndRotation(_spawnPos[RoleScript.seatNo], Quaternion.Euler(4.7f, 180, 0f));
        }
    }

    public void OnClickPptCamera()
    {
        /* 簡報視角 */
        Camera.main.transform.SetPositionAndRotation(new Vector3(-2.24f, 1.63f, 3.46f), Quaternion.Euler(0f, 0f, 0f));
    }
}

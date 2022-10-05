using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoleSceneScript : MonoBehaviour
{
    public Button left, right;
    public RectTransform[] roles;
    public Vector2[] targetPos;

    int current = 0;
    bool locked = false;

    void Start()
    {
    }

    void Update()
    {
        left.onClick.AddListener(Previous);
        right.onClick.AddListener(Next);
        Refresh();

    }

    void Next()
    {
        if (locked)
            return;

        targetPos[current].x = 2340f;
        current ++;
        if (current >= roles.Length)
            current = 0;
        roles[current].anchoredPosition = new Vector2(-2340f, 0);
        targetPos[current].x = 0;
        StartCoroutine("Lock");
    }

    void Previous()
    {
        if (locked)
            return;

        targetPos[current].x = -2340f;
        current--;
        if (current < 0)
            current = roles.Length - 1;
        roles[current].anchoredPosition = new Vector2(2340f, 0);
        targetPos[current].x = 0;
        StartCoroutine("Lock");
    }

    void Refresh()
    {
        for(int i=0; i<roles.Length; i++)
        {
            Vector3 pos = roles[i].anchoredPosition;
            pos = Vector3.Lerp(pos, targetPos[i], 0.2f);
            roles[i].anchoredPosition = pos;
        }
    }

    IEnumerator Lock()
    {
        locked = true;
        yield return new WaitForSeconds(0.2f);
        locked = false;
    }
}

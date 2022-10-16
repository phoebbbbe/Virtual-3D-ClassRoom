using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void LoadStudentMenuScene()
    {
        SceneManager.LoadScene("StudentMenuScene");
    }

    public void LoadTeacherMenuScene()
    {
        SceneManager.LoadScene("TeacherMenuScene");
    }
}

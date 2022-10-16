using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IdentitySceneScript : MonoBehaviour
{
    public void OnClickTeacherIdentity()
    {
        RoleScript.identityNo = 0;
        SceneManager.LoadScene("TeacherRoleScene");
    }

    public void OnClickStudentIdentity()
    {
        RoleScript.identityNo = 1;
        SceneManager.LoadScene("StudentRoleScene");
    }
}

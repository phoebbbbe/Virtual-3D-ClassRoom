using System.Collections;
using System.Collections.Generic;
using System.IO;
using SFB;
using UnityEngine;

public class BlackboardScript : MonoBehaviour
{
    public string pptPath;
    private Texture2D tex;
    private int page = 1, pageCount = 1;
    private byte[] imageDate;

    private void LoadPPT()
    {
        if (File.Exists(pptPath + @"\" + page.ToString() + ".JPG"))
        {
            imageDate = File.ReadAllBytes(pptPath + @"\" + page.ToString() + ".JPG");  //AssetDatabase.GetAssetPath() return the path of the texture

            pageCount = page--;
            page = pageCount;
        }
        else if (File.Exists(pptPath + @"\" + page.ToString() + ".PNG"))
        {
            imageDate = File.ReadAllBytes(pptPath + @"\" + page.ToString() + ".PNG");

            pageCount = page--;
            page = pageCount;
        }
        else
        {
            if (!(page < 1))
            {
                page--;
            }
        }

        tex.LoadImage(imageDate);

        Color[] pixels = tex.GetPixels(0);  //get all size of the texture
        System.Array.Reverse(pixels, 0, pixels.Length);  //rotates the image 180 degrees
        tex.SetPixels(pixels, 0);
        tex.Apply();

        GetComponent<Renderer>().material.mainTexture = tex;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            page++;
            LoadPPT();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (page > 1)
            {
                page--;
                LoadPPT();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            string[] path = StandaloneFileBrowser.OpenFolderPanel("", "", false);

            if (path.Length != 0)
            {
                tex = new Texture2D(0, 0);
                pptPath = "";
                foreach (string i in path)
                {
                    if (i != "/")
                        pptPath += i;
                    else
                        pptPath += @"\";
                }

                page = 1;
                pageCount = 1;
                LoadPPT();
            }
        }
    }
}

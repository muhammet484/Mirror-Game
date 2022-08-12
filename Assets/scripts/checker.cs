using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class checker : MonoBehaviour
{
    [SerializeField] Text winText;
    public GameObject mirror;
    public GameObject instantiatedMirror;
    //public bool isThrowed = false;
    public int enemies = 1;
    [SerializeField] int levelNumber;

    private void Update()
    {
        if (enemies == 0 && !winText.enabled)
        {
            winText.enabled = true;
            Invoke("sceneReload", 5f);
        }
            if (Input.GetKeyDown(KeyCode.P))
            {
                Debug.Break();
            }
        
    }

    void sceneReload()
    {
        SceneManager.LoadScene("level " + (levelNumber+1));
    }
}

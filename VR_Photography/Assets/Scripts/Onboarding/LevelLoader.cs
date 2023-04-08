using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public string levelName;
    bool check = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown && check)
        {
            LoadLevel();
        }
    }

        void LoadLevel()
    {
        SceneManager.LoadScene(levelName);
    }

    void checking()
    {
        check = true;
    }
}

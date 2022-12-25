using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public int type;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(800, 400, false, 60);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonClicked()
    {
            SceneManager.LoadScene("PlayScene");
    }
}

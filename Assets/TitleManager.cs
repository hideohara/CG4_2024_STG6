using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public GameObject hitKeyText;
    private int timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("SampleScene");
        }

        timer++;
        if (timer % 100 > 50)
        {
            hitKeyText.SetActive(false);
        }
        else
        {
            hitKeyText.SetActive(true);
        }
    }
}

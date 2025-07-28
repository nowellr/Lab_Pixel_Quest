using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HW3SecondLevel : MonoBehaviour
{
    public string Level2 = "HW3_Basement";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Finish":
                {
                    SceneManager.LoadScene(Level2);
                    break;
                }
        }
    }
}


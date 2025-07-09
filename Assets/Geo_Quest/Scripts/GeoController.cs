using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    int varOne = 3;
    // Start is called before the first frame update
    void Start()
    {
        string varTwo = "World";
        Debug.Log(varOne + varTwo);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(varOne++);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<LoadScene>().LoadSelectedScene(1);
        }

        if (Input.GetKey(KeyCode.C))
        {
            GetComponent<LoadScene>().QuitGame();
        }
    }
}

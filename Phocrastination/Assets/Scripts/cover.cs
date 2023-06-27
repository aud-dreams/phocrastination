using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Bool", 1);
        PlayerPrefs.SetInt("Bowl", 0);
        PlayerPrefs.SetInt("firstClick", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu1 : MonoBehaviour
{
    public GameObject buttonObject;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Bool") == 1) {
            buttonObject.SetActive(true);
        } else {
            buttonObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu5 : MonoBehaviour
{
    public GameObject buttonObject;
    
    // Start is called before the first frame update
    void Start() {
        if (PlayerPrefs.GetInt("Bool") == 0) {
            buttonObject.SetActive(false);
        } else {
            buttonObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

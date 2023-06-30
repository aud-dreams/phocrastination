using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customer_manager : MonoBehaviour
{
    // HARDCODED num of customers for now
    private int numCustomers = 5;
    private int copyNumCustomers = 5;
    float offset = 1f;
    public GameObject current;

    void Start() {
        Vector3 position = current.transform.position; 
        Renderer renderer1 = current.GetComponent<Renderer>();
        Renderer renderer2 = GetComponent<Renderer>();
        renderer2.sortingOrder = copyNumCustomers + 1;

        for (int i = 1; i <= numCustomers; i++) {
            GetComponent<Renderer>().sortingOrder = copyNumCustomers;
            copyNumCustomers--;
            Vector3 newPosition = new Vector3(position.x + (i * offset), position.y, position.z);
            Instantiate(current, newPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

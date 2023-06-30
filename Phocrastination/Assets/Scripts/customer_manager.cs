using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customer_manager : MonoBehaviour
{
    // HARDCODED num of customers for now
    private int numCustomers = 5, copyNumCustomers = 5;
    float offset = 1f;
    public GameObject current;
    public List<GameObject> customers = new List<GameObject>();
    public int currentIndex = 0;


    void Start() {
        Vector3 position = new Vector3(3f, 3.04f, 0f); 
        Renderer renderer = current.GetComponent<Renderer>();

        for (int i = 0; i < numCustomers; i++) {
            renderer.sortingOrder = copyNumCustomers;
            copyNumCustomers--;

            Vector3 newPosition = new Vector3(position.x + (i * offset), position.y, position.z);
            GameObject newCustomer = Instantiate(current, newPosition, Quaternion.identity);

            customers.Add(newCustomer);
        }
        
        current.SetActive(false);

        // first customer in list leaves
        customers[0].SetActive(true);
        StartCoroutine(Leave(customers[0]));
    }

    public GameObject speech;
    public float speed = 5f;

    public IEnumerator Leave(GameObject customer) {
        Debug.Log("in function");
        // wait 5 seconds for order
        yield return new WaitForSeconds(5f);
        speech.SetActive(false);

        while (customer.transform.position.x > -11) {
            customer.transform.Translate(Vector3.left * speed * Time.deltaTime);
            yield return null;
        }

        // deactivate off screen
        customer.SetActive(false); 
    }
}

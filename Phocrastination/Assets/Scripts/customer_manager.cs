using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customer_manager : MonoBehaviour
{
    // HARDCODED num of customers for now
    private int numCustomers = 10, copyNumCustomers = 10;
    float offset = 1f;
    public GameObject current;
    public List<GameObject> customers = new List<GameObject>();
    public int currentIndex = 0;

    void Start() {
        Vector3 position = new Vector3(3f, 3.04f, 0f); 
        Renderer renderer1 = current.GetComponent<Renderer>();

        for (int i = 0; i < numCustomers; i++) {
            renderer1.sortingOrder = copyNumCustomers;
            copyNumCustomers--;

            Vector3 newPosition = new Vector3(position.x + (i * offset), position.y, position.z);
            GameObject newCustomer = Instantiate(current, newPosition, Quaternion.identity);

            customers.Add(newCustomer);
        }

        current.SetActive(false);
        Shadow();

        // first customer in list leaves
        StartCoroutine(Order(customers[0]));
        customers.RemoveAt(0);
        Debug.Log(customers.Count);
    }

    public void Shadow() {
        for (int i = 1; i < customers.Count; i++) {
            Renderer renderer2 = customers[i].GetComponent<SpriteRenderer>();
            float darkenAmount = 0.65f;
            Color dark = new Color(renderer2.material.color.r * darkenAmount, renderer2.material.color.g * darkenAmount, renderer2.material.color.b * darkenAmount, renderer2.material.color.a);
            renderer2.material.color = dark;
        }
    }

    public GameObject speech;
    public float speed = 5f;

    public IEnumerator Order(GameObject customer) {
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

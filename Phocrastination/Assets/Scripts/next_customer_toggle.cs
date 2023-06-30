using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class next_customer_toggle : MonoBehaviour
{
    private Renderer render;
    private new Collider collider;

    private void Start() {
        // get render component
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider>();

        // set visibility at start
        SetVisibility(false);
    }

    private void OnMouseEnter() {
        SetVisibility(true);
    }

    private void OnMouseExit() {
        SetVisibility(false);
    }

    private void SetVisibility(bool isVisible) {
        render.enabled = isVisible;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity)) {
                // all customers shift left
                // foreach (customer in customers) {
                    // shift their position 0.5f to the left
                // customers[0].SetActive(true);
                // StartCoroutine(Leave(customers[0]));
            }
        }
    }

    public GameObject speech;
    public float speed = 5f;

    public IEnumerator Leave(GameObject customer) {
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

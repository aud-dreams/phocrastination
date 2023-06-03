using UnityEngine;

public class dish_pile : MonoBehaviour
{
    public GameObject bowl;
    private int count;
    private new Collider collider;
    public GameObject dish_pile_large;
    public GameObject dish_pile_small;

    private void Start() {
        collider = GetComponent<Collider>();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (collider.Raycast(ray, out hit, Mathf.Infinity)) {
                if (bowl != null) {
                    Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    spawnPosition.z = 0f;
                    Instantiate(bowl, spawnPosition, Quaternion.identity);
                }

                count++;
            }
        }
        if (count == 4) {
            dish_pile_large.SetActive(false);
            dish_pile_small.SetActive(true);
        }

        if (count == 8) {
            dish_pile_small.SetActive(false);
        }
    }
}

using UnityEngine;

public class dish_pile : MonoBehaviour
{
    public GameObject bowl;
    private int count;
    private new Collider collider;
    public GameObject dish_pile_large;
    public GameObject dish_pile_small;
    Vector3 mousePositionOffset;

    private void Start() {
        collider = GetComponent<Collider>();
        dish_pile_small.SetActive(true);

        mousePositionOffset = bowl.transform.position - transform.position;
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (collider.Raycast(ray, out hit, Mathf.Infinity)) {
                bowl.transform.position = hit.point;
                bowl.SetActive(true);
            }
        }
        int count = PlayerPrefs.GetInt("Bowl");

        if (count == 4) {
            dish_pile_large.SetActive(false);
            dish_pile_small.SetActive(true);
        }

        if (count == 7) {
            dish_pile_small.SetActive(false);
        }
    }
}

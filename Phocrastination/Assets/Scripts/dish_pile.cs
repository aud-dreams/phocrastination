using UnityEngine;

public class dish_pile : MonoBehaviour
{
    public game_data game_data;
    public int dirty_bowls;
    private new Collider collider;
    public GameObject bowl, dish_pile_large, dish_pile_small;
    Vector3 mousePositionOffset;

    private void Start() {
        collider = GetComponent<Collider>();

        dirty_bowls = game_data.dirty_bowls;

        if (dirty_bowls >= 1 && dirty_bowls <= 4) {
            dish_pile_small.SetActive(true);
            dish_pile_large.SetActive(false);
        } else if (dirty_bowls == 0) {
            dish_pile_small.SetActive(false);
            dish_pile_large.SetActive(false);
        } else {
            dish_pile_small.SetActive(false);
            dish_pile_large.SetActive(true);
        }

        mousePositionOffset = bowl.transform.position - transform.position;
    }

    private void Update() {
        if (game_data.allow_bowls) {
            if (Input.GetMouseButtonDown(0)) {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (collider.Raycast(ray, out hit, Mathf.Infinity)) {
                    bowl.transform.position = hit.point;
                    bowl.SetActive(true);
                }
            }

            // get updated values
            dirty_bowls = game_data.dirty_bowls;

            // base condition
            if (dirty_bowls == 1) {
                if (Input.GetMouseButtonDown(0)) {
                    dish_pile_small.SetActive(false);
                }
            }

            if (dirty_bowls == 5) {
                if (Input.GetMouseButtonDown(0)) {
                    dish_pile_large.SetActive(false);
                    dish_pile_small.SetActive(true);
                }
            }
        }
    }
}
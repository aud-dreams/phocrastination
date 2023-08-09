using UnityEngine;
using Proyecto26;

public class dish_pile : MonoBehaviour
{
    public game_data game_data;
    public stat_data stat_data;
    public int dirty_bowls;
    private new Collider collider;
    public GameObject bowl, dish_pile_large, dish_pile_small;
    Vector3 mousePositionOffset;
    private Renderer render;

    user_log user = new user_log();

    private void Start()
    {
        collider = GetComponent<Collider>();
        render = bowl.GetComponent<Renderer>();

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
                    render.enabled = true;

                    // first click only
                    if (stat_data.isFirstClick) {
                        user.bowl_washed_ts1 = game_data.timer;
                        RestClient.Post("https://phocrastination-27ee9-default-rtdb.firebaseio.com/" + game_data.userID + ".json", user);
                        stat_data.isFirstClick = false;
                    }
                }
            }

            game_data.washing = true;   // once bowl picked up, currently washing

            // base condition
            if (game_data.dirty_bowls == 1)
            {
                dish_pile_small.SetActive(false);
            }
            if (game_data.dirty_bowls == 5)
            {
                dish_pile_large.SetActive(false);
                dish_pile_small.SetActive(true);
            }
        }
    }
}

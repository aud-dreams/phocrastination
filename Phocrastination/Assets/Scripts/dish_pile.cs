using UnityEngine;

public class dish_pile : MonoBehaviour
{
    public game_data game_data;
    private new Collider collider;
    public GameObject bowl, dish_pile_large, dish_pile_small;
    Vector3 mousePositionOffset;
    private Renderer render;

    private void Start()
    {
        collider = GetComponent<Collider>();
        render = bowl.GetComponent<Renderer>();

        if (game_data.dirty_bowls >= 1 && game_data.dirty_bowls <= 4)
        {
            dish_pile_small.SetActive(true);
            dish_pile_large.SetActive(false);
        }
        else if (game_data.dirty_bowls == 0)
        {
            dish_pile_small.SetActive(false);
            dish_pile_large.SetActive(false);
        }
        else
        {
            dish_pile_small.SetActive(false);
            dish_pile_large.SetActive(true);
        }

        mousePositionOffset = bowl.transform.position - transform.position;
    }

    private void Update()
    {
        if (game_data.allow_bowls)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (collider.Raycast(ray, out hit, Mathf.Infinity))
                {
                    bowl.transform.position = hit.point;
                    bowl.SetActive(true);
                    render.enabled = true;
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
    }
}
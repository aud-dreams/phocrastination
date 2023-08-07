using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_toggle : MonoBehaviour
{
    private Renderer render;
    private new Collider collider;
    public game_data game_data;
    private SpriteRenderer toggle_render;
    public GameObject home;

    private void Start()
    {
        // get render component
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider>();

        // set visibility at start
        render.enabled = false;
    }

    private void OnMouseEnter()
    {
        render.enabled = true;
    }

    private void OnMouseExit()
    {
        render.enabled = false;
    }

    private IEnumerator blink(GameObject toggle)
    {
        toggle_render = toggle.GetComponent<SpriteRenderer>();
        for (int i = 0; i < 5; i++)
        {
            toggle_render.enabled = true;
            yield return new WaitForSeconds(0.3f);
            toggle_render.enabled = false;
            yield return new WaitForSeconds(0.3f);
        }
    }

    public Animator crossfade;
    public string scene;
    IEnumerator LoadScene()
    {
        crossfade.SetTrigger("end");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
    }

    void Update()
    {
        // blink home for tutorial after finish_bowl_button pressed (for crafting station)
        if (game_data.crafting_blink && game_data.tutorial)
        {
            StartCoroutine(blink(home));
            game_data.crafting_blink = false;
        }

        // blink home for tutorial when finish washing dishes
        if (game_data.dishes_blink && game_data.tutorial)
        {
            StartCoroutine(blink(home));
            game_data.dishes_blink = false;
            game_data.home_on = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (collider.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (collider.CompareTag("Serving"))
                {
                    game_data.can_next = false;
                    if (game_data.tutorial)
                    {
                        game_data.take_order_done = true;
                        game_data.home_on = false;
                    }
                }

                if (collider.CompareTag("Crafting"))
                {
                    game_data.crafting_continue = true;
                    game_data.current_color = Color.black;
                    if (game_data.tutorial)
                    {
                        game_data.make_order_done = true;
                        game_data.home_on = false;
                    }
                }

                if (collider.CompareTag("Pickup"))
                {
                    game_data.can_next2 = false;
                    if (game_data.tutorial)
                    {
                        game_data.drop_order_done = true;
                        game_data.home_on = false;
                    }
                }

                if (collider.CompareTag("Dishes"))
                {
                    if (game_data.tutorial)
                    {
                        game_data.wash_dishes_done = true;
                        game_data.home_on = false;
                    }
                }

                if (collider.CompareTag("Cat"))
                {
                    game_data.allow_hand = false;
                    game_data.hand_on = false;
                    game_data.outside_catscene = true;
                    if (game_data.tutorial)
                    {
                        game_data.pet_cat_done = true;
                        game_data.home_on = false;
                    }
                }

                StartCoroutine(LoadScene());
            }
        }
    }
}

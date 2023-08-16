using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;

public class color_switch : MonoBehaviour
{
    private Renderer render;
    private new Collider collider;
    public GameObject baseDot;
    public game_data game_data;
    public stat_data stat_data;

    user_log user = new user_log();

    private void Start() {
        // get render component
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider>();

        // set visibility at start
        render.enabled = false;
    }

    private void OnMouseEnter() {
        if (!game_data.help) {
            render.enabled = true;
        }
    }

    private void OnMouseExit() {
        render.enabled = false;
    }

    private Color HexToColor(string hex) {
        Color color = Color.black;
        if (ColorUtility.TryParseHtmlString(hex, out color)) {
            return color;
        }
        return color;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (collider.Raycast(ray, out hit, Mathf.Infinity)) {
                // switch base dot to new color
                if (!game_data.help) {
                    if (this.CompareTag("OutlineColor")) {
                        game_data.current_color = Color.black;
                    }

                    if (this.CompareTag("BeefColor")) {
                        game_data.current_color = HexToColor("#8d6042");

                        if(stat_data.switched)
                        {
                            user.game_status = game_data.round_type;
                            user.color_switch++;
                            RestClient.Post(game_data.db_url + game_data.userID + ".json", user);
                            stat_data.switched = false;
                        }
                        stat_data.switched = true;
                    }

                    if (this.CompareTag("BrothColor")) {
                        game_data.current_color = HexToColor("#cfa76e");

                        if(stat_data.switched)
                        {
                            user.game_status = game_data.round_type;
                            user.color_switch++;
                            RestClient.Post(game_data.db_url + game_data.userID + ".json", user);
                            stat_data.switched = false;
                        }
                        stat_data.switched = true;
                    }
                    if (this.CompareTag("HerbsColor")) {
                        game_data.current_color = HexToColor("#507d4a");

                        if(stat_data.switched)
                        {
                            user.game_status = game_data.round_type;
                            user.color_switch++;
                            RestClient.Post(game_data.db_url + game_data.userID + ".json", user);
                            stat_data.switched = false;
                        }
                        stat_data.switched = true;
                    }
                    if (this.CompareTag("NoodlesColor")) {
                        game_data.current_color = HexToColor("#f0ddb6");

                        if(stat_data.switched)
                        {
                            user.game_status = game_data.round_type;
                            user.color_switch++;
                            RestClient.Post(game_data.db_url + game_data.userID + ".json", user);
                            stat_data.switched = false;
                        }
                        stat_data.switched = true;
                    }
                }
            }
        }
    }
}

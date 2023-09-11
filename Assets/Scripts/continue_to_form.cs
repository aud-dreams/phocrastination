using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;

public class continue_to_form : MonoBehaviour
{
    public game_data game_data;
    private Renderer render;
    private new Collider collider;
    private string qualtricsURL = "https://qfreeaccountssjc1.az1.qualtrics.com/jfe/form/SV_bCbomAn7psR0Fp4";
    user_log user = new user_log();

    private void Start()
    {
        // get render component
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
    }

    public void OpenLink()
    {
        Application.OpenURL(qualtricsURL);
        Debug.Log("opening link");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
            {
                OpenLink();
                user.game_done = true;
                RestClient.Post(game_data.db_url + game_data.userID + ".json", user);
            }
        }
    }
}
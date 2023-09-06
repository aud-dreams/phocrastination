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
    private string qualtricsURL = "https://www.google.com/search?q=cat+pho&tbm=isch&ved=2ahUKEwjDt82g4oiBAxX5M0QIHS2HBZcQ2-cCegQIABAA&oq=cat+pho&gs_lcp=CgNpbWcQAzIHCAAQigUQQzIICAAQgAQQsQMyCAgAEIAEELEDMggIABCABBCxAzIFCAAQgAQyCwgAEIAEELEDEIMBMgUIABCABDIFCAAQgAQyBQgAEIAEMgUIABCABDoGCAAQCBAeOgcIABAYEIAEOgoIABCKBRCxAxBDUO8JWLAQYPgVaABwAHgAgAFtiAGsBJIBAzYuMpgBAKABAaoBC2d3cy13aXotaW1nwAEB&sclient=img&ei=Z4LxZIPoLPnnkPIPrY6WuAk&bih=1157&biw=1162&rlz=1C1YTUH_enUS989US989#imgrc=sAdcgS4Pgs5BRM";
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
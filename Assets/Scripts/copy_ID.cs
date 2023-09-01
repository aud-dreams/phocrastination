using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class copy_ID : MonoBehaviour
{
    public game_data game_data;
    private Renderer render;
    private new Collider collider;
    public GameObject status;

    private void Start()
    {
        // get render component
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
        status.SetActive(false);
    }

    public void CopyToClipboard()
    {
        GUIUtility.systemCopyBuffer = game_data.userID.ToString();
        Debug.Log("Unique ID copied to clipboard: " + game_data.userID.ToString());
        status.SetActive(true);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
            {
                CopyToClipboard();
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundaries : MonoBehaviour {
    public Camera MainCamera;
    private Vector2 screenBounds;
    private float width, height;

    // Use this for initialization
    void Start () {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        width = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        height = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }

    // Update is called once per frame
    void LateUpdate(){
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + width, screenBounds.x - width);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + height, screenBounds.y - height);
        transform.position = viewPos;
    }
}
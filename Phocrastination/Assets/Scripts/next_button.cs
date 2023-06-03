using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class next_button : MonoBehaviour
{
    private Renderer render;
    private new Collider collider;

    public SpriteRenderer sprite1ToEnable;
    public SpriteRenderer sprite1ToDisable;
    public SpriteRenderer sprite2ToEnable;
    public SpriteRenderer sprite2ToDisable;
    public GameObject[] spritesToDisableEnd;
    public GameObject[] spritesToEnableEnd;
    public GameObject buttonObject;

    private int click = 1;

    private void Start() {
        if (PlayerPrefs.GetInt("Bool") == 1) {
            buttonObject.SetActive(true);
        } else {
            buttonObject.SetActive(false);
        }
        
        // get render component
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider>();

        // set visibility at start
        SetVisibility(false);
    }

    private void OnMouseEnter() {
        SetVisibility(true);
    }

    private void OnMouseExit() {
        SetVisibility(false);
    }

    private void SetVisibility(bool isVisible) {
        render.enabled = isVisible;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (collider.Raycast(ray, out hit, Mathf.Infinity)) {
                if (click == 1) {
                    // enable menu2
                    sprite1ToEnable.enabled = true;
                    // disable menu1
                    sprite1ToDisable.enabled = false;
                    click += 1;
                } else if (click == 2) {
                    // enable menu5
                    sprite2ToEnable.enabled = true;
                    // disable menu2
                    sprite2ToDisable.enabled = false;
                    click += 1;
                } else if (click == 3) {
                    // disable all menu sprites
                    foreach (GameObject sprite in spritesToDisableEnd) {
                        sprite.SetActive(false);
                    }
                    // enable all hovers
                    foreach (GameObject sprite in spritesToEnableEnd) {
                        sprite.SetActive(true);
                    }
                    buttonObject.SetActive(false);
                    PlayerPrefs.SetInt("Bool", 0);
                }
                
            }
        }
    }
}

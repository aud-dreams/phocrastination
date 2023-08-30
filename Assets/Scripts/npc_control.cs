using UnityEngine;
using UnityEngine.SceneManagement;

public class npc_control : MonoBehaviour
{
    private Vector3 targetPosition;
    private bool isMoving = true;
    private SpriteRenderer render;
    public Sprite npcfront, npcback, npcleft, npcright;
    private string station;

    private void Awake()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Npc");

        if (obj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        render = GetComponent<SpriteRenderer>();
        targetPosition = new Vector3(1.9f, 3.2f, 0f);
        render.sprite = npcleft;
        station = "Order";
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            render.enabled = true;
        }
        else
        {
            render.enabled = false;
        }

        if (isMoving)
        {
            // move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 4 * Time.deltaTime);

            // if the character has reached the target position
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                isMoving = false;

                // determine the next target position and sprite
                if (targetPosition == new Vector3(1.9f, 3.2f, 0f))
                {
                    station = "Crafting";
                    targetPosition = new Vector3(-5.78f, 0.54f, 0f);
                    Invoke("ResumeMovement", 5f);
                }
                else if (targetPosition == new Vector3(-5.78f, 0.54f, 0f))
                {
                    station = "Pickup";
                    targetPosition = new Vector3(-4.42f, 3.32f, 0f);
                    Invoke("ResumeMovement", 10f);
                }
                else if (targetPosition == new Vector3(-4.42f, 3.32f, 0f))
                {
                    station = "Dishes";
                    targetPosition = new Vector3(-0.64f, -1.34f, 0f);
                    Invoke("ResumeMovement", 5f);
                }
                else if (targetPosition == new Vector3(-0.64f, -1.34f, 0f))
                {
                    station = "Order";
                    targetPosition = new Vector3(1.9f, 3.2f, 0f);
                    Invoke("ResumeMovement", 10f);
                }
            }
        }
    }

    private void ResumeMovement()
    {
        isMoving = true;

        if (station == "Crafting")
        {
            render.sprite = npcleft;
        }
        else if (station == "Pickup")
        {
            render.sprite = npcback;
        }
        else if (station == "Dishes")
        {
            render.sprite = npcfront;
        }
        else if (station == "Order")
        {
            render.sprite = npcright;
        }
    }
}

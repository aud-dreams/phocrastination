using UnityEngine;

public class UpdateHandler : MonoBehaviour
{
    public game_data game_data;
    public AudioSource src;
    public AudioClip jingle;

    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("Jingle_Music");

        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        src.clip = jingle;
    }

    private void Update()
    {
        // Update customer timer
        if (game_data.allow_timer && !game_data.tutorial)
        {
            game_data.customerTimer -= Time.deltaTime;
        }

        if ((game_data.round_type == 1 || game_data.round_type == 3) && (game_data.timer > 120 && game_data.timer < 300) && game_data.customerTimer <= 0)       // timer between 3 min and 5 min, add customer every 90 secs
        {
            // Day1: 2 start, 2 added, 4 total
            // Day3: 2 start, 2 added, 4 total

            game_data.total_customers += 1;
            game_data.current_customers += 1;
            game_data.customerTimer = 90;

            src.Play();
        }
        else if ((game_data.round_type == 2) && (game_data.timer > 60 && game_data.timer < 360) && game_data.customerTimer <= 0)       // timer between 1 min and 6 min, add customer every 60 secs
        {
            // Day2: 4 start, 6 added, 10 total

            game_data.total_customers += 1;
            game_data.current_customers += 1;
            game_data.customerTimer = 60;
        }

        // Update dishes timer
        if (game_data.allow_timer && !game_data.tutorial)
        {
            game_data.dishesTimer -= Time.deltaTime;
        }

        if ((game_data.timer > 120 && game_data.timer < 300) && game_data.dishesTimer <= 0)         // timer between 3 min and 5 min, add dish every 30 secs
        {
            // Day1: 3 start, 6 addded, 9 total
            // Day2: 5 start, 6 added, 11 total
            // Day3: 3 start, 6 addded, 9 total

            game_data.dirty_bowls += 1;
            game_data.dishesTimer = 30;
        }
    }
}
using UnityEngine;

public class UpdateHandler : MonoBehaviour
{
    public game_data game_data;

    private void Update()
    {
        // Update customer timer
        if (game_data.allow_timer && !game_data.tutorial)
        {
            game_data.customerTimer -= Time.deltaTime;
        }

        if ((game_data.timer > 120 && game_data.timer < 300) && game_data.customerTimer <= 0)       // timer between 3 min and 5 min, add customer every min
        {
            // Day1: 3 start, 3 added, 6 total
            // Day2: 5 start, 3 added, 8 total
            // Day3: 3 start, 3 added, 6 total

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
            // Day1: 3 start, 7 addded, 10 total
            // Day2: 5 start, 7 added, 12 total
            // Day3: 3 start, 7 addded, 10 total

            game_data.dirty_bowls += 1;
            game_data.dishesTimer = 30;
        }
    }
}

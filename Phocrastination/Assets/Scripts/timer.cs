using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Proyecto26;

public class timer : MonoBehaviour
{
        public game_data game_data;
        public stat_data stat_data;
        public Animator crossfade;
        public string scene;

        user_log user = new user_log();

        IEnumerator LoadScene()
        {
                crossfade.SetTrigger("end");
                yield return new WaitForSeconds(1f);
                SceneManager.LoadScene(scene);
        }

        void Update()
        {
                if (game_data.allow_timer && !game_data.tutorial)
                {
                        game_data.timer += Time.deltaTime;
                }

                if (game_data.timer > 420 && game_data.round_type == 1)      // Day1 over
                {
                        user.order_collected_rem = game_data.current_customers;
                        user.order_collected_tot = game_data.total_customers;
                        user.order_given_rem = game_data.constructed_orders;
                        user.order_given_tot = game_data.total_customers;
                        user.bowl_created_rem = game_data.orders;
                        user.bowl_created_tot = game_data.total_customers;
                        user.bowl_washed_rem = game_data.dirty_bowls;
                        user.bowl_washed_tot = stat_data.dirty_bowls_tot;
                        RestClient.Post("https://phocrastination-27ee9-default-rtdb.firebaseio.com/" + game_data.userID + ".json", user);

                        game_data.Day2 = true;
                        game_data.first_day2_help = true;
                        StartCoroutine(LoadScene());
                }
                else if (game_data.timer > 420 && game_data.round_type == 2)      // Day2 over
                {
                        user.order_collected_rem = game_data.current_customers;
                        user.order_collected_tot = game_data.total_customers;
                        user.order_given_rem = game_data.constructed_orders;
                        user.order_given_tot = game_data.total_customers;
                        user.bowl_created_rem = game_data.orders;
                        user.bowl_created_tot = game_data.total_customers;
                        user.bowl_washed_rem = game_data.dirty_bowls;
                        user.bowl_washed_tot = stat_data.dirty_bowls_tot;
                        RestClient.Post("https://phocrastination-27ee9-default-rtdb.firebaseio.com/" + game_data.userID + ".json", user);

                        game_data.Day3 = true;
                        game_data.first_day3_help = true;
                        StartCoroutine(LoadScene());
                }
                else if (game_data.timer > 420 && game_data.round_type == 3)      // Day3 over
                {
                        user.order_collected_rem = game_data.current_customers;
                        user.order_collected_tot = game_data.total_customers;
                        user.order_given_rem = game_data.constructed_orders;
                        user.order_given_tot = game_data.total_customers;
                        user.bowl_created_rem = game_data.orders;
                        user.bowl_created_tot = game_data.total_customers;
                        user.bowl_washed_rem = game_data.dirty_bowls;
                        user.bowl_washed_tot = stat_data.dirty_bowls_tot;
                        RestClient.Post("https://phocrastination-27ee9-default-rtdb.firebaseio.com/" + game_data.userID + ".json", user);

                        Application.Quit();
                }

                // decrement cat bar once cat scene first clicked on
                if (!game_data.first_cat_help && game_data.outside_catscene && game_data.progress_scale.x > 0)
                {
                        game_data.progress_position = game_data.progress_position - new Vector3(0.0000099999f, 0f, 0f);
                        game_data.progress_scale = game_data.progress_scale - new Vector3(0.00001f, 0f, 0f);
                }
        }
}

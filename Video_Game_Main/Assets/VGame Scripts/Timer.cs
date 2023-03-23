using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;

    public TextMeshProUGUI TimerText;
    [SerializeField] private GameObject victoryScreen;
    // Start is called before the first frame update
    void Start()
    {
        TimerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                TimerOn = false;
                TimeLeft = 0;

                GameObject player = GameObject.FindGameObjectWithTag("Player");
                Component[] components = player.GetComponents<Component>();
                foreach (Component component in components)
                {
                    if (component.GetType() != typeof(SkinnedMeshRenderer)
                        && component.GetType() != typeof(Transform)
                        && component.GetType() != typeof(Animator)
                       )
                    {
                        Destroy(component);
                    }
                }
                foreach (Enemy enemy in GameObject.FindObjectsOfType<Enemy>())
                {
                    enemy.LostPlayer(gameObject);
                }
                GameObject.FindObjectsOfType<Enemy>();

                victoryScreen.SetActive(true);
            }
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}

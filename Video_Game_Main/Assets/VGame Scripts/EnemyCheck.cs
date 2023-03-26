using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheck : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject Timer;
    [SerializeField] private int numberOfEnemies;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
       // numberOfEnemies = enemies.Length;
       
        
        if (numberOfEnemies >= 100)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerHealth foundHealth = player.GetComponentInParent<PlayerHealth>();
            if (foundHealth != null)
            {
                foundHealth.Die();
            }
        }
    }

    public void OnTriggerEnter(Collider entered)
    {
        if (entered.CompareTag("Enemy"))
        {
            numberOfEnemies += 1;
        }
    }

    public void OnTriggerExit(Collider entered)
    {
        if (entered.CompareTag("Enemy"))
        {
            numberOfEnemies -= 1;
        }
    }

    public void Died()
    {
        
        
            numberOfEnemies -= 1;
        
    }

   
}

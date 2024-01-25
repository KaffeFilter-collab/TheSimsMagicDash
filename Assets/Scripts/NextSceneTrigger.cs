using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextSceneTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //In welche Scene soll er laden?
            SceneManager.LoadScene(0);
            //Distance(playerpos, enemypos, 3)
        }
    }
}

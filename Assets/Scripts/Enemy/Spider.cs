using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    public Player player;   
    private bool alive;
    private void Awake()
    {
        
        player = GetComponent<Player>();
        alive = true;
        StartCoroutine(Spiderlogic());
    }

    IEnumerator Spiderlogic() 
    {
        while (true) 
        {
          //  Instantiate(spiderprojektileprefab, player.transform);


        }
    }
}

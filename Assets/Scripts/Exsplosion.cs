using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exsplosion : MonoBehaviour
{
 public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("Player"))
        {
           StartCoroutine(boomstop());
        }
    }
    IEnumerator boomstop()
    {
        yield return new WaitForEndOfFrame();
        Destroy(gameObject);
    }

}

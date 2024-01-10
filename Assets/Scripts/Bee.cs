using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] public float movementSpeed = 3f;
    GameObject player;
    public GameObject exsplosion;
    private new Rigidbody2D rigidbody2D;
    private Enemy enemy;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        rigidbody2D=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Bee(player.transform.position);
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        print("outsideif");
        if(collision.gameObject.CompareTag("Player"))
        {
            
            print("inIFstatment");
           Instantiate(exsplosion);
            Destroy(gameObject);
        }
    }
    

    private void Bee(Vector3 targetPosition)
    {
        Vector2 moveDirection =
            new Vector2(targetPosition.x - transform.position.x, 
                        targetPosition.y - transform.position.y);
        moveDirection = moveDirection.normalized;

        rigidbody2D.velocity = moveDirection * movementSpeed;
    }

    
}

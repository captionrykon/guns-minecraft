using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybu : MonoBehaviour
{
    public float speed;
    [SerializeField]
    private GameObject player;
    private Vector3 target;
   // [SerializeField]
   // public GameObject ImapctEBPartical;
    [SerializeField]
    private enemyStates stats = null;

    private void Start()
    {
        stats = GetComponent<enemyStates>();
        player = GameObject.FindGameObjectWithTag("Player");
        target = new Vector3(player.transform.position.x , player.transform.position.y, player.transform.position.z);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(transform.position.x == target.x  && transform.position.y == target.y  && transform.position.z == target.z )
        {

            destroyBullet();
            
        }
    }
   
   
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            CharacterStats targetStates = player.GetComponent<CharacterStats>();
            attacktarget(targetStates);
            //Destroy(this.gameObject);
           // GameObject impactEB = Instantiate(ImapctEBPartical, transform.position, Quaternion.identity);
           // Destroy(impactEB, 0.5f);
            destroyBullet();

        }
        else
        {
            Destroy(this.gameObject);
           // GameObject impactEB = Instantiate(ImapctEBPartical, transform.position, Quaternion.identity);
            //Destroy(impactEB, 0.5f);
        }
    }
    private void attacktarget(CharacterStats statsToDamage)
    {
        stats.DealDamage(statsToDamage);
    }
    void destroyBullet()
    {
        Destroy(gameObject, 0.5f);
       // GameObject impactEB = Instantiate(ImapctEBPartical, transform.position, Quaternion.identity);
       // Destroy(impactEB, 0.5f);

    }
}

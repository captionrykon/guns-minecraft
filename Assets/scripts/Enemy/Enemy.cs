using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform target;
    public Transform groundCheck;

    public float speed = 4f;
    public float maxDist = 1f;
    public float jumpForce = 50f;
    public float groundDistance = 0.4f;
    public float chaseRadius = 10f;
    private Animator anim = null;
    public int attackRandomizer;

    public float distanceToPlayer;
    public GameObject enemyBspawner;
    private float timeForLAstAttack;
    public float startTimeBtwShorts;
    public float timeBtwShots;
    public float fightRange;
    [SerializeField]
    private enemyStates stats = null;
    private bool attackLast = false;
    public GameObject projectile;
  
    public bool playerisInsightRange, playerInAttackRange;



    public bool isGrounded;
   
    public Rigidbody rb;

    public LayerMask obstacle;
    public LayerMask Player;
    public LayerMask ground;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        if(target!= null)
        {
            target = GameObject.FindWithTag("Player").transform;

        }
        
        stats = GetComponent<enemyStates>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerCheck();
        GroundCheck();

        startTimeBtwShorts = timeBtwShots;
      

        playerisInsightRange = Physics.CheckSphere(transform.position, fightRange, Player);
        playerInAttackRange = Physics.CheckSphere(transform.position, chaseRadius, Player);
    }

    public void Movement()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        rb.MovePosition(pos);

        Vector3 targetPostition = new Vector3(target.position.x, this.transform.position.y, target.position.z);
        this.transform.LookAt(targetPostition);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDist, obstacle))
        {
            rb.AddForce(transform.up * jumpForce);
        }
    }

    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, ground);
    }

    void PlayerCheck()
    {
        if (Physics.CheckSphere(transform.position, chaseRadius, Player )&& distanceToPlayer > fightRange)
        {
            
            {
                Movement();
                anim.SetFloat("speed", 1f, 0.3f, Time.deltaTime);

            }
              
        }

        if (playerisInsightRange == false && playerInAttackRange == false)
        {
            anim.SetFloat("speed", 0f);
        }

        // Calculate the distance between the enemy and the player.
         distanceToPlayer = Vector3.Distance(transform.position, target.position);

        if (playerisInsightRange == true && playerInAttackRange == true && distanceToPlayer < fightRange)
        {
            rb.velocity = Vector3.zero;
            anim.SetFloat("speed", 0f);
            AttackPlayer();

        }
    }

    private void AttackPlayer()
    {


        transform.LookAt(target);
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;
        if (!attackLast && timeBtwShots <= 0)
        {

            anim.SetTrigger("attack");
            anim.SetFloat("speed", 0f);
            Instantiate(projectile, enemyBspawner.transform.position, Quaternion.identity);
            // FindObjectOfType<audioManager>().play("robotbullets");
           // GameObject spark = Instantiate(enemySpark, enemyBspawner.transform.position, Quaternion.LookRotation(transform.position));
           /// Destroy(spark, 2f);
            timeBtwShots = startTimeBtwShorts;
            attackLast = true;
            Invoke(nameof(ResetAttack), timeForLAstAttack);
            anim.SetFloat("speed", 1f);
        }
        else
        {
            timeBtwShots -= Time.deltaTime;

        }
    }
    private void ResetAttack()
    {
        attackLast = false;
    }

    private void attacktarget(CharacterStats statsToDamage)
    {
        stats.DealDamage(statsToDamage);
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,fightRange );
    }
}
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

//public class enemyController : MonoBehaviour
//{
//    [SerializeField]
//    private float stoppingDistance = 3;

//    [SerializeField]
//    private Transform target = null;
//    private Animator anim = null;
//    [SerializeField]
//    private enemyStates stats = null;

//    public LayerMask Player, Ground;
//    //attaking
//    [SerializeField]
//    private float timeForLAstAttack;
//    private bool attackLAst = false;
//    public GameObject projectile;
//    public GameObject enemyBspawner;
//    public GameObject enemySpark;
//    public float startTimeBtwShorts;
//    public float timeBtwShots;

//    //states
//    public float sightRange, attackrange;
//    public bool playerisInsightRange, playerInAttackRange;

//    // patroling
//    public Vector3 walkpoint;
//    bool walkPointSet;
//    public float walkPointRange;

//    public Rigidbody rb;
//    // Start is called before the first frame update
//    void Start()
//    {
//        getReference();
//        startTimeBtwShorts = timeBtwShots;
//        playerInAttackRange = false;
//        playerisInsightRange = false;
//        rb = GetComponent<Rigidbody>();

//    }
//    private void Update()
//    {
//        playerisInsightRange = Physics.CheckSphere(transform.position, sightRange, Player);
//        playerInAttackRange = Physics.CheckSphere(transform.position, attackrange, Player);

//        if (playerisInsightRange == false && playerInAttackRange == false)
//        {
//            Patroling();

//        }
//        if (playerisInsightRange == true && playerInAttackRange == false)
//        {
//            if (gameObject.tag == "Player")
//            {
//                ChasePlayer();
//            }

//        }
//        if (playerisInsightRange == true && playerInAttackRange == true)
//        {
//            AttackPlayer();

//        }


//    }
//    private void Patroling()
//    {

//        if (!walkPointSet) SearchWalkingPoint();
//        if (walkPointSet)
//        {

//            anim.SetFloat("speed", 0f);
//            playerInAttackRange = false;
//            playerisInsightRange = false;
//        }
//        Vector3 distanceToWalkPoint = transform.position - walkpoint;

//        //Walkpoint reached
//        if (distanceToWalkPoint.magnitude < 1f)
//            walkPointSet = false;
//    }

//    private void SearchWalkingPoint()
//    {
//        anim.SetFloat("speed", 0f);
//        //Calculate random point in range
//        float randomZ = Random.Range(-walkPointRange, walkPointRange);
//        float randomX = Random.Range(-walkPointRange, walkPointRange);

//        walkpoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

//        if (Physics.Raycast(walkpoint, -transform.up, 2f, Ground))
//            walkPointSet = true;
//        playerInAttackRange = false;
//        playerisInsightRange = false;

//    }
//    private void ChasePlayer()
//    {



//        float distanceToTarget = Vector3.Distance(target.position, transform.position);
//        if (distanceToTarget > agent.stoppingDistance)
//        {

//            transform.position = Vector3.MoveTowards(transform.position, target.position, agent.speed * Time.deltaTime);
//            anim.SetFloat("speed", 1f, 0.3f, Time.deltaTime);
//        }
//        else if (Vector3.Distance(transform.position, target.position) < agent.stoppingDistance && Vector3.Distance(transform.position, target.position) > agent.stoppingDistance)
//        {

//            transform.position = this.transform.position;
//            anim.SetFloat("speed", 0f);
//        }
//        else if (distanceToTarget < agent.stoppingDistance)
//        {

//            transform.position = Vector3.MoveTowards(transform.position, target.position, -agent.speed * Time.deltaTime);
//            anim.SetFloat("speed", 1f, 0.3f, Time.deltaTime);
//        }

//    }
//    private void AttackPlayer()
//    {


//        //Make sure enemy doesn't move
//        agent.SetDestination(target.position);

//        transform.LookAt(target);
//        if (!attackLAst && timeBtwShots <= 0)
//        {

//            anim.SetTrigger("attack");
//            anim.SetFloat("speed", 0f);
//            Instantiate(projectile, enemyBspawner.transform.position, Quaternion.identity);
//            // FindObjectOfType<audioManager>().play("robotbullets");
//            GameObject spark = Instantiate(enemySpark, enemyBspawner.transform.position, Quaternion.LookRotation(transform.position));
//            Destroy(spark, 2f);
//            timeBtwShots = startTimeBtwShorts;
//            attackLAst = true;
//            Invoke(nameof(ResetAttack), timeForLAstAttack);
//            anim.SetFloat("speed", 1f);
//        }
//        else
//        {
//            timeBtwShots -= Time.deltaTime;

//        }
//    }
//    private void ResetAttack()
//    {
//        attackLAst = false;
//    }

//    private void attacktarget(CharacterStats statsToDamage)
//    {
//        stats.DealDamage(statsToDamage);
//    }
//    void getReference()
//    {
//        agent = GetComponent<NavMeshAgent>();
//        anim = GetComponentInChildren<Animator>();
//        stats = GetComponent<enemyStates>();
//        // target = PlayerMovement.instance.GetComponent<Transform>();

//    }
//    public void OnDrawGizmosSelected()
//    {
//        Gizmos.color = Color.red;
//        Gizmos.DrawWireSphere(transform.position, sightRange);
//        Gizmos.color = Color.blue;
//        Gizmos.DrawWireSphere(transform.position, attackrange);
//    }
//}

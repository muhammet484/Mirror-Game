using UnityEngine;
[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class skeletonMoving : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public CharacterController controller;
    [SerializeField] Transform target;
    Vector3 targetPosition = Vector3.zero;
    [SerializeField] Animator mainAnimation;

    public float speed = 10f;
    public float gravity = -10f;
    public float jumpHeight = 5f;
    Vector3 velocity;

    [SerializeField] Transform bow;//the bow which is in skeleton
    [SerializeField] Transform leftHand;//left hand of skeleton

    [SerializeField] GameObject arrow;//the arrow will be throwed
    [SerializeField] Transform rightHand; // right hands finger. this should catch the arrow
    private void Start()
    {
        agent.updateRotation = false;
        agent.updatePosition = true;
    }
    void Update()
    {
       
        /*
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }*/

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        //konuma ulaştıysa hareketi kessin. konum değişmiş ise hareket etsin.
        //is target not null?
        if (target != null)
            //has targets position been changed?
            if(targetPosition != target.position)
            {
                agent.SetDestination(target.position);
                //go to target but stop in 1 distance
                if (agent.remainingDistance - 1  > agent.stoppingDistance)
                {
                    //change skeletons rotation to where it is walking
                    RotateTowards(target);

                    //walk
                    controller.Move(agent.desiredVelocity * speed * Time.deltaTime);
                    mainAnimation.SetBool("isWalking", true);
                    mainAnimation.SetBool("isStoping", false);
                }
                else
                //don't walk
                {
                    mainAnimation.SetBool("isWalking", false);
                    mainAnimation.SetBool("isStoping", true);
                    targetPosition = target.position;
                }
            }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

       
    }
    private void RotateTowards(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
    }

    void changeParent()
    {
        bow.parent = leftHand;
    }

    void takeArrow()
    {
        GameObject template= Instantiate(arrow ,rightHand );
        template.transform.localPosition = new Vector3(0.141399994f, 0.128999993f, 0.0654999986f);
        template.transform.localRotation = new Quaternion(-0.325645328f, 0.930132091f, 0.0153073501f, 0.169041902f);
        template.transform.localScale = new Vector3(35.7224388f, 35.7224388f, 35.7224388f);
    }
}

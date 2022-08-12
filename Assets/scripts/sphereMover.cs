using UnityEngine;

public class sphereMover : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    checker Checker;
    public Quaternion TrueAngle;
    // Start is called before the first frame update
    void Start()
    {

        Checker = GameObject.Find("checker").GetComponent<checker>();
        //Checker.isThrowed = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Checker.isThrowed = false;
        Checker.instantiatedMirror = Instantiate(Checker.mirror, transform.position, TrueAngle);
        Destroy(gameObject);
    }
}

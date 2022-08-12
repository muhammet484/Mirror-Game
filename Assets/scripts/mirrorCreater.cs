using UnityEngine;
using UnityEngine.UI;
public class mirrorCreater : MonoBehaviour
{
    Ray ray;

    [SerializeField] RawImage aim;
    [SerializeField] GameObject sphere;
    [SerializeField] float sphereSpeed = 4f;

    [SerializeField] GameObject cchecker;
    checker Checker;

    GameObject clone;

    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        Checker = GameObject.Find("checker").GetComponent<checker>();
    }

    // Update is called once per frame
    void Update()
    {

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
        if (Physics.Raycast(ray.origin, ray.direction, out hit))
        {
            aim.enabled = true;
        }
        else
        {
            aim.enabled = false;
        }
            if (Input.GetMouseButtonDown(1))
            {
                if (Physics.Raycast(ray.origin, ray.direction, out hit))
                {
                    Quaternion trueAngle = Quaternion.LookRotation(-hit.normal);
                    //aynayı yok et
                    Destroy(Checker.instantiatedMirror);
                    //önceki clone'u yok et
                    Destroy(clone);
                    clone = Instantiate(sphere, ray.origin + (ray.direction * 3), Quaternion.identity);
                    clone.GetComponent<sphereMover>().TrueAngle = trueAngle;
                    clone.GetComponent<Rigidbody>().velocity = ray.direction * sphereSpeed;
                
                }
            }
    }
}

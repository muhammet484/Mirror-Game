using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class laserMaker : MonoBehaviour
{
    [SerializeField] GameObject endOfLaser;//add a red light to end of laser
    [SerializeField] GameObject laserGun;

    public int reflections;
    public float maxLenght;

    private LineRenderer lineRenderer;
    private Ray ray;
    private RaycastHit hit, hit2;
    private Vector3 direction;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            lineRenderer.enabled = true;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            lineRenderer.positionCount = 1;
            lineRenderer.SetPosition(0, laserGun.transform.position);

            float remainingLenght = maxLenght;

            for (int i = 0; i < reflections; i++)
            {
                if (Physics.Raycast(ray.origin, ray.direction, out hit, remainingLenght))
                {
                    lineRenderer.positionCount += 1;
                    lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);
                    remainingLenght -= Vector3.Distance(ray.origin, hit.point);
                    ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
                    if (hit.collider.tag != "mirror")
                    {
                        if (hit.collider.tag == "enemy")
                        {
                            hit.transform.gameObject.GetComponent<enemyManager>().Health--;
                        }
                        break;
                    }
                    
                }
                else
                {
                    lineRenderer.positionCount += 1;
                    lineRenderer.SetPosition(lineRenderer.positionCount - 1, ray.origin + ray.direction * remainingLenght);
                    
                }
            }
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            lineRenderer.enabled = false;
        }
    }
}

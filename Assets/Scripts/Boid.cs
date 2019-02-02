using UnityEngine;

public class Boid : MonoBehaviour
{
    public Vector3 velocity;

    private float cohesionRadius = 10;
    private float separationDistance = 5;
    private Collider[] boids;
    private Vector3 cohesion;
    private Vector3 separation;
    private int separationCount;

    private void Start()
    {
        InvokeRepeating("CalculateVelocity", 0, 1);
    }

    void CalculateVelocity()
    {
        velocity = Vector3.zero;
        cohesion = Vector3.zero;
        separation = Vector3.zero;
        separationCount = 0;

        boids = Physics.OverlapSphere(transform.position, cohesionRadius);
        foreach (var boid in boids)
        {
            cohesion += boid.transform.position;

            if (boid != GetComponent<Collider>() && (transform.position - boid.transform.position).magnitude < separationDistance)
            {
                separation += (transform.position - boid.transform.position) / (transform.position - boid.transform.position).magnitude;
                separationCount++;
            }
        }

        cohesion = cohesion / boids.Length;
        cohesion = cohesion - transform.position;
        if (separationCount > 0)
        {
            separation = separation / separationCount;
        }

        velocity += cohesion + separation;
    }

    void Update()
    {
        transform.position += velocity * Time.deltaTime;

        Debug.DrawRay(transform.position, separation, Color.green);
        Debug.DrawRay(transform.position, cohesion, Color.magenta);
    }
}
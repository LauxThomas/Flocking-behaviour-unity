using UnityEngine;

public class Boid : MonoBehaviour
{
    public Vector3 velocity;

    private float cohesionRadius = 10;
    private Collider[] boids;
    private Vector3 cohesion;

    private void Start()
    {
        InvokeRepeating("CalculateVelocity", 0, 1);
    }

    void CalculateVelocity()
    {
        velocity = Vector3.zero;
        cohesion = Vector3.zero;
        boids = Physics.OverlapSphere(transform.position, cohesionRadius);
        foreach (var boid in boids)
        {
            cohesion += boid.transform.position;
        }
        cohesion = cohesion / boids.Length;
        cohesion = cohesion - transform.position;
        velocity += cohesion;
    }

    void Update()
    {
        transform.position += velocity * Time.deltaTime;
        Debug.DrawRay(transform.position, cohesion, Color.magenta);
    }
}
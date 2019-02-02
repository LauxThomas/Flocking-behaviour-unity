using UnityEngine;

public class Boid : MonoBehaviour
{
    public Vector3 velocity;
    public GameObject boundaries;

    private float cohesionRadius = 10;
    private float separationDistance = 7;
    private Collider[] boids;
    private Vector3 cohesion;
    private Vector3 separation;
    private int separationCount;
    private Vector3 alignment;
    private float maxSpeed = 15;

    private void Start()
    {
        //InvokeRepeating("CalculateVelocity", 0, 0.1f);
    }


    void CalculateVelocity()
    {
        velocity = Vector3.zero;
        cohesion = Vector3.zero;
        separation = Vector3.zero;
        separationCount = 0;
        alignment = Vector3.zero;

        boids = Physics.OverlapSphere(transform.position, cohesionRadius);
        foreach (var boid in boids)
        {
            cohesion += boid.transform.position;
            alignment += boid.GetComponent<Boid>().velocity;

            if (boid != GetComponent<Collider>() &&
                (transform.position - boid.transform.position).magnitude < separationDistance)
            {
                separation += (transform.position - boid.transform.position) /
                              (transform.position - boid.transform.position).magnitude;
                separationCount++;
            }
        }

        cohesion = cohesion / boids.Length;
        cohesion = cohesion - transform.position;
        cohesion = Vector3.ClampMagnitude(cohesion, maxSpeed);
        if (separationCount > 0)
        {
            separation = separation / separationCount;
            separation = Vector3.ClampMagnitude(separation, maxSpeed);
        }

        alignment = alignment / boids.Length;
        alignment = Vector3.ClampMagnitude(alignment, maxSpeed);

        //weighting flockbehaviours:
        velocity += cohesion * 0.5f + separation * 10f + alignment * 1.5f;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
    }

    void Update()
    {
        if (Random.Range(0, 5) < 1)
        {
            CalculateVelocity();
        }

        Bounds bounds = new Bounds(Vector3.zero, new Vector3(boundaries.GetComponent<Transform>().localScale.x,
            boundaries.GetComponent<Transform>().localScale.y, boundaries.GetComponent<Transform>().localScale.z));
        if (!bounds.Contains(transform.position))
        {
            velocity += -2 * transform.position.normalized;
        }

//        if (transform.position.magnitude > 100)
//        {
//            velocity += -2*transform.position.normalized;
//        }
        if (velocity.magnitude <= 0.1f && !(GetComponent<MeshRenderer>().material.color == Color.red))
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            velocity += new Vector3(Random.value * maxSpeed, Random.value * maxSpeed, Random.value * maxSpeed);
            transform.position = Vector3.zero;
        }
        else if (!(GetComponent<MeshRenderer>().material.color == Color.black))
        {
            GetComponent<MeshRenderer>().material.color = Color.black;
        }

        transform.position += velocity * Time.deltaTime;

        //Debug.DrawRay(transform.position, velocity, Color.red);
        Debug.DrawRay(transform.position, separation, Color.green);
        Debug.DrawRay(transform.position, cohesion, Color.magenta);
        Debug.DrawRay(transform.position, alignment, Color.blue);
    }
}
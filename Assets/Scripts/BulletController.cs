using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float orbitRadius = 5f;
    public float radiusDetection = 10f;
    public float orbitSpeed = 2f;
    public string otherLayerToIgnore = "Props";
    public float gravitationalPull = 10f;
    public bool power = false;
    public GunType type;

    private void Start()
    {
        int otherLayer = LayerMask.NameToLayer(otherLayerToIgnore);
        Physics.IgnoreLayerCollision(gameObject.layer, otherLayer);
    }

    private void Update()
    {
        if(power)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radiusDetection);
            switch (type)
            {
                
                case (GunType.Pull):

                    float angle = Time.time * orbitSpeed;
                    float x = Mathf.Cos(angle) * orbitRadius;
                    float y = Mathf.Sin(angle) * orbitRadius;

                    Vector3 targetPosition = new Vector3(x, y, 0f) + transform.position;

                    foreach (Collider collider in colliders)
                    {
                        if (collider.gameObject != gameObject)
                        {
                            Rigidbody rb = collider.GetComponent<Rigidbody>();
                            if (rb != null)
                            {
                                if (collider.CompareTag("Ground") || collider.CompareTag("Wall") || collider.CompareTag("Player"))
                                {
                                    continue;
                                }

                                Vector3 direction = (targetPosition - collider.transform.position).normalized;

                                rb.AddForce(direction * gravitationalPull, ForceMode.Force);
                            }
                        }
                    }
                    break;
                case (GunType.Push):
                    foreach (Collider collider in colliders)
                    {
                        if (collider.gameObject != gameObject)
                        {
                            Rigidbody rb = collider.GetComponent<Rigidbody>();
                            if (rb != null)
                            {
                                if (collider.CompareTag("Ground") || collider.CompareTag("Wall") || collider.CompareTag("Player"))
                                {
                                    continue;
                                }

                                Vector3 direction = (collider.transform.position - transform.position).normalized;
                                rb.AddForce(direction * gravitationalPull, ForceMode.Force);
                            }
                        }
                    }
                    break;
            }
            
        }
        
    }
}

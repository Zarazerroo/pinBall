using UnityEngine;

public class SparksParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem ShreddingParticle;
    private ParticleSystem ShreddingParticleInstance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D()
    {
        SpawnShredderParticle();
    }

    private void SpawnShredderParticle()
    {
        ShreddingParticleInstance = Instantiate(ShreddingParticle, transform.position, Quaternion.identity);
    }
}

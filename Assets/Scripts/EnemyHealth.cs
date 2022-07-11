using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHitPoints = 5;
    [SerializeField] int difficultyRamp = 1;
    private int currentHitPoints = 0;
    Enemy enemy;
    MeshRenderer[] renderer;
    [SerializeField] GameObject explotionParticle;
    AudioSource audioSource;
    bool particleCoroutineHasStarted;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        renderer = GetComponentsInChildren<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;   
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHitPoints--;

        if(currentHitPoints<= 0)
        {
            //gameObject.SetActive(false);

            foreach (var mesh in renderer)
            {
                mesh.enabled = false;
            }

            if (!particleCoroutineHasStarted)
            {
                StartCoroutine(InstantiateEplotionParticle());
            }


            foreach (var mesh in renderer)
            {
                mesh.enabled = true;
            }
            gameObject.SetActive(false);

            maxHitPoints += difficultyRamp;
            enemy.RewardGold();
        }
    }

    private IEnumerator InstantiateEplotionParticle()
    {
        Vector3 explotionPosition = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        GameObject particleGameobject = Instantiate(explotionParticle, explotionPosition, Quaternion.identity);
        Debug.Log($"particle");
        audioSource.Play();
        yield return new WaitForSeconds(0.3f);
        

        //foreach (var mesh in renderer)
        //{
        //    mesh.enabled = true;
        //}
        Destroy(particleGameobject);
        //gameObject.SetActive(false);

        particleCoroutineHasStarted = true;
    }
}

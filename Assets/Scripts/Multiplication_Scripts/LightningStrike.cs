using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStrike : MonoBehaviour
{
    [SerializeField]
    private GameObject _lightning;
    [SerializeField]
    private AudioSource _lightningClip;

    //-10 - 10 , 3.9
 
    void Start()
    {
        StartCoroutine(LightningStrikes());
    }

    private IEnumerator LightningStrikes()
    {
        while (true)
        {
            yield return new WaitForSeconds(5.0f);
            _lightningClip.Play();
            var lightning = Instantiate(_lightning, new Vector3(Random.Range(-10f, 10f), 4.5f, 0f), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(2f, 6f));
            Destroy(lightning.gameObject);
            _lightningClip.Stop();

        }
    }

}

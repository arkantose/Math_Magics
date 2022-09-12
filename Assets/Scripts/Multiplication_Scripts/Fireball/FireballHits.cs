using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballHits : MonoBehaviour
{
    [SerializeField]
    private GameObject _fireBall;
    [SerializeField]
    private AudioClip _fireballHit;
    private GameObject _thisFireBall;
    



    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Fireball")
        {
            GameObject gameObject1 = other.transform.GetChild(0).gameObject;
            GameObject gameObject2 = other.transform.GetChild(1).gameObject;
            gameObject1.SetActive(false);
            gameObject2.SetActive(true);
            _thisFireBall = other.gameObject;
            StartCoroutine(TurnOnEnd());
        }
    }

    private IEnumerator TurnOnEnd()
    {
        AudioSource.PlayClipAtPoint(_fireballHit, Camera.main.transform.position);
        yield return new WaitForSeconds(1f);
        Destroy(_thisFireBall);
    }
}


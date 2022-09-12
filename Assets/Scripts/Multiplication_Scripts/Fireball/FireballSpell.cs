using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpell : MonoBehaviour
{

    [SerializeField]
    private GameObject _castleSpell;
    [SerializeField]
    private GameObject _dragonSpell;
    [SerializeField]
    private Transform _castlePos;
    [SerializeField]
    private Transform _dragonPos;
    [SerializeField]
    private AudioClip _fireballCast;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DragonSpell()
    {
        Quaternion rot = new Quaternion(0f, 0f, 0f, 0f);
        Vector3 dragonpos = _dragonPos.transform.position;
        Instantiate(_dragonSpell, dragonpos, rot);
        AudioSource.PlayClipAtPoint(_fireballCast, Camera.main.transform.position);
    }

    public void CastleSpell()
    {
        Quaternion rot = new Quaternion(0f, 0f, 0f, 0f);
        Vector3 castlepos = _castlePos.transform.position;
        Instantiate(_castleSpell, castlepos, rot);
        AudioSource.PlayClipAtPoint(_fireballCast, Camera.main.transform.position);
    }
}

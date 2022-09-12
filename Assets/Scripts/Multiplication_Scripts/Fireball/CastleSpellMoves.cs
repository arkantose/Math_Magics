using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleSpellMoves : MonoBehaviour
{
    [SerializeField]
    private Transform _dragonPos;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _dragonPos.position, 20 * Time.deltaTime);
    }
}

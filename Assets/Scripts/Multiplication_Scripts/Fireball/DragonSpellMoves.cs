using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSpellMoves : MonoBehaviour
{
    [SerializeField]
    private Transform _castlePos;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _castlePos.position, 20 * Time.deltaTime);
    }
}

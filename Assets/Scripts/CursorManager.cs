using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorManager : MonoBehaviour
{
    public Texture2D cursorArrow;
    public Texture2D cursorArrowUpdate;
    [SerializeField]
    private List<GameObject> _clickSpell = new List<GameObject>();
    private Camera _cam;
    [SerializeField]
    private AudioClip _clickClip;
    
    
    
    void Start()
    {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
        _cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            AudioSource.PlayClipAtPoint(_clickClip, _cam.transform.position);
            Cursor.SetCursor(cursorArrowUpdate, Vector2.zero, CursorMode.ForceSoftware);
            var screenPos = Input.mousePosition;
            screenPos.z = 10;
            var worldPos = _cam.ScreenToWorldPoint(screenPos);
            var newInstance = Instantiate( _clickSpell[Random.Range(0, 6)], worldPos, Quaternion.identity);
            Destroy(newInstance, 1.0f);


        }
        
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
        }
    }

}

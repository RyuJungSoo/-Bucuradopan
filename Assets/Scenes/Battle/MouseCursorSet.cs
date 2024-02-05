using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorSet : MonoBehaviour
{

    public Texture2D[] mouseCursor;

    void Start()
    {
        Cursor.SetCursor(mouseCursor[0], Vector2.zero, CursorMode.Auto);  
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Cursor.SetCursor(mouseCursor[1], Vector2.zero, CursorMode.Auto);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Cursor.SetCursor(mouseCursor[0], Vector2.zero, CursorMode.Auto);
        }
        
    }

    private void OnDestroy()
    {
        //씬 이동시, 원래 마우스 포인터로 돌아가게끔 설정
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }


}

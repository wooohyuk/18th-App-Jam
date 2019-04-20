using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour
{
    private void OnMouseDrag()
    {
        transform.position = Camera.main.WorldToScreenPoint(Input.mousePosition);
    }
}

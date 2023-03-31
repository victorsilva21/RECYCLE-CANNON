using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMovement : MonoBehaviour
{
    [SerializeField] Analog m_InputReceiver;  
    [SerializeField] float m_Speed;  
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, m_InputReceiver.movement.localPosition.x * 1 * m_Speed * 0.001f));
        
    }
}

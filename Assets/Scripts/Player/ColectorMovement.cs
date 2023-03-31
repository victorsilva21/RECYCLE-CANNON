using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColectorMovement : MonoBehaviour
{
    [SerializeField] Analog m_InputReceiver;
    [SerializeField] float m_Speed;
    private Rigidbody physicsReceiver;
    private Vector3 screenLimits;

    void Start()
    {
        physicsReceiver = gameObject.GetComponent<Rigidbody>();
        screenLimits = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(m_InputReceiver.movement.localPosition.x, 0, m_InputReceiver.movement.localPosition.y);
        physicsReceiver.velocity = movement * m_Speed * 0.1f;
        transform.LookAt(transform.position + movement);

        // Restringindo a posição do personagem dentro dos limites da tela
        float aspectRatio = (float)Screen.width / Screen.height;
        float cameraHeight = Camera.main.orthographicSize * 2;
        float cameraWidth = cameraHeight * aspectRatio;
        float screenLimitsX = cameraWidth / 2.25f;
        float screenLimitsZ = cameraHeight / 2;
        float clampedX = Mathf.Clamp(transform.position.x, -screenLimitsX, screenLimitsX);
        float clampedZ = Mathf.Clamp(transform.position.z, -screenLimitsZ, screenLimitsZ/3);
        transform.position = new Vector3(clampedX, transform.position.y, clampedZ);
    }




}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;

    [Range(1, 10)] public float smoothFactor;
    [SerializeField] private Vector3 minValues, maxValues;

    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 targetPos = player.position + offset;

        Vector3 boundPos = new Vector3(
            Mathf.Clamp(targetPos.x, minValues.x, maxValues.x),
            Mathf.Clamp(targetPos.y, minValues.y, maxValues.y),
            Mathf.Clamp(targetPos.z, minValues.z, maxValues.z));

        Vector3 smoothPos = Vector3.Lerp(transform.position, boundPos, smoothFactor * Time.deltaTime);
        transform.position = smoothPos;
    }
}

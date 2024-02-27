using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParallaxEffect : MonoBehaviour
{
    public Camera cam;
    public Transform followTarget;

    // Start is called before the first frame update
    Vector2 startingPosition;
    float startingZ;
    Vector2 camMoveSinceStart => (Vector2)cam.transform.position -  startingPosition;
    float zDistanceFromTarget => transform.position.z - followTarget.transform.position.z;
    float clippingPlane => (cam.transform.position.z + (zDistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));
    float parallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;
    void Start()
    {
        startingPosition = transform.position;
        startingZ = transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPositon = startingPosition + camMoveSinceStart * parallaxFactor;
        transform.position = new Vector3(newPositon.x, newPositon.y, startingZ);

    }
}

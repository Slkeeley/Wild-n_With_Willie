using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

/// <summary>
/// Listens for touch events and performs an AR raycast from the screen touch point.
/// AR raycasts will only hit detected trackables like feature points and planes.
///
/// If a raycast hits a trackable, the <see cref="placedPrefab"/> is instantiated
/// and moved to the hit position.
/// </summary>
[RequireComponent(typeof(ARRaycastManager))]
public class PlaceOnPlane : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Instantiates this prefab on a plane at the touch location.")]
    GameObject m_PlacedPrefab;

    UnityEvent placementUpdate;

    [SerializeField]
    GameObject visualObject;

    /// <summary>
    /// The prefab to instantiate on touch.
    /// </summary>
    public GameObject placedPrefab
    {
        get { return m_PlacedPrefab; }
        set { m_PlacedPrefab = value; }
    }

    /// <summary>
    /// The object instantiated as a result of a successful raycast intersection with a plane.
    /// </summary>
    public GameObject spawnedObject { get; private set; }
    private float zRotationVal; 
    void Awake()
    {
        zRotationVal = 0; 
        m_RaycastManager = GetComponent<ARRaycastManager>();

        if (placementUpdate == null)
            placementUpdate = new UnityEvent();

        placementUpdate.AddListener(DiableVisual);
        spawnedObject = Instantiate(m_PlacedPrefab, transform.position, Quaternion.identity);
        spawnedObject.transform.rotation = Quaternion.Euler(-90, 0, 0);
        spawnedObject.SetActive(true); 

    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;
        Touch touch = Input.GetTouch(0);


        if (touch.phase == TouchPhase.Began)
        {
            var tp= touch.position;
            bool isOverUI = tp.IsPointOverUIObject(); 
            if(isOverUI)
            {
                return; 
            }

            if (m_RaycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
            {
                // Raycast hits are sorted by distance, so the first one
                // will be the closest hit.
                var hitPose = s_Hits[0].pose;

                if (spawnedObject == null)
                {
                    spawnedObject = Instantiate(m_PlacedPrefab, hitPose.position, hitPose.rotation);
                    spawnedObject.transform.rotation = Quaternion.Euler(0, 0, 0); 
                }
                else
                {
                    spawnedObject.SetActive(true); 
                    spawnedObject.transform.position = hitPose.position;
                }
                placementUpdate.Invoke();
            }
        }
    }
    
    public void rotateObjRight()
    {
        Debug.Log("Right");
        zRotationVal = zRotationVal + 15; 
        spawnedObject.transform.rotation = Quaternion.Euler(-90, 0, zRotationVal);
    }

    public void rotateObjLeft()
    {
        Debug.Log("Left");
        zRotationVal = zRotationVal - 15; 
        spawnedObject.transform.rotation = Quaternion.Euler(-90, 0, zRotationVal);
    }

    public void DiableVisual()
    {
        visualObject.SetActive(false);
    }

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    ARRaycastManager m_RaycastManager;
}
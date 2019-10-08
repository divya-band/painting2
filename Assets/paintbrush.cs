using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paintbrush : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject currentStroke; // Holds the current stroke being drawn
    public GameObject strokePrefab; // Reference to the stroke prefab we created before
    private bool isDrawing = false;
    public float minDistance = 0.01f; // Distance required to move the pen before a point will be added
    private bool newLine = true;
    public GameObject script;
    
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if button is down
        if (Input.GetButton("Fire1"))
        {
            if (call.isLine)
            {



                isDrawing = true;

                if (newLine)
                {
                    // Create new stroke
                    currentStroke = Instantiate(strokePrefab);
                    currentStroke.GetComponent<Renderer>().material.color = call.color;
                    newLine = false;
                }
            }
            else
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = script.transform.position;
                cube.transform.localScale = new Vector3(.1f, .1f, .1f);
                cube.GetComponent<Renderer>().material.color = call.color;
            }
        }
        else
        {
            isDrawing = false;
            newLine = true;
        }
        // While the pen is drawing
        if (isDrawing)
        {
            // Get a reference to the line renderer
            LineRenderer line = currentStroke.GetComponent<LineRenderer>();

            // Automatically add a point if there are no positions
            if (line.positionCount == 0)
            {
                line.positionCount += 1;
                line.SetPosition(line.positionCount - 1, transform.position);
            }
            else
            {
                // Get a reference to the last point added
                Vector3 lastPosition = line.GetPosition(line.positionCount - 1);
                // compute a vector that points from the last position to the current position
                Vector3 distanceVec = transform.position - lastPosition;

                // Add a point if the current position is far enough away
                if (distanceVec.sqrMagnitude > minDistance * minDistance)
                {
                    line.positionCount += 1;
                    line.SetPosition(line.positionCount - 1, transform.position);
                }
            }
        }
    }
    /*private void FireRay()
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;
       
        
            Vector3 direction = requiredComponents.RaycastPosition.position - transform.position;

            RaycastHit raycastHit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out raycastHit, Mathf.Infinity, layerMask))
            {
                if (raycastHit.collider.tag != "Billboard")
                {
                    return;
                }

                Renderer renderer = raycastHit.collider.GetComponent<MeshRenderer>();
                Texture2D texture2D = renderer.material.mainTexture as Texture2D;
                Vector2 pCoord = raycastHit.textureCoord;
                pCoord.x *= texture2D.width;
                pCoord.y *= texture2D.height;

                Vector2 tiling = renderer.material.mainTextureScale;
                Color color = texture2D.GetPixel(Mathf.FloorToInt(pCoord.x * tiling.x), Mathf.FloorToInt(pCoord.y * tiling.y));

                Debug.Log("Picked color : " + color);
                requiredComponents.CollisionEvents.PixelColor = color;

                if (requiredComponents.CollisionEvents.OnRayHitBillboard != null)
                {
                    requiredComponents.CollisionEvents.OnRayHitBillboard.Invoke();
                }
            }
        
    }*/
}

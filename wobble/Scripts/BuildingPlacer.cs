using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Wobble))]
public class BuildingPlacer : MonoBehaviour
{
    [Tooltip("Prefab for your wobbly object. This prefab should be using a material based on the WobbleShader. Only this material will be affected.")]
    public GameObject prefab;

    private Wobble wobble;

    
    void PlaceBuilding(Vector3 position)
	{
        if (!prefab) return;
        GameObject newObject = GameObject.Instantiate(prefab, position, Quaternion.identity);

        wobble.newObject = newObject;

        wobble?.triggerWobble();
    }


	private void OnValidate()
	{
        wobble = GetComponent<Wobble>();
	}

	// Update is called once per frame
	void Update()
    {
        CheckForInput();        
    }

	private void CheckForInput()
	{
        //using the new unity UI input system.
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Assert((Camera.main != null), "Main camera must be tagged");

            Vector3 pos = Mouse.current.position.ReadValue();

            // find the object clicked on
            Ray ray = Camera.main.ScreenPointToRay(pos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.white, 2f);
                PlaceBuilding(hit.point);
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wobble : MonoBehaviour
{
	Material material;

    [Header("Wobble Settings")]
    public float strength = 2.5f;
    public float radius = 10f;
    public float time = 0.75f;
	public float falloff = 12f;
	public AnimationCurve wobbleCurve = new AnimationCurve(new Keyframe(0,0), 
		new Keyframe(0.07f, 0.9f), 
		new Keyframe(0.3f, -0.4f), 
		new Keyframe(0.6f,0.39f), 
		new Keyframe(0.7f, -.02f),
		new Keyframe(0.85f, 0.06f), 
		new Keyframe(0.91f, -.007f), 
		new Keyframe(1f, 0) );

	[Header("For Testing")]
	public bool endlessWobble;

	//Wobble Data
	[HideInInspector]
	public GameObject newObject;
	float startTime;
	float endTime;
	float phase;
	float modifiedStrength;

	[ContextMenu("Re-initialize Most Recent Wobble")]
	public void triggerWobble()
	{
		StartCoroutine(updateWobble());
	}

	private IEnumerator updateWobble()
	{
		startTime = Time.realtimeSinceStartup;
		endTime = startTime + time;
		MeshRenderer[] renderers = newObject.GetComponentsInChildren<MeshRenderer>();
		List<Material> materials = new List<Material>();
		foreach(MeshRenderer renderer in renderers)
		{
			materials.Add(renderer.sharedMaterial); //shared materials will prevent materials from instancing. We want nearby like items to wobble too.
		}

		while (Time.realtimeSinceStartup < endTime)
		{
			for (int i=0; i< materials.Count; i++)
			{
				calculateWobbleStrength();
				
				Vector3 center = newObject.GetComponentInChildren<Collider>().bounds.center; //grab the first collider we find in our prefab, and use its center for the wobble.
				materials[i].SetVector("_wobblePosition", center);
				materials[i].SetFloat("_radius", radius);
				materials[i].SetFloat("_strength", modifiedStrength);
				materials[i].SetFloat("_falloff", falloff);
			}			

			yield return null;
		}

		//zero out when we're done
		for (int i = 0; i < materials.Count; i++)
		{
			materials[i].SetFloat("_strength", 0);
		}

		if (endlessWobble)
		{
			StartCoroutine(updateWobble());
		}
	}

	private void calculateWobbleStrength()
	{
		phase = (Time.realtimeSinceStartup - startTime) / (endTime - startTime);
		modifiedStrength = wobbleCurve.Evaluate(phase) * strength;
	}

}

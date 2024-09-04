using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class LaunchPads : MonoBehaviour
{
	[Header("UI Elements")]
    [SerializeField] private GameObject textUI;

	[Header("Impulse Direction")]
	[Range(-1, 1)] [SerializeField] private int xAxis;
	[Range(-1, 1)] [SerializeField] private int yAxis;
	[Range(-1, 1)] [SerializeField] private int zAxis;


	[Header("Impulse Force")]
	[SerializeField] private float force;
    private bool onTrigger;
	[SerializeField] private ParticleSystem dustPrefab;

	
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(xAxis, yAxis, zAxis) * force, ForceMode.Impulse);
			dustPrefab.Play();

		}
		
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			//textUI.gameObject.SetActive(false);
			
			
		}
	}
	

}

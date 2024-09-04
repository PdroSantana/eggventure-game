using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleActivation : MonoBehaviour
{
	[SerializeField] private ParticleSystem particle;

	public void playParticle()
	{
		particle.Play();
	}
}

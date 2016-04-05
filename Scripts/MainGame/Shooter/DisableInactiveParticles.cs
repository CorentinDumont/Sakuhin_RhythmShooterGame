// Utilitary script to fix a bug of Unity v5.3.1f1 about the behaviour of particles systems in the edit mode

using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class DisableInactiveParticles : MonoBehaviour
{
	ParticleSystem.Particle[] unused = new ParticleSystem.Particle[1];

	void Start() {
		Destroy (this.transform.parent.gameObject, this.GetComponent<ParticleSystem> ().duration);
	}

	void Awake() {
		GetComponent<ParticleSystemRenderer>().enabled = false;
	}

	void LateUpdate() {
		GetComponent<ParticleSystemRenderer>().enabled = GetComponent<ParticleSystem>().GetParticles(unused) > 0;
	}
}

// Copyright 2025 Muhammad Alhasan. All rights reserved.

using UnityEngine;

public class Rotate : MonoBehaviour
{
	AudioManager audioManager;

	public float speed = 10f;

	Rigidbody2D rb;
	[SerializeField]
	public ParticleSystem ShreddingParticle;
	 ParticleSystem ShreddingParticleInstance;

	private void Awake()
	{
		audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	 {
		audioManager.PlaySFX(audioManager.RotateSfx);

		ShreddingParticleInstance = Instantiate(ShreddingParticle, transform.position, Quaternion.identity);
	}
	void Start()
	{
			rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		rb.rotation += speed * Time.fixedDeltaTime;
	}
}

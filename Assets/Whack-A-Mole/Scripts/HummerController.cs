using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HummerController : MonoBehaviour {

	public GameObject particle;
	public AudioClip hitSE;
    public AudioClip hitError;
    public AudioClip hitDouble;

	AudioSource audio;

	void Start () {
		this.audio = GetComponent<AudioSource> ();	
	}

	IEnumerator Hit(Vector3 target, bool isNegative, bool isDouble)
	{
		// Hummer Down		
		transform.position = new Vector3(target.x, 0, target.z);

		// Impact
		Instantiate (this.particle, transform.position, Quaternion.identity);

		Camera.main.GetComponent<CameraController>().Shake();

        AudioClip clip;
        if (isNegative)
        {
           clip = this.hitError;
        }
        else if (isDouble)
        {
            clip = this.hitDouble;
        }
        else {
            clip = this.hitSE;
        }

		this.audio.PlayOneShot (clip);

		yield return new WaitForSeconds (0.1f);

		// Hummer Up
		for (int i = 0; i < 6; i++) 
		{
			transform.Translate (0, 0, 1.0f);
			yield return null;
		}
	}

	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100))
            {
                GameObject mole = hit.collider.gameObject;

                bool isHit = mole.GetComponent<MoleController>().Hit();

                // if hit the mole, show hummer and effect
                if (isHit)
                {
                    bool isNegativePoints = mole.GetComponent<MoleController>().isNegativePoint;
                    bool isDoublePoints = mole.GetComponent<MoleController>().isDoublePoint;
                    StartCoroutine(Hit(mole.transform.position, isNegativePoints, isDoublePoints));
                    if (isNegativePoints)
                    {
                        ScoreManager.Score -= 10;
                    }
                    else if (isDoublePoints)
                    {
                        ScoreManager.Score += 20;
                    }
                    else
                    {
                        ScoreManager.Score += 10;
                    }
                }
            }
        }
	}
}

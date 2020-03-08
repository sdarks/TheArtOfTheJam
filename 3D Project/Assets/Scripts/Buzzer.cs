using System;
using UnityEngine;

public class Buzzer : MonoBehaviour
{
    public float buzzDuration = 1.5f;
    public float buzzInterval = 0.3f;

    private float buzzCounter;
    private float totalBuzzCounter;

    private bool buzzOn = false;

    private bool buzzing = false;
    
    private DateTime timeOfBuzz;

    public SpriteRenderer renderer;
	public SpriteRenderer GuyRenderer;

    private Sprite normalSprite;
    public Sprite buzzSprite;
	private Sprite normalGuySprite;
	public Sprite happyGuySprite;

	public AudioClip BuzzerSound;



	void Awake()
    {
		if(!renderer)
			renderer = GetComponent<SpriteRenderer>();
        normalSprite = renderer.sprite;
		normalGuySprite = GuyRenderer.sprite;
    }

    void FixedUpdate()
    {
        if (buzzOn)
        {
            buzzCounter += Time.deltaTime;
            totalBuzzCounter += Time.deltaTime;
            
            if (buzzCounter > buzzInterval)
            {
                buzzCounter -= buzzInterval;
                if (!buzzing)
                {
                    renderer.sprite = buzzSprite;
					GuyRenderer.sprite = happyGuySprite;
                    buzzing = true;
                }
                else
                {
                    renderer.sprite = normalSprite;
					GuyRenderer.sprite = normalGuySprite;
                    buzzing = false;
                }
            }

            if (totalBuzzCounter > buzzDuration)
            {
                buzzOn = false;
                if (buzzing)
                {
                    buzzing = false;
                    renderer.sprite = normalSprite;
					GuyRenderer.sprite = normalGuySprite;
                }
            }
        }
    }

    public void startBuzz()
    {
        buzzCounter = 0;
        totalBuzzCounter = 0;
        buzzing = false;
        buzzOn = true;

		RoomStateManager.inst.CameraAudio.PlayOneShot(BuzzerSound);
	
    }

}

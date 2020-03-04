using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomStateManager : MonoBehaviour
{
	public SpriteRenderer GreenButton;
	public SpriteRenderer RedButton;
	public Sprite GreenButtonOn;
	public Sprite GreenButtonOff;
	public Sprite RedButtonOn;
	public Sprite RedButtonOff;
	public float SecondsToFlashGreenButton;
	public float SecondsToFlashRedButton;

	public List<SpriteRenderer> ProgressBlobs;
	public List<Sprite> ProgressBlobOnSprites;
	public List<Sprite> ProgressBlobOffSprites;


	public bool IncrementProgressOnSuccess = true;
	public bool DecrementProgressOnFail = true;
	public bool ResetProgressOnFail = true;
	public bool FlashLightOnSuccess = true;
	public bool FlashLightOnFail = true;


	bool FlashingGreenButton = false;
	bool FlashingRedButton = false;
	float TimeStartGreenButtonFlash = 0;
	float TimeStartRedButtonFlash = 0;
	int Progress = 0;

	int GetMaxProgress()
	{
		return ProgressBlobs.Count;
	}

	public void IncrementProgress()
	{
		if(IncrementProgressOnSuccess && Progress < GetMaxProgress())
			Progress++;

		if(FlashLightOnSuccess)
		{
			if(GreenButton)
			{
				FlashingGreenButton = true;
				TimeStartGreenButtonFlash = Time.time;

				GreenButton.sprite = GreenButtonOn;
			}
			else
			{
				Debug.LogError("You forgot to assign a GREEN button in RoomStateManager and are trying to flash it");
			}
		}

		UpdateProgressBlobs();
	}
	public void DecrementProgress()
	{
		if(DecrementProgressOnFail && Progress > 0)
			Progress--;

		if (ResetProgressOnFail)
			Progress = 0;

		if (FlashLightOnFail)
		{
			if (RedButton)
			{
				FlashingRedButton = true;
				TimeStartRedButtonFlash = Time.time;

				RedButton.sprite = RedButtonOn;
			}
			else
			{
				Debug.LogError("You forgot to assign a RED button in RoomStateManager and are trying to flash it");
			}
		}

		UpdateProgressBlobs();
	}

	void UpdateProgressBlobs()
	{
		for(int i=0; i<ProgressBlobs.Count; i++)
		{
			if(i < Progress)
			{
				ProgressBlobs[i].sprite = ProgressBlobOnSprites[i];
			}
			else
			{
				ProgressBlobs[i].sprite = ProgressBlobOffSprites[i];
			}
		}
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(FlashingGreenButton && (Time.time > TimeStartGreenButtonFlash + SecondsToFlashGreenButton))
		{
			FlashingGreenButton = false;
			TimeStartGreenButtonFlash = 0;
			GreenButton.sprite = GreenButtonOff;
		}

		if (FlashingRedButton && (Time.time > TimeStartRedButtonFlash + SecondsToFlashRedButton))
		{
			FlashingRedButton = false;
			TimeStartRedButtonFlash = 0;
			RedButton.sprite = RedButtonOff;
		}
	}
}

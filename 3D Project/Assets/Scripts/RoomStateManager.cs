﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomStateManager : MonoBehaviour
{

	public static RoomStateManager inst;

	public Buzzer failBuzzer;
	public Buzzer goodBuzzer;

	public AudioSource CameraAudio;

	public AudioClip CardInsertSound;
	public AudioClip MouseUpSound;
	public AudioClip MouseDownSound;


	public float BuzzDelay = 0.5f;
	IEnumerator BuzzAfterTime(float time, Buzzer buzz)
	{
		yield return new WaitForSeconds(time);

		buzz.startBuzz();

	}
	private void Awake()
	{
		if(inst == null)
		{
			inst = this;
		}
		else
		{
			Destroy(this);
			Debug.LogError("Multiple RoomStateManager detected, deleting the newest");
		}
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

	public void PlayMouseDownSound()
	{
		CameraAudio.PlayOneShot(MouseDownSound);
	}

	public void PlayMouseUpSound()
	{
		CameraAudio.PlayOneShot(MouseUpSound);
	}

	public void InsertCardSound()
	{
		CameraAudio.PlayOneShot(CardInsertSound);
	}

	public void GoodAction()
	{
		StartCoroutine(BuzzAfterTime(BuzzDelay, goodBuzzer));
	}

	public void invalidAction()
	{
		StartCoroutine(BuzzAfterTime(BuzzDelay, failBuzzer));
	}
	// Update is called once per frame
    void Update()
    {
  //       if(FlashingGreenButton && (Time.time > TimeStartGreenButtonFlash + SecondsToFlashGreenButton))
		// {
		// 	FlashingGreenButton = false;
		// 	TimeStartGreenButtonFlash = 0;
		// 	GreenButton.sprite = GreenButtonOff;
		// }
  //
		// if (FlashingRedButton && (Time.time > TimeStartRedButtonFlash + SecondsToFlashRedButton))
		// {
		// 	FlashingRedButton = false;
		// 	TimeStartRedButtonFlash = 0;
		// 	RedButton.sprite = RedButtonOff;
		// }
	}
}

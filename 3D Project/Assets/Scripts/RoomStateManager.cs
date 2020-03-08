using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomStateManager : MonoBehaviour
{

	public static RoomStateManager inst;

	public Buzzer failBuzzer;
	public Buzzer goodBuzzer;
	
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

	public void invalidAction()
	{
		failBuzzer.startBuzz();
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

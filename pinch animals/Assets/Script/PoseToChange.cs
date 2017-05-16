using UnityEngine;
using System.Collections;

public class PoseToChange : MonoBehaviour 
{
	void PoseDeactive()
	{
		Time.timeScale = 0;
		Pose.i = false;
	}
}

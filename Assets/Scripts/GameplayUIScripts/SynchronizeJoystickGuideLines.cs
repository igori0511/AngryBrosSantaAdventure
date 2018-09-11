using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SynchronizeJoystickGuideLines : MonoBehaviour {
	
	public enum AxisOption
	{
		// Options for which axes to use
		Both, // Use both
		OnlyHorizontal, // Only horizontal
		OnlyVertical // Only vertical
	}
	 
	public AxisOption axesToUse = AxisOption.Both; // The options for the axes that the still will use
	public string horizontalAxisName = "Horizontal"; // The name given to the horizontal axis for the cross platform input
	public string verticalAxisName = "Vertical"; // The name given to the vertical axis for the cross platform input

	bool m_UseX; // Toggle for using the x axis
	bool m_UseY; // Toggle for using the Y axis
	CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis; // Reference to the joystick in the cross platform input
	CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis; // Reference to the joystick in the cross platform input

	void OnEnable()
	{
		CrossPlatformInputManager.UnRegisterVirtualAxis (verticalAxisName);
		CrossPlatformInputManager.UnRegisterVirtualAxis (horizontalAxisName);
		CreateVirtualAxes();
	}

	void CreateVirtualAxes()
	{
		// set axes to use
		m_UseX = (axesToUse == AxisOption.Both || axesToUse == AxisOption.OnlyHorizontal);
		m_UseY = (axesToUse == AxisOption.Both || axesToUse == AxisOption.OnlyVertical);

		// create new axes based on axes to use
		if (m_UseX)
		{
			m_HorizontalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(horizontalAxisName);
			CrossPlatformInputManager.RegisterVirtualAxis(m_HorizontalVirtualAxis);
		}
		if (m_UseY)
		{
			m_VerticalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(verticalAxisName);
			CrossPlatformInputManager.RegisterVirtualAxis(m_VerticalVirtualAxis);
		}
	}
}

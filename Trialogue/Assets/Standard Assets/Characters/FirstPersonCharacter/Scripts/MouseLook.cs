using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;
namespace UnityStandardAssets.Characters.FirstPerson
{
    [Serializable]
    public class MouseLook
    {
        public float XSensitivity = 2f;
        public float YSensitivity = 2f;
        public bool clampVerticalRotation = true;
        public float MinimumX = -90F;
        public float MaximumX = 90F;
        public bool smooth;
		public bool controllerAttached=false;
        public float smoothTime = 5f;


        private Quaternion m_CharacterTargetRot;
        private Quaternion m_CameraTargetRot;


        public void Init(Transform character, Transform camera)
        {
            m_CharacterTargetRot = character.localRotation;
            m_CameraTargetRot = camera.localRotation;

			string[] contList = Input.GetJoystickNames ();
			//Debug.Log (contList.Length);
			for (int i = 0; i < contList.Length; i++) {
				Debug.Log (contList [i]);
				if (contList [i].Contains ("360")) {
					Debug.Log ("INSIDE");
					controllerAttached = true;
				}
			}
        }


        public void LookRotation(Transform character, Transform camera)
        {
			float yRot = 0f;
			float xRot=0f;
			if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer) {
				yRot = CrossPlatformInputManager.GetAxis ("Mouse X") * XSensitivity;
				xRot = CrossPlatformInputManager.GetAxis ("Mouse Y") * YSensitivity;
			} 
//			else {
//				yRot = CrossPlatformInputManager.GetAxis ("Mouse X") * XSensitivity;
//				xRot = CrossPlatformInputManager.GetAxis ("Mouse Y") * YSensitivity;
//			}
				else if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer && controllerAttached) {
				//Debug.Log ("nOPE");
				yRot = CrossPlatformInputManager.GetAxis ("MouseXMac") * XSensitivity;
				xRot = CrossPlatformInputManager.GetAxis ("MouseYMac") * YSensitivity;
			} 

/*
            float xJoy= CrossPlatformInputManager.GetAxis("Joystick X") * XSensitivity;
            float yJoy= CrossPlatformInputManager.GetAxis("Joystick Y") * XSensitivity;

            if (yJoy > 0.05)
            {
                m_CharacterTargetRot *= Quaternion.Euler(0f, yJoy, 0f);
            }
            if (xJoy>0.05)
            {
                m_CameraTargetRot *= Quaternion.Euler(-xJoy, 0f, 0f);
            }
            */
            m_CharacterTargetRot *= Quaternion.Euler (0f, yRot, 0f);
            m_CameraTargetRot *= Quaternion.Euler (-xRot, 0f, 0f);

            if(clampVerticalRotation)
                m_CameraTargetRot = ClampRotationAroundXAxis (m_CameraTargetRot);

            if(smooth)
            {
                character.localRotation = Quaternion.Slerp (character.localRotation, m_CharacterTargetRot,
                    smoothTime * Time.deltaTime);
                camera.localRotation = Quaternion.Slerp (camera.localRotation, m_CameraTargetRot,
                    smoothTime * Time.deltaTime);
            }
            else
            {
                character.localRotation = m_CharacterTargetRot;
                camera.localRotation = m_CameraTargetRot;
            }
        }


        Quaternion ClampRotationAroundXAxis(Quaternion q)
        {
            q.x /= q.w;
            q.y /= q.w;
            q.z /= q.w;
            q.w = 1.0f;

            float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan (q.x);

            angleX = Mathf.Clamp (angleX, MinimumX, MaximumX);

            q.x = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleX);

            return q;
        }

    }
}

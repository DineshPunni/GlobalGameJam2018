/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class DefaultTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        #region PRIVATE_MEMBER_VARIABLES
 
        private TrackableBehaviour mTrackableBehaviour;
		private GameObject child;
		private Vector3 startPos;
		private Animator animator;

		#endregion // PRIVATE_MEMBER_VARIABLES

		GameObject QRCode;
        GameObject QRCodeContent;

        #region UNTIY_MONOBEHAVIOUR_METHODS
    
        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }

			child = transform.GetChild(0).gameObject;
			startPos = child.transform.localPosition;
			animator = child.GetComponent<Animator>();
        
		}

		#endregion // UNTIY_MONOBEHAVIOUR_METHODS



		#region PUBLIC_METHODS

		/// <summary>
		/// Implementation of the ITrackableEventHandler function called when the
		/// tracking state changes.
		/// </summary>
		public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
				RemoveChild();
            }
            else
            {
                OnTrackingLost();
            }
        }

        #endregion // PUBLIC_METHODS


        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
            }

            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
			if (transform.childCount > 0)
			{
				GetComponent<AudioSource>().pitch = 1.0f;
				GetComponent<AudioSource>().Play();
			}
        }


        private void OnTrackingLost()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Disable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
            }

            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = false;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
			//GetComponent<AudioSource>().pitch = 0.5f;
			//GetComponent<AudioSource>().Play();
		}

		#endregion // PRIVATE_METHODS

		void RemoveChild()
		{
            QRCode = GameObject.Find("QR-Code");
            QRCodeContent = QRCode.transform.GetChild(1).gameObject;

            if (transform.childCount > 0)
			{ 
				child.transform.parent = QRCodeContent.transform;
				child.transform.rotation = Quaternion.Euler(0, 0, 0);

				if(child.name == "KorschLogo")
					child.transform.rotation = Quaternion.Euler(180, 180, 0);

				child.transform.position = startPos;
				child.SetActive(true);
				Debug.Log(startPos);
			}
		}

		public void ResetHologram()
		{
			child.transform.parent = transform;
			child.transform.localPosition= startPos;
			child.SetActive(false);
		}
	}
}

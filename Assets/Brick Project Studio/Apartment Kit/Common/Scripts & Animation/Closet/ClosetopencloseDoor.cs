using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

namespace SojaExiles

{
	public class ClosetopencloseDoor : MonoBehaviour
	{
		public XRSimpleInteractable simpleInteractable; // 참조할 XR
		public Animator Closetopenandclose;
		public bool open;

		void Start()
		{
			open = false;
		}
		void OnEnable()
		{
			simpleInteractable.selectEntered.AddListener(HandleSelectEntered);
		}

		void OnDisable()
		{
			simpleInteractable.selectEntered.RemoveListener(HandleSelectEntered);
		}
        private void HandleSelectEntered(SelectEnterEventArgs arg)
        {
            if (open == false)
            {
                StartCoroutine(opening());
            }
            else
            {
                if (open == true)
                {
                    StartCoroutine(closing());
                }

            }
        }

        IEnumerator opening()
        {

            Closetopenandclose.Play("ClosetOpening");
            open = true;
            yield return new WaitForSeconds(.5f);
        }

        IEnumerator closing()
        {

            Closetopenandclose.Play("ClosetClosing");
            open = false;
            yield return new WaitForSeconds(.5f);
        }


    }
}
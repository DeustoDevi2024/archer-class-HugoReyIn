using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Archer
{


    public class Bow : MonoBehaviour
    {

        // Referencia a la acci�n de Input para disparar
        [SerializeField]
        private InputActionReference fireInputReference;

        // Una referencia al prefab de la flecha
        [SerializeField]
        private GameObject arrowPrefab;

        // Cantidad de fuerza que aplicaremos al disparar la flecha
        [SerializeField]
        private float force;
        
        // Una referencia a un transform que servir� de punto de referencia para disparar la flecha
        [SerializeField]
        private Transform handPosition;

      

        private Animator animator;

        private void Awake()
        {
           
            // Nos subscribimos al evento de input de disparo (el espacio o el bot�n A).
            fireInputReference.action.performed += Action_performed;

            animator = GetComponent<Animator>();
        }

        private void Action_performed(InputAction.CallbackContext obj)
        {
            // Cuando se pulsa espacio, producimos un disparo
            StartCoroutine(Shoot());
        }

        private IEnumerator Shoot()
        {

            animator.SetTrigger("Shoot");
            yield return new WaitForSeconds(0.3f);


            // Instanciar una flecha
            GameObject newArrow = Instantiate(arrowPrefab);

            // Colocar la flecha en el punto de referencia de la mano de la arquera
            newArrow.transform.position = handPosition.position;

            // Orientar la flecha hacia delante con respecto a la arquera
            newArrow.transform.rotation = handPosition.rotation;

            // Aplicar una fuerza a la flecha para que salga disparada
            Rigidbody arrowRigidbody = newArrow.GetComponent<Rigidbody>();
            arrowRigidbody.AddForce(handPosition.forward * force, ForceMode.Impulse);

        }
    }

}
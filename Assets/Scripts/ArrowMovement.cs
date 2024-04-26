using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archer
{
    public class ArrowMovement : MonoBehaviour
    {
        public Arrow flechaPrefab;
        public Transform puntoDeLanzamiento;
        public float fuerzaLanzamiento = 10f;

        public void LanzarFlecha()
        {
            Arrow flecha = Instantiate(flechaPrefab, puntoDeLanzamiento.position, puntoDeLanzamiento.rotation);
            flecha.Launch(puntoDeLanzamiento.forward, fuerzaLanzamiento);
        }
    }
}

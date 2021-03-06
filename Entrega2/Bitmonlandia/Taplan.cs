﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitmonlandia
{
    class Taplan: Bitmon
    {
        public Taplan(int tiempoDeVida, int puntosDeVida, int puntosDeAtaque, int cantidadDeHijos, int posicionX, int posicionY)
        {
            this.tiempoDeVida = tiempoDeVida;
            this.puntosDeVida = puntosDeVida;
            this.puntosDeAtaque = puntosDeAtaque;
            this.especie = "Taplan";
            this.cantidadDeHijos = cantidadDeHijos;
            this.posicionX = posicionX;
            this.posicionY = posicionY;
        }
        public Taplan(Bitmon bitmon)
        {
            if (bitmon.Especie() == "Taplan")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
        }

        public override string CambioTerreno()
        {
                return "V";
        }
        public override int Daño(Bitmon bitmon)
        {
            if (bitmon.Especie() == "Wetar" || bitmon.Especie() == "Doti")
            {
                return puntosDeAtaque * 2;
            }
            else
            {
                return Convert.ToInt32(puntosDeAtaque * 0.5);
            }
        }
        public override void Desplazamiento(Mapa mapa)
        {
            Random random = new Random();
            while (true)
            {
                int rnd = random.Next(3);
                if (rnd == 0 && posicionX != mapa.Ancho()) // con 0 se mueve hacia la derecha
                {
                    posicionX += 1;
                    break;
                }
                else if (rnd == 1 && posicionX != 0) // con 1 se mueve hacia la izquierda
                {
                    posicionX -= 1;
                    break;
                }
                else if (rnd == 2 && posicionY != 0) //con 2 se mueve hacia arriba
                {
                    posicionY -= 1;
                    break;
                }
                else if (rnd == 3 && posicionY != mapa.Largo())// con 3 se mueve hacia abajo            
                {
                    posicionY += 1;
                    break;
                }
                else
                {
                    continue;
                }

            }
        }
        public override int AfinidadTerreno(string terreno)
        {
            if (terreno == "V")
            {
                return 1; // con 0 cambia el terreno, con 1 si es afin y con 2 no
            }
            else if (terreno == "A")
            {
                return 2;
            }
            else if (terreno == "D")
            {
                return 0;
            }
            else if (terreno == "N")
            {
                return 2;
            }
            else
            {
                return 2;
            }
        }


    }

}


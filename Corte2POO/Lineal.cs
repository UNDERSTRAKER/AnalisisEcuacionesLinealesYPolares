namespace Corte2POO
{
    /* 
     * Nombre 1:  LUIS FELIPE PADILLA ARENAS
     * Nombre 2:  DANIEL FELIPE CELIS
     * */

    internal class Lineal: ClaseMadre {
        private double valA, valB, valC, valD, valE, valF, valG;

        //Ingresa los coeficientes para el polinomio de grado 6
        public void Coeficientes(double valA, double valB, double valC, double valD, double valE, double valF, double valG) {
            this.valA = valA;
            this.valB = valB;
            this.valC = valC;
            this.valD = valD;
            this.valE = valE;
            this.valF = valF;
            this.valG = valG;
        }

        //Retorna el valor de Y dado el valor de X
        private double ValorY(double ValorX) {
            //Su código va aquí
            return 0;
        }

        /*
         * La integral de una función Y = F(X) sobre un intervalo (a, b) calcula el área neta entre la curva y el eje X.
         * Esto significa que las áreas por encima del eje X son positivas y las áreas por debajo del eje X son negativas.
         * Para calcular el área total en un rango [a,b] debería:
         * a. Saber si hay uno o más puntos de corte
         * b. La curva en ese rango está por encima del eje X
         * c. La curva en ese rango está por debajo del eje X
         * Son tres posibilidades, luego el método PosibleCalcularArea debe retornar:
         * 1 La curva en ese rango está por encima del eje X
         * -1 La curva en ese rango está por debajo del eje X
         * 0  La curva en ese rango tiene uno o más cortes
         * */
        public int CasosCalcularArea(double Xini, double Xfin) {
            //Su código va aquí
            return 0;
        }
    }
}

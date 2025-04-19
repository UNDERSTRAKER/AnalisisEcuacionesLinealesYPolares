namespace Corte2POO
{
    /* 
     * Nombre 1:  AQUI VA A IR EL NOMBRE COMPLETO DEL PRIMER MIEMBRO DEL GRUPO
     * Nombre 2:  AQUI VA A IR EL NOMBRE COMPLETO DEL SEGUNDO MIEMBRO DEL GRUPO
     * */
    class Polar : ClaseMadre
    {
        private double valA, valB;

        //Ingresa los coeficientes para ecuación polar
        // r= a*seno(b*θ*π/180)
        public void Coeficientes(double valA, double valB) {
            this.valA = valA;
            this.valB = valB;
        }

        private double valorR(double Theta) {
            //Su código va aquí
            return 0;
        }

        private double ValorX(double R) {
            //Su código va aquí
            return 0;
        }

        private double ValorY(double R) {
            //Su código va aquí
            return 0;
        }

        //Retorna el máximo valor de X en el rango dado
        public double MaximoValorX() {
            //Su código va aquí
            return 0;
        }

        //Retorna el mínimo valor de X en el rango dado
        public double MinimoValorX() {
            //Su código va aquí
            return 0;
        }
    }
}

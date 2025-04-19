namespace Corte2POO
{
    /* 
     * Nombre 1:  LUIS FELIPE PADILLA ARENAS
     * Nombre 2:  DANIEL FELIPE CELIS
     * */

    abstract class ClaseMadre {
        //Ingresa el rango de exploración
        abstract public void Rango(double Minimo, double Maximo);

        //Ingresa el valor de avance por el rango
        abstract public void setPaso(double Paso);

        //Retorna el número de puntos de corte
        abstract public int TotalPuntosCorte();

        /* Retorna si existe ese punto de corte. 
         * Por ejemplo: si la ecuación tiene cuatro puntos de corte en el eje X en el rango dado,
         * entonces los Puntos de corte van de 1 a 4, luego esto debería responder este método:
         * ExistePuntoCorte(1); responde true
         * ExistePuntoCorte(2); responde true
         * ExistePuntoCorte(3); responde true
         * ExistePuntoCorte(4); responde true
         * ExistePuntoCorte(5); responde false
         * ExistePuntoCorte(6); responde false
         */
        abstract public bool ExistePuntoCorte(int Punto);


        //Retorna el valor de ese punto de corte. Hay que validar que ese punto de corte exista (use el método anterior)
        abstract public double ValorPuntoCorte(int Punto);

        //Retorna el máximo valor de Y en el rango dado
        abstract public double MaximoValorY();

        //Retorna el mínimo valor de Y en el rango dado
        abstract public double MinimoValorY();

    }
}

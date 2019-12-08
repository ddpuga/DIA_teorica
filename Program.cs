using System;
using System.Collections.Generic;

namespace Sobrecarga
{
    class Program
    {
        
        class Persona
        {

            public override int GetHashCode()
            {
                return Dni.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                var otraPersona = obj as Persona;

                return this.Equals(otraPersona);
            }

            public bool Equals(Persona otra)
            {
                return ReferenceEquals (this, otra) || (otra != null && this.Dni == otra.Dni );
            }

            public string Dni
            {
                get;set;
            }

            public int Edad
            {
                get;set;
            }

            public string Email
            {
                get;set;
            }
        }

        class Punto : IEquatable<Punto>
        {

            public override bool Equals(object obj)
            {
                Punto punto = obj as Punto;

                return this.Equals(punto);
            }

            public bool Equals(Punto p)
            {
                return ReferenceEquals(this, p) || (p !=null && this.X == p.X && this.Y == p.Y);
            }

            public override int GetHashCode()
            {
                return 11 * this.X.GetHashCode() + 17 * this.Y.GetHashCode();
            }

            public int DistanciaOrigen()
            {
                return (int) Math.Sqrt(this.X * this.X + this.Y * this.Y);
            }
            public static Boolean operator==(Punto uno, Punto otro)
            {
                return !ReferenceEquals(uno,null) && uno.Equals(otro);

            }

            public static Boolean operator !=(Punto uno, Punto otro)
            {
                return !ReferenceEquals(uno, null) && !uno.Equals(otro);
            }

            public static Boolean operator >(Punto uno, Punto otro)
            {

                return !ReferenceEquals(uno,null) && !ReferenceEquals(otro,null) &&  uno.DistanciaOrigen() > otro.DistanciaOrigen();
            }

            public static Boolean operator <(Punto uno, Punto otro)
            {

                return !ReferenceEquals(uno, null) && !ReferenceEquals(otro, null) && uno.DistanciaOrigen() < otro.DistanciaOrigen();
            }


            public static Boolean operator >=(Punto uno, Punto otro)
            {

                return !ReferenceEquals(uno, null) && !ReferenceEquals(otro, null) && uno.DistanciaOrigen() >= otro.DistanciaOrigen();
            }

            public static Boolean operator <=(Punto uno, Punto otro)
            {

                return !ReferenceEquals(uno, null) && !ReferenceEquals(otro, null) && uno.DistanciaOrigen() <= otro.DistanciaOrigen();
            }



            public int X { get; set; }
            public int Y { get; set; }
        }

        class Poligono
        {
            public Poligono()
            {
                this.puntos = new List<Punto>();
            }

            public void Add (Punto p)
            {
                this.puntos.Add(p);
            }

            public Punto Get(int i)
            {
                return this.puntos[i];
            }

            public Punto this[int i]
            {
                get
                {
                    return this.Get(i);
                }
                set
                {
                    this.puntos[i] = value;
                }

            }

            List<Punto> puntos;

        }


        class MainClass
        {
            static void Main(string[] args)
            {
                var p1 = new Punto { X = 5, Y = 6 };
                var p2 = new Punto { X = 1, Y = 2 };
                var p3 = new Punto { X = 5, Y = 6 };

                Console.WriteLine("p1.getHashCode() = {0}", p1.GetHashCode());
                Console.WriteLine("p2.getHashCode() = {0}", p2.GetHashCode());
                Console.WriteLine("p3.getHashCode() = {0}", p3.GetHashCode());

                Console.WriteLine("p1.Equals(p2) = {0}", p1.Equals(p2));
                Console.WriteLine("p2.Equals(p3) = {0}", p2.Equals(p3));
                Console.WriteLine("p3.Equals(p1) = {0}", p3.Equals(p1));

                Console.WriteLine("p1 == p2 = {0}", p1 == p2);
                Console.WriteLine("p2 == p3 = {0}", p2 == p3);
                Console.WriteLine("p3 == p1 = {0}", p3 == p1);
            }
        }
    }
}

using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUGenerarPasswordAleatoria : ICUGenerarPasswordAleatoria
    {
        public string Generar()
        {
            const string letrasMinus = "abcdefghijklmnopqrstuvwxyz";
            const string letrasMayus = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numeros = "0123456789";

            Random random = new Random();

            char mayuscula = letrasMayus[random.Next(letrasMayus.Length)];
            string minusculas = new string(Enumerable.Range(0, 2)
                .Select(_ => letrasMinus[random.Next(letrasMinus.Length)]).ToArray());
            string nums = new string(Enumerable.Range(0, 4)
                .Select(_ => numeros[random.Next(numeros.Length)]).ToArray());

            return $"{mayuscula}{minusculas}{nums}";
        }


    }
    
}

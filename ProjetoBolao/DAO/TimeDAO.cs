using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoBolao.Models;

namespace ProjetoBolao.DAO
{
    public class TimeDAO
    {
        public static IList<Time> ListarTimes()
        {
            IList<Time> lista;

            using (var contexto = new SiteContext())
            {
                lista = contexto.Times.ToList<Time>();
            }

            return lista;
        }

        public static Time Time(string nome)
        {
            Time time;

            using (var contexto = new SiteContext())
            {
                return time = contexto.Times.FirstOrDefault(u => u.NomeTime == nome);
            }
        }

        public static Time Time(int codigo)
        {
            Time time;

            using (var contexto = new SiteContext())
            {
                return time = contexto.Times.FirstOrDefault(u => u.Id == codigo);
            }
        }

    }
}
using Microsoft.EntityFrameworkCore;
using MiguelGondresPA2.DAL;
using MiguelGondresPA2.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MiguelGondresPA2.BLL
{
    public class LlamadasBLL
    {
        public static bool Guardar(Llamadas llamadas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Llamadas.Add(llamadas);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Llamadas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Llamadas llamadas = new Llamadas();
            try
            {
                llamadas = contexto.Llamadas.Where(p => p.LlamadaId == id)
                    .Include(m => m.LlamadaDetalle)
                    .SingleOrDefault();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return llamadas;
        }

        public static bool Modificar(Llamadas llamadas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Database.ExecuteSqlRaw($"DELETE FROM LlamadaDetalle Where LlamadaId={llamadas.LlamadaId}");
                foreach (var anterior in llamadas.LlamadaDetalle)
                {
                    contexto.Entry(anterior).State = EntityState.Added;
                }
                contexto.Entry(llamadas).State = EntityState.Modified;
                paso = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var eliminar = contexto.Llamadas.Find(id);
                contexto.Entry(eliminar).State = EntityState.Deleted;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static List<Llamadas> GetList(Expression<Func<Llamadas, bool>> llamadas)
        {
            List<Llamadas> lista = new List<Llamadas>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Llamadas.Where(llamadas).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}

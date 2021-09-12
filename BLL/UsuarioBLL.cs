using Microsoft.EntityFrameworkCore;
using RegistroUsuario.DAL;
using RegistroUsuario.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RegistroUsuario.BLL
{
    public class UsuarioBLL
    {
        public static bool Guardar(Roles usuario)
        {
            if (!Existe(usuario.ID))
                return Insertar(usuario);
            else
                return Modificar(usuario);

            // MessageBox.Show("modifico", "Fallo", MessageBoxButton.OK, MessageBoxImage.Information);



        }

        private static bool Insertar(Roles usuario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Roles.Add(usuario) != null)
                {
                    paso = (contexto.SaveChanges() > 0);
                    MessageBox.Show("Agregoo", "Fallo", MessageBoxButton.OK, MessageBoxImage.Information);

                }


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

        private static bool Modificar(Roles usuario)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(usuario).State = EntityState.Modified;
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

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var usuario = contexto.Roles.Find(id);
                if (usuario != null)
                {
                    contexto.Roles.Remove(usuario);
                    paso = contexto.SaveChanges() > 0;
                }

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

        public static Roles Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Roles usuario;

            try
            {
                usuario = contexto.Roles.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return usuario;

        }

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Roles.Any(e => e.ID == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

        public static List<Roles> GetList(Expression<Func<Roles, bool>> criterio)
        {
            List<Roles> lista = new List<Roles>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Roles.Where(criterio).ToList();
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

using System;
using System.Collections.Generic;
using System.Text;
using RegistroCompleto.Entidades;
using RegistroCompleto.DAL;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;


namespace RegistroCompleto.BLL
{
    public class RegistroBLL
    {

        
    public static bool Guardar(Persona persona)
    {
        bool paso = false;

        Contexto db = new Contexto();

        try
        {
            if (db.Registro.Add(persona) != null)
                paso = (db.SaveChanges() > 0);

                
        }
            
        catch (Exception)
        {
            throw;
        }
        finally
        {
            db.Dispose();
        }
           

            return paso;
    }

    public static bool Modificar(Persona persona)
    {
        bool paso = false;
        Contexto db = new Contexto();

        try
        {
            db.Entry(persona).State = EntityState.Modified;
            paso = (db.SaveChanges() > 0);

        }
        catch
        {
            throw;
        }
        finally
        {
            db.Dispose();
        }

        return paso;
    }

    public static bool Eliminar(int id)
    {
        bool paso = false;
        Contexto db = new Contexto();

        try
        {
                var eliminar=db.Registro.Find(id);              //find busca
                db.Entry(eliminar).State = EntityState.Deleted;

                paso = (db.SaveChanges() > 0);
        }
        catch
        {
            throw;
        }      
        finally
        {
            db.Dispose();
        }

        return paso;
      
    }

    public static Persona Buscar (int id)
            {
        Contexto db = new Contexto();
        Persona persona = new Persona();

        try
        {
            persona = db.Registro.Find(id);
        }
        catch(Exception)
        {
            throw;
        }
        finally
        {
            db.Dispose();
        }

        return persona;
    }

    public static List<Persona> GetList(Expression<Func<Persona, bool>> persona)         // PERMITE EXTRAER PERSONAS DE LA BASE DE DATOS
    {
        List<Persona> Lista = new List<Persona>();
        Contexto db = new Contexto();

        try
        {
            Lista = db.Registro.Where(persona).ToList();

        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            db.Dispose();
        }

        return Lista;
    }

    }

}

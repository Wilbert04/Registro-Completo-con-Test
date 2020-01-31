using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RegistroCompleto.Entidades;



namespace RegistroCompleto.DAL
{
    public class Contexto : DbContext               // SE HEREDA DE DB CONTEXT 
    {
     
        public DbSet<Persona> Registro{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)   // PROPIEDAD QUE GUARDARA EN LA BASE DB
        {
            
            optionsBuilder.UseSqlServer(@"Server = .\SqlExpress; Database = RegistroPersonaDB; Trusted_Connection = True; ");
        }                   // AQUI SE AGREGA UN STRING, SE PASA EL NOMBRE DEL SERVIDOR, NOMBRE DE LA DB Y POR ULTIMO EL TIPO DE CONEXION
                    
    }
}

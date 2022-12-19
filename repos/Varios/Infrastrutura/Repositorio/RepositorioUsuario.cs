using Dominio.Interfaces;
using Entidades.Entidades;
using Infraestrutura.Configuracoes;
using Infrastrutura.Repositorio.Generiocos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrutura.Repositorio
{
    public class RepositorioUsuario : RepsoitorioGenerico<ApplicationUser>, IUsuario
    {
        private readonly DbContextOptions<Contexto> _optionsbuilder;
        public RepositorioUsuario()
        {
            _optionsbuilder = new DbContextOptions<Contexto>();
        }

        public async Task<bool> AdicionarUsuario(string email, string senha, int idade, string celular)
        {
            try
            {
                using (var data = new Contexto(_optionsbuilder))
                {
                    await data.ApplicationUser.AddAsync(new ApplicationUser
                    {
                        Email = email,
                        PasswordHash = senha,
                        Idade = idade,
                        Celular = celular
                    });
                    await data.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                return false;
            }
            return true; 
        }

        public async Task<bool> ExisteUsuario(string email, string senha)
        {
            try
            {
                using (var data = new Contexto(_optionsbuilder))
                {
                    return await data.ApplicationUser.Where(u=>u.Email.Equals(email) && u.PasswordHash.Equals(senha)).AsNoTracking().AnyAsync();
                  
                 
                }

            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}

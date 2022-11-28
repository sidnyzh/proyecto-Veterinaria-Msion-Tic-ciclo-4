using Application.Response;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IVetApplication
    {

        Task<Response<bool>> CreateVet(Vet vet);

        Task<Response<bool>> UpdateVet(Vet vet);
        Task<Response<bool>> DeleteVet(string nit);

        //Task<Response<string>> AuthenticateVet(string username, string password);

    }
}

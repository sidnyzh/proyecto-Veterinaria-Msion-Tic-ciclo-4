using Application.Interfaces;
using Domain.Entity;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Response;
using MongoDB.Driver;
using Nest;
using Microsoft.Extensions.Configuration;
using Application.Main.Helper;
using System.Security.Claims;

namespace Application.Main
{
    public class VetApplication : IVetApplication
    {
        private readonly Domain.Repository.IRepository<Vet> _vet;
        private const string vets = "vets";
        private readonly IConfiguration _configuration;


        public VetApplication(Domain.Repository.IRepository<Vet> vet, IConfiguration configuration)
        {
            _vet = vet;
            _configuration = configuration;
        }

        public async Task<Response<bool>> CreateVet(Vet vet)
        {
            var response = new Response<bool>();

            try
            {
                var filter = Builders<Vet>.Filter.Eq("NIT", vet.NIT);
                var existsVet = await _vet.ExistsAsync(filter, vets);
                if (existsVet)
                {
                    response.Message = $"Ya existe una veterinaria registrada con el NIT: {vet.NIT}";
                   response.IsSuccess = false;

                   
                }

                vet.Password = SHA512(vet.Password);
                 await _vet.CreateAsync(vet, vets);

                response.IsSuccess = true;
                response.Message = "Veterinaria creada exitosamente"; 
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error: " + ex.Message;
            }
            return response;
        }



        public async Task<Response<string>> AuthenticateVet(string username, string password)
        {
            var response = new Response<string>();

            try
            {
                var filter = Builders<Vet>.Filter.Exists(username.ToLower()) & Builders<Vet>.Filter.Exists(SHA512(password));
                var existsVet = await _vet.ExistsAsync(filter, vets);
                if (existsVet)
                {
                    response.Message = $"Usuario y/o contraseña incorrectos";
                    response.IsSuccess = false;
                }

                response.IsSuccess = true;
                response.Message = "Autenticación exitosa";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error: " + ex.Message;
            }
            return response;
        }

        public async Task<Response<bool>> UpdateVet(Vet vet)
        {
            var response = new Response<bool>();

            try
            {

                vet.Password = SHA512(vet.Password);
                var filter = Builders<Vet>.Filter.Eq("NIT", vet.id);
                var update = Builders<Vet>.Update
                    .Set(x => x.Name, vet.Name).Set(x => x.Email, vet.Email)
                    .Set(x => x.Address, vet.Address).Set(x => x.user, vet.user)
                    .Set(x => x.Password, vet.Password).Set(x => x.PhoneNumber, vet.PhoneNumber);

                await _vet.UpdateAsync(filter, update, "vets");


                response.Message = $"Información actualizada exitosamente";
                response.IsSuccess = false;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error: " + ex.Message;
            }
            return response;
        }

        public async Task<Response<bool>> DeleteVet(string nit)
        {
            var response = new Response<bool>();
            try
            {
                var filter = Builders<Vet>.Filter.Eq("NIT",nit);
                var existsVet = await _vet.ExistsAsync(filter, vets);
                if (existsVet)
                {
                    await _vet.DeleteAsync(filter, vets);
                    response.IsSuccess = true;
                    response.Message = "Veterinaria eliminada exitosamente";
                }  
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error: " + ex.Message;
            }
            return response;
        }

        private string SHA512(string password)
        {
            var bytes = Encoding.UTF8.GetBytes(password);

            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);
                var hashedInputStringBuilder = new StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.AppendFormat("{0:x2}", b);
                return hashedInputStringBuilder.ToString();
            }
        }

       

    }
}

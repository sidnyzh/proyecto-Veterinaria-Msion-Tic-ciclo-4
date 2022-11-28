﻿using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
   
    
        public interface IPetApplication
        {
            Task<IEnumerable<Pet>> GetPets();
            Task CreatePet(Pet pet);
        }
    
}

﻿using API_Models;
using API_Models.Models.VModels;

namespace API_Project.Services.Interfaces
{
    public interface ICSVService
    {
         public Task seedBooks(string seed);
         public Task seedAuthors(string seed);

    }
}

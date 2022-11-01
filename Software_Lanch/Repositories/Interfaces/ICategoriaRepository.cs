﻿using Software_Lanch.Models;

namespace Software_Lanch.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> Categorias { get; }
    }
}

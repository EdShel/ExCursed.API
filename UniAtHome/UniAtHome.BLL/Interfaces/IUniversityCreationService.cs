﻿using System.Collections.Generic;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.UniversityCreation;

namespace UniAtHome.BLL.Interfaces
{
    public interface IUniversityCreationService
    {
        Task AddRequestAsync(UniversityCreateDTO creationInfo);

        Task<IEnumerable<UniversityRequestDTO>> GetAllRequestsAsync();

        Task ApproveRequestAsync(int id);

        Task DeclineRequestAsync(int id);
    }
}

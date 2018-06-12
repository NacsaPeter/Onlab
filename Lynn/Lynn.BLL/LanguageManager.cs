﻿using AutoMapper;
using Lynn.BLL.Services;
using Lynn.DAL;
using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lynn.BLL
{
    public class LanguageManager
    {
        private readonly ILanguageRepository _repo;
        private readonly IMapper _mapper;

        public LanguageManager(ILanguageRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public ICollection<DTO.Language> GetLanguages()
        {
            return _mapper.Map<ICollection<DTO.Language>>(_repo.GetLanguages());
        }
    }
}

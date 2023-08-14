using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using sunguIntegration.DTO;
using sunguIntegration.DTO.RequestDTO;
using sunguIntegration.Service;

namespace sunguIntegration.Controllers
{
    [Route("api/[controller]")]
    public class GeneralController: Controller
	{
        private GeneralRestService _generalRestService;
        private readonly IMapper _mapper;

        public GeneralController(GeneralRestService generalRestService, IMapper mapper)
        {
            _generalRestService = generalRestService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("createProduct")]
        public async Task<string> CreateProduct(GeneralProductRequestDTO productRequest)
        {
            // trendyol api'sine git
            // todo convert GeneralProductRequestDTO to TrendyolRequestDTO
            var trendyolRequestDto = _mapper.Map<TrendyolProductRequestDTO>(productRequest);
            _generalRestService.Post("api/TrendyolGeneral/createProduct", trendyolRequestDto);
            return "a";
           


        }
    }
}


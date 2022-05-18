using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CountryHotel.IRepository;
using CountryHotel.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CountryHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CountryController> _logger;
        private readonly IMapper _mapper;

        public CountryController(IUnitOfWork unitOfWork, ILogger<CountryController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCountries()
        {
            _logger.LogInformation($"Starting the {nameof(GetCountries)} endpoint");
            
            try
            {
                var countries = await _unitOfWork.Countries.GetAll(null, null, new List<string>{"Hotels"});
                var result = _mapper.Map<IList<CountryDTO>>(countries);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetCountries)} endpoint in {nameof(CountryController)} controller");
                
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCountry(int id)
        {
            _logger.LogInformation($"Starting the {nameof(GetCountry)} endpoint");

            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"The Client's input is not valid in {nameof(GetCountry)} endpoint");
                return BadRequest(ModelState);
            }

            try
            {
                var country = await _unitOfWork.Countries.Get(c => c.Id == id, new List<string> {"Hotels"});
                if (country == null)
                {
                    _logger.LogError($"The Country with id = {id} is null");
                    return NotFound();
                }
                
                var result = _mapper.Map<CountryDTO>(country);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(GetCountry)} endpoint in the{nameof(CountryController)} controller");
                
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
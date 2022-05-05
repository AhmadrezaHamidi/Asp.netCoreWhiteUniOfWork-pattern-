using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TamsaApi.Domain.BaseDomain;
using TamsaApi.Domain.Entity;
using TamsaApi.ViewModels;
using tTamsaApi.Domain.BaseDomain;

namespace TamsaApi.TamsaApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    ///[Authorize] ///all the serveses need token 
    [AllowAnonymous]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private TamsaApisaContext _TamsaApisaContext;
        private readonly PassarGadModel _passargad;
        private readonly KaveNegarModel _kaveNegar;   
        public WeatherForecastController(ILogger<WeatherForecastController> logger,
        IOptions<PassarGadModel> passarGad,
        IOptions<KaveNegarModel> KaveNegar,TamsaApisaContext TamsaApisaContext)
        {
            _logger = logger;
            _passargad = passarGad.Value;
            _kaveNegar = KaveNegar.Value;
            _TamsaApisaContext = TamsaApisaContext;
        }

        [HttpGet]
        public IEnumerable<TransActionEntity> GetTranActions()
        {
            var trsn = _TamsaApisaContext.TransActionTb.ToList();
            return trsn;
        }

        [HttpGet]
        public IActionResult GetTranActionById(string Id)
        {
            var trsn = _TamsaApisaContext.TransActionTb.
            FirstOrDefault(x => x.Id.Equals(Id));
            
            
            
            if(trsn is null)
              return BadRequest();
            
            
            
            return Ok(trsn);
        }
        
    }
}

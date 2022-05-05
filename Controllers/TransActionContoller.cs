using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TamsaApi.Domain.BaseDomain;
using TamsaApi.ViewModels;
using tTamsaApi.Domain.BaseDomain;

namespace TamsaApi.TamsaApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TransActionContoller : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private TamsaApisaContext _TamsaApisaContext;
        private readonly PassarGadModel _passargad;
        private readonly KaveNegarModel _kaveNegar;

        public TransActionContoller(ILogger<WeatherForecastController> logger, TamsaApisaContext TamsaApisaContext, PassarGadModel passargad, KaveNegarModel kaveNegar)
        {
            _logger = logger;
            _TamsaApisaContext = TamsaApisaContext;
            _passargad = passargad;
            _kaveNegar = kaveNegar;
        }
       
    }
        

}
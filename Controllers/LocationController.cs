using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Repositories;
using WebApi.Models;

namespace WebApi.Controllers
{
        public class LocationController : ApiController
        {
            private IRepository<State> _stateRepository;

            public LocationController()
                : this(new StateRepository())
            { }

            public LocationController(IRepository<State> stateRepository)
            {
                _stateRepository = stateRepository;
            }

            //
            // GET: /api/Location/
            public IEnumerable<string> GetStates()
            {
                return _stateRepository.GetAll().Select(c => c.Name);
            }
        }
}

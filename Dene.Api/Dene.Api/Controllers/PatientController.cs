using Dene.Business.Abstract;
using Dene.Entity.Concrete.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dene.Api.Controllers
{
    [Route("api/Patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }


        //[HttpGet]
        //[Route("GetMan")]
        //public GetManPatientResponse GetManList()
        //{
        //    GetManPatientRequest request = new GetManPatientRequest();
        //    return _patientService.GetManList(request);
        //}

        //[HttpGet]
        //[Route("GetWomen")]
        //public GetWomenPatientResponse GetWomenList()
        //{
        //    GetWomenPatientRequest request = new GetWomenPatientRequest();
        //    return _patientService.GetWomenList(request);
        //}

        [HttpDelete]
        [Route("DeletePatient")]
        public DeletePatientResponse DeletePatient(DeletePatientRequest request)
        {
            return _patientService.DeletePatient(request);
        }
        [HttpPut]
        [Route("UpdatePatient")]
        public UpdatePatientResponse UpdatePatient(UpdatePatientRequest request)
        {
            // GetPatientRequest request = new GetPatientRequest();
            return _patientService.UpdatePatient(request);
        }
        [HttpPost]
        [Route("AddPatient")]
        public AddPatientResponse AddPatient(AddPatientRequest request)
        {
            // GetPatientRequest request = new GetPatientRequest();
            return _patientService.AddPatient(request);
        }

        [HttpGet]
        [Route("GetPatient")]
        public GetPatientResponse GetPatient()
        {
            GetPatientRequest request = new GetPatientRequest();
            return _patientService.GetList(request);
        }
    }

}

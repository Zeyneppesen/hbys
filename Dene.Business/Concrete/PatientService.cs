using Dene.Business.Abstract;
using Dene.Data.Abstract;
using Dene.Entity.Concrete.DTO;
using Dene.Entity.Concrete.Models;
using Dene.Entity.Concrete.Validators;
using DocumentFormat.OpenXml.EMMA;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Dene.Business.Concrete
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
      
        public DeletePatientResponse DeletePatient(DeletePatientRequest request)
        {

            var response = new DeletePatientResponse();
            try
            {
                var patient = _patientRepository.Get(p => p.Id == request.Id);


                _patientRepository.Delete(patient);
                response.Code = "200";
                response.Message = "Silindi.";


                return response;
            }
            catch (Exception e)
            {
                response.Errors.Add("Bir hata ile karşılaşıldı");
                response.Code = "400";
                response.Message = e + " Hatası";
                return response;
            }
        }

        public UpdatePatientResponse UpdatePatient(UpdatePatientRequest request)
        {
            var response = new UpdatePatientResponse();
            try
            {
                //  var patient = _patientRepository.Get(p=>p.Id==request.Id);


                var validator = new UpdatePatientValidator();
                var validatorResult = validator.Validate(request);

                var patient = new Patient();
                patient.Id = request.Id;
                patient.Name = request.Name;
                patient.LastName = request.LastName;
                patient.TcNo = request.TcNo;
                patient.Gender = request.Gender;
                patient.BirthDate = request.BirthDate;
                patient.Place = request.Place;
                patient.BloodType = request.BloodType;
                patient.Phone = request.Phone;
                patient.Eposta = request.Eposta;
                patient.Adress = request.Adress;
                patient.PoliClinic = request.PoliClinic;
                //patient.InDate = request.InDate;
                //patient.OutDate = request.OutDate;


                _patientRepository.Update(patient);
                response.Code = "200";
                response.Message = "Güncellendi";
                return response;
            }
            catch (Exception e)
            {

                response.Errors.Add("Bir hata ile karşılaşıldı");
                response.Code = "400";
                response.Message = e + " Hatası";
                return response;
            }
        }



        public AddPatientResponse AddPatient(AddPatientRequest request)
        {
            var response = new AddPatientResponse();
            try
            {
                var validator = new AddPatientValidator();
                var validatorResult = validator.Validate(request);

                var patient = new Patient();
                patient.Id = request.Id;
                patient.Name = request.Name;
                patient.LastName = request.LastName;
                patient.TcNo = request.TcNo;
                patient.Gender = request.Gender;
                patient.BirthDate = request.BirthDate;
                patient.Place = request.Place;
                patient.BloodType = request.BloodType;
                patient.Phone = request.Phone;
                patient.Eposta = request.Eposta;
                patient.Adress = request.Adress;
                patient.PoliClinic = request.PoliClinic;
                //patient.InDate = request.InDate;
                //patient.OutDate = request.OutDate;
                _patientRepository.Add(patient);
                response.Code = "200";
                response.Message = "Veri Eklendi.";
                return response;
            }
            catch (Exception e)
            {
                response.Message = e + " Hatası";
                response.Code = "400";
                return response;
            }
        }

        public GetManPatientResponse GetManList(GetManPatientRequest request)
        {

            var response = new GetManPatientResponse();
            try
            {
                var patients = _patientRepository.GetList();
                List<PatientModel> patientsModels = new List<PatientModel>();


                foreach (var patient in patients)
                {
                    if (patient.Gender == "Erkek")
                    {
                        var model = new PatientModel();
                        model.Id = patient.Id;
                        model.Name = patient.Name;
                        model.LastName = patient.LastName;
                        model.TcNo = patient.TcNo;
                        model.Gender = patient.Gender;
                        model.BirthDate = patient.BirthDate;
                        model.Place = patient.Place;
                        model.BloodType = patient.BloodType;
                        model.Phone = patient.Phone;
                        model.Eposta = patient.Eposta;
                        model.Adress = patient.Adress;
                        model.PoliClinic = patient.PoliClinic;
                        //model.InDate = patient.InDate;
                        //model.OutDate = patient.OutDate;
                        patientsModels.Add(model);
                    }
                }
                response.PatientModels = patientsModels;
                response.Code = "200";
                response.Message = "Cinsiyeti erkek olanların Verileri getirildi.";
                return response;
            }
            catch (Exception e)
            {
                response.Errors.Add("Bir hata ile karşılaşıldı. " + e.Message);
                response.Code = "400";
                return response;
            }
        }

        public GetPatientResponse GetList(GetPatientRequest request)
        {

            var response = new GetPatientResponse();

            try
            {

                var patients = _patientRepository.GetList();
                List<PatientModel> patientsModels = new List<PatientModel>();

                foreach (var patient in patients)
                {
                        var model = new PatientModel();
                        model.Id = patient.Id;
                        model.Name = patient.Name;
                        model.LastName = patient.LastName;
                        model.TcNo = patient.TcNo;
                        model.Gender = patient.Gender;
                        model.BirthDate = patient.BirthDate;
                        model.Place = patient.Place;
                        model.BloodType = patient.BloodType;
                        model.Phone = patient.Phone;
                        model.Eposta = patient.Eposta;
                        model.Adress = patient.Adress;
                        model.PoliClinic = patient.PoliClinic;
                        //model.InDate = patient.InDate;
                        //model.OutDate = patient.OutDate;
                        patientsModels.Add(model);
                }

                response.PatientModels = patientsModels;
                response.Code = "200";
                response.Message = " Tüm Veriler getirildi.";
                return response;
            }
            catch (Exception e)
            {
                response.Errors.Add("Bir hata ile karşılaşıldı. " + e.Message);
                response.Code = "400";
                return response;
            }
        }
        public GetWomenPatientResponse GetWomenList(GetWomenPatientRequest request)
        {
            var response = new GetWomenPatientResponse();
            try
            {
                var patients = _patientRepository.GetList();
                List<PatientModel> patientsModels = new List<PatientModel>();
                foreach (var patient in patients)
                {
                    if (patient.Gender=="Kadın")
                    {
                        var model = new PatientModel();
                        model.Id = patient.Id;
                        model.Name = patient.Name;
                        model.LastName = patient.LastName;
                        model.TcNo = patient.TcNo;
                        model.Gender = patient.Gender;
                        model.BirthDate = patient.BirthDate;
                        model.Place = patient.Place;
                        model.BloodType = patient.BloodType;
                        model.Phone = patient.Phone;
                        model.Eposta = patient.Eposta;
                        model.Adress = patient.Adress;
                        model.PoliClinic = patient.PoliClinic;
                        //model.InDate = patient.InDate;
                        //model.OutDate = patient.OutDate;
                        patientsModels.Add(model);
                    }
                }
                response.PatientModels = patientsModels;
                response.Code = "200";
                response.Message = "Cinsiyeti kadın olanların Verileri getirildi.";
                return response;
            }
            catch (Exception e)
            {
                response.Errors.Add("Bir hata ile karşılaşıldı. " + e.Message);
                response.Code = "400";
                return response;
            }
        }

            public GetManOverTewFourResponse GetManOverTewFour(GetManOverTewFourRequest request)
            {
            var response = new GetManOverTewFourResponse();
            try
            {
                var patients = _patientRepository.GetList();
                List<PatientModel> patientsModels = new List<PatientModel>();
                DateTime targetDate = new DateTime(1999, 9, 22);
                foreach (var patient in patients)
                {
                    if (patient.BirthDate < targetDate&&patient.Gender=="Erkek")
                    {
                        var model = new PatientModel();
                        model.Id = patient.Id;
                        model.Name = patient.Name;
                        model.LastName = patient.LastName;
                        model.TcNo = patient.TcNo;
                        model.Gender = patient.Gender;
                        model.BirthDate = patient.BirthDate;
                        model.Place = patient.Place;
                        model.BloodType = patient.BloodType;
                        model.Phone = patient.Phone;
                        model.Eposta = patient.Eposta;
                        model.Adress = patient.Adress;
                        model.PoliClinic = patient.PoliClinic;
                        //model.InDate = patient.InDate;
                        //model.OutDate = patient.OutDate;
                        patientsModels.Add(model);
                    }
                }
                response.PatientModels = patientsModels;
                response.Code = "200";
                response.Message = "Yaşı 24 büyük erkek hasta verileri getirildi.";
                return response;
            }
            catch (Exception e)
            {
                response.Errors.Add("Bir hata ile karşılaşıldı. " + e.Message);
                response.Code = "400";
                return response;
            }
        }
        public GetNameWithZResponse GetNameWithZ(GetNameWithZRequest request)
        {
            var response = new GetNameWithZResponse();
            try
            {
                var patients = _patientRepository.GetList();
                List<PatientModel> patientsModels = new List<PatientModel>();
                foreach (var patient in patients)
                {
                    if (patient.Name.StartsWith("Z", StringComparison.OrdinalIgnoreCase))
                    {
                        var model = new PatientModel();
                        model.Id = patient.Id;
                        model.Name = patient.Name;
                        model.LastName = patient.LastName;
                        model.TcNo = patient.TcNo;
                        model.Gender = patient.Gender;
                        model.BirthDate = patient.BirthDate;
                        model.Place = patient.Place;
                        model.BloodType = patient.BloodType;
                        model.Phone = patient.Phone;
                        model.Eposta = patient.Eposta;
                        model.Adress = patient.Adress;
                        model.PoliClinic = patient.PoliClinic;
                        //model.InDate = patient.InDate;
                        //model.OutDate = patient.OutDate;
                        patientsModels.Add(model);
                    }
                }
                response.PatientModels = patientsModels;
                response.Code = "200";
                response.Message = "İsminin Baş harfinde z bulunan veriler getirildi.";
                return response;
            }
            catch (Exception e)
            {

                response.Errors.Add("Bir hata ile karşılaşıldı. " + e.Message);
                response.Code = "400";
                return response;
            }
        }

        //public GetTotalAgeResponse GetTotalAge(GetTotalAgeRequest request)
        //{
        //    var response = new GetTotalAgeResponse();
        //    try
        //    {

        //        var patients = _patientRepository.GetList();
        //        List<PatientModel> patientsModels = new List<PatientModel>();
        //        int totalAgeIn5Years = 0;
        //        foreach (var patient in patients)
        //        { 

        //                var model = new PatientModel();
        //                //model.Id = patient.Id;
        //                //model.Name = patient.Name;
        //                //model.LastName = patient.LastName;
        //                //model.TcNo = patient.TcNo;
        //                //model.Gender = patient.Gender;
        //                model.BirthDate = patient.BirthDate;
        //                //model.Place = patient.Place;
        //                //model.BloodType = patient.BloodType;
        //                //model.Phone = patient.Phone;
        //                //model.Eposta = patient.Eposta;
        //                //model.Adress = patient.Adress;
        //                //model.PoliClinic = patient.PoliClinic;
        //                //model.InDate = patient.InDate;
        //                //model.OutDate = patient.OutDate;

        //           // DateTime dgunu = new DateTime(1990, 12, 15);
        //            DateTime birthDateIn5Years = patient.BirthDate.AddYears(-5);
        //            int ageIn5Years=0;
        //           // int ageIn5Years = DateTime.Now.Year  - birthDateIn5Years.Year;
        //            totalAgeIn5Years += ageIn5Years;
        //            patientsModels.Add(model);
                    
        //        }
        //        response.TotalAgeIn5Years = totalAgeIn5Years;

        //        response.PatientModels = patientsModels;
        //        response.Code = "200";
        //        response.Message = "5 yıl sonraki yaşları toplamı";
        //        return response;
        //    }
        //    catch (Exception e)
        //    {

        //        response.Errors.Add("Bir hata ile karşılaşıldı. " + e.Message);
        //        response.Code = "400";
        //        return response;
        //    }
        //}
    }
    }




        
    


        

      
    

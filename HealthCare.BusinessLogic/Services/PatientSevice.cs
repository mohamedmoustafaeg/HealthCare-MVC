﻿using AutoMapper;
using HealthCare.BusinessLogic.Interfaces;
using HealthCare.BusinessLogic.ViewModels;
using HealthCare.DataAccess.Interfaces;
using HealthCare.DataAccess.Models;
using HealthCare.Presentaion.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.BusinessLogic.Services
{
    public class PatientSevice : IPatientService
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        public PatientSevice(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Add(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.Compelete();
        }

        public List<PatientToDisplayVM> GetAll()
        {
            var patients = _context.Patients.GetAll();
            var patientsVM = _mapper.Map<List<PatientToDisplayVM>>(patients);
            return patientsVM;
        }

        public PatientToDisplayVM GetPatientById(int id)
        {
            var patient = _context.Patients.GetAll().FirstOrDefault(e => e.Id == id);
            if (patient != null)
            {
                return _mapper.Map<PatientToDisplayVM>(patient);
            }
            return null;
        }

        public void Update(Patient patient)
        {
            var existingPatient = _context.Patients.GetAll().FirstOrDefault(e => e.Id == patient.Id);
            if (existingPatient != null)
            {
                existingPatient.FirstName = patient.FirstName;
                existingPatient.LastName = patient.LastName;
                existingPatient.DateOfBirth = patient.DateOfBirth;
                existingPatient.Gender = patient.Gender;
                existingPatient.ContactNumber = patient.ContactNumber;
                existingPatient.Address = patient.Address;

                _context.Patients.Update(existingPatient);  // Now this method exists
                _context.Compelete();
            }
            else
            {
                throw new ArgumentException($"Patient with ID {patient.Id} does not exist.");
            }
        }

        public void Delete(int id)
        {
            var patient = _context.Patients.GetAll().FirstOrDefault(e => e.Id == id);
            if (patient != null)
            {
                _context.Patients.Delete(patient);  // Now this method exists
                _context.Compelete();
            }
            else
            {
                throw new ArgumentException($"Patient with ID {id} does not exist.");
            }
        }

    }
}
﻿using JobSearch.API.Database;
using JobSearch.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private int numberOfRegistryByPage = 5;
        private JobSearchContext _data;
        public JobsController(JobSearchContext data)
        {
            _data = data;
        }
        [HttpGet]
        public IEnumerable<Job> GetJobs(string word, string cityState, int numberOfPage = 1)
        {
            //TODO - Tratar parametros nulos
            if (word == null)
                word = "";
            
            if (cityState == null)
                cityState = "";

            //TODO - Add paginação (infinity scroll)


            return _data.Jobs
                .Where(a =>
                    //Limita pesquisa por período
                    a.PublicationDate > DateTime.Now.AddDays(-15) &&
                    a.CityState.ToLower().Contains(cityState.ToLower()) && 
                    (
                        a.JobTitle.ToLower().Contains(word.ToLower()) ||
                        a.TecnologyTools.ToLower().Contains(word.ToLower()) ||
                        a.Company.ToLower().Contains(word.ToLower())
                    )
            )
            .Skip(numberOfRegistryByPage * (numberOfPage - 1))
            .Take(numberOfRegistryByPage)
            .ToList<Job>();
        }
        //api/jobs/1
        [HttpGet("{id}")]
        public IActionResult GetJob(int id)
        {
            Job jobDb = _data.Jobs.Find(id);

            if(jobDb == null)
            {
                return NotFound();
            }
            return new JsonResult(jobDb);
        }
        public IActionResult AddJob(Job job)
        {
            //TODO - validação
            job.PublicationDate = DateTime.Now;
            _data.Jobs.Add(job);
            _data.SaveChanges();

            return CreatedAtAction(nameof(GetJob), new { id = job.Id }, job);
        }
    }
}

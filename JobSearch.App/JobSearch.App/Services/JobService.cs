﻿using JobSearch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.App.Services
{
    public class JobService : Service
    {
        public async Task<IEnumerable<Job>> GetJobs(string word, string cityState, int numberOfPage = 1)
        {
            HttpResponseMessage response = await _client.GetAsync($"{BaseApiUrl}/api/Jobs?word={word}&cityState={cityState}&numberOfPage={numberOfPage}");

            List<Job> list = null;
            if (response.IsSuccessStatusCode)
            {
                list = await response.Content.ReadAsAsync<List<Job>>();
            }
            return list;
        }
        public async Task<Job> GetJob(int id)
        {
            HttpResponseMessage response = await _client.GetAsync($"{BaseApiUrl}/api/Jobs/1");

            Job job = null;
            if (response.IsSuccessStatusCode)
            {
                job = await response.Content.ReadAsAsync<Job>();
            }
            return job;
        }
        public async Task<Job> AddJob(Job job)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync($"{BaseApiUrl}/api/Jobs", job);

            if (response.IsSuccessStatusCode)
            {
                job = await response.Content.ReadAsAsync<Job>();
            }
            return job;
        }
    }
}
